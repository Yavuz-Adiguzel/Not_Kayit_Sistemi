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
    public partial class FrOgretmenKayit : Form
    {
        
        public FrOgretmenKayit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ASUS\\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        private void BtnKayitYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBLOGRETMEN (OGRTADSOYAD,BRANS,SIFRE) VALUES (@P1,@P2,@P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", TxtAdSoyad.Text);
            komut.Parameters.AddWithValue("@P2", TxtBrans.Text);
            komut.Parameters.AddWithValue("@P3", TxtSifre.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğretmen Kaydı Yapılmıştır");

        }
    }
}
