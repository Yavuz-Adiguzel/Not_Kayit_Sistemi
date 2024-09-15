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
    public partial class FrOgretmenDetay : Form
    {
        public FrOgretmenDetay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ASUS\\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBLOGRENCI (OGRNO,OGRAD,OGRSOYAD) VALUES (@P1,@P2,@P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@P2", textBox1.Text);
            komut.Parameters.AddWithValue("@p3", textBox2.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            this.tBLOGRENCITableAdapter.Fill(this.dbNotKayitDataSet1.TBLOGRENCI);
            MessageBox.Show("Öğrenci Kaydı Yapıldı");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            string durum;
            s1 = Convert.ToDouble(TxtSinav1.Text);
            s2 = Convert.ToDouble(TxtSinav2.Text);
            s3 = Convert.ToDouble(TxtSinav3.Text);
            ortalama = (s1 + s2 + s3) / 3;
            LblOrtalama.Text = ortalama.ToString("0.00");
            if (ortalama >= 60)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE TBLOGRENCI SET SINAV1=@P1,SINAV2=@P2,SINAV3=@P3,ORTALAMA=@P4,DURUM=@P5 WHERE OGRNO=@P6", baglanti);
            komut.Parameters.AddWithValue("@P1", TxtSinav1.Text);
            komut.Parameters.AddWithValue("@P2", TxtSinav2.Text);
            komut.Parameters.AddWithValue("@P3", TxtSinav2.Text);
            komut.Parameters.AddWithValue("@P4", LblOrtalama.Text);
            komut.Parameters.AddWithValue("@P5", durum);
           
            komut.Parameters.AddWithValue("@P6", maskedTextBox1.Text);
            komut.ExecuteNonQuery();
            this.tBLOGRENCITableAdapter.Fill(this.dbNotKayitDataSet1.TBLOGRENCI);
            baglanti.Close();
            MessageBox.Show("Öğrenci Notu Güncellendi");

        }

        private void FrOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotKayitDataSet1.TBLOGRENCI' table. You can move, or remove it, as needed.
            this.tBLOGRENCITableAdapter.Fill(this.dbNotKayitDataSet1.TBLOGRENCI);
            LblGecenSayi.Text = dbNotKayitDataSet1.TBLOGRENCI.Count(x => x.DURUM == true).ToString();
            LblKalanSayi.Text = dbNotKayitDataSet1.TBLOGRENCI.Count(x => x.DURUM == false).ToString();
            LblSinifOrt.Text = dbNotKayitDataSet1.TBLOGRENCI.Average(x => x.ORTALAMA).ToString("0.00");
            LblEnBasarili.Text = (from x in dbNotKayitDataSet1.TBLOGRENCI orderby x.DURUM descending select x.OGRAD +" "+ x.OGRSOYAD).FirstOrDefault().ToString();
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            LblOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            
            
                SqlCommand komut = new SqlCommand("DELETE FROM TBLOGRENCI WHERE OGRNO=@P1", baglanti);
                komut.Parameters.AddWithValue("@P1", maskedTextBox1.Text);
                komut.ExecuteNonQuery();
            this.tBLOGRENCITableAdapter.Fill(this.dbNotKayitDataSet1.TBLOGRENCI);


            baglanti.Close();
            MessageBox.Show("Öğrenci kaydı silinmiştir");
        }
    }
}
