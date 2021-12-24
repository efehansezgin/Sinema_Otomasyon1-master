using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
       
        private void Koltuk_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 49; i++)
            {
                Button btn = new Button();
                btn.Name = i.ToString();
                btn.Text = i.ToString();
                btn.Width = 80;
                btn.Height = 50;
                btn.Click += Btn_Click;
                flowLayoutPanel1.Controls.Add(btn);
             
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
           
            Button btn = (Button)sender;
            btn.BackColor = Color.Red;
            btn.Enabled = !btn.Enabled;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
