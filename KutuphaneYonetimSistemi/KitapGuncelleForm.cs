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
using System.Data.SqlTypes;

namespace KutuphaneYonetimSistemi
{
    public partial class KitapGuncelleForm : Form
    {
        private int kitapID; //başka bir formdan alınıyor
        public KitapGuncelleForm(int kitapID,string baslik,int yazarID,string yayinEvi,short basimYili)
        {
            InitializeComponent();
            this.kitapID = kitapID;
            txtBaslik.Text = baslik;
            txtYazarID.Text = yazarID.ToString();
            txtYayinEvi.Text = yayinEvi;
            txtBasimYili.Text = basimYili.ToString();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_KitapGuncelle", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@KitapID",kitapID);
                cmd.Parameters.AddWithValue("@Baslik", txtBaslik.Text);
                cmd.Parameters.AddWithValue("@YazarID", Convert.ToInt32(txtYazarID.Text));//dönüşüm
                cmd.Parameters.AddWithValue("@YayinEvi", txtYayinEvi.Text);
                cmd.Parameters.AddWithValue("@BasimYili", Convert.ToInt32(txtBasimYili.Text));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();//sp yi çalıştır
                    MessageBox.Show("Kitap başarıyla güncellendi.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata:"+ex.Message);
                }
            }
        }

        private void KitapGuncelleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
