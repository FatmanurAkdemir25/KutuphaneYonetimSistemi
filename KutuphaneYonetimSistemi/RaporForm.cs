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
    public partial class RaporForm : Form
    {
        public RaporForm()
        {
            InitializeComponent();
        }

        private void RaporForm_Load(object sender, EventArgs e)
        {
            cmbFiltre.Items.Add("Tümü");
            cmbFiltre.Items.Add("Teslim Edilenler");
            cmbFiltre.Items.Add("Teslim Edilmeyenler");
            cmbFiltre.SelectedIndex = 0;

            OduncKayitlariniGetir("Tümü");
        }

        private void cmbFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            OduncKayitlariniGetir(cmbFiltre.SelectedItem.ToString());
        }
        private void OduncKayitlariniGetir(string filtre)
        {
            

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_OduncRapor", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Filtre", filtre);

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvRapor.DataSource = dt;

                    if (dgvRapor.Columns.Contains("GecenGun"))
                        dgvRapor.Columns["GecenGun"].HeaderText = "Geçen Gün";

                    dgvRapor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvRapor.ReadOnly = true;
                    dgvRapor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
