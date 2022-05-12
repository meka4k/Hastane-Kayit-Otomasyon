using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Hastane_Otomasyonu
{
    public partial class frmBransPaneli : Form
    {
        public frmBransPaneli()
        {
            InitializeComponent();
        }
        sqlbaglantisi con = new sqlbaglantisi();
        void gridgetir()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_branslar", con.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            txtBrans.Clear();
            txtid.Clear();
            
        }
        private void frmBransPaneli_Load(object sender, EventArgs e)
        {
            gridgetir();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_branslar (BransAd) values (@p1)", con.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBrans.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Branş Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridgetir();
            con.baglanti().Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtBrans.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from tbl_branslar where Bransid=@p1", con.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtid.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("Branş Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridgetir();
            con.baglanti().Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("Update tbl_branslar set BransAd=@p1 where Bransid=@p2", con.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", txtBrans.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtid.Text);
            komutguncelle.ExecuteNonQuery();
            MessageBox.Show("Branş Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridgetir();
            con.baglanti().Close();
        }
    }
}
