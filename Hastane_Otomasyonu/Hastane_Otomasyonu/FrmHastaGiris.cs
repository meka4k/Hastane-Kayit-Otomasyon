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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        private void lnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit fr = new FrmHastaKayit();
            {
                fr.Show();
            }
        }
        sqlbaglantisi con = new sqlbaglantisi();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbl_hastalar where HastaTc=@p1 and HastaSifre=@p2", con.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTCno.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı Hasta Detay Paneline Aktarılıyorsunuz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmHastaDetay fr = new FrmHastaDetay();
                fr.tc = mskTCno.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("TC veya Şifre Yanlış", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.baglanti().Close();
        }
    }
}
