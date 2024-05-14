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
    public partial class kurucumuz : Form
    {
        public kurucumuz()
        {
            InitializeComponent();
        }
        private void kurucumuzToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            MessageBox.Show("Zaten bu sayfadasınız. You have already this page.", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void misyonVeVizyonumuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            misyon ms = new misyon();
            ms.Show();
            this.Hide();
        }


       
    }
}
