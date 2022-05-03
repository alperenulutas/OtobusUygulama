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
    public partial class Seferler : Form
    {
        public Seferler()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Otobus.accdb");
        private void Seferler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand command = new OleDbCommand("Select SeferNo,Nereden,Nereye,Tarih,Saat,Fiyat,KoltukNo From Sefer",baglanti);
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
    }
}
