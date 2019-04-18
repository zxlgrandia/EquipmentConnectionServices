using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace EquipmentWindowsService
{
    public partial class CardService : ServiceBase
    {

        WebSocketServer wssv;

        public CardService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.StartListening();
        }

        protected override void OnStop()
        {
            this.StopListening();
        }

        private void StartListening()
        {
            try
            {
                if (null != wssv)
                {
                    wssv.Stop();
                }
                string ads = Convert.ToString(ConfigurationManager.AppSettings["card_ads"]);
                string op = Convert.ToString(ConfigurationManager.AppSettings["card_op"]);
                if (string.IsNullOrEmpty(ads))
                {
                    // 记录日志
                    return;

                }
                if (string.IsNullOrEmpty(op))
                {
                    // 记录日志
                    return;
                }
                wssv = new WebSocketServer(ads);
                wssv.AddWebSocketService<Laputa>(op);
                wssv.Start();

                //记录日志
                ServiceLog.WriteServiceLog(ServiceLog.CARD_SERVICE, "开启刷卡服务【成功】", "", DateTime.Now.ToLocalTime());

            }
            catch (Exception ex)
            {
                // 记录日志
                ServiceLog.WriteServiceLog(ServiceLog.CARD_SERVICE, "刷卡服务启动【失败】", ex.Message, DateTime.Now.ToLocalTime());
                
            }
        }

        private void StopListening()
        {
            try
            {
                if (null != wssv)
                {
                    wssv.Stop();
                    // 记录日志
                    ServiceLog.WriteServiceLog(ServiceLog.CARD_SERVICE, "停止刷卡服务", "", DateTime.Now.ToLocalTime());
                }
            }
            catch (Exception ex)
            {
                // 记录日志
                ServiceLog.WriteServiceLog(ServiceLog.CARD_SERVICE, "停止刷卡服务异常", ex.Message, DateTime.Now.ToLocalTime());
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
            string cardNumber = ReadCard();
            CloseCard();
            Send(cardNumber);

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
