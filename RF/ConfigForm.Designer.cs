namespace WindowsFormsApplication1
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_card_op = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_card_ads = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip_DZC = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_DZC_save = new System.Windows.Forms.ToolStripButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbx_DZC_DataBits = new System.Windows.Forms.ComboBox();
            this.cbx_DZC_StopBits = new System.Windows.Forms.ComboBox();
            this.cbx_DZC_Paritv = new System.Windows.Forms.ComboBox();
            this.cbx_DZC_BaudRate = new System.Windows.Forms.ComboBox();
            this.cbx_DZC_COMPort = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_DZC_op = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_DZC_ads = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_WSD_ServerIP = new System.Windows.Forms.TextBox();
            this.textBox_WSD_SendMssg = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_WSD_ServerPort = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.toolStrip_CARD = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_card_save = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_WSD_save = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip_DZC.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip_CARD.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 439);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStrip_CARD);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(780, 413);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "刷卡器配置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_card_op);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_card_ads);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 119);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务信息";
            // 
            // textBox_card_op
            // 
            this.textBox_card_op.Location = new System.Drawing.Point(339, 37);
            this.textBox_card_op.Name = "textBox_card_op";
            this.textBox_card_op.Size = new System.Drawing.Size(167, 21);
            this.textBox_card_op.TabIndex = 16;
            this.textBox_card_op.Text = "/Laputa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "方法：";
            // 
            // textBox_card_ads
            // 
            this.textBox_card_ads.Location = new System.Drawing.Point(51, 38);
            this.textBox_card_ads.Name = "textBox_card_ads";
            this.textBox_card_ads.Size = new System.Drawing.Size(192, 21);
            this.textBox_card_ads.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "地址：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.toolStrip_DZC);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(780, 413);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "电子称配置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip_DZC
            // 
            this.toolStrip_DZC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_DZC_save});
            this.toolStrip_DZC.Location = new System.Drawing.Point(3, 3);
            this.toolStrip_DZC.Name = "toolStrip_DZC";
            this.toolStrip_DZC.Size = new System.Drawing.Size(774, 25);
            this.toolStrip_DZC.TabIndex = 18;
            this.toolStrip_DZC.Text = "电子称";
            // 
            // toolStripButton_DZC_save
            // 
            this.toolStripButton_DZC_save.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_DZC_save.Image")));
            this.toolStripButton_DZC_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_DZC_save.Name = "toolStripButton_DZC_save";
            this.toolStripButton_DZC_save.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_DZC_save.Text = "保存";
            this.toolStripButton_DZC_save.Click += new System.EventHandler(this.toolStripButton_DZC_save_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbx_DZC_DataBits);
            this.groupBox5.Controls.Add(this.cbx_DZC_StopBits);
            this.groupBox5.Controls.Add(this.cbx_DZC_Paritv);
            this.groupBox5.Controls.Add(this.cbx_DZC_BaudRate);
            this.groupBox5.Controls.Add(this.cbx_DZC_COMPort);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Location = new System.Drawing.Point(18, 167);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(622, 138);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "串口信息";
            // 
            // cbx_DZC_DataBits
            // 
            this.cbx_DZC_DataBits.FormattingEnabled = true;
            this.cbx_DZC_DataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
            this.cbx_DZC_DataBits.Location = new System.Drawing.Point(341, 38);
            this.cbx_DZC_DataBits.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_DZC_DataBits.Name = "cbx_DZC_DataBits";
            this.cbx_DZC_DataBits.Size = new System.Drawing.Size(143, 20);
            this.cbx_DZC_DataBits.TabIndex = 17;
            // 
            // cbx_DZC_StopBits
            // 
            this.cbx_DZC_StopBits.FormattingEnabled = true;
            this.cbx_DZC_StopBits.Items.AddRange(new object[] {
            "0",
            "1",
            "1.5",
            "2"});
            this.cbx_DZC_StopBits.Location = new System.Drawing.Point(56, 61);
            this.cbx_DZC_StopBits.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_DZC_StopBits.Name = "cbx_DZC_StopBits";
            this.cbx_DZC_StopBits.Size = new System.Drawing.Size(137, 20);
            this.cbx_DZC_StopBits.TabIndex = 16;
            // 
            // cbx_DZC_Paritv
            // 
            this.cbx_DZC_Paritv.FormattingEnabled = true;
            this.cbx_DZC_Paritv.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
            this.cbx_DZC_Paritv.Location = new System.Drawing.Point(341, 14);
            this.cbx_DZC_Paritv.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_DZC_Paritv.Name = "cbx_DZC_Paritv";
            this.cbx_DZC_Paritv.Size = new System.Drawing.Size(143, 20);
            this.cbx_DZC_Paritv.TabIndex = 15;
            // 
            // cbx_DZC_BaudRate
            // 
            this.cbx_DZC_BaudRate.FormattingEnabled = true;
            this.cbx_DZC_BaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200"});
            this.cbx_DZC_BaudRate.Location = new System.Drawing.Point(56, 38);
            this.cbx_DZC_BaudRate.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_DZC_BaudRate.Name = "cbx_DZC_BaudRate";
            this.cbx_DZC_BaudRate.Size = new System.Drawing.Size(137, 20);
            this.cbx_DZC_BaudRate.TabIndex = 14;
            // 
            // cbx_DZC_COMPort
            // 
            this.cbx_DZC_COMPort.FormattingEnabled = true;
            this.cbx_DZC_COMPort.Location = new System.Drawing.Point(56, 14);
            this.cbx_DZC_COMPort.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_DZC_COMPort.Name = "cbx_DZC_COMPort";
            this.cbx_DZC_COMPort.Size = new System.Drawing.Size(137, 20);
            this.cbx_DZC_COMPort.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 17);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "通讯口";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 40);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "波特率";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 65);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "停止位";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(292, 17);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "校验";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(285, 40);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 9;
            this.label12.Text = "数据位";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_DZC_op);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox_DZC_ads);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(18, 37);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(622, 104);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "服务信息";
            // 
            // textBox_DZC_op
            // 
            this.textBox_DZC_op.Location = new System.Drawing.Point(339, 37);
            this.textBox_DZC_op.Name = "textBox_DZC_op";
            this.textBox_DZC_op.Size = new System.Drawing.Size(167, 21);
            this.textBox_DZC_op.TabIndex = 16;
            this.textBox_DZC_op.Text = "/Laputa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "方法：";
            // 
            // textBox_DZC_ads
            // 
            this.textBox_DZC_ads.Location = new System.Drawing.Point(51, 38);
            this.textBox_DZC_ads.Name = "textBox_DZC_ads";
            this.textBox_DZC_ads.Size = new System.Drawing.Size(192, 21);
            this.textBox_DZC_ads.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "地址：";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.toolStrip1);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(780, 413);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "温湿度传感器";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_WSD_ServerIP);
            this.groupBox2.Controls.Add(this.textBox_WSD_SendMssg);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_WSD_ServerPort);
            this.groupBox2.Location = new System.Drawing.Point(19, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(646, 163);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服务信息";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "消息内容：";
            // 
            // textBox_WSD_ServerIP
            // 
            this.textBox_WSD_ServerIP.Location = new System.Drawing.Point(117, 52);
            this.textBox_WSD_ServerIP.Name = "textBox_WSD_ServerIP";
            this.textBox_WSD_ServerIP.Size = new System.Drawing.Size(214, 21);
            this.textBox_WSD_ServerIP.TabIndex = 13;
            // 
            // textBox_WSD_SendMssg
            // 
            this.textBox_WSD_SendMssg.Location = new System.Drawing.Point(117, 91);
            this.textBox_WSD_SendMssg.Name = "textBox_WSD_SendMssg";
            this.textBox_WSD_SendMssg.Size = new System.Drawing.Size(214, 23);
            this.textBox_WSD_SendMssg.TabIndex = 11;
            this.textBox_WSD_SendMssg.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "服务器地址：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "端口：";
            // 
            // textBox_WSD_ServerPort
            // 
            this.textBox_WSD_ServerPort.Location = new System.Drawing.Point(434, 52);
            this.textBox_WSD_ServerPort.Name = "textBox_WSD_ServerPort";
            this.textBox_WSD_ServerPort.Size = new System.Drawing.Size(171, 21);
            this.textBox_WSD_ServerPort.TabIndex = 15;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(780, 413);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "工业相机";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // toolStrip_CARD
            // 
            this.toolStrip_CARD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_card_save});
            this.toolStrip_CARD.Location = new System.Drawing.Point(3, 3);
            this.toolStrip_CARD.Name = "toolStrip_CARD";
            this.toolStrip_CARD.Size = new System.Drawing.Size(774, 25);
            this.toolStrip_CARD.TabIndex = 14;
            this.toolStrip_CARD.Text = "刷卡";
            // 
            // toolStripButton_card_save
            // 
            this.toolStripButton_card_save.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_card_save.Image")));
            this.toolStripButton_card_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_card_save.Name = "toolStripButton_card_save";
            this.toolStripButton_card_save.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_card_save.Text = "保存";
            this.toolStripButton_card_save.Click += new System.EventHandler(this.toolStripButton_card_save_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_WSD_save});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(780, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_WSD_save
            // 
            this.toolStripButton_WSD_save.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_WSD_save.Image")));
            this.toolStripButton_WSD_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_WSD_save.Name = "toolStripButton_WSD_save";
            this.toolStripButton_WSD_save.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_WSD_save.Text = "保存";
            this.toolStripButton_WSD_save.Click += new System.EventHandler(this.toolStripButton_WSD_save_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 454);
            this.Controls.Add(this.tabControl1);
            this.Name = "ConfigForm";
            this.Text = "服务设置";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip_DZC.ResumeLayout(false);
            this.toolStrip_DZC.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip_CARD.ResumeLayout(false);
            this.toolStrip_CARD.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_card_op;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_card_ads;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_WSD_ServerIP;
        private System.Windows.Forms.RichTextBox textBox_WSD_SendMssg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_WSD_ServerPort;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_DZC_op;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_DZC_ads;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbx_DZC_DataBits;
        private System.Windows.Forms.ComboBox cbx_DZC_StopBits;
        private System.Windows.Forms.ComboBox cbx_DZC_Paritv;
        private System.Windows.Forms.ComboBox cbx_DZC_BaudRate;
        private System.Windows.Forms.ComboBox cbx_DZC_COMPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStrip toolStrip_DZC;
        private System.Windows.Forms.ToolStripButton toolStripButton_DZC_save;
        private System.Windows.Forms.ToolStrip toolStrip_CARD;
        private System.Windows.Forms.ToolStripButton toolStripButton_card_save;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_WSD_save;
    }
}