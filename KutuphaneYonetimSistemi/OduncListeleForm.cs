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
    public partial class OduncListeleForm : Form
    {
        public OduncListeleForm()
        {
            InitializeComponent();
        }

        private void OduncListeleForm_Load(object sender, EventArgs e)
        {
            OduncKayitlariniGetir();
        }
        private void OduncKayitlariniGetir()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_OduncListele", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvOdunc.DataSource = dt;

                    dgvOdunc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvOdunc.ReadOnly = true;
                    dgvOdunc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
