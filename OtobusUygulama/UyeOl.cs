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
    public partial class UyeOl : Form
    {
        public UyeOl()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Otobus.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (VarMi(txtKad.Text) != 0)
            {
                MessageBox.Show("Bu Kullanıcı Adı ile daha önce kayıt yapılmış");
                baglanti.Open();
                OleDbCommand kom = new OleDbCommand("Delete From Uye Where KullanıcıAd=@p1 and Sifre=@p2",baglanti);
                kom.Parameters.AddWithValue("@p1",txtKad.Text);
                kom.Parameters.AddWithValue("@p2", txtSifre.Text);
                kom.ExecuteNonQuery();
                baglanti.Close();
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into Uye(Ad,Soyad,KullanıcıAd,Sifre,Cinsiyet,Yas,Telefon,TC) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglanti);
                komut.Parameters.AddWithValue("@p1", txtAd.Text);
                komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
                komut.Parameters.AddWithValue("@p3", txtKad.Text);
                komut.Parameters.AddWithValue("@p4", txtSifre.Text);
                komut.Parameters.AddWithValue("@p5", cmbCins.Text);
                komut.Parameters.AddWithValue("@p6", cmbYas.Text);
                komut.Parameters.AddWithValue("@p7", txtTel.Text);
                komut.Parameters.AddWithValue("@p8", txtTC.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarıyla Üye Oldunuz");
            }

        }

        private void txtAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void txtSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void UyeOl_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }
        public int VarMi(string aranan)
        {
            int sonuc;
            string sorgu = "Select COUNT(KullanıcıAd and TC) from Uye WHERE KullanıcıAd=@p1 and TC=@p2";
            OleDbCommand komut1 = new OleDbCommand(sorgu, baglanti);
            komut1.Parameters.AddWithValue("@p1", txtKad.Text);
            komut1.Parameters.AddWithValue("@p2", txtTC.Text);
            baglanti.Open();

            sonuc = Convert.ToInt32(komut1.ExecuteScalar());
            baglanti.Close();
            return sonuc;
        }
    }
}
