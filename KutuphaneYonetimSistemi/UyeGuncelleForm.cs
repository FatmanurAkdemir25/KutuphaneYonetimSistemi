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
    public partial class UyeGuncelleForm : Form
    {
        private int uyeID;
        public UyeGuncelleForm(int uyeID,string ad,string soyad,string telefon)
        {
            InitializeComponent();
            this.uyeID = uyeID;
            txtAd.Text = ad;
            txtSoyad.Text = soyad;
            txtTelefon.Text = telefon;
        }

        private void UyeGuncelleForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_UyeGuncelle", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UyeID", uyeID);
                cmd.Parameters.AddWithValue("@Ad", txtAd.Text);
                cmd.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
                cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Üye başarıyla güncellendi");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata:" + ex.Message);
                }
            }
        }
    }
}
