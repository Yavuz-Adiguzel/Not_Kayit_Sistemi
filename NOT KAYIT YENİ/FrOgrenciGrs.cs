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
    public partial class FrOgrenciGrs : Form
    {
        public FrOgrenciGrs()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrOgrenciKayit fr = new FrOgrenciKayit();
            fr.Show();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ASUS\\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Öğrenci No ve Şifre giriniz");
            }

            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLOGRENCI where OGRNO=@p1 and OGRSIFRE=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrOgrenciDetay fr = new FrOgrenciDetay();
                fr.numara = maskedTextBox1.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre");
            }
           
            baglanti.Close();
        }
    }
}
