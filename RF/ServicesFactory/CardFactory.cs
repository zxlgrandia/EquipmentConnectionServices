using Model;
using ServicesFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Utils;
using WebSocketSharp;
using WebSocketSharp.Server;
using WindowsFormsApplication1;

namespace ServicesFactory
{
    public class CardFactory: EquipmentFactory
    {
        public override WebSocketBehavior CreateService(EquipmentModel equipment)
        {
            // 获取设备信息
            CardService service = new CardService();
            return service;
        }
    }

    public class CardService : WebSocketBehavior
    {

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
                ServiceLog.WriteServiceLog(ServiceLog.CARD_SERVICE, "连接读卡设备成功", "", DateTime.Now);
                byte[] status = new byte[30];
                st = Program.rf_get_status(icdev, status);
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
                 
                }
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
                ServiceLog.WriteServiceLog(ServiceLog.CARD_SERVICE, "读卡数据："+ snr1, "", DateTime.Now);
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

        public static class JB
        {
            public static int d = 0;
        }
        // 只读
      

        protected override void OnClose(CloseEventArgs e)
        {
            CloseCard();
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
            Open();
            ServiceLog.WriteServiceLog(ServiceLog.HT_SERVICE, "打开连接", "成功", DateTime.Now);
            base.OnOpen();
        }

    }


}
