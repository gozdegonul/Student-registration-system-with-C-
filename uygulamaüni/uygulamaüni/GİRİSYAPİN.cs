using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace uygulamaüni
{
    public partial class GİRİSYAPİN : Form
    {

        public GİRİSYAPİN()
        {
            InitializeComponent();
         
        }
        SqlConnection baglanti = new SqlConnection("Data Source=Gozde_Huawei;Initial Catalog=kisiselbilgiveritabani;Integrated Security=True");
        

        private void button1_Click(object sender, EventArgs e)
        {


       

            baglanti.Open();
            SqlCommand giris = new SqlCommand("select KullaniciAdı from Table_1 where KullaniciAdı=@girisad and KullaniciSifre=@girissifre", baglanti);
            giris.Parameters.AddWithValue("@girisad", txtkullanici.Text);
            giris.Parameters.AddWithValue("@girissifre", txtsifre.Text);
            SqlDataReader reader = giris.ExecuteReader();
            if (reader.Read())
            {
                Form1 form = new Form1();
              
               form.kullanici = txtkullanici.Text;
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Bilgileri Yanlış.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            baglanti.Close();
          
          

        }

        private void GİRİSYAPİN_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtsifre.UseSystemPasswordChar = false;
            }
            else
            {
                txtsifre.UseSystemPasswordChar = true;

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifreyiunuttum sd = new sifreyiunuttum();
            sd.Show();
            this.Hide();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
          

        }

        private void txtsifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
         
             
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kayitolun ko=new kayitolun();
            ko.Show();
            this.Hide();
        }
    }
}


