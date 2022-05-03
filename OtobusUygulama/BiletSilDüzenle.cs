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
    public partial class BiletSilDüzenle : Form
    {
        public BiletSilDüzenle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Otobus.accdb");
        public string no, ad, soyad,nereden,nereye,tarih,saat,fiyat,koltuk;

        private void btnGuncel_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("Update Sefer Set Ad=@p1,Soyad=@p2,Nereden=@p3,Nereye=@p4,Tarih=@p5,Saat=@p6,Fiyat=@p7,KoltukNo=@p8 where SeferNo=@p9",baglanti);
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", cmbNereden.Text);
            cmd.Parameters.AddWithValue("@p4", cmbNereye.Text);
            cmd.Parameters.AddWithValue("@p5", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@p6", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p7", cmbFiyat.Text);
            cmd.Parameters.AddWithValue("@p8", textBox1.Text);
            cmd.Parameters.AddWithValue("@p9", txtId.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Biletiniz Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BiletSilDüzenle_Load(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Transparent;
            txtId.Text = no;
            txtAd.Text = ad;
            txtSoyad.Text = soyad;
            cmbNereden.Text = nereden;
            cmbNereye.Text = nereye;
            dateTimePicker1.Text = tarih;
            maskedTextBox1.Text = saat;
            cmbFiyat.Text = fiyat;
            textBox1.Text = koltuk;

        }

        private void btnDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("Delete From Sefer Where SeferNo=@p1", baglanti);
            cmd.Parameters.AddWithValue("@p1", txtId.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Biletiniz İptal Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        

            
        }
    }
}
