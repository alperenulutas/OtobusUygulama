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
    public partial class BiletAl : Form
    {
        public BiletAl()
        {
            InitializeComponent();
        }
        public string kad1;
        string koltuk;
        
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Alperen\\Documents\\Otobus.accdb");
        private void btnDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void BiletAl_Load(object sender, EventArgs e)
        {
            label8.Text = kad1;
            pictureBox7.BackColor = Color.Transparent;
            baglanti.Open();
            OleDbCommand command = new OleDbCommand("Select * From Uye Where KullanıcıAd=@p1",baglanti);
            command.Parameters.AddWithValue("@p1",label8.Text);
            OleDbDataReader dr1 = command.ExecuteReader();
            if (dr1.Read())
            {
               txtAd.Text = dr1[1].ToString();
                txtSoyad.Text = dr1[2].ToString(); 
            }
            baglanti.Close();
        }

        private void btnAl_Click(object sender, EventArgs e)
        {
            if (VarMi(textBox1.Text) != 0)
            {
                MessageBox.Show("Bu Koltuk Daha Önce Alınmış");              
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into Sefer(Ad,Soyad,Nereden,Nereye,Tarih,Saat,Fiyat,KoltukNo) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglanti);
                komut.Parameters.AddWithValue("@p1", txtAd.Text);
                komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
                komut.Parameters.AddWithValue("@p3", cmbNereden.Text);
                komut.Parameters.AddWithValue("@p4", cmbNereye.Text);
                komut.Parameters.AddWithValue("@p5", dateTimePicker1.Text);
                komut.Parameters.AddWithValue("@p6", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@p7", cmbFiyat.Text);
                komut.Parameters.AddWithValue("@p8", textBox1.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Bileti Başarıyla Aldınız");
            }
            

        }
        public int VarMi(string aranan)
        {
            baglanti.Open();
            int sonuc;
            string sorgu = "Select COUNT(KoltukNo) From Sefer Where KoltukNo=@p1";
            OleDbCommand komut1 = new OleDbCommand(sorgu, baglanti);
            komut1.Parameters.AddWithValue("@p1", textBox1.Text);
            sonuc = Convert.ToInt32(komut1.ExecuteScalar());
            baglanti.Close();
            return sonuc;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = button2.Text;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = button9.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = button10.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = button11.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = button12.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = button13.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = button14.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = button15.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = button16.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = button17.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = button18.Text;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = button19.Text;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = button20.Text;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text = button21.Text;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text = button22.Text;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text = button23.Text;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox1.Text = button24.Text;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            textBox1.Text = button25.Text;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox1.Text = button26.Text;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            textBox1.Text = button27.Text;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            textBox1.Text = button28.Text;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            textBox1.Text = button29.Text;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            textBox1.Text = button30.Text;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            textBox1.Text = button31.Text;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            textBox1.Text = button32.Text;
        }
       
    }
}
