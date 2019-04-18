using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WindowsFormsApplication1
{
    public partial class ElectronicScaleFormService : Form
    {
        public ElectronicScaleFormService()
        {
            InitializeComponent();
        }
        SerialPort sp = null;   //声明串口类
        bool isOpen = false;    //打开串口标志
        bool isSetProperty = false; //属性设置标志
        bool isHex = false;     //十六进制显示标志位
        WebSocketServer wssv;
        private void toolStripButton_star_Click(object sender, EventArgs e)
        {
            OpenCom();
            if (null != wssv)
            {
                wssv.Stop();
            }

            string ads = Convert.ToString(ConfigurationManager.AppSettings["DZC_ads"]);
            string op = Convert.ToString(ConfigurationManager.AppSettings["DZC_op"]);
            if (string.IsNullOrEmpty(ads))
            {
                // list_m.Items.Add("请设置地址!例如：ws://192.168.1.115:8086");
                return;

            }
            if (string.IsNullOrEmpty(op))
            {
                // list_m.Items.Add("请设置方法!例如：/Cheng");
                return;
            }
            ChengValue.d = "";
            wssv = new WebSocketServer(ads);
            wssv.AddWebSocketService<ElectronicScale>(op);
            wssv.Start();
            list_m.Items.Add("启动服务!");
            toolStripLabel_status.Text = "服务状态：启动服务！";
        }
        private void clearItem (){

            if (list_m.Items.Count > 1000) {
                list_m.Items.Clear();
            }
        }
        private void toolStripButton_stop_Click(object sender, EventArgs e)
        {
            CloseCom();
            if (null != wssv)
            {
                wssv.Stop();
                // CloseCard();
                list_m.Items.Add("关闭服务!");
                toolStripLabel_status.Text = "服务状态：关闭服务！";
            }
        }

        private void OpenCom()
        {
            if (isOpen == true)
            {
                try       //关闭串口       
                {
                    sp.Close();
                    isOpen = false;
                }
                catch (Exception)
                {
                    list_m.Items.Add("关闭串口时发生错误!");
                    MessageBox.Show("关闭串口时发生错误！", "错误提示");
                }
            }

            if (isOpen == false)
            {
                if (!CheckPortSetting())        //检测串口设置
                {
                    MessageBox.Show("串口未设置！", "错误提示");
                    return;
                }
                if (!isSetProperty)             //串口未设置则设置串口
                {
                    SetPortProPerty();
                    isSetProperty = true;
                }
                try
                {
                    sp.Open();
                    isOpen = true;
                    list_m.Items.Add("启动串口!");
                }
                catch (Exception)
                {
                    //打开串口失败后，相应标志位取消
                    isSetProperty = false;
                    isOpen = false;
                    list_m.Items.Add("串口无效或已被占用!");
                    MessageBox.Show("串口无效或已被占用！", "错误提示");
                }
            }


        }

        private void CloseCom()
        {
            try       //关闭串口       
            {
                sp.Close();
                isOpen = false;
                list_m.Items.Add("关闭串口!");
            }
            catch (Exception)
            {
                list_m.Items.Add("关闭串口时发生错误!");
                MessageBox.Show("关闭串口时发生错误！", "错误提示");
            }
        }
        private void SetPortProPerty()      //设置串口属性
        {

            sp = new SerialPort();

            sp.PortName = Convert.ToString(ConfigurationManager.AppSettings["DZC_COMPort"]).Trim();       //串口名

            sp.BaudRate = Convert.ToInt32(Convert.ToString(ConfigurationManager.AppSettings["DZC_BaudRate"]).Trim());//波特率

            float f = Convert.ToSingle(Convert.ToString(ConfigurationManager.AppSettings["DZC_StopBits"]).Trim());//停止位
            if (f == 0)
            {
                sp.StopBits = StopBits.None;
            }
            else if (f == 1.5)
            {
                sp.StopBits = StopBits.OnePointFive;
            }
            else if (f == 1)
            {
                sp.StopBits = StopBits.One;
            }
            else if (f == 2)
            {
                sp.StopBits = StopBits.Two;
            }
            else
            {
                sp.StopBits = StopBits.One;
            }

            sp.DataBits = Convert.ToInt16(Convert.ToString(ConfigurationManager.AppSettings["DZC_DataBits"]).Trim());//数据位

            string s = Convert.ToString(ConfigurationManager.AppSettings["DZC_Paritv"]).Trim();       //校验位
            if (s.CompareTo("无") == 0)
            {
                sp.Parity = Parity.None;
            }
            else if (s.CompareTo("奇校验") == 0)
            {
                sp.Parity = Parity.Odd;
            }
            else if (s.CompareTo("偶校验") == 0)
            {
                sp.Parity = Parity.Even;
            }
            else
            {
                sp.Parity = Parity.None;
            }

            sp.ReadTimeout = -1;         //设置超时读取时间
            sp.RtsEnable = true;

            //定义DataReceived事件，当串口收到数据后触发事件
            sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            isHex = false;


            void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                System.Threading.Thread.Sleep(100);     //延时100ms等待接收数据

                //this.Invoke  跨线程访问ui的方法
                this.Invoke((EventHandler)(delegate
                {
                    if (isHex == false)
                    {
                        clearItem();
                        list_m.Items.Add(sp.ReadLine());
                        ChengValue.d = sp.ReadLine();
                    }
                    else
                    {
                        Byte[] ReceivedData = new Byte[sp.BytesToRead];
                        sp.Read(ReceivedData, 0, ReceivedData.Length);
                        String RecvDataText = null;
                        for (int i = 0; i < ReceivedData.Length - 1; i++)
                        {
                            RecvDataText += ("0x" + ReceivedData[i].ToString("X2") + "");
                        }
                        list_m.Items.Add(RecvDataText);
                    }
                    sp.DiscardInBuffer();       //丢弃接收缓冲区数据
                }));
            }
        }

        private bool CheckPortSetting()     //串口是否设置
        {
            if (Convert.ToString(ConfigurationManager.AppSettings["DZC_COMPort"]).Trim() == "") return false;
            if (Convert.ToString(ConfigurationManager.AppSettings["DZC_Paritv"]).Trim() == "") return false;
            if (Convert.ToString(ConfigurationManager.AppSettings["DZC_BaudRate"]).Trim() == "") return false;
            if (Convert.ToString(ConfigurationManager.AppSettings["DZC_DataBits"]).Trim() == "") return false;
            if (Convert.ToString(ConfigurationManager.AppSettings["DZC_StopBits"]).Trim() == "") return false;
            return true;
        }
    }

    public static class ChengValue
    {
        public static string d = "";
    }


    public class ElectronicScale : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {

            var msg = e.Data == "BALUS"
                      ? "I've been balused already..."
                      : "I'm not available now.";
            string kahao = ReadCard();
            Send(kahao);

        }

        public int icdev;
        int st;
        byte[] snr = new byte[5];


        // 只读
        public string ReadCard()
        {
            return ChengValue.d;
        }

    }
}
