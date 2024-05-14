using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace uygulamaüni
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
           
            
        }
        SqlConnection baglanti = new SqlConnection("Data Source=Gozde_Huawei;Initial Catalog=kisiselbilgiveritabani;Integrated Security=True");
      
        public string kullanici;
        public string yenikul;

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Text = kullanici;
            label6.Text = yenikul;


            
            baglanti.Open();
            SqlCommand ad1=new SqlCommand("Select * from Table_1 where KullaniciAdı=@p1",baglanti);
            ad1.Parameters.AddWithValue("@p1", label5.Text);
            SqlDataReader reader = ad1.ExecuteReader();
            while (reader.Read())
            {
                label2.Text = reader[1].ToString();
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void kurucumuzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kurucumuz kr = new kurucumuz();
            kr.ShowDialog();
            
        }
       

        private void misyonVeVizyonumuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            misyon ms=new misyon();
            ms.ShowDialog();
           
        }

     
        private void acıbademÜniversitesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.acibadem.edu.tr/akademik/lisans/tip-fakultesi");
            panel1.Hide();
            pictureBox1.Hide();
            label3.Hide();
            label2.Hide();
            label1.Hide();
        }

        private void bezmiAlemÜniversitesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://bezmialem.edu.tr/tip-fakultesi/tr/Sayfalar/anasayfa.aspx");
            panel1.Hide();
            pictureBox1.Hide();
            label3.Hide();
            label2.Hide();
            label1.Hide();
        }

       
        

        private void yıldızTeknikÜniversitesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://mim.yildiz.edu.tr/");
            panel1.Hide();
            pictureBox1.Hide();
            label3.Hide();
            label2.Hide();
            label1.Hide();
        }

       

      
        

        private void iTÜToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.itu.edu.tr/tum-bolumler");
        }

        private void boğaziçiÜniversitesiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://hf.boun.edu.tr/");
            panel1.Hide();
            pictureBox1.Hide();
            label3.Hide();
            label2.Hide();
            label1.Hide();
        }

        private void bahçeşehirÜniversitesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://bau.edu.tr/akademik/12548-hukuk-fakultesi");
            panel1.Hide();
            pictureBox1.Hide();
            label3.Hide();
            label2.Hide();
            label1.Hide();
        }

        

        

        private void yeditepeÜniversitesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://law.yeditepe.edu.tr/");
            panel1.Hide();
            pictureBox1.Hide();
            label3.Hide();
            label2.Hide();
            label1.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void istanbulTıpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://istanbultip.istanbul.edu.tr/tr/_");
        }

        private void marmaraTıpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://tip.marmara.edu.tr/");
        }

        private void istanbulCerrahpaşaTıpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://cerrahpasa.iuc.edu.tr/tr/_");
        }

        private void biruniTıpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://tip.biruni.edu.tr/");
        }

        private void üsküdarTıpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://uskudar.edu.tr/tip-fakultesi/");
        }

        private void ankaraÜniversitesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.law.ankara.edu.tr/");
        }

        private void marmaraÜniversitesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://hukuk.marmara.edu.tr/");
        }

        private void galatasarayÜniversitesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://hukuk.gsu.edu.tr/");
        }

        private void bilkentÜniversitesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.hukuk.bilkent.edu.tr/");
        }

        private void beykentÜniversitesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://hukuk.beykent.edu.tr/");
        }

        private void oDTÜToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://arch.metu.edu.tr/tr/");
        }

        private void bilgiÜniversitesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.bilgi.edu.tr/tr/akademik/mimarlik-fakultesi/");
        }

        private void bilgiÜniversitesiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.bilgi.edu.tr/tr/akademik/hukuk-fakultesi/");
        }

        private void mimarSinanÜniversitesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://msgsu.edu.tr/akademik/mimarlik-fakultesi/");
        }

        private void bahçeşehirÜniversitesiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://bau.edu.tr/akademik/12551-mimarlik-ve-tasarim-fakultesi"); 
        }

        private void yeditepeÜniversitesiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://darch.itu.edu.tr/");
        }

        private void marmaraÜniversitesiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://eng.marmara.edu.tr/");
        }

        private void bahçeşehirÜniversitesiToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://bau.edu.tr/akademik/12552-muhendislik-ve-doga-bilimleri-fakultesi");
        }

        private void özyeğinÜniversitesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.ozyegin.edu.tr/tr/muhendislik-fakultesi");
        }

        private void oDTÜToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://muhfd.metu.edu.tr/tr");
        }

        private void tOBBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.etu.edu.tr/tr/akademik");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void üniversiteSıralamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tercih_Listesi tl=new Tercih_Listesi();
            tl.kullanici2 = label5.Text;
            tl.Show();
            this.Hide();    
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kişiselBilgilerimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hesabım h =new hesabım();
            h.ka = label5.Text;
            
            h.Show();
            this.Hide();
           
            
             
            
           
            
           
        }





        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void şifreToolStripMenuItem_Click(object sender, EventArgs e)
        {
  

            
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Herhangi bir sorununuz varsa lütfen gozdegonul2004@gmail.com mailine sorununuzu bildirin", "Yardım", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void çıkışToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
