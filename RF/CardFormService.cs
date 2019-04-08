using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class CardFormService : Form
    {
        public CardFormService()
        {
            InitializeComponent();
        }
        WebSocketServer wssv;
        private void toolStripButton_star_Click(object sender, EventArgs e)
        {
            try {
                if (null != wssv)
                {
                    wssv.Stop();
                }
                string ads = Convert.ToString(ConfigurationManager.AppSettings["card_ads"]);
                string op = Convert.ToString(ConfigurationManager.AppSettings["card_op"]);
                if (string.IsNullOrEmpty(ads))
                {
                    list_m.Items.Add("请设置地址!例如：ws://192.168.1.115:8086");
                    return;

                }
                if (string.IsNullOrEmpty(op))
                {
                    list_m.Items.Add("请设置方法!例如：/Laputa");
                    return;
                }
                wssv = new WebSocketServer(ads);
                wssv.AddWebSocketService<Laputa>(op);
                wssv.Start();


                //  Open();
                //  Console.ReadKey(true);
                toolStripLabel_status.Text = "服务状态：启动服务！";
                list_m.Items.Add("启动服务!");
            } catch {
                MessageBox.Show("启动异常！");
            }
        
        }

        private void toolStripButton_stop_Click(object sender, EventArgs e)
        {
            try
            {
                if (null != wssv)
                {
                    wssv.Stop();
                    // CloseCard();
                    list_m.Items.Add("关闭服务!");
                    toolStripLabel_status.Text = "服务状态：关闭服务！";
                }
            }
            catch {
                MessageBox.Show("关闭服务异常！");
            }
           
        }
       
    }

    public static class JB
    {
        public static int d = 0;
    }


    public class Laputa : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {

            var msg = e.Data == "BALUS"
                      ? "I've been balused already..."
                      : "I'm not available now.";
            Open();
            string kahao = ReadCard();
            CloseCard();
            Send(kahao);

        }

        public int icdev;
        int st;
        byte[] snr = new byte[5];

        public void Open()
        {
            icdev = JB.d;
            if (icdev > 0)
            {
                // Program.rf_exit(icdev);
            }
            if (icdev <= 0)
            {
                icdev = Program.rf_init(0, 9600);
            }
            JB.d = icdev;
            if (icdev > 0)
            {
                //   list_m.Items.Add("连接读卡设备成功!");
                byte[] status = new byte[30];
                st = Program.rf_get_status(icdev, status);
                //lbHardVer.Text=System.Text.Encoding.ASCII.GetString(status);
                //  list_m.Items.Add(System.Text.Encoding.Default.GetString(status));
                // Program.rf_beep(icdev, 25); // 蜂鸣时间，单位是25毫秒
            }
            else { }
            //  list_m.Items.Add("连接读卡设备失败!");

            byte[] key = { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
            int mode = 0;
            int sector = 0;
            for (int i = 0; i < 16; i++)
            {
                st = Program.rf_load_key(icdev, mode, sector, key);
                if (st != 0)
                {
                    string s1 = Convert.ToString(sector);
                    // list_m.Items.Add(s1 + " sector rf_load_key error!");
                }
                //else
                //{
                //   listBox1.Items.Add("rf_load_key seccess!");
                //}
                sector++;
            }

            // timer1.Enabled = false;
        }

        // 只读
        public string ReadCard()
        {
            int sector = 3;
            st = Program.rf_card(icdev, 1, snr);　　　　//寻卡
            if (st != 0)
            {
                // list_m.Items.Add("寻卡失败");
                Thread.Sleep(1000);
                // Program.rf_beep(icdev, 10); // 蜂鸣时间，单位是50毫秒
                return ReadCard();
            }
            else
            {
                byte[] snr1 = new byte[8];
                //  list_m.Items.Add("寻卡成功!");
                Program.hex_a(snr, snr1, 4); // 读取软件版本号
                                             // list_m.Items.Add(System.Text.Encoding.Default.GetString(snr1));

                Program.rf_beep(icdev, 50); // 蜂鸣时间，单位是50毫秒
                return System.Text.Encoding.Default.GetString(snr1);
            }

            // Program.rf_halt(icdev); // 执行该命令后如果是ALL寻卡模式则必须重新寻卡才能够对该卡操作，如果是IDLE模式则必须把卡移开感应区再进来才能寻得这张卡。
            // Program.rf_beep(icdev, 50); // 蜂鸣时间，单位是50毫秒
        }

        private void CloseCard()
        {
            st = Program.rf_exit(icdev);
            if (st == 0)
            {
                // list_m.Items.Add("断开连接！");
            }
            icdev = 0;
            // timer1.Enabled = false;
            JB.d = icdev;
        }
    }
}
