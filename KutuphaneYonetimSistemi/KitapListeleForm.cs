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
    public partial class KitapListeleForm : Form
    {
        public KitapListeleForm()
        {
            InitializeComponent();
        }

        private void KitapListeleForm_Load(object sender, EventArgs e)
        {
            KitaplariListele();
        }
        private void KitaplariListele()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_KitapListele", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKitaplar.DataSource = dt;

                    dgvKitaplar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  //kolon genişlikleri otomatik
                    dgvKitaplar.ReadOnly = true; //sadece okuma veri düzenlemeyi engelleme
                    dgvKitaplar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//tüm satırlar seçilebilir CellSelect: Bir hücre seçilir.RowHeaderSelect: Sadece satır başlığı seçilir.ColumnHeaderSelect: Sadece sütun başlığı seçilir.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvKitaplar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek bir kitap seçiniz!");
                return;
            }
            
            int kitapID= Convert.ToInt32(dgvKitaplar.SelectedRows[0].Cells["KitapID"].Value); //ilk seçilen satırın ıd değerini kitapID ye ata

            DialogResult dr = MessageBox.Show("Bu kitabı silmek istediğinize emin misiniz?","Kitap sil",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes) //kullanıcı evet derse
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_KitapSil", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    
                    cmd.Parameters.AddWithValue("@KitapID", kitapID);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Kitap başarıyla silindi");
                        KitaplariListele();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if(dgvKitaplar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir kitap seçiniz!");
                return;
            }

            DataGridViewRow row=dgvKitaplar.SelectedRows [0];
            int kitapID = Convert.ToInt32(row.Cells["KitapID"].Value);
            string baslik = row.Cells["Baslik"].Value.ToString();
            int yazarID = Convert.ToInt32(row.Cells["YazarID"].Value);
            string yayinEvi = row.Cells["YayinEvi"].Value.ToString();
            object value = row.Cells["BasimYili"].Value;
            short basimYili = value == DBNull.Value ? (short)0 : Convert.ToInt16(value); //boşsa 0 değilse short

            KitapGuncelleForm form= new KitapGuncelleForm(kitapID,baslik,yazarID,yayinEvi,basimYili);
            form.FormClosed += (s, args) => KitaplariListele();//güncelle formu kapandığında yenileme
            form.ShowDialog(); //form kapanana kadar ana formla etkileşim yok
        }
    }
}
