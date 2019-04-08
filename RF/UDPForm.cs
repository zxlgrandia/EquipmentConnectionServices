using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//本段代码中需要新增加的命名空间
using System.Net.Sockets;
using System.Net;
using System.Threading;
using WebSocketSharp.Server;
using WebSocketSharp;

namespace WindowsFormsApplication1
{
    public partial class UDPForm : Form
    {
        WebSocketServer wssv;

        public UDPForm()
        {
            InitializeComponent();
        }

        private void UDPForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private void StartWSServer()
        {
            wssv = new WebSocketServer("ws://127.0.0.1:8087");
            wssv.AddWebSocketService<SensorService>("/SensorService");
            wssv.Start();
        }

        private void btnOpenUDP_Click(object sender, EventArgs e)
        {
            ConnectionConfig.Ip = txtServerIP.Text == String.Empty ? "127.0.0.1" : txtServerIP.Text;
            ConnectionConfig.Port = txtServerPort.Text ==String.Empty ? "10006" : txtServerPort.Text;
            ConnectionConfig.UDPCommand = txtSendMssg.Text == String.Empty ? "ReadData1" : txtSendMssg.Text;
            ConnectionConfig.IsUdpRecvStart = false;
            StartWSServer();

            lblStatus.Text = "数据监听已启动";
        }

        public static class ConnectionConfig
        {
            public static string Ip;
            public static string Port;
            public static string UDPCommand;
            public static bool IsUdpRecvStart;
        }

        public class SensorService : WebSocketBehavior
        {
            IPEndPoint ip;
            Socket server;
            private string StartUDPListen()
            {
                string returnData = "";
                ip = new IPEndPoint(IPAddress.Parse(ConnectionConfig.Ip), Convert.ToInt32(ConnectionConfig.Port)); // 本机IP和监听端口号
                server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                returnData = SendData(ConnectionConfig.UDPCommand);
                return returnData;
            }

            private string SendData(string sendString)
            {
                byte[] data = new byte[1024];
                data = Encoding.ASCII.GetBytes(sendString);
                server.SendTo(data, data.Length, SocketFlags.None, ip);
                IPEndPoint senders = new IPEndPoint(IPAddress.Any, 0);
                EndPoint Remote = (EndPoint)senders;
                data = new byte[1024];
                //对于不存在的IP地址，加入此行代码后，可以在指定时间内解除阻塞模式限制
                int recv = server.ReceiveFrom(data, ref Remote);
                string message = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine("Message received from {0}: ", Remote.ToString());
                Console.WriteLine(message);
                return message;
            }

            protected override void OnMessage(MessageEventArgs e)
            {
                var msg = e.Data;
                var message = StartUDPListen();
                Send(message);

                if(server !=null && server.Connected)
                {
                    server.Disconnect(false);
                    server.Close();
                }

            }
        }

        private void bt_send_Click(object sender, EventArgs e)
        {

        }
    }


   

}
