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
    public partial class btnEkle : Form
    {
        public btnEkle()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglantı = new NpgsqlConnection("server=localHost; port = 5432; Database=dbTranskript; user ID=postgres;  password=1234");
        
        private void formGetir(Form form)
        {
            panel1.Controls.Clear();
            form.MdiParent = this;
            form.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(form);
            form.Show();

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele listele = new Listele();
            formGetir(listele);
        }

        private void btneEklee_Click(object sender, EventArgs e)
        {
            Ekle ekle = new Ekle();
            formGetir(ekle);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Sil sil = new Sil();
            formGetir(sil);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Güncelle güncelle = new Güncelle();
            formGetir(güncelle);
        }
    }
}
