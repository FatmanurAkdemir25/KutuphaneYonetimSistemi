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
    public partial class KitapEkleForm : Form
    {
        public KitapEkleForm()
        {
            InitializeComponent();
        }

        private void KitapEkleForm_Load(object sender, EventArgs e)
        {
            YazarListele();
        }
        private void YazarListele()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT YazarID, YazarAdi + ' ' + YazarSoyadi AS YazarAd FROM Yazarlar", conn); //yazaradi+yazarsoyadi=yazarad
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt); //değerleri al datatable ye koy

                cmbYazar.DataSource = dt; //bilgileri dt den al
                cmbYazar.DisplayMember = "YazarAd"; //kullanıcıya görünen
                cmbYazar.ValueMember = "YazarID"; //arkaplanda saklanan
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBaslik.Text))
            {
                MessageBox.Show("Lütfen kitap başlığını girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_KitapEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Baslik", txtBaslik.Text.Trim());
                cmd.Parameters.AddWithValue("@YazarID", cmbYazar.SelectedValue); //cmbyazardakini döndür
                cmd.Parameters.AddWithValue("@YayinEvi", string.IsNullOrWhiteSpace(txtYayinEvi.Text) ? (object)DBNull.Value : txtYayinEvi.Text.Trim());  //boş bıraklablr boşsa null 
                cmd.Parameters.AddWithValue("@BasimYili", string.IsNullOrWhiteSpace(txtBasimYili.Text) ? (object)DBNull.Value : txtBasimYili.Text.Trim());

                try
                {
                    conn.Open();
                    object yeniKitapID = cmd.ExecuteScalar();
                    MessageBox.Show("Kitap başarıyla eklendi.\nKitap ID: " + yeniKitapID, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtBaslik.Clear();
                    txtYayinEvi.Clear();
                    txtBasimYili.Clear();
                    cmbYazar.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
