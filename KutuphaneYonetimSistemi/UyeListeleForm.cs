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
    public partial class UyeListeleForm : Form
    {
        public UyeListeleForm()
        {
            InitializeComponent();
        }

        private void UyeListeleForm_Load(object sender, EventArgs e)
        {
            UyeleriListele();
        }
        private void UyeleriListele()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_UyeListele", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUyeler.DataSource = dt;

                    dgvUyeler.Columns["UyeID"].HeaderText = "ID";
                    dgvUyeler.Columns["Ad"].HeaderText = "Ad";
                    dgvUyeler.Columns["Soyad"].HeaderText = "Soyad";
                    dgvUyeler.Columns["Telefon"].HeaderText = "Telefon";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvUyeler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek bir üye seçiniz!");
                return;
            }

            int uyeID = Convert.ToInt32(dgvUyeler.SelectedRows[0].Cells["UyeID"].Value);

            DialogResult dr = MessageBox.Show("Bu üyeyi silmek istediğinize emin misiniz?", "Üye Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_UyeSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uyeID", uyeID);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Üye başarıyla silindi!");
                    UyeleriListele();
                }
                catch (Exception ex)
                {
                    {
                        MessageBox.Show("Hata:" + ex.Message, "Hata:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvUyeler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir üye seçiniz!");
                return;
            }
            DataGridViewRow row = dgvUyeler.SelectedRows [0];
            int uyeID=Convert.ToInt32(row.Cells ["UyeID"].Value);
            string ad=row.Cells ["Ad"].Value.ToString();
            string soyad=row.Cells["Soyad"].Value.ToString();
            string telefon=row.Cells["telefon"].Value.ToString();

            UyeGuncelleForm form = new UyeGuncelleForm(uyeID,ad, soyad, telefon);
            form.FormClosed += (s, args) => UyeleriListele();
            form.ShowDialog();
        }
    }
}
