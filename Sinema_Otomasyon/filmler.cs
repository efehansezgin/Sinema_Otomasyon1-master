using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace Sinema_Otomasyon
{
    public partial class filmler : Form
    {
        public filmler()
        {
            InitializeComponent();
        }
        string dosyayolu;
        string dosyaAdi;
       
        SqlConnection baglanti = new SqlConnection("Data Source=WIN-IM38HI1GTD6\\SQLEXPRESS;Initial Catalog=sinema;Integrated Security=True");

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void filmler_Load(object sender, EventArgs e)
        {
            
           try
            { 

                baglanti.Open();
                SqlCommand listele = new SqlCommand("select * from salon", baglanti);
               SqlDataReader dr = listele.ExecuteReader();
               while (dr.Read())
               {
                    comboBox1.Items.Add(dr["salon_id"].ToString());
                  comboBox3.Items.Add(dr["salon_adi"].ToString());
               }
               baglanti.Close();

                baglanti.Open();
                SqlCommand listeleseans = new SqlCommand("select * from seans", baglanti);
                SqlDataReader drs = listeleseans.ExecuteReader();
                while (drs.Read())
                {
                    comboBox2.Items.Add(drs["seans_id"].ToString());
                    comboBox4.Items.Add(drs["seans_adi"].ToString());
               }
                baglanti.Close();
            }
            catch (Exception hata)
            {

              MessageBox.Show(hata.Message);
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = comboBox3.SelectedIndex; 
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //OpenFileDialog dosya = new OpenFileDialog();
            //dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            //dosya.Title = "";
            //dosya.ShowDialog();
            //string DosyaYolu = dosya.FileName;
            //pictureBox1.ImageLocation = DosyaYolu;


            if (DosyaAc.ShowDialog() == DialogResult.OK)
            {
                foreach (string i in DosyaAc.FileName.Split('\\'))
                {
                    if (i.Contains(".jpg")) { dosyaAdi = i; }
                    else if (i.Contains(".png")) { dosyaAdi = i; }
                    else { dosyayolu += i + "\\"; }
                }
                pictureBox1.ImageLocation = DosyaAc.FileName;
            }
            else
            {
                MessageBox.Show("Dosya Girmediniz!");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int deneme;
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand ekle = new SqlCommand("insert into filmler(film_adi,film_turu,yonetmen,afis,yapimtar,salon_id,seans_id) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + pictureBox1.ImageLocation.ToString() + "','" + dateTimePicker1.Text + "','" + deneme2 + "','" + deneme + "')", baglanti);
                ekle.ExecuteNonQuery();
                ekle.Dispose();
                MessageBox.Show("Ekleme İşleminiz Başarıyla Gerçekleşmiştir.", "Kayıt");
                if (dosyaAdi != "") File.WriteAllBytes(dosyaAdi, File.ReadAllBytes(DosyaAc.FileName));
                MessageBox.Show("Kayıt İşlemi Tamamlandı ! ", "İşlem Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                baglanti.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                pictureBox1.ImageLocation = "AFİSEKLE.png";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
           
                
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form1 frmm = new Form1();
            frmm.Show();
            this.Hide();
        }

        private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand();

            komut.CommandText = "select * from seans where seans_adi='" + comboBox4.Text + "'";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr2;

            dr2 = komut.ExecuteReader();
            while (dr2.Read())
            {
                deneme = Convert.ToInt32(dr2["seans_id"]);
            }
            baglanti.Close();
            dr2.Close();
        }
        int deneme2;
        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand();

            komut.CommandText = "select * from salon where salon_adi='" + comboBox3.Text + "'";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr2;

            dr2 = komut.ExecuteReader();
            while (dr2.Read())
            {
                deneme2 = Convert.ToInt32(dr2["salon_id"]);
            }
            dr2.Close();
            baglanti.Close();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
