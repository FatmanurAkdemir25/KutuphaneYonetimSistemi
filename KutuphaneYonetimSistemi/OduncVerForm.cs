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

namespace KutuphaneYonetimSistemi
{
    public partial class OduncVerForm : Form
    {
        public OduncVerForm()
        {
            InitializeComponent();
        }

        private void OduncVerForm_Load(object sender, EventArgs e)
        {
            KitaplariGetir();
            UyeleriGetir();
        }
        private void KitaplariGetir()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT KitapID, Baslik FROM Kitaplar WHERE Durum = 1", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbKitaplar.DataSource = dt;
                cmbKitaplar.DisplayMember = "Baslik";
                cmbKitaplar.ValueMember = "KitapID";
            }
        }
        private void UyeleriGetir()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT UyeID, Ad + ' ' + Soyad AS AdSoyad FROM Uyeler", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbUyeler.DataSource = dt;
                cmbUyeler.DisplayMember = "AdSoyad";
                cmbUyeler.ValueMember = "UyeID";
            }
        }

        private void btnOduncVer_Click(object sender, EventArgs e)
        {
            if (cmbKitaplar.SelectedValue == null || cmbUyeler.SelectedValue == null)
            {
                MessageBox.Show("Lütfen kitap ve üye seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int kitapID = Convert.ToInt32(cmbKitaplar.SelectedValue);
            int uyeID = Convert.ToInt32(cmbUyeler.SelectedValue);
            int kullaniciID = Session.KullaniciID;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_KitapOduncVer", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@KitapID", kitapID);
                cmd.Parameters.AddWithValue("@UyeID", uyeID);
                cmd.Parameters.AddWithValue("@KullaniciID", kullaniciID);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kitap ödünç verildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KitaplariGetir(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
