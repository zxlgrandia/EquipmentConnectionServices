using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WindowsFormsApplication1
{
    public partial class ElectronicScaleForm : Form
    {

        SerialPort sp = null;   //声明串口类
        bool isOpen = false;    //打开串口标志
        bool isSetProperty = false; //属性设置标志
        bool isHex = false;     //十六进制显示标志位

        public ElectronicScaleForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;
            for (int i=0;i<10;i++)
            {
                cbxCOMPort.Items.Add("COM" + (i + 1).ToString());
            }
        }

        private void btnCheckCOM_Click(object sender, EventArgs e)  //检测有哪串口
        {
            bool comExistence = false;  //是否有可用的串口
            cbxCOMPort.Items.Clear();   //清除当前串口号中的所有串口名称
            for(int i=0;i<10;i++)
            {
                try
                {
                    SerialPort sp = new SerialPort("COM" + (i + 1).ToString());
                    sp.Open();
                    sp.Close();
                    cbxCOMPort.Items.Add("COM" + (i + 1).ToString());
                    comExistence = true;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            if (comExistence)
            {
                cbxCOMPort.SelectedIndex = 0;//使ListBox显示第一个添加的索引
            }
            else
            {
                MessageBox.Show("没有找到可用串口！","错误提示");
            }
        }

        private bool CheckPortSetting()     //串口是否设置
        {
            if (cbxCOMPort.Text.Trim() == "") return false;
            if (cbxBaudRate.Text.Trim() == "") return false;
            if (cbxDataBits.Text.Trim() == "") return false;
            if (cbxParitv.Text.Trim() == "") return false;
            if (cbxStopBits.Text.Trim() == "") return false;
            return true;
        }
        private bool CheckSendData()
        {
            if (tbxSendData.Text.Trim() == "") return false;
            return true;
        }

        private void SetPortProPerty()      //设置串口属性
        {
            sp = new SerialPort();

            sp.PortName = cbxCOMPort.Text.Trim();       //串口名

            sp.BaudRate = Convert.ToInt32(cbxBaudRate.Text.Trim());//波特率

            float f = Convert.ToSingle(cbxStopBits.Text.Trim());//停止位
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

            sp.DataBits = Convert.ToInt16(cbxDataBits.Text.Trim());//数据位

            string s = cbxParitv.Text.Trim();       //校验位
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
            if (rbnHex.Checked)
            {
                isHex = true;
            }
            else
            {
                isHex = false;
            }

            void sp_DataReceived(object sender,SerialDataReceivedEventArgs e)
            {
                System.Threading.Thread.Sleep(100);     //延时100ms等待接收数据

                //this.Invoke  跨线程访问ui的方法
                this.Invoke((EventHandler)(delegate
                {
                    if (isHex == false)
                    {
                        tbxRecvData.Text += sp.ReadLine();
                        ChengValue.d = sp.ReadLine();
                    }
                    else
                    {
                        Byte[] ReceivedData = new Byte[sp.BytesToRead];
                        sp.Read(ReceivedData, 0, ReceivedData.Length);
                        String RecvDataText = null;
                        for(int i = 0; i < ReceivedData.Length - 1; i++)
                        {
                            RecvDataText += ("0x" + ReceivedData[i].ToString("X2") + "");
                        }
                        tbxRecvData.Text += RecvDataText;
                    }
                    sp.DiscardInBuffer();       //丢弃接收缓冲区数据
                }));
            }
        }

        private void btnSend_Click(object sender, EventArgs e)      //发送数据
        {
            if (isOpen)
            {
                try
                {
                    sp.WriteLine(tbxSendData.Text);
                }
                catch(Exception)
                {
                    MessageBox.Show("发送数据时发生错误！", "错误提示");
                    return;
                }
            }
            else
            {
                MessageBox.Show("串口未打开", "错误提示");
                return;
            }
            if (!CheckSendData())
            {
                MessageBox.Show("请输入要发送的数据!", "错误提示");
                return;
            }
        }

        private void btnOpenCom_Click(object sender, EventArgs e)
        {
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
                    btnOpenCom.Text = "关闭串口";
                    //串口打开后则相关串口设置按钮便不可再用
                    cbxCOMPort.Enabled = false;
                    cbxBaudRate.Enabled = false;
                    cbxDataBits.Enabled = false;
                    cbxParitv.Enabled = false;
                    cbxStopBits.Enabled = false;
                    rbnChar.Enabled = false;
                    rbnHex.Enabled = false;
                }
                catch (Exception)
                {
                    //打开串口失败后，相应标志位取消
                    isSetProperty = false;
                    isOpen = false;
                    MessageBox.Show("串口无效或已被占用！", "错误提示");
                }
            }
            else
            {
                try       //关闭串口       
                {
                    sp.Close();
                    isOpen = false;
                    btnOpenCom.Text = "打开串口";
                    //关闭串口后，串口设置选项可以继续使用
                    cbxCOMPort.Enabled = true;
                    cbxBaudRate.Enabled = true;
                    cbxDataBits.Enabled = true;
                    cbxParitv.Enabled = true;
                    cbxStopBits.Enabled = true;
                    rbnChar.Enabled = true;
                    rbnHex.Enabled = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("关闭串口时发生错误！", "错误提示");
                }
            }
            
        }
        private void btnCleanData_Click(object sender, EventArgs e)
        {
            tbxRecvData.Text = "";
            tbxSendData.Text = "";
        }


        WebSocketServer wssv;
        // 启动服务
        private void bt_star_Click(object sender, EventArgs e)
        {
            if (null != wssv)
            {
                wssv.Stop();
            }
            string ads = textBox_ads.Text;
            string op = textBox_op.Text;
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
        }
        // 关闭服务
        private void bt_close_Click(object sender, EventArgs e)
        {
            if (null != wssv)
            {
                wssv.Stop();
                // CloseCard();
                // list_m.Items.Add("关闭服务!");
            }
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
