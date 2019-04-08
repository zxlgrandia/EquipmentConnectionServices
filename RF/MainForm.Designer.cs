namespace WindowsFormsApplication1
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CardItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ElectronicScaleItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SensorItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CardItem,
            this.ElectronicScaleItem,
            this.SensorItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(80, 21);
            this.toolStripMenuItem1.Text = "触摸屏服务";
            // 
            // CardItem
            // 
            this.CardItem.Name = "CardItem";
            this.CardItem.Size = new System.Drawing.Size(180, 22);
            this.CardItem.Text = "读卡器服务";
            this.CardItem.Click += new System.EventHandler(this.CardItem_Click);
            // 
            // ElectronicScaleItem
            // 
            this.ElectronicScaleItem.Name = "ElectronicScaleItem";
            this.ElectronicScaleItem.Size = new System.Drawing.Size(180, 22);
            this.ElectronicScaleItem.Text = "电子秤服务";
            this.ElectronicScaleItem.Click += new System.EventHandler(this.ElectronicScaleItem_Click);
            // 
            // SensorItem
            // 
            this.SensorItem.Name = "SensorItem";
            this.SensorItem.Size = new System.Drawing.Size(180, 22);
            this.SensorItem.Text = "温湿度传感器服务";
            this.SensorItem.Click += new System.EventHandler(this.SensorItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "服务中心";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CardItem;
        private System.Windows.Forms.ToolStripMenuItem ElectronicScaleItem;
        private System.Windows.Forms.ToolStripMenuItem SensorItem;
    }
}