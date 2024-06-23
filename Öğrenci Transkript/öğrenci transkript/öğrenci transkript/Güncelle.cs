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
    public partial class Güncelle : Form
    {
        public Güncelle()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglantı = new NpgsqlConnection("server=localHost; port = 5432; Database=dbTranskript; user ID=postgres;  password=1234");

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update ders set derskodu=@p1,dersadi=@p2,kredi=@p3,akts=@p4,ogretimuyesiadsoyad=@p5,donem=@p6,harfnotu=@p7 where derskodu=@p8", baglantı);
            komut.Parameters.AddWithValue("@p1", txtDersKodu.Text);
            komut.Parameters.AddWithValue("@p2", txtDersAdi.Text);
            komut.Parameters.AddWithValue("@p3", txtKredi.Text);
            komut.Parameters.AddWithValue("@p4", txtAKTS.Text);
            komut.Parameters.AddWithValue("@p5", txtOgruyeadsoyad.Text);
            komut.Parameters.AddWithValue("@p6", txtDonem.Text);
            komut.Parameters.AddWithValue("@p7", txtHarfnotu.Text);
            komut.Parameters.AddWithValue("@p8", txtDersKodu.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("ders güncelleme işlemi başarılı");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from ders order by donem,derskodu";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilen = dataGridView1.SelectedCells[0].RowIndex;

            txtDersKodu.Text = dataGridView1.Rows[seçilen].Cells[0].Value.ToString();
            txtDersAdi.Text = dataGridView1.Rows[seçilen].Cells[1].Value.ToString();
            txtKredi.Text = dataGridView1.Rows[seçilen].Cells[2].Value.ToString();
            txtAKTS.Text = dataGridView1.Rows[seçilen].Cells[3].Value.ToString();
            txtOgruyeadsoyad.Text = dataGridView1.Rows[seçilen].Cells[4].Value.ToString();
            txtDonem.Text = dataGridView1.Rows[seçilen].Cells[5].Value.ToString();
            txtHarfnotu.Text = dataGridView1.Rows[seçilen].Cells[6].Value.ToString();
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

        private void btnBilgigetir_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            NpgsqlCommand komutgiris = new NpgsqlCommand("select * from ders where derskodu like '" + txtDersKodu.Text + "' ", baglantı);
            NpgsqlDataReader reader = komutgiris.ExecuteReader();


            while (reader.Read())
            {
                txtDersAdi.Text = reader[1].ToString();
                txtKredi.Text = reader[2].ToString();
                txtAKTS.Text = reader[3].ToString();
                txtOgruyeadsoyad.Text = reader[4].ToString();
                txtDonem.Text = reader[5].ToString();
                txtHarfnotu.Text = reader[6].ToString();

                if (reader[1] != null)
                {
                    txtDersAdi.Enabled = true;
                    txtKredi.Enabled = true;
                    txtAKTS.Enabled = true;
                    txtOgruyeadsoyad.Enabled = true;
                    txtDonem.Enabled = true;
                    txtHarfnotu.Enabled = true;

                }
            }
            baglantı.Close();
        }
    }
}
