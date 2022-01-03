using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sinema_Otomasyon
{
    public partial class Koltuk : Form
    {
        public Koltuk()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=WIN-IM38HI1GTD6\\SQLEXPRESS;Initial Catalog=sinema;Integrated Security=True");
        const int ogrenciFiyat = 20;
        const int tamFiyat = 35;
        int toplamFiyat = 0;
        private void Koltuk_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 9; i++)
            {
                Button btn = new Button();
                btn.Name = i.ToString();
                btn.Text ="A-"+ i.ToString();
                btn.Width = 80;
                btn.Height = 50;
                btn.Click += Btn_Click;
                flowLayoutPanel1.Controls.Add(btn);
             
            }

            flp2();
            flp3();
            flp4();
            flp5();
            flp6();


        }
        public void flp2()
        {
            for (int i = 1; i < 9; i++)
            {
                Button btn = new Button();
                btn.Name = i.ToString();
                btn.Text = "B-" + i.ToString();
                btn.Width = 80;
                btn.Height = 50;
                btn.Click += Btn_Click;
                flowLayoutPanel2.Controls.Add(btn);

            }
        }

        public void flp3()
        {
            for (int i = 1; i < 9; i++)
            {
                Button btn = new Button();
                btn.Name = i.ToString();
                btn.Text = "C-" + i.ToString();
                btn.Width = 80;
                btn.Height = 50;
                btn.Click += Btn_Click;
                flowLayoutPanel3.Controls.Add(btn);

            }
        }
        public void flp4()
        {
            for (int i = 1; i < 9; i++)
            {
                Button btn = new Button();
                btn.Name = i.ToString();
                btn.Text = "D-" + i.ToString();
                btn.Width = 80;
                btn.Height = 50;
                btn.Click += Btn_Click;
                flowLayoutPanel4.Controls.Add(btn);

            }
        }
        public void flp5()
        {
            for (int i = 1; i < 9; i++)
            {
                Button btn = new Button();
                btn.Name = i.ToString();
                btn.Text = "E-" + i.ToString();
                btn.Width = 80;
                btn.Height = 50;
                btn.Click += Btn_Click;
                flowLayoutPanel5.Controls.Add(btn);

            }
        }
        public void flp6()
        {
            for (int i = 1; i < 9; i++)
            {
                Button btn = new Button();
                btn.Name = i.ToString();
                btn.Text = "F-" + i.ToString();
                btn.Width = 80;
                btn.Height = 50;
                btn.Click += Btn_Click;
                flowLayoutPanel6.Controls.Add(btn);

            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;


            #region Renk

            if (radioButton1.Checked)
            {
                toplamFiyat += ogrenciFiyat;
                buton_renk_degistir(Color.Red,btn);
                textBox1.Text += " " + btn.Text;
            }
            else if (radioButton2.Checked)
            {
                toplamFiyat += tamFiyat;
                buton_renk_degistir(Color.Red, btn);
                textBox1.Text += " " + btn.Text;
            }
            else
            {
                MessageBox.Show("Lütfen Bilet Türü Seçin!","Uyarı");
            }

            #endregion
            label5.Text = toplamFiyat.ToString();
        
        }

        private void buton_renk_degistir(Color color,Button button)
        {;
            button.BackColor = color;
            button.Enabled = !button.Enabled;
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        Button btn = new Button();
        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("insert into koltuk(ucret,koltuk_ad) values ('" + label5.Text + "','" + textBox1.Text + "')", baglanti);
            ekle.ExecuteNonQuery();
            ekle.Dispose();
            MessageBox.Show(textBox1.Text + " Koltuklarını seçtiniz onaylıyor musunuz ?","Kayıt");

            MessageBox.Show("Satın alın " +  label5.Text + "TL");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bilet_Kes bilett = new Bilet_Kes();
            bilett.Show();
            this.Hide();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
