using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sinema_Otomasyon
{
    public partial class seanslar : Form
    {
        public seanslar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=WIN-IM38HI1GTD6\\SQLEXPRESS;Initial Catalog=sinema;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("insert into seans(seans_adi,seans_tarih,seans_saat) values('" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + maskedTextBox1.Text + "')", baglanti);
            ekle.ExecuteNonQuery();
            ekle.Dispose();
            baglanti.Close();
            MessageBox.Show("Seans Ekleme İşlemi Başarılı", "Kayıt");
            textBox1.Text = "";
            maskedTextBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void seanslar_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            foreach (Control item3 in dateTimePicker1.Controls)
            {
                item3.Enabled = true;
            }

            DateTime bugün = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime yeni = DateTime.Parse(dateTimePicker1.Text);
            if (yeni == bugün)
            {
                foreach (Control item in dateTimePicker1.Controls)
                {
                    if (DateTime.Parse(DateTime.Now.ToShortTimeString()) > DateTime.Parse(item.Text))
                    {
                        item.Enabled = false;
                    }
                }
            }
            else if (yeni < bugün)
            {
                MessageBox.Show("Geriye dönük işlem yapılamaz!!!", "Uyarı");
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            }
        }
    }
}

