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
    public partial class FrOgrenciDetay : Form
    {
        public FrOgrenciDetay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ASUS\\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        public string numara;
        private void FrOgrenciDetay_Load(object sender, EventArgs e)
        {
            LblNumara.Text = numara;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT TBLOGRENCI.OGRAD, TBLOGRENCI.OGRSOYAD,TBLOGRENCI.SINAV1, TBLOGRENCI.SINAV2,TBLOGRENCI.SINAV3,TBLOGRENCI.ORTALAMA,TBLOGRENCI.DURUM FROM TBLOGRENCI where TBLOGRENCI.OGRNO=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1",numara);
            SqlDataReader dr = komut.ExecuteReader(); 
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];
                string adsoyad = LblAdSoyad.Text;
                this.Text = adsoyad;
                LblSinav1.Text = dr[2].ToString();
                LblSinav2.Text = dr[3].ToString();
                LblSinav3.Text = dr[4].ToString();
                LblOrtalama.Text = dr[5].ToString();
                LblDurum.Text = dr[6].ToString();
                
            }
            baglanti.Close();
        }
    }
}
