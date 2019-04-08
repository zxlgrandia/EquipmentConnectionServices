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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CardItem_Click(object sender, EventArgs e)
        {
            FormWeb web = GenericSingleton<FormWeb>.CreateInstrance();
            web.Show();
        }

        private void ElectronicScaleItem_Click(object sender, EventArgs e)
        {
            ElectronicScaleForm elec = GenericSingleton<ElectronicScaleForm>.CreateInstrance();
            elec.Show();
        }

        private void SensorItem_Click(object sender, EventArgs e)
        {
            UDPForm sensor = GenericSingleton<UDPForm>.CreateInstrance();
            sensor.Show();
        }
    }
}
