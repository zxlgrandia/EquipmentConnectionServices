using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace WindowsFormsApplication1
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

      

     

        // tab 加载
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    getCardConfig(); // 刷卡
                    break;
                case 1:
                    getDZCConfig(); // 电子称
                    break;
                case 2:
                    getWSDConfig(); // 温湿度
                    break;
            }
        }

        /// <summary>
        /// 读取配置 刷卡
        /// </summary>
        private void getCardConfig() {
            textBox_card_ads.Text = Convert.ToString(ConfigurationManager.AppSettings["card_ads"]);
            textBox_card_op.Text = Convert.ToString(ConfigurationManager.AppSettings["card_op"]);
        }
        /// <summary>
        /// 读取配置 温湿度
        /// </summary>
        private void getWSDConfig()
        {
            textBox_WSD_ServerIP.Text = Convert.ToString(ConfigurationManager.AppSettings["WSD_ServerIP"]);
            textBox_WSD_ServerPort.Text = Convert.ToString(ConfigurationManager.AppSettings["WSD_ServerPort"]);
            textBox_WSD_SendMssg.Text = Convert.ToString(ConfigurationManager.AppSettings["WSD_SendMssg"]);
        }
        /// <summary>
        /// 读取配置 电子称
        /// </summary>
        private void getDZCConfig()
        {
            textBox_DZC_ads.Text = Convert.ToString(ConfigurationManager.AppSettings["DZC_ads"]);
            textBox_DZC_op.Text = Convert.ToString(ConfigurationManager.AppSettings["DZC_op"]);

            for (int i = 0; i < 10; i++)
            {
                cbx_DZC_COMPort.Items.Add("COM" + (i + 1).ToString());
            }
            cbx_DZC_COMPort.Text = Convert.ToString(ConfigurationManager.AppSettings["DZC_COMPort"]);
            cbx_DZC_Paritv.Text = Convert.ToString(ConfigurationManager.AppSettings["DZC_Paritv"]);
            cbx_DZC_BaudRate.Text = Convert.ToString(ConfigurationManager.AppSettings["DZC_BaudRate"]);
            cbx_DZC_DataBits.Text = Convert.ToString(ConfigurationManager.AppSettings["DZC_DataBits"]);
            cbx_DZC_StopBits.Text = Convert.ToString(ConfigurationManager.AppSettings["DZC_StopBits"]);

                
        }


        private void toolStripButton_DZC_save_Click(object sender, EventArgs e)
        {
            ConfigHelper.UpdateAppConfig("DZC_ads", textBox_DZC_ads.Text.ToString());
            ConfigHelper.UpdateAppConfig("DZC_op", textBox_DZC_op.Text.ToString());

            ConfigHelper.UpdateAppConfig("DZC_COMPort", cbx_DZC_COMPort.Text.ToString());
            ConfigHelper.UpdateAppConfig("DZC_Paritv", cbx_DZC_Paritv.Text.ToString());
            ConfigHelper.UpdateAppConfig("DZC_BaudRate", cbx_DZC_BaudRate.Text.ToString());
            ConfigHelper.UpdateAppConfig("DZC_DataBits", cbx_DZC_DataBits.Text.ToString());
            ConfigHelper.UpdateAppConfig("DZC_StopBits", cbx_DZC_StopBits.Text.ToString());

        }
        //刷卡
        private void toolStripButton_card_save_Click(object sender, EventArgs e)
        {
            ConfigHelper.UpdateAppConfig("card_ads", textBox_card_ads.Text.ToString());
            ConfigHelper.UpdateAppConfig("card_op", textBox_card_op.Text.ToString());

        }

        private void toolStripButton_WSD_save_Click(object sender, EventArgs e)
        {
            ConfigHelper.UpdateAppConfig("WSD_ServerIP", textBox_WSD_ServerIP.Text.ToString());
            ConfigHelper.UpdateAppConfig("WSD_ServerPort", textBox_WSD_ServerPort.Text.ToString());
            ConfigHelper.UpdateAppConfig("WSD_SendMssg", textBox_WSD_SendMssg.Text.ToString());

        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            getCardConfig(); // 刷卡
        }
    }
}
