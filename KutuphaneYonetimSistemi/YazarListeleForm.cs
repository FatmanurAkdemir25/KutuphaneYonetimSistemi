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
    public partial class YazarListeleForm : Form
    {
        public YazarListeleForm()
        {
            InitializeComponent();
        }

        private void YazarListeleForm_Load(object sender, EventArgs e)
        {
            YazarListele();
        }
        private void YazarListele()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_YazarListele", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvYazarlar.DataSource = dt;

                    dgvYazarlar.Columns["YazarID"].HeaderText = "ID";
                    dgvYazarlar.Columns["YazarAdi"].HeaderText = "Ad";
                    dgvYazarlar.Columns["YazarSoyadi"].HeaderText = "Soyad";

                    dgvYazarlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvYazarlar.ReadOnly = true;
                    dgvYazarlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata:" + ex.Message);
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvYazarlar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silmek için bir yazar seçiniz!");
                return;
            }

            int yazarID = Convert.ToInt32(dgvYazarlar.SelectedRows[0].Cells["YazarID"].Value);

            DialogResult dr = MessageBox.Show("Bu yazarı silmek istediğinize emin misiniz?", "Yazar Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_YazarSil", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@YazarID", yazarID);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Yazar silindi!");
                        YazarListele();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvYazarlar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncellemek için bir yazar seçiniz!");
                return;
            }

            DataGridViewRow row = dgvYazarlar.SelectedRows[0];
            int yazarID = Convert.ToInt32(row.Cells["YazarID"].Value);
            string ad = row.Cells["YazarAdi"].Value.ToString();
            string soyad = row.Cells["YazarSoyadi"].Value.ToString();

            YazarGuncelleForm form = new YazarGuncelleForm(yazarID, ad, soyad);
            form.FormClosed += (s, args) => YazarListele();
            form.ShowDialog();
        }
    }
    
}
