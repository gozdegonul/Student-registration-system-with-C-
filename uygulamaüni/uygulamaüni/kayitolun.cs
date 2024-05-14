using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace uygulamaüni
{
    public partial class kayitolun : Form
    {
        public kayitolun()
        {
            InitializeComponent();
           
        }

        SqlConnection baglanti=new SqlConnection("Data Source=Gozde_Huawei;Initial Catalog=kisiselbilgiveritabani;Integrated Security=True");
        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = new DateTime(1970, 1, 1);
            dateTimePicker1.MaxDate = new DateTime(2010, 12, 31);
           


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {



        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {




        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] sembol1 = { "a", "b", "c", "4", "0", "g" };
            string[] sembol2 = { "3", "R", "T", "P", "D" };
            string[] sembol3 = { "9", "J", "y", "S", "h" };
            
            Random rd = new Random();
            int s1, s2, s3, s4;
            s1 = rd.Next(0, sembol1.Length);
            s2=rd.Next(0, sembol2.Length);
            s3 = rd.Next(5, 10);
            s4=rd.Next(0, sembol3.Length);

            r1.Text = sembol1[s1].ToString();
            r2.Text = sembol2[s2].ToString();
            r3.Text = s3.ToString();
            r4.Text = sembol3[s4].ToString();

        }



        private void button2_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand kg = new SqlCommand("Select KullaniciAdı from Table_1 where KullaniciAdı='" + textBox1.Text + "'", baglanti);
            SqlDataReader ka = kg.ExecuteReader();
            if (ka.Read())
            {
                MessageBox.Show("Kullanıcı adınız başka bir kullanıcı ile aynı \n Lütfen kullanıcı adınızı değiştirin.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                textBox1.Text = string.Empty;
                textBox1.Focus();
                ka.Close();
                baglanti.Close();
                return;
            }
            baglanti.Close();


            if (textsifre.Text != txtsifre2.Text)
            {
                MessageBox.Show("Girilen şifreler aynı değil.", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                string[] sembol1 = { "a", "b", "c", "4", "0", "g" };
                string[] sembol2 = { "3", "R", "T", "P", "D" };
                string[] sembol3 = { "9", "J", "y", "S", "h" };
                Random r = new Random();
                int s1, s2, s3, s4;
                s1 = r.Next(0, sembol1.Length);
                s2 = r.Next(0, sembol2.Length);
                s3 = r.Next(5, 10);
                s4 = r.Next(0, sembol3.Length);

                r1.Text = sembol1[s1].ToString();
                r2.Text = sembol2[s2].ToString();
                r3.Text = s3.ToString();
                r4.Text = sembol3[s4].ToString();
                txtsifre2.Text = string.Empty;
                txtsifre2.Focus();
                return;
            }
            if (txtgüvenlik.Text != r1.Text + r2.Text + r3.Text + r4.Text)
            {
                MessageBox.Show("Girilen güvenlik kodu doğru değil.", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                string[] sembol1 = { "a", "b", "c", "4", "0", "g" };
                string[] sembol2 = { "3", "R", "T", "P", "D" };
                string[] sembol3 = { "9", "J", "y", "S", "h" };
                Random r7 = new Random();
                int s1, s2, s3, s4;
                s1 = r7.Next(0, sembol1.Length);
                s2 = r7.Next(0, sembol2.Length);
                s3 = r7.Next(5, 10);
                s4 = r7.Next(0, sembol3.Length);

                r1.Text = sembol1[s1].ToString();
                r2.Text = sembol2[s2].ToString();
                r3.Text = s3.ToString();
                r4.Text = sembol3[s4].ToString();
                txtgüvenlik.Text = string.Empty;
                txtgüvenlik.Focus();
                return;
            }
            if (textsifre.Text == txtsifre2.Text && txtgüvenlik.Text == r1.Text + r2.Text + r3.Text + r4.Text)
            {
                MessageBox.Show("Kaydınız başarı ile oluşturulmuştur.\nLütfen tamam tuşuna basın ve anasayfadan giriş yapın.\nKullanıcı adınız:" + textBox1.Text + "  şifreniz:" + textsifre.Text, "bilgi", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                GİRİSYAPİN gr = new GİRİSYAPİN();

                geneltanımlarcs.gnl_sifre = textsifre.Text;
                gr.Show();
                this.Hide();

                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Table_1 (KullaniciAd,KullaniciSoyad,KullaniciDT,KullaniciSehir,KullaniciSifre,KullaniciAdı,KullaniciTel) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
                komut.Parameters.AddWithValue("@p1", txtad.Text);
                komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
                komut.Parameters.AddWithValue("@p3", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@p4", comboBox1.Text);
                komut.Parameters.AddWithValue("@p5", textsifre.Text);
                komut.Parameters.AddWithValue("@p6", textBox1.Text);
                komut.Parameters.AddWithValue("@p7",msktel.Text);

                komut.ExecuteNonQuery();
                baglanti.Close();
                

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
               textsifre.UseSystemPasswordChar = false;
            }
            else
            {
                textsifre.UseSystemPasswordChar = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                txtsifre2.UseSystemPasswordChar = false;
            }
            else
            {
                txtsifre2.UseSystemPasswordChar = true;
            }
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void kayitolun_Load(object sender, EventArgs e)
        {
            




        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void cbs_CheckedChanged(object sender, EventArgs e)
        {
            if (cbs.Checked)
            {
                textsifre.UseSystemPasswordChar = false;
            }
            else
            {
                textsifre.UseSystemPasswordChar = true;
            }

        }

        private void cbs2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbs2.Checked)
            {
                txtsifre2.UseSystemPasswordChar = false;
            }
            else
            {
                txtsifre2.UseSystemPasswordChar = true;
            }
        }

    }
}
