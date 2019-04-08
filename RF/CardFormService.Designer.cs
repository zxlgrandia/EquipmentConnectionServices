namespace WindowsFormsApplication1
{
    partial class CardFormService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardFormService));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_star = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_stop = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_status = new System.Windows.Forms.ToolStripLabel();
            this.list_m = new System.Windows.Forms.ListBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_star,
            this.toolStripButton_stop,
            this.toolStripLabel_status});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(732, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_star
            // 
            this.toolStripButton_star.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_star.Image")));
            this.toolStripButton_star.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_star.Name = "toolStripButton_star";
            this.toolStripButton_star.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton_star.Text = "启动服务";
            this.toolStripButton_star.Click += new System.EventHandler(this.toolStripButton_star_Click);
            // 
            // toolStripButton_stop
            // 
            this.toolStripButton_stop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_stop.Image")));
            this.toolStripButton_stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_stop.Name = "toolStripButton_stop";
            this.toolStripButton_stop.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton_stop.Text = "停止服务";
            this.toolStripButton_stop.Click += new System.EventHandler(this.toolStripButton_stop_Click);
            // 
            // toolStripLabel_status
            // 
            this.toolStripLabel_status.Name = "toolStripLabel_status";
            this.toolStripLabel_status.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel_status.Text = "服务状态：";
            // 
            // list_m
            // 
            this.list_m.FormattingEnabled = true;
            this.list_m.ItemHeight = 12;
            this.list_m.Location = new System.Drawing.Point(12, 28);
            this.list_m.Name = "list_m";
            this.list_m.Size = new System.Drawing.Size(708, 328);
            this.list_m.TabIndex = 5;
            // 
            // CardFormService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 361);
            this.Controls.Add(this.list_m);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CardFormService";
            this.Text = "刷卡服务";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_star;
        private System.Windows.Forms.ToolStripButton toolStripButton_stop;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_status;
        private System.Windows.Forms.ListBox list_m;
    }
}