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
    public partial class sifreyiunuttum : Form
    {
        public sifreyiunuttum()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=Gozde_Huawei;Initial Catalog=kisiselbilgiveritabani;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            string[] sembol1 = { "a", "b", "c", "4", "0", "g" };
            string[] sembol2 = { "3", "R", "T", "P", "D" };


            Random rd = new Random();
            int s1, s2, s3;
            s1 = rd.Next(0, sembol1.Length);
            s2 = rd.Next(0, sembol2.Length);
            s3 = rd.Next(5, 10);


            label3.Text = sembol1[s1].ToString();
            label4.Text = sembol2[s2].ToString();
            label5.Text = s3.ToString();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtsifre.UseSystemPasswordChar =false;
            }
            else
            {
                txtsifre.UseSystemPasswordChar=true;
            }
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                txtsifre2.UseSystemPasswordChar = false;
            }
            else
            {
                txtsifre2.UseSystemPasswordChar=true;
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void lblyenisifre2_Click(object sender, EventArgs e)
        {

        }

        private void lblyenisifre_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand g1 = new SqlCommand("Select KullaniciAdı from Table_1 where KullaniciAdı='" + textBox1.Text + "'", baglanti);
            SqlDataReader ka = g1.ExecuteReader();
            if (ka.Read())
            {
                MessageBox.Show("Kullanıcı adınız yanlış.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = string.Empty;
                textBox1.Focus();
                ka.Close();
                baglanti.Close();
                return;
            }

            baglanti.Close();

            if (txtsifre.Text != txtsifre2.Text)
            {
                MessageBox.Show("Şifreler aynı değil", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsifre2.Text = string.Empty;
                txtsifre2.Focus();
                return;

            }
            if (textBox1.Text != label3.Text + label4.Text + label5.Text)
            {
                MessageBox.Show("Güvenlik kodu yanlış", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = string.Empty;
                textBox1.Focus();
                string[] sembol1 = { "a", "b", "c", "4", "0", "g" };
                string[] sembol2 = { "3", "R", "T", "P", "D" };


                Random rd = new Random();
                int s1, s2, s3;
                s1 = rd.Next(0, sembol1.Length);
                s2 = rd.Next(0, sembol2.Length);
                s3 = rd.Next(5, 10);


                label3.Text = sembol1[s1].ToString();
                label4.Text = sembol2[s2].ToString();
                label5.Text = s3.ToString();
                return;
            }

            baglanti.Open();
            //SqlCommand cd1 = new SqlCommand("Select * from Table_1 where KullaniciSifre='" + maskedTextBox1.Text + "' and KullaniciAdı='" + textBox2.Text + "'", baglanti);
            SqlCommand cd1 = new SqlCommand("Select * from Table_1 where KullaniciAdı='" + textBox2.Text + "'", baglanti);

            //cd1.Parameters.AddWithValue("@a1", maskedTextBox1.Text);
            //cd1.Parameters.AddWithValue("@a2", textBox2.Text);
            SqlDataReader yenisifre = cd1.ExecuteReader();


            if (yenisifre.Read())
            {
                string sifre = "";
                sifre = yenisifre["KullaniciSifre"].ToString();
                if (sifre == txtsifre.Text)
                    {
                    MessageBox.Show("Yeni şifreniz eski şifreniz ile aynı olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsifre.Text = string.Empty;
                    txtsifre2.Text = string.Empty;
                    txtsifre.Focus();
                    return;
                }
                   

            }
            else
            {
                MessageBox.Show("Lütfen mevcut bir kullanıcı kodu yazınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Text = string.Empty;
                textBox2.Focus();
                yenisifre.Close();
                baglanti.Close();
                return;

            }
            baglanti.Close();

            baglanti.Open();

            SqlCommand ys = new SqlCommand("Update Table_1 set KullaniciSifre=@k1 where KullaniciAdı=@k2", baglanti);
            ys.Parameters.AddWithValue("@k1", txtsifre.Text);
            ys.Parameters.AddWithValue("@k2", textBox2.Text);
            ys.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Şifreniz başarı ile değiştirilmiştir.\n Lütfen tekrar giriş yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GİRİSYAPİN g = new GİRİSYAPİN();
            g.Show();
            this.Hide();




           

         

             


            
           
         
            
        }

        private void sifreyiunuttum_Load(object sender, EventArgs e)
        {

        }

        //    baglanti.Open();
        //        SqlCommand cd1 = new SqlCommand("Select * from Table_1 where KullaniciSifre=@a1 and KullaniciAdı=@a2", baglanti);
        //    cd1.Parameters.AddWithValue("@a1", maskedTextBox1.Text);
        //        cd1.Parameters.AddWithValue("@a2", textBox2.Text);
        //        SqlDataReader yenisifre = cd1.ExecuteReader();

        //        if (yenisifre.Read())
        //        {

        //            MessageBox.Show("Yeni şifreniz eski şifreniz ile aynı olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            maskedTextBox1.Text = string.Empty;
        //            maskedTextBox2.Text = string.Empty;
        //            maskedTextBox1.Focus();


        //        }
        //baglanti.Close();




        //        baglanti.Open();
        //        SqlCommand ys = new SqlCommand("Update Table_1 set KullaniciSifre=@k1 where KullaniciAdı=@k2", baglanti);
        //ys.Parameters.AddWithValue("@k1", maskedTextBox1.Text);
        //        ys.Parameters.AddWithValue("@k2", textBox2.Text);
        //        ys.ExecuteNonQuery();
        //        baglanti.Close();


        //        MessageBox.Show("Şifreniz başarı ile değiştirilmiştir.\n Lütfen tekrar giriş yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        GİRİSYAPİN g = new GİRİSYAPİN();
        //g.Show();
        //        this.Hide();






    }
    } 



           

        
   

