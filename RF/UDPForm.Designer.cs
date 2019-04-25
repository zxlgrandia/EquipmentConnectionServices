namespace WindowsFormsApplication1
{
    partial class UDPForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UDPForm));
            this.bt_send = new System.Windows.Forms.Button();
            this.txtSendMssg = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOpenUDP = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbReceiveMessage = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtn_start = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStatusLbl = new System.Windows.Forms.ToolStripLabel();
            this.tsStatus = new System.Windows.Forms.ToolStripLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_send
            // 
            this.bt_send.Location = new System.Drawing.Point(315, 75);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(200, 23);
            this.bt_send.TabIndex = 0;
            this.bt_send.Text = "发送";
            this.bt_send.UseVisualStyleBackColor = true;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // txtSendMssg
            // 
            this.txtSendMssg.Location = new System.Drawing.Point(90, 75);
            this.txtSendMssg.Name = "txtSendMssg";
            this.txtSendMssg.Size = new System.Drawing.Size(214, 23);
            this.txtSendMssg.TabIndex = 5;
            this.txtSendMssg.Text = "ReadData1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "服务器地址：";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(90, 36);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(115, 21);
            this.txtServerIP.TabIndex = 7;
            this.txtServerIP.Text = "192.168.1.56";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(252, 36);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(49, 21);
            this.txtServerPort.TabIndex = 9;
            this.txtServerPort.Text = "10006";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "端口：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnOpenUDP);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtServerIP);
            this.groupBox1.Controls.Add(this.bt_send);
            this.groupBox1.Controls.Add(this.txtSendMssg);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtServerPort);
            this.groupBox1.Location = new System.Drawing.Point(18, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 162);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务端配置";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(88, 129);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 12);
            this.lblStatus.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "连接状态：";
            // 
            // btnOpenUDP
            // 
            this.btnOpenUDP.Location = new System.Drawing.Point(315, 34);
            this.btnOpenUDP.Name = "btnOpenUDP";
            this.btnOpenUDP.Size = new System.Drawing.Size(200, 23);
            this.btnOpenUDP.TabIndex = 11;
            this.btnOpenUDP.Text = "开启通道";
            this.btnOpenUDP.UseVisualStyleBackColor = true;
            this.btnOpenUDP.Click += new System.EventHandler(this.btnOpenUDP_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "消息内容：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbReceiveMessage);
            this.groupBox2.Location = new System.Drawing.Point(12, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 190);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "消息内容";
            // 
            // lbReceiveMessage
            // 
            this.lbReceiveMessage.FormattingEnabled = true;
            this.lbReceiveMessage.ItemHeight = 12;
            this.lbReceiveMessage.Location = new System.Drawing.Point(6, 17);
            this.lbReceiveMessage.Name = "lbReceiveMessage";
            this.lbReceiveMessage.Size = new System.Drawing.Size(510, 172);
            this.lbReceiveMessage.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtn_start,
            this.toolStripSeparator1,
            this.toolStatusLbl,
            this.tsStatus});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(540, 25);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtn_start
            // 
            this.tsbtn_start.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtn_start.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_start.Image")));
            this.tsbtn_start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_start.Name = "tsbtn_start";
            this.tsbtn_start.Size = new System.Drawing.Size(60, 22);
            this.tsbtn_start.Text = "开启服务";
            this.tsbtn_start.Click += new System.EventHandler(this.tsbtn_start_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStatusLbl
            // 
            this.toolStatusLbl.Name = "toolStatusLbl";
            this.toolStatusLbl.Size = new System.Drawing.Size(68, 22);
            this.toolStatusLbl.Text = "服务状态：";
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(0, 22);
            // 
            // UDPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 464);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UDPForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "UDPForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UDPForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_send;
        private System.Windows.Forms.RichTextBox txtSendMssg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOpenUDP;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbReceiveMessage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtn_start;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStatusLbl;
        private System.Windows.Forms.ToolStripLabel tsStatus;
    }
}