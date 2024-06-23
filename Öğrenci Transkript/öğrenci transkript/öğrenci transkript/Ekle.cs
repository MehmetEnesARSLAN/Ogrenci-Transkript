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
    public partial class Ekle : Form
    {
        public Ekle()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglantı = new NpgsqlConnection("server=localHost; port = 5432; Database=dbTranskript; user ID=postgres;  password=1234");
        
        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into ders (derskodu,dersadi,kredi,akts,ogretimuyesiadsoyad,donem,harfnotu) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)",baglantı);

            komut.Parameters.AddWithValue("@p1", txtDersKodu.Text);
            komut.Parameters.AddWithValue("@p2", txtDersAdi.Text);
            komut.Parameters.AddWithValue("@p3", txtKredi.Text);
            komut.Parameters.AddWithValue("@p4", txtAKTS.Text);
            komut.Parameters.AddWithValue("@p5", txtOgruyeadsoyad.Text);
            komut.Parameters.AddWithValue("@p6", txtDonem.Text);
            komut.Parameters.AddWithValue("@p7", txtHarfnotu.Text);

            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Ders kaydı başarılı." + "\n" +
                            "Ders başarıyla transkriptte eklenmiştir!!!");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from mufredat";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtDersKodu.Clear();
            txtDersAdi.Clear();
            txtAKTS.Clear();
            txtDonem.Clear();
            txtKredi.Clear();
            txtOgruyeadsoyad.Clear();
            txtHarfnotu.Clear();
        }
    }
}
