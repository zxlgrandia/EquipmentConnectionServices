namespace WindowsFormsApplication1
{
    partial class FormWeb
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
            this.bt_star = new System.Windows.Forms.Button();
            this.bt_close = new System.Windows.Forms.Button();
            this.list_m = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ads = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_op = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bt_star
            // 
            this.bt_star.Location = new System.Drawing.Point(55, 79);
            this.bt_star.Name = "bt_star";
            this.bt_star.Size = new System.Drawing.Size(75, 23);
            this.bt_star.TabIndex = 0;
            this.bt_star.Text = "启动服务";
            this.bt_star.UseVisualStyleBackColor = true;
            this.bt_star.Click += new System.EventHandler(this.bt_star_Click);
            // 
            // bt_close
            // 
            this.bt_close.Location = new System.Drawing.Point(190, 79);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(75, 23);
            this.bt_close.TabIndex = 1;
            this.bt_close.Text = "关闭";
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // list_m
            // 
            this.list_m.FormattingEnabled = true;
            this.list_m.ItemHeight = 12;
            this.list_m.Location = new System.Drawing.Point(22, 133);
            this.list_m.Name = "list_m";
            this.list_m.Size = new System.Drawing.Size(631, 268);
            this.list_m.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "地址：";
            // 
            // textBox_ads
            // 
            this.textBox_ads.Location = new System.Drawing.Point(100, 28);
            this.textBox_ads.Name = "textBox_ads";
            this.textBox_ads.Size = new System.Drawing.Size(192, 21);
            this.textBox_ads.TabIndex = 6;
            this.textBox_ads.Text = "ws://192.168.1.115:8086";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "方法：";
            // 
            // textBox_op
            // 
            this.textBox_op.Location = new System.Drawing.Point(388, 27);
            this.textBox_op.Name = "textBox_op";
            this.textBox_op.Size = new System.Drawing.Size(167, 21);
            this.textBox_op.TabIndex = 8;
            this.textBox_op.Text = "/Laputa";
            // 
            // FormWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox_op);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_ads);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.list_m);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.bt_star);
            this.Name = "FormWeb";
            this.Text = "刷卡器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_star;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.ListBox list_m;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ads;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_op;
    }
}