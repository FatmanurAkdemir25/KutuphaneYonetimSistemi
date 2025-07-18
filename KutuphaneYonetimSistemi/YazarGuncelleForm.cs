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

namespace KutuphaneYonetimSistemi
{
    public partial class YazarGuncelleForm : Form
    {
        private int yazarID;
        public YazarGuncelleForm(int yazarID, string yazarAdi, string yazarSoyadi)
        {
            InitializeComponent();
            this.yazarID = yazarID;
            txtAd.Text = yazarAdi;
            txtSoyad.Text = yazarSoyadi;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad))
            {
                MessageBox.Show("Ad ve soyad boş olamaz!");
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_YazarGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@YazarID", yazarID);
                cmd.Parameters.AddWithValue("@YazarAdi", ad);
                cmd.Parameters.AddWithValue("@YazarSoyadi", soyad);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Yazar güncellendi!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}
