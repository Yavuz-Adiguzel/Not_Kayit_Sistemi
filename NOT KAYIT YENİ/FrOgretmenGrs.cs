using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NOT_KAYIT_YENİ
{
    public partial class FrOgretmenGrs : Form
    {
        public FrOgretmenGrs()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrOgretmenKayit fr = new FrOgretmenKayit();
            fr.Show();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ASUS\\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre boş bırakılamaz");
            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TBLOGRETMEN where OGRTADSOYAD=@P1 AND SIFRE=@P2", baglanti);
            komut.Parameters.AddWithValue("@P1", textBox1.Text);
            komut.Parameters.AddWithValue("@P2", textBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrOgretmenDetay fr = new FrOgretmenDetay();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
            }
            baglanti.Close();

        }
    }
}
