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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi con = new sqlbaglantisi();
        private void FrmDoktorGiris_Load(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from tbl_doktorlar where DoktorTC=@p1 and DoktorSifre=@p2", con.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTCno.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay fr = new FrmDoktorDetay();
                MessageBox.Show("Giriş Başarılı Doktor Paneline Aktarılıyorsunuz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fr.TC = mskTCno.Text;
                fr.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız Lütfen Tekrar Deneyin", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.baglanti().Close();
        }
    }
}
