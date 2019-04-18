using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainServiceForm : Form
    {
        public MainServiceForm()
        {
            InitializeComponent();
        }

        private void toolStripButton_star_Click(object sender, EventArgs e)
        {

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
    }
}
