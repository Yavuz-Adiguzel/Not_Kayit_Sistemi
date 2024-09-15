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

namespace NOT_KAYIT_YENİ
{
    public partial class FrOgrenciKayit : Form
    {
        public FrOgrenciKayit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ASUS\\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        private void BtnKayitYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBLOGRENCI (OGRAD,OGRSOYAD,OGRNO,OGRSIFRE,OGRCINSIYET) VALUES (@P1,@P2,@P3,@P4,@P5)", baglanti);
            komut.Parameters.AddWithValue("@P1", TxtAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@P3", MskNo.Text);
            komut.Parameters.AddWithValue("@P4", TxtSifre.Text);
            komut.Parameters.AddWithValue("@P5", CmbCinsiyet.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Kaydı Yapıldı");
        }

        private void CmbCinsiyet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrOgrenciKayit_Load(object sender, EventArgs e)
        {
            CmbCinsiyet.Items.Add("Erkek");
            CmbCinsiyet.Items.Add("Kadın");
        }
    }
}
