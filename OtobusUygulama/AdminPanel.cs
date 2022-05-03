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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }
        public string kad;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Otobus.accdb");
        private void AdminPanel_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
            label2.Text = kad;
            baglanti.Open();
            //Ad Soyad Çekme
            OleDbCommand cmd = new OleDbCommand("Select Ad,Soyad From Uye where KullanıcıAd=@p1",baglanti);
            cmd.Parameters.AddWithValue("@p1",label2.Text);
            OleDbDataReader dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                label4.Text = dr1[0].ToString();
                label5.Text = dr1[1].ToString();
            }
            baglanti.Close();


            //Sefer Çekme
            baglanti.Open();
            OleDbCommand command = new OleDbCommand("Select * From Sefer where Ad=@p1 and Soyad=@p2", baglanti);
            command.Parameters.AddWithValue("p1",label4.Text);
            command.Parameters.AddWithValue("p2", label5.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

        }

        private void btnAl_Click(object sender, EventArgs e)
        {
            BiletAl biletAl = new BiletAl();           
            biletAl.kad1 = label2.Text;
            biletAl.Show();
            
        }

     

        private void btnSefer_Click(object sender, EventArgs e)
        {
            Seferler seferler = new Seferler();
            seferler.Show();
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            BilgiDüzenle bilgi = new BilgiDüzenle();
            bilgi.kad4 = label2.Text;
            bilgi.Show();
            
        }

        private void btnGiriseDon_Click(object sender, EventArgs e)
        {
            GirisYap giris = new GirisYap();
            giris.Show();
            this.Close();
            
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            Uyelikİptal uye = new Uyelikİptal();
            uye.kad6 = label2.Text;
            uye.Show();
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BiletSilDüzenle bl = new BiletSilDüzenle();
            bl.no = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            bl.ad = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            bl.soyad = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            bl.nereden = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            bl.nereye = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            bl.tarih = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            bl.saat = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            bl.fiyat = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            bl.koltuk = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            bl.Show();

        }
    }
}
