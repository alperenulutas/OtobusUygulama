using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace OtobusUygulama
{
    public partial class GirisYap : Form
    {
        public GirisYap()
        {
            InitializeComponent();
        }
        
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Alperen\\Documents\\Otobus.accdb");
        private void btnUye_Click(object sender, EventArgs e)
        {
            UyeOl uyeOl = new UyeOl();
            uyeOl.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hakkında fr = new Hakkında();
            fr.Show();
            
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("Select * From Uye Where KullanıcıAd=@p1 and Sifre=@p2",baglanti);
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
            OleDbDataReader dr1 = cmd.ExecuteReader();
            if (dr1.Read())
                {
                AdminPanel ad = new AdminPanel();
                ad.kad = txtAd.Text;
                ad.Show();
                this.Hide();
                }
            baglanti.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtSifre.PasswordChar = '\0';
            }
            else
            {
                txtSifre.PasswordChar = '*';
            }
        }

        private void GirisYap_Load(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
            

        }

        private void btnFace_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/VaranTurkiye/");
        }

        private void btnins_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/varanturkiye/");
        }

        private void btnTwit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/varanturkiye/");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
