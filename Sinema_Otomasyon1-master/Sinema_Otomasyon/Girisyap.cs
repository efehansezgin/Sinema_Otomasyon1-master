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
    public partial class Girisyap : Form
    {
        public Girisyap()
        {
            InitializeComponent();
        }
        bool move;
        int mouse_x;
        int mouse_y;
        char? none = null;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-OQH5QGJ;Initial Catalog=sinema;Integrated Security=True");
        private void Girisyap_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KayıtOlma kayıt = new KayıtOlma();
            kayıt.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Girisyap_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Girisyap_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Girisyap_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
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

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Şifre";
            }
            textBox2.PasswordChar = Convert.ToChar(none);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;

            string sorgu = "SELECT * FROM kisiler where kullanici_adi=@user AND sifre=@pass";
            cmd = new SqlCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("@user", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);
            baglanti.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız. ");
                Bilet_Kes bilet = new Bilet_Kes();
                bilet.Show();
                this.Hide();
            }
            if (textBox1.Text == "admin" && textBox2.Text == "1234")
            {
                this.Hide();
                Form1 admin = new Form1();
                admin.Show();
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız. ");
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }

           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
