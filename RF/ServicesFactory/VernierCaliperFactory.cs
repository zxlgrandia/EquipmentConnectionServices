using Model;
using ServicesFactory;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using Utils;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WindowsFormsApplication1.ServicesFactory
{
    public class VernierCaliperFactory: EquipmentFactory
    {
        public override WebSocketBehavior CreateService(EquipmentModel equipment)
        {
            // 获取设备信息
            VernierCaliperService service = new VernierCaliperService();
            service.KC_COMPort = equipment.EquipmentAgreement.Com;
            service.KC_Paritv = equipment.EquipmentAgreement.CheckPoint;
            service.KC_BaudRate = equipment.EquipmentAgreement.Bps;
            service.KC_DataBits = equipment.EquipmentAgreement.DataBit;
            service.KC_StopBits = equipment.EquipmentAgreement.EndPosition;
            return service;
        }
    }

    public class VernierCaliperService : WebSocketBehavior
    {
        public string KC_COMPort { get; set; }
        public string KC_Paritv { get; set; }
        public int KC_BaudRate { get; set; }
        public int KC_DataBits { get; set; }
        public float KC_StopBits { get; set; }

        SerialPort sp = null;   //声明串口类
        bool isOpen = false;    //打开串口标志
        bool isSetProperty = false; //属性设置标志
        bool isHex = false;     //十六进制显示标志位
    
        /// <summary>
        /// 打开串口
        /// </summary>
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
                    ServiceLog.WriteServiceLog(ServiceLog.VC_SERVICE, "关闭串口时发生错误", "", DateTime.Now);
                 
                }
            }

            if (isOpen == false)
            {
                if (!CheckPortSetting())        //检测串口设置
                {
                    ServiceLog.WriteServiceLog(ServiceLog.VC_SERVICE, "串口未设置", "", DateTime.Now);
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
                    
                    ServiceLog.WriteServiceLog(ServiceLog.VC_SERVICE, "启动串口", "", DateTime.Now);
                }
                catch (Exception)
                {
                    //打开串口失败后，相应标志位取消
                    isSetProperty = false;
                    isOpen = false;
                    ServiceLog.WriteServiceLog(ServiceLog.VC_SERVICE, "串口无效或已被占用", "", DateTime.Now);
                }
            }


        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        private void CloseCom()
        {
            try       //关闭串口       
            {
                sp.Close();
                isOpen = false;
                ServiceLog.WriteServiceLog(ServiceLog.VC_SERVICE, "关闭串口", "", DateTime.Now);
            }
            catch (Exception)
            {
                ServiceLog.WriteServiceLog(ServiceLog.VC_SERVICE, "关闭串口时发生错误", "", DateTime.Now);
            }
        }
        private void SetPortProPerty()      //设置串口属性
        {

            sp = new SerialPort();

            sp.PortName = KC_COMPort;       //串口名

            sp.BaudRate = KC_BaudRate;//波特率

            float f = KC_StopBits;//停止位
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

            sp.DataBits = KC_DataBits;//数据位

            string s = KC_Paritv;       //校验位
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
                System.Threading.Thread.Sleep(50);     //延时100ms等待接收数据

                if (isHex == false)
                {

                    string rs = sp.ReadExisting();
                    if (rs.IndexOf('S') >= 0)
                    {

                        rs = rs.Substring(1, rs.Length - 1);
                        ServiceLog.WriteServiceLog(ServiceLog.VC_SERVICE, "读取数据："+ rs, "", DateTime.Now);
                        KachiValue.d = rs;

                    }

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
                }
                sp.DiscardInBuffer();       //丢弃接收缓冲区数据
            }
        }

        private bool CheckPortSetting()     //串口是否设置
        {
            if (KC_COMPort == "") return false;
            if (KC_Paritv == "") return false;
            if (KC_BaudRate <0) return false;
            if (KC_DataBits < 0) return false;
            if (KC_StopBits < 0) return false;
            return true;
        }
        public int icdev;
        int st;
        byte[] snr = new byte[5];

        public static class KachiValue
        {
            public static string d = "";
        }
        // 只读
        public string ReadCard()
        {
            return KachiValue.d;
        }

        protected override void OnClose(CloseEventArgs e)
        {
            CloseCom();
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
            var message = ReadCard();
            Send(message);

            ServiceLog.WriteServiceLog(ServiceLog.HT_SERVICE, "发送数据：", message, DateTime.Now);

        }

        protected override void OnOpen()
        {
            OpenCom();
            ServiceLog.WriteServiceLog(ServiceLog.HT_SERVICE, "打开连接", "成功", DateTime.Now);
            base.OnOpen();
        }

    }
}
