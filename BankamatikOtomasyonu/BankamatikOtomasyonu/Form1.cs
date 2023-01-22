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

namespace BankamatikOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-BITUB47;Initial Catalog=DbBankaTest;Integrated Security=True");
        private void LnkKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLKISILER where hesapno=@p1 and sıfre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", MskHesapNo.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form2 fr = new Form2();
                fr.hesap = MskHesapNo.Text;
                fr.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Bilgi");
            }
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
