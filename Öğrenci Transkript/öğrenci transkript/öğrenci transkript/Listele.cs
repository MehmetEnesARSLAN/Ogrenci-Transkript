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
    public partial class Listele : Form
    {
        public Listele()
        {
            InitializeComponent();
        }
   
        NpgsqlConnection baglantı = new NpgsqlConnection("server=localHost; port = 5432; Database=dbTranskript; user ID=postgres;  password=1234");

        private void Listele_Load(object sender, EventArgs e)
        {
            string sorgu = "select * from ders order by donem,derskodu";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnganohesap_Click(object sender, EventArgs e)
        {
            baglantı.Open();

            NpgsqlCommand komutgiris = new NpgsqlCommand("select * from ders", baglantı);
            NpgsqlDataReader reader = komutgiris.ExecuteReader();
            
            while (reader.Read())
            {
                
              reader["kredi"].ToString();



                if (reader["harfnotu"].ToString() == "AA")
                {
                    
                }
            }

            baglantı.Close();

            
        }
    }
}
