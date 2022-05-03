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
    public partial class Uyelikİptal : Form
    {
        public Uyelikİptal()
        {
            InitializeComponent();
        }
        public string kad6;

        private void btnDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Alperen\\Documents\\Otobus.accdb");
        private void Uyelikİptal_Load(object sender, EventArgs e)
        {
            label9.Text = kad6;
            pictureBox7.BackColor = Color.Transparent;
            baglanti.Open();
            OleDbCommand command1 = new OleDbCommand("Select * From Uye Where KullanıcıAd=@p1", baglanti);
            command1.Parameters.AddWithValue("@p1", label9.Text);
            OleDbDataReader dr1 = command1.ExecuteReader();
            if (dr1.Read())
            {
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

        private void btnGuncel_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("Delete From Uye Where KullanıcıAd=@p1",baglanti);
            cmd.Parameters.AddWithValue("@p1",label9.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Üyeliğiniz İptal Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
