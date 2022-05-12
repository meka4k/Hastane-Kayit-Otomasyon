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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi con = new sqlbaglantisi();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from tbl_sekreter where SekreterTC=@p1 and SekreterSifre=@p2", con.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTCno.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay fr = new FrmSekreterDetay();
                MessageBox.Show("Giriş Başarılı. Sekreter Paneline Aktarılıyorsunuz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fr.tcnumara = mskTCno.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("TC veya Şifre Yanlış!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.baglanti().Close();
        }
    }
}
