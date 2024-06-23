using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace öğrenci_transkript
{
    public partial class Sil : Form
    {
        public Sil()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglantı = new NpgsqlConnection("server=localHost; port = 5432; Database=dbTranskript; user ID=postgres;  password=1234");

       

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            string sorgu = "Delete From ders where derskodu=@p1";
            NpgsqlCommand komut2 = new NpgsqlCommand(sorgu, baglantı);
            komut2.Parameters.AddWithValue("@p1", txtDersKodu.Text);
            komut2.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("silme işlemi başarılı");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from ders order by donem,derskodu";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtDersKodu.Clear();
        }
    }
}
