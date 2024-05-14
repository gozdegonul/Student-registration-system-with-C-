using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace uygulamaüni
{
    public partial class Tercih_Listesi : Form
    {
        public Tercih_Listesi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=Gozde_Huawei;Initial Catalog=kisiselbilgiveritabani;Integrated Security=True");
        public string adsoyad;
        public string kullanici2;
       
        private void Tercih_Listesi_Load(object sender, EventArgs e)
        {
            label5.Text = kullanici2;
            lbladsoyad.Text = adsoyad;

            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select KullaniciAd,KullaniciSoyad from Table_1 where KullaniciAdı='" + label5.Text + "'", baglanti);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lbladsoyad.Text = reader[0].ToString().ToUpper() + " " + reader[1].ToString().ToUpper();
                lblkullanici.Text = kullanici2;
            }
            baglanti.Close();

            cbalan.Items.Clear();
            baglanti.Open();
            SqlCommand alan = new SqlCommand("Select Alan,count(*) from Tercih group by Alan", baglanti);
            SqlDataReader al = alan.ExecuteReader();
            while (al.Read())
            {
                cbalan.Items.Add(al[0]);
            }

            baglanti.Close();

            



        }



        private void cbalan_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbölüm.Items.Clear();
            baglanti.Open();
            SqlCommand bölüm = new SqlCommand("Select Bölüm from Tercih where Alan=@p1", baglanti);
            bölüm.Parameters.AddWithValue("@p1", cbalan.Text);
            SqlDataReader b = bölüm.ExecuteReader();
            while (b.Read())
            {
                cbbölüm.Items.Add(b[0]);
            }
            baglanti.Close();
        }
        private void cbbölüm_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void btntercih_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void btnanasayfa_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.kullanici = lblkullanici.Text;
            fr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tercih_Say where Bölüm='" + cbbölüm.Text + "'", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

        }

        //private void btndoyayolu_Click(object sender, EventArgs e)
        //{
        //    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        dosyayolu = folderBrowserDialog1.SelectedPath.ToString();
        //        textdoyayolu.Text = dosyayolu;
        //    }
        //}

        //private void btndosyadi_Click(object sender, EventArgs e)
        //{
        //    dosyaadi = txtdosyaadi.Text;
        //    sw = File.CreateText(dosyayolu + "\\" + dosyaadi + ".txt");
        //    sw.Close();

        //    //if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    //{
        //    //    StreamReader sr = new StreamReader(openFileDialog1.FileName);
        //    //    string satir = sr.ReadLine();
        //    //    while (satir != null)
        //    //    {
        //    //        dataGridView1.DataSource = satir;
        //    //        satir = sr.ReadLine();
        //    //    }
        //    //}
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        StreamReader sr = new StreamReader(openFileDialog1.FileName);
        //        string satir = sr.ReadLine();
        //        while (satir != null)
        //        {
        //            dataGridView1.DataSource = satir;
        //            satir = sr.ReadLine();
        //        }
        //    }




           

        //}

        //private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        //{ 
        //    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        //    {

        //        saveFileDialog1.ShowDialog();
        //        StreamReader sr = new StreamReader(openFileDialog1.FileName);
        //        sw.WriteLine(dataGridView1.DataSource.ToString());
        //        sw.Close();



        //    }

        //}

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            label6.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString() +" " +dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            
            //Tıp
           
            string mdtıp = "Medipol Üniversitesi(İng) Tıp";
            string kctıp = "Koç Üniversitesi Tıp";
            string acbtıp = "Acıbadem Üniversitesi Tıp";
            string Tobbtıp = "TOBB Üniversitesi Tıp";
            string cerrtıp = "İstanbul Cerrahpaşa Üniversitesi Tıp";
            string hcttıp = "Hacettepe Üniversitesi(İng) Tıp";
            string mdptt = "Medipol Üniversitesi(Tür) Tıp";
            string hcttt = "Hacettepe Üniversiesi(Tür) Tıp";
            string ydptıp = "Yeditepe Üniversitesi Tıp";


            if (label6.Text.Contains(mdtıp))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=203110477");
            }

            if (label6.Text.Contains(kctıp))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=203910699");
            }

            if (label6.Text.Contains(acbtıp))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=200110071");
            }


            if (label6.Text.Contains(Tobbtıp))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=205411015");
            }

            if (label6.Text.Contains(cerrtıp))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=111610025");
            }

            if (label6.Text.Contains(hcttıp))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=104810626");
            }


            if (label6.Text.Contains(mdptt))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=203110035");
            }

            if (label6.Text.Contains(hcttt))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=104810617");
            }


            if (label6.Text.Contains(ydptıp))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=206110759");
            }





            //Diş
            string ydtdiş = "Yeditepe Üniversitesi Diş";
            string iüdiş = "İstanbul Üniversitesi Diş";
            string hctdiş = "Hacettepe Üniversitesi Diş";
            string bzmdis = "Bezmi-Alem Üniversitesi Diş";
            string egediş = "Ege Üniversitesi Diş";

            if (label6.Text.Contains(ydtdiş))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=206110026");
            }

            if (label6.Text.Contains(iüdiş))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=105690484");
            }

            if (label6.Text.Contains(hctdiş))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=104810017");
            }

            if (label6.Text.Contains(bzmdis))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=200910054");
            }

            if (label6.Text.Contains(egediş))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=103410015");
            }

            //Bilgisayar Mühendisliği
            string kcbm = "Koç Üniversitesi Bilgisayar Mühendisliği ";
            string bounbm = "Boğaziçi Üniversitesi Bilgisayar Mühendisliği";
            string bilbm = "Bilkent Üniversitesi Bilgisayar Mühendisliği";
            string Odtübm = "ODTÜ Bilgisayar Mühendisliği";
            string İtübm = "İTÜ Bilgisayar Mühendisliği";
            string özbm = "Özyeğin Üniversitesi Bilgisayar Mühendisliği";
            string Tobbbm = "TOBB Üniversitesi Bilgisayar Mühendisliği";
            string bilkbm = "Bilkent Üniversitesi(%50) Bilgisayar Mühendisliği";
            string ydpbm= "Yeditepe Üniversitesi Bilgisayar Mühendisliği";

            if (label6.Text.Contains(kcbm))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=203910363");
            }

            if (label6.Text.Contains(bounbm))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=102210277");
            }

            if (label6.Text.Contains(bilbm))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=202110408");
            }

            if (label6.Text.Contains(Odtübm))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=108410336");
            }

            if (label6.Text.Contains(İtübm))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=105510608");
            }

            if (label6.Text.Contains(özbm))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=204810176");
            }


            if (label6.Text.Contains(Tobbbm))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=205410114");
            }

            if (label6.Text.Contains(bilkbm))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=202110735");
            }

            if (label6.Text.Contains(ydpbm))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=206110592");
            }

            //Endüstri Mühendisliği
            string kçem = "Koç Üniversitesi Endüstri Mühendisliği";
            string bounem = "Boğaziçi Üniversitesi Endüstri Mühendisliği";
            string bilem = "Bilkent Üniversitesi Endüstri Mühendisliği";
            string odem = "ODTÜ Endüstri Mühendisliği";

            if (label6.Text.Contains(kçem))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=203910424");
            }

            if (label6.Text.Contains(bounem))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=102210295");
            }

            if (label6.Text.Contains(bilem))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=202110444");
            }

            if (label6.Text.Contains(odem))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=108410363");
            }

            //Dilbilimi ve İngiliz Dili ve Edebiyatı
            string boundb = "Boğaziçi Üniversitesi Dilbilimi";
            string hctdb = "Hacettepe Üniversitesi Dilbilimi";
            string iüdb = "İstanbul Üniversitesi Dilbilimi";
            string bilie = "Bilkent Üniversitesi İngiliz Dili ve Edebiyatı";
            string bounie = "Boğaziçi Üniversitesi İngiliz Dili ve Edebiyatı";
            string tobbie = "TOBB Üniversitesi İngiliz Dili ve Edebiyatı";


            if (label6.Text.Contains(boundb))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=102270026");
            }


            if (label6.Text.Contains(hctdb))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=104810098");
            }


            if (label6.Text.Contains(iüdb))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=105611111");
            }

            if (label6.Text.Contains(bilie))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=202110938");
            }

            if (label6.Text.Contains(bounie))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=102210135");
            }


            if (label6.Text.Contains(tobbie))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=205410486");
            }

            //Psikoloji
            string kcps = "Koç Üniversitesi Psikoloji";
            string bilps = "Bilkent Üniversitesi Psikoloji";
            string bounps = "Boğaziçi Üniversitesi Psikoloji";
            string ozps = "Özyeğin Üniversitesi Psikoloji";
            string odps = "ODTÜ Psikoloji";
            string tobbps = "TOBB Üniversitesi Psikoloji";

            if (label6.Text.Contains(kcps))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=203910133");
            }

            if (label6.Text.Contains(bilps))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=202110241");
            }

            if (label6.Text.Contains(bounps))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=102210171");
            }

            if (label6.Text.Contains(ozps))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=204810273");
            }

            if (label6.Text.Contains(odps))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=108410178");
            }
            if (label6.Text.Contains(tobbps))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=205410989");
            }

            //Hukuk
            string kchukuk = "Koç Üniversitesi Hukuk";
            string gshukuk = "Galatasaray Üniversitesi(Fr) Hukuk";
            string bilhukuk = "Bilkent Üniversitesi Hukuk";
            string tobbhukuk = "TOBB Üniversitesi Hukuk";
            string iüham = "İstanbul Üniversitesi(Hamburg) Hukuk";
            string ydthukuk = "Yeditepe Üniversitesi Hukuk";
            string ozhukuk = "Özyeğin Üniversitesi Hukuk";
            string bilhk = "Bilkent Üniversitesi(% 50) Hukuk";
            string bounhukuk = "Boğaziçi Üniversitesi Hukuk";
            string aköln = "Altınbaş Üniversitesi(Köln) Hukuk";
            string bah = "Bahçeşehir Üniversitesi Hukuk";
            string anhuk = "Ankara Üniversitesi Hukuk";
            string iühuk = "İstanbul Üniversitesi Hukuk";
            string bilhuk = "Bilgi Üniversitesi Hukuk";
            string hcthuk = "Hacettepe Üniversitesi Hukuk";
            string İü2 = "İstanbul Üniversitesi(2.Öğ) Hukuk";
            string ibnh = "İbn Haldun Üniversitesi Hukuk";
            string marh = "Marmara Üniversitesi Hukuk";

            if (label6.Text.Contains(kchukuk))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=203910796");
            }

            if (label6.Text.Contains(gshukuk))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=104010052");
            }

            if (label6.Text.Contains(bilhukuk))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=202111106");
            }

            if (label6.Text.Contains(tobbhukuk))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=205410283");
            }

            if (label6.Text.Contains(iüham))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=105690587");
            }

            if (label6.Text.Contains(ydthukuk))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=206111969");
            }

            if (label6.Text.Contains(ozhukuk))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=204810228");
            }

            if (label6.Text.Contains(bilhk))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=202111115");
            }

            if (label6.Text.Contains(bounhukuk))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=102270035");
            }

            if (label6.Text.Contains(aköln))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=202910736");
            }

            if (label6.Text.Contains(bah))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=200511568");
            }

            if (label6.Text.Contains(anhuk))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=101110518");
            }

            if (label6.Text.Contains(iühuk))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=105610501");
            }

            if (label6.Text.Contains(bilhuk))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=202510167");
            }

            if (label6.Text.Contains(hcthuk))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=104810759");
            }

            if (label6.Text.Contains(İü2))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=105630092");
            }

            if (label6.Text.Contains(ibnh))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=208610015");
            }

            if (label6.Text.Contains(marh))
            {
                webBrowser1.Navigate("https://yokatlas.yok.gov.tr/lisans.php?y=107210332");
            }









        }


    }
      
    }

