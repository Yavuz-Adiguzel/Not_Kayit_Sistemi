using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NOT_KAYIT_YENİ
{
    public partial class Frmİlk : Form
    {
        public Frmİlk()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrOgrenciGrs fr = new FrOgrenciGrs();
            fr.Show();
        }

        private void BtnOgretmenGrs_Click(object sender, EventArgs e)
        {
            FrOgretmenGrs fr = new FrOgretmenGrs();
            fr.Show();
        }
    }
}
