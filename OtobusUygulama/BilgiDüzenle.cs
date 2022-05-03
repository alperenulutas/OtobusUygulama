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
    public partial class BilgiDüzenle : Form
    {
        public BilgiDüzenle()
        {
            InitializeComponent();
        }
        public string kad4;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Otobus.accdb");
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuncel_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand command = new OleDbCommand("Update Uye Set Ad=@p1,Soyad=@p2,KullanıcıAd=@p3,Sifre=@p4,Cinsiyet=@p5,Yas=@p6,Telefon=@p7,TC=@p8 Where UyeNo=@p9",baglanti);            
            command.Parameters.AddWithValue("@p1", txtAd.Text);
            command.Parameters.AddWithValue("@p2", txtSoyad.Text);
            command.Parameters.AddWithValue("@p3", txtKad.Text);
            command.Parameters.AddWithValue("@p4", txtSifre.Text);
            command.Parameters.AddWithValue("@p5", cmbCins.Text);
            command.Parameters.AddWithValue("@p6", cmbYas.Text);
            command.Parameters.AddWithValue("@p7", txtTel.Text);
            command.Parameters.AddWithValue("@p8",txtTC.Text);
            command.Parameters.AddWithValue("@p9", txtıd.Text);
            command.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bilgileriniz Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BilgiDüzenle_Load(object sender, EventArgs e)
        {
            label9.Text = kad4;
            baglanti.Open();
            OleDbCommand command1 = new OleDbCommand("Select * From Uye Where KullanıcıAd=@p1", baglanti);
            command1.Parameters.AddWithValue("@p1", label9.Text);
            OleDbDataReader dr1 = command1.ExecuteReader();
            if (dr1.Read())
            {
                txtıd.Text = dr1[0].ToString();
                txtAd.Text = dr1[1].ToString();
                txtSoyad.Text = dr1[2].ToString();
                txtKad.Text = dr1[3].ToString();
                txtSifre.Text = dr1[4].ToString();
                cmbCins.Text = dr1[5].ToString();
                cmbYas.Text = dr1[6].ToString();
                txtTel.Text = dr1[7].ToString();
                txtTC.Text = dr1[8].ToString();             
            }
            baglanti.Close();
        }
    }
}
