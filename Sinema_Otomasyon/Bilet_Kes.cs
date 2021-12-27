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
    public partial class Bilet_Kes : Form
    {
        public Bilet_Kes()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=WIN-IM38HI1GTD6\\SQLEXPRESS;Initial Catalog=sinema;Integrated Security=True");





        private void Bilet_Kes_Load(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM filmler";
            kayitGetir();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["film_adi"]);
            }
            baglanti.Close();

            //salon();
            //seans();



        }

        private void salon()
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM salon";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["salon_adi"]);
            }
            baglanti.Close();
        }

        private void seans()
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM seans";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["seans_id"]);
            }
            baglanti.Close();



        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //{
            //    textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            //    textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            //    textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            //    film_id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //    //seans_id = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            //    salon_id = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            //    pictureBox1.ImageLocation= dataGridView1.CurrentRow.Cells[6].Value.ToString();
            //    baglanti.Open();
            //    SqlCommand listeleseans = new SqlCommand("select * from seans where seans_id='" + int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString()) + "'", baglanti);
            //    SqlDataReader drs = listeleseans.ExecuteReader();
            //    if (drs.Read())
            //    {
            //        textBox4.Text = drs["seans_tarih"].ToString();
            //        textBox5.Text = drs["seans_saat"].ToString();
            //        textBox6.Text = drs["seans_adi"].ToString();
            //    }
            //    baglanti.Close();

            //    baglanti.Open();
            //    SqlCommand listele = new SqlCommand("select * from salon where salon_id='"+ int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()) + "'", baglanti);
            //    SqlDataReader dr = listele.ExecuteReader();
            //   while (dr.Read())
            //  {

            //   textBox7.Text= dr["salon_adi"].ToString();
            //    }
            //    baglanti.Close();

            //}
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        int salon_id, seans_id;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand();

            komut.CommandText = "select * from filmler where film_adi='" + comboBox1.Text + "'";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr2;

            dr2 = komut.ExecuteReader();
            while (dr2.Read())
            {
                salon_id= Convert.ToInt32(dr2["salon_id"]);
                seans_id = Convert.ToInt32(dr2["seans_id"]);
            }
            dr2.Close();
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand();

            komut2.CommandText = "select * from salon where salon_id='" + salon_id + "'";
            komut2.Connection = baglanti;
            komut2.CommandType = CommandType.Text;
            SqlDataReader dr22;

            dr22 = komut2.ExecuteReader();
            while (dr22.Read())
            {
                comboBox2.Items.Add(dr22["salon_adi"]);
            }
            dr22.Close();
            baglanti.Close();

            /////////////////////
            ///




            baglanti.Open();
            SqlCommand komut3 = new SqlCommand();

            komut3.CommandText = "select * from seans where seans_id='" + seans_id + "'";
            komut3.Connection = baglanti;
            komut3.CommandType = CommandType.Text;
            SqlDataReader dr3;

            dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                comboBox3.Items.Add(dr3["seans_adi"]);
            }
            dr3.Close();
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("insert into satis(film_adi,salon_adi,seans_id,kisi_adi,kisi_soyadi) values ('" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')", baglanti);
            ekle.ExecuteNonQuery();
            ekle.Dispose();
            MessageBox.Show("Bilet Kesme sİşleminiz Başarıyla Gerçekleşmiştir.", "Kayıt");


            baglanti.Close();

            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is TextBox) this.Controls[i].Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 formm1 = new Form1();
            formm1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Koltuk klt = new Koltuk();
            klt.Show();
            this.Hide();
        }
        private void kayitGetir()
        {
            baglanti.Open();
            string kayit = "SELECT * from seans";
           
            SqlCommand komut = new SqlCommand(kayit, baglanti);
           
            SqlDataAdapter da = new SqlDataAdapter(komut);
           
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            dataGridView1.DataSource = dt;
            
            baglanti.Close();
        }
    }
}
