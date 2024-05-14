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
    public partial class hesabım : Form
    {
        public hesabım()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=Gozde_Huawei;Initial Catalog=kisiselbilgiveritabani;Integrated Security=True");
        public string ka;
       
       
        private void hesabım_Load(object sender, EventArgs e)
        {
            textka.Text = ka;
          

            label8.Text = textka.Text;
          
          
            


            baglanti.Open();
            SqlCommand hesabım=new SqlCommand("Select * from Table_1 where KullaniciAdı=@p1",baglanti);
            hesabım.Parameters.AddWithValue("@p1", textka.Text);
            SqlDataReader oku=hesabım.ExecuteReader();
            while(oku.Read())
            {             
                textad.Text = oku[1].ToString();
                textsoyad.Text = oku[2].ToString();
                dateTimePicker1.Text = oku[3].ToString();
                cbseh.Text = oku[4].ToString();
                txtsif.Text = oku[5].ToString();
                mssktel.Text = oku[6].ToString();
               
            }
            baglanti.Close();
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                txtsif.UseSystemPasswordChar = false;
            }
            else
            {
                txtsif.UseSystemPasswordChar= true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textka.Enabled = false;
            textad.Enabled = true;
            textsoyad.Enabled = true;
            cbseh.Enabled = true;
            dateTimePicker1.Enabled = true;
            mssktel.Enabled=true;
            txtsif.Enabled = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {


            //baglanti.Open();
            //SqlCommand kg = new SqlCommand("Select KullaniciAdı from Table_1 where KullaniciAdı='" + textka.Text + "'", baglanti);
            //SqlDataReader ka1 = kg.ExecuteReader();
            //if (ka1.Read())
            //{
            //    MessageBox.Show("Kullanıcı adınız başka bir kullanıcı ile aynı \n Lütfen kullanıcı adınızı değiştirin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    textka.Text = string.Empty;
            //    textka.Focus();
            //    ka1.Close();
            //    baglanti.Close();
            //    return;
            //}

            //baglanti.Close();



            baglanti.Open();
            SqlCommand sql = new SqlCommand("Update Table_1 set KullaniciAd=@a1,KullaniciSoyad=@a2,KullaniciDT=@a3,KullaniciSehir=@a4,KullaniciSifre=@a5,KullaniciTel=@a6,KullaniciAdı=@a8 where KullaniciAdı=@a7",baglanti);
            sql.Parameters.AddWithValue("@a1",textad.Text);
            sql.Parameters.AddWithValue("@a2",textsoyad.Text);
            sql.Parameters.AddWithValue("@a3",dateTimePicker1.Value);
            sql.Parameters.AddWithValue("@a4",cbseh.Text);
            sql.Parameters.AddWithValue("@a5",txtsif.Text);
            sql.Parameters.AddWithValue("@a6",mssktel.Text);
            sql.Parameters.AddWithValue("@a8",textka.Text);
            sql.Parameters.AddWithValue("@a7",textka.Text);
            sql.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bilgileriniz başarı ile güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {   Form1 form = new Form1();
            form.kullanici = textka.Text;
            form.yenikul=textka.Text;
            form.Show();
            this.Hide();

        }

        private void txtyenikullanici_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
