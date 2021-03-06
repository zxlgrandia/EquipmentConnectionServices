﻿using DAL;
using Model;
using ServicesFactory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Utils;
using WebSocketSharp.Server;

namespace WindowsFormsApplication1
{
    public partial class MainServiceForm : Form
    {
        private List<EquipmentModel> list = new List<EquipmentModel>();
        public MainServiceForm()
        {
            InitializeComponent();
        }

        private void toolStripButton_star_Click(object sender, EventArgs e)
        {
           
        }


        /// <summary>
        /// 温湿度传感器
        /// </summary>
        /// <returns></returns>
        private EquipmentModel GetSensorEquipmentModel()
        {
            EquipmentAgreementModel am = new EquipmentAgreementModel
            {
                AgreementType = "sensor",
                ConnectionEntry = "SensorService",
                SendMessage = "ReadData1",
                WebSocketIp = "ws://127.0.0.1",
                WebSocketPort = "8087",
                EquipmentIp = "192.168.1.56",
                EquipmentPort = "10006"
            };

            EquipmentModel em = new EquipmentModel
            {
                Name = "温湿度传感器",
                Manufacturer = "山东瀛海",
                Model = "20-1240-9",
                ClientIp = "192.168.1.56",
                ClientPort = 10006,
                EquipmentAgreement = am
            };

            return em;
        }

        /// <summary>
        /// 游标卡尺
        /// </summary>
        /// <returns></returns>
        private EquipmentModel GetVernierEquipmentModel()
        {
            EquipmentAgreementModel am = new EquipmentAgreementModel
            {
                AgreementType = "vernier",
                ConnectionEntry = "VernierCaliperService",
                WebSocketIp = "ws://127.0.0.1",
                WebSocketPort = "8089",
                Bps = 9600,
                EndPosition = 1,
                DataBit = 8,
                CheckPoint = "无",
                Com = "COM4"
            };

            EquipmentModel em = new EquipmentModel
            {
                Name = "游标卡尺",
                Manufacturer = "广陆制造",
                Model = "201-31240-9",
                EquipmentAgreement = am
            };

            return em;

        }

        /// <summary>
        /// 电子称
        /// </summary>
        /// <returns></returns>
        private EquipmentModel GetElectronicScaleEquipmentModel()
        {
            EquipmentAgreementModel am = new EquipmentAgreementModel
            {
                AgreementType = "electronicScale",
                ConnectionEntry = "ElectronicScaleService",
                WebSocketIp = "ws://127.0.0.1",
                WebSocketPort = "8099",
                Bps = 9600,
                EndPosition = 1,
                DataBit = 8,
                CheckPoint = "无",
                Com = "COM1"
            };

            EquipmentModel em = new EquipmentModel
            {
                Name = "电子秤",
                Manufacturer = "moxa",
                Model = "201-31240-9",
                EquipmentAgreement = am
            };

            return em;

        }

        private void StartWebSocket(EquipmentModel em)
        {
            string ws = "ws://" + em.EquipmentAgreement.WebSocketIp + ":" + em.EquipmentAgreement.WebSocketPort;
            WebSocketServer wssv = new WebSocketServer(ws);

            switch (em.EquipmentAgreement.AgreementType)
            {
                case "SensorService":
                    wssv.AddWebSocketService<SensorEquipmentService>(
                        "/SensorService",
                        new Action<SensorEquipmentService>((s) => {
                            s.IP = em.EquipmentAgreement.WebSocketIp;
                            s.Port = em.EquipmentAgreement.WebSocketPort;
                            s.SendMessage = em.EquipmentAgreement.SendMessage;
                        }));
                    wssv.Start();

                    //lsMessage.Items.Add("温湿度传感器服务开启");
                    break;
                case "VernierCaliper":
                    wssv.AddWebSocketService<VernierCaliperService>(
                       "/VernierCaliper",
                       new Action<VernierCaliperService>((s) => {
                           s.KC_BaudRate = em.EquipmentAgreement.Bps;
                           s.KC_COMPort = em.EquipmentAgreement.Com;
                           s.KC_DataBits = em.EquipmentAgreement.DataBit;
                           s.KC_Paritv = em.EquipmentAgreement.CheckPoint;
                           s.KC_StopBits = em.EquipmentAgreement.EndPosition;
                          // s.OpenCom();
                       }));
                    wssv.Start();

                    //lsMessage.Items.Add("游标卡尺服务开启");
                    break;
                case "ElectronicScale":
                    wssv.AddWebSocketService<ElectronicScaleService>(
                       "/ElectronicScale",
                       new Action<ElectronicScaleService>((s) => {
                           s.KC_BaudRate = em.EquipmentAgreement.Bps;
                           s.KC_COMPort = em.EquipmentAgreement.Com;
                           s.KC_DataBits = em.EquipmentAgreement.DataBit;
                           s.KC_Paritv = em.EquipmentAgreement.CheckPoint;
                           s.KC_StopBits = em.EquipmentAgreement.EndPosition;
                       }));
                    wssv.Start();

                   // lsMessage.Items.Add("电子秤服务开启");
                    break;
                case "Card":
                    wssv.AddWebSocketService<CardService>("/Laputa");
                    wssv.Start();
                    //lsMessage.Items.Add("刷卡服务开启");
                    break;
                default:
                    break;
            }

            
        } 

        private void LoadEquipment()
        {
            lsMessage.Items.Add("设备侦测中...,请稍后");
            // 访问数据库读取所有设备信息
            string hostName = Dns.GetHostName();   //获取本机名
            IPHostEntry localhost = Dns.GetHostByName(hostName);    //可以获取IPv4的地址
                                                                    //IPHostEntry localhost = Dns.GetHostEntry(hostName);   //获取IPv6地址
            IPAddress localaddr = localhost.AddressList[0];

            List<EquipmentModel> equipmentList = EquipmentDAL.GetEquipmentList(localaddr.ToString());
            equipmentList.ForEach(item =>
            {
                List<EquipmentAgreementModel> agreementList = EquipmentAgreementDAL.GetEquipmentAgreementList(item.AgreementId);
                item.EquipmentAgreement = agreementList[0];
            });

            lsMessage.Items.Add("设备侦测结束,发现" + equipmentList.Count + "台设备与当前主机匹配");

            // 根据设备信息读取设备协议内容
            // 循环遍历设备，初始化服务
            //List<EquipmentModel> list = new List<EquipmentModel> {
            //    this.GetSensorEquipmentModel(),
            //    this.GetVernierEquipmentModel(),
            //    this.GetElectronicScaleEquipmentModel()
            //};

            lsMessage.Items.Add("设备连接中...,请稍后");

            for (int i = 0; i < equipmentList.Count; i++)
            {
                var si = i;
                var s = equipmentList[si];
                new Thread(() =>
                {
                    Console.WriteLine("执行" + si.ToString());
                    this.StartWebSocket(s);

                }).Start();

            }
        }

        private void toolStripButton_set_Click(object sender, EventArgs e)
        {
            ConfigForm config = GenericSingleton<ConfigForm>.CreateInstrance();
            config.Show();
        }

        private void toolStripButton_about_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_Card_Click(object sender, EventArgs e)
        {
            CardFormService config = GenericSingleton<CardFormService>.CreateInstrance();
           // config.Show();

       
            // 将窗体Form2显示在tabPage[0]中
            config.TopLevel = false;
            if (tabControl1.TabPages.Count > 1)
            {
                bool isCreate = true;
                for (int i = 0; i < tabControl1.TabPages.Count; i++) {
                    if (tabControl1.TabPages[i].Text == "刷卡服务") {
                        isCreate = false;
                    }
                }
                if (isCreate) {
                    TabPage Page = new TabPage();
                    Page.Text = "刷卡服务";
                    Page.Controls.Add(config);
                    config.Show();
                    tabControl1.Controls.Add(Page);
                }
            }
            else {
                if (tabControl1.TabPages[0].Text == "服务信息")
                {
                    tabControl1.TabPages[0].Text = "刷卡服务";
                    tabControl1.TabPages[0].Controls.Add(config);
                    config.Show();
                }
                else {
                    TabPage Page = new TabPage();
                    Page.Text = "刷卡服务";
                    Page.Controls.Add(config);
                    config.Show();
                    tabControl1.Controls.Add(Page);
                } 
            }
          
        }

        private void ToolStripMenuItem_Sensor_Click(object sender, EventArgs e)
        {
            UDPForm config = GenericSingleton<UDPForm>.CreateInstrance();
            config.TopLevel = false;
            if (tabControl1.TabPages.Count > 1)
            {
                bool isCreate = true;
                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    if (tabControl1.TabPages[i].Text == "温湿度传感器服务")
                    {
                        isCreate = false;
                    }
                }
                if (isCreate)
                {
                    TabPage Page = new TabPage();
                    Page.Text = "温湿度传感器服务";
                    Page.Controls.Add(config);
                    config.Show();
                    tabControl1.Controls.Add(Page);
                }
            }
            else
            {
                if (tabControl1.TabPages[0].Text == "服务信息")
                {
                    tabControl1.TabPages[0].Text = "温湿度传感器服务";
                    tabControl1.TabPages[0].Controls.Add(config);
                    config.Show();
                }
                else
                {
                    TabPage Page = new TabPage();
                    Page.Text = "温湿度传感器服务";
                    Page.Controls.Add(config);
                    config.Show();
                    tabControl1.Controls.Add(Page);
                }
            }
        }

        private void ToolStripMenuItem_ElectronicScale_Click(object sender, EventArgs e)
        {
            ElectronicScaleFormService config = GenericSingleton<ElectronicScaleFormService>.CreateInstrance();
            config.TopLevel = false;
            if (tabControl1.TabPages.Count > 1)
            {
                bool isCreate = true;
                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    if (tabControl1.TabPages[i].Text == "电子称服务")
                    {
                        isCreate = false;
                    }
                }
                if (isCreate)
                {
                    TabPage Page = new TabPage();
                    Page.Text = "电子称服务";
                    Page.Controls.Add(config);
                    config.Show();
                    tabControl1.Controls.Add(Page);
                }
            }
            else
            {
                if (tabControl1.TabPages[0].Text == "服务信息")
                {
                    tabControl1.TabPages[0].Text = "电子称服务";
                    tabControl1.TabPages[0].Controls.Add(config);
                    config.Show();
                }
                else
                {
                    TabPage Page = new TabPage();
                    Page.Text = "电子称服务";
                    Page.Controls.Add(config);
                    config.Show();
                    tabControl1.Controls.Add(Page);
                }
            }
        }
        /// <summary>
        /// 游标卡尺
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_VernierCaliper_Click(object sender, EventArgs e)
        {
            VernierCaliperFormService config = GenericSingleton<VernierCaliperFormService>.CreateInstrance();
            config.TopLevel = false;
            if (tabControl1.TabPages.Count > 1)
            {
                bool isCreate = true;
                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    if (tabControl1.TabPages[i].Text == "游标卡尺服务")
                    {
                        isCreate = false;
                    }
                }
                if (isCreate)
                {
                    TabPage Page = new TabPage();
                    Page.Text = "游标卡尺服务";
                    Page.Controls.Add(config);
                    config.Show();
                    tabControl1.Controls.Add(Page);
                }
            }
            else
            {
                if (tabControl1.TabPages[0].Text == "服务信息")
                {
                    tabControl1.TabPages[0].Text = "游标卡尺服务";
                    tabControl1.TabPages[0].Controls.Add(config);
                    config.Show();
                }
                else
                {
                    TabPage Page = new TabPage();
                    Page.Text = "游标卡尺服务";
                    Page.Controls.Add(config);
                    config.Show();
                    tabControl1.Controls.Add(Page);
                }
            }
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            LoadEquipment();
        }

        private void lsMessage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
