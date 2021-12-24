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
    public partial class salonlar : Form
    {
        public salonlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-OQH5QGJ;Initial Catalog=sinema;Integrated Security=True");
        private void salonlar_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand salonekle = new SqlCommand("insert into salon(salon_adi) values('"+textBox1.Text+"')", baglanti);
            baglanti.Open();
            salonekle.ExecuteNonQuery();
            salonekle.Dispose();
            baglanti.Close();
            MessageBox.Show("Salon ekleme işlemi gerçekleşti","Kayıt");
            textBox1.Text = "";
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

        private void button5_Click(object sender, EventArgs e)
        {

            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }
    }
}
