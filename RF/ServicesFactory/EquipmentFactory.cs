using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Utils;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace ServicesFactory
{
    public abstract class EquipmentFactory
    {
        public WebSocketBehavior PublishService(EquipmentModel equipment )
        {
            WebSocketBehavior service = CreateService(equipment);
            return service;
        }
        public abstract WebSocketBehavior CreateService(EquipmentModel equipment);
    }

    public class SensorEquipmentFactory : EquipmentFactory
    {
        public override WebSocketBehavior CreateService(EquipmentModel equipment)
        {
            // 获取设备信息
            // 初始化传感器设备服务
            SensorEquipmentService service = new SensorEquipmentService();
            service.IP = equipment.EquipmentAgreement.WebSocketIp;
            service.Port = equipment.EquipmentAgreement.WebSocketPort;
            service.SendMessage = equipment.EquipmentAgreement.SendMessage;
            return service;
        }
    }

    public class SensorEquipmentService : WebSocketBehavior
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public string SendMessage { get; set; }
        public IPEndPoint EndPoint { get; set; }
        public Socket SocketServer { get; set; }

        public string StartListen()
        {
            string returnData = "";
            EndPoint = new IPEndPoint(IPAddress.Parse(IP), Port); // 本机IP和监听端口号
            SocketServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            returnData = SendData(SendMessage);
            return returnData;
        }

        public string SendData(string sendData)
        {
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(sendData);
            SocketServer.SendTo(data, data.Length, SocketFlags.None, EndPoint);
            IPEndPoint senders = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)senders;
            data = new byte[1024];
            //对于不存在的IP地址，加入此行代码后，可以在指定时间内解除阻塞模式限制
            int recv = SocketServer.ReceiveFrom(data, ref Remote);
            string message = Encoding.ASCII.GetString(data, 0, recv);
            Console.WriteLine("Message received from {0}: ", Remote.ToString());
            Console.WriteLine(message);
            return message;
        }

        protected override void OnClose(CloseEventArgs e)
        {
            ServiceLog.WriteServiceLog(ServiceLog.HT_SERVICE, "连接关闭", "", DateTime.Now);
            base.OnClose(e);
        }

        protected override void OnError(ErrorEventArgs e)
        {
            ServiceLog.WriteServiceLog(ServiceLog.HT_SERVICE, "连接异常", e.Message, DateTime.Now);
            base.OnError(e);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            var msg = e.Data;
            Console.WriteLine(msg);
            var message = StartListen();
            Send(message);

            if (SocketServer != null && SocketServer.Connected)
            {
                SocketServer.Disconnect(false);
                SocketServer.Close();
            }

            ServiceLog.WriteServiceLog(ServiceLog.HT_SERVICE, "发送数据：", message , DateTime.Now);

        }

        protected override void OnOpen()
        {
            ServiceLog.WriteServiceLog(ServiceLog.HT_SERVICE, "打开连接", "成功", DateTime.Now);
            base.OnOpen();
        }
    }
}
