namespace WindowsFormsApplication1
{
    partial class MainServiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainServiceForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_star = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItem_Card = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ElectronicScale = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Sensor = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_VernierCaliper = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton_set = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_about = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnStartServer = new System.Windows.Forms.ToolStripButton();
            this.lsMessage = new System.Windows.Forms.ListBox();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartServer,
            this.toolStripButton_star,
            this.toolStripButton_set,
            this.toolStripButton_about});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_star
            // 
            this.toolStripButton_star.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Card,
            this.ToolStripMenuItem_ElectronicScale,
            this.ToolStripMenuItem_Sensor,
            this.ToolStripMenuItem_VernierCaliper});
            this.toolStripButton_star.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_star.Image")));
            this.toolStripButton_star.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_star.Name = "toolStripButton_star";
            this.toolStripButton_star.Size = new System.Drawing.Size(85, 22);
            this.toolStripButton_star.Text = "服务测试";
            this.toolStripButton_star.Click += new System.EventHandler(this.toolStripButton_star_Click);
            // 
            // ToolStripMenuItem_Card
            // 
            this.ToolStripMenuItem_Card.Name = "ToolStripMenuItem_Card";
            this.ToolStripMenuItem_Card.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_Card.Text = "刷卡服务";
            this.ToolStripMenuItem_Card.Click += new System.EventHandler(this.ToolStripMenuItem_Card_Click);
            // 
            // ToolStripMenuItem_ElectronicScale
            // 
            this.ToolStripMenuItem_ElectronicScale.Name = "ToolStripMenuItem_ElectronicScale";
            this.ToolStripMenuItem_ElectronicScale.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_ElectronicScale.Text = "电子称服务";
            this.ToolStripMenuItem_ElectronicScale.Click += new System.EventHandler(this.ToolStripMenuItem_ElectronicScale_Click);
            // 
            // ToolStripMenuItem_Sensor
            // 
            this.ToolStripMenuItem_Sensor.Name = "ToolStripMenuItem_Sensor";
            this.ToolStripMenuItem_Sensor.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_Sensor.Text = "温湿度传感器服务";
            this.ToolStripMenuItem_Sensor.Click += new System.EventHandler(this.ToolStripMenuItem_Sensor_Click);
            // 
            // ToolStripMenuItem_VernierCaliper
            // 
            this.ToolStripMenuItem_VernierCaliper.Name = "ToolStripMenuItem_VernierCaliper";
            this.ToolStripMenuItem_VernierCaliper.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_VernierCaliper.Text = "游标卡尺服务";
            this.ToolStripMenuItem_VernierCaliper.Click += new System.EventHandler(this.ToolStripMenuItem_VernierCaliper_Click);
            // 
            // toolStripButton_set
            // 
            this.toolStripButton_set.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_set.Image")));
            this.toolStripButton_set.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_set.Name = "toolStripButton_set";
            this.toolStripButton_set.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton_set.Text = "服务设置";
            this.toolStripButton_set.Click += new System.EventHandler(this.toolStripButton_set_Click);
            // 
            // toolStripButton_about
            // 
            this.toolStripButton_about.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_about.Image")));
            this.toolStripButton_about.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_about.Name = "toolStripButton_about";
            this.toolStripButton_about.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_about.Text = "关于";
            this.toolStripButton_about.Click += new System.EventHandler(this.toolStripButton_about_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 410);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lsMessage);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 384);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "服务信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnStartServer
            // 
            this.btnStartServer.Image = ((System.Drawing.Image)(resources.GetObject("btnStartServer.Image")));
            this.btnStartServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(100, 22);
            this.btnStartServer.Text = "启动设备服务";
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // lsMessage
            // 
            this.lsMessage.FormattingEnabled = true;
            this.lsMessage.ItemHeight = 12;
            this.lsMessage.Items.AddRange(new object[] {
            "等待服务开启......"});
            this.lsMessage.Location = new System.Drawing.Point(6, 6);
            this.lsMessage.Name = "lsMessage";
            this.lsMessage.Size = new System.Drawing.Size(756, 376);
            this.lsMessage.TabIndex = 0;
            this.lsMessage.SelectedIndexChanged += new System.EventHandler(this.lsMessage_SelectedIndexChanged);
            // 
            // MainServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainServiceForm";
            this.Text = "客户服务程序";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_set;
        private System.Windows.Forms.ToolStripButton toolStripButton_about;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton_star;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Card;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Sensor;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ElectronicScale;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_VernierCaliper;
        private System.Windows.Forms.ToolStripButton btnStartServer;
        private System.Windows.Forms.ListBox lsMessage;
    }
}