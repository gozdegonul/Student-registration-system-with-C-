using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uygulamaüni
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kayitolun ko=new kayitolun();
            ko.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

     

        private void button2_Click_1(object sender, EventArgs e)
        {
            GİRİSYAPİN G1 = new GİRİSYAPİN();
            G1.Show();
            this.Hide();
        }
    }
}
