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
    public partial class KitapAraForm : Form
    {
        public KitapAraForm()
        {
            InitializeComponent();
        }

        private void KitapAraForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string arama = txtArama.Text.Trim(); //arama kelimesini txtArama dan al

            if (string.IsNullOrEmpty(arama))
            {
                MessageBox.Show("Lütfen bir arama kelimesi girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_KitapAra", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AramaKelimesi", arama);

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);//sp nin sonuçlarını alır datatable ye doldurur
                    if (dt.Columns.Contains("Durum"))
                        dt.Columns["Durum"].ColumnName = "DurumOrijinal";//Eğer gelen tabloda Durum adlı bir sütun varsa, onun adını DurumOrijinal olarak değiştir


                    DataColumn durumTextCol = new DataColumn("Durum", typeof(string));
                    dt.Columns.Add(durumTextCol); //yeni bie durum sütunu eklenir bu sütunda okunabilir değerler var

                    
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["DurumOrijinal"] != DBNull.Value && row["DurumOrijinal"].ToString() == "1")
                            row["Durum"] = "Müsait";
                        else
                            row["Durum"] = "Ödünçte";
                    }

                    dgvSonuclar.DataSource = dt; //datagridview e sonuçlar yüklenir

                    
                    dgvSonuclar.Columns["Durum"].HeaderText = "Durum"; //durumun sütun başlığı durum olarak ayarlanır

                    
                    if (dgvSonuclar.Columns.Contains("DurumOrijinal"))
                        dgvSonuclar.Columns["DurumOrijinal"].Visible = false; //durumorijinal gizlenir kullanıcı yalnızca okunabilir alanları görür
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
