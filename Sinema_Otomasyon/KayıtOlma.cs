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
    public partial class KayıtOlma : Form
    {
        public KayıtOlma()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=WIN-5D1N64KPPAU;Initial Catalog=sinema;User ID=sa;Password=qwerT12/;");
        private void KayıtOlma_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Girisyap giris = new Girisyap();
            giris.Show();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kullanıcı Adı")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı Adı";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Şifre")
            {
                textBox2.Text = "";
            }
            textBox2.PasswordChar = '*';
        }
        char? none = null;
        bool move;
        int mouse_x;
        int mouse_y;
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Şifre";
            }
            textBox2.PasswordChar = Convert.ToChar(none);
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Tekrar Şifre")
            {
                textBox3.Text = "";
            }
            textBox3.PasswordChar = '*';
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Tekrar Şifre";
            }
            textBox3.PasswordChar = Convert.ToChar(none);
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Gmail")
            {
                textBox4.Text = "";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Gmail";
            }
        }

        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {

            if (maskedTextBox1.Text == "Tel")
            {
                maskedTextBox1.Text = "";
            }
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "Tel")
            {
                maskedTextBox1.Text = "";
            }
        }

        private void KayıtOlma_MouseMove(object sender, MouseEventArgs e)
        {

            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void KayıtOlma_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void KayıtOlma_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand command = new SqlCommand("Insert into kisiler (kullanici_adi,sifre,sifre_tek,gmail,tel) values ('" + (textBox1.Text) + "', '" + (textBox2.Text) + "', '" + (textBox3.Text) + "','" + (textBox4.Text) + "', '" + (maskedTextBox1.Text) + "')", baglanti);
            command.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt yapıldı! Giriş yapabilirsiniz.");
        }
    }
}
