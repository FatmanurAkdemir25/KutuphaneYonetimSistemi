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
    public partial class IadeForm : Form
    {
        public IadeForm()
        {
            InitializeComponent();
        }

        private void IadeForm_Load(object sender, EventArgs e)
        {
            OduncListesiGetir();
        }
        private void OduncListesiGetir()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        oi.IslemID, 
                        k.Baslik + ' → ' + u.Ad + ' ' + u.Soyad AS Bilgi
                    FROM OduncIslemleri oi
                    INNER JOIN Kitaplar k ON k.KitapID = oi.KitapID
                    INNER JOIN Uyeler u ON u.UyeID = oi.OduncAlanUyeID 
                    WHERE oi.TeslimTarihi IS NULL", conn); //teslim edilmeyenler

                SqlDataAdapter da = new SqlDataAdapter(cmd); //veritabanından veri alma
                DataTable dt = new DataTable(); //verileri tablo şeklinde bellekte saklama
                da.Fill(dt);//da yı çalıştır gelen verileri tabloya oldur

                cmbOduncIslemleri.DataSource = dt; //verikaynağı olarak dt atanıyor yanı bilgiler tablodan alınacak
                cmbOduncIslemleri.DisplayMember = "Bilgi"; //kullanıcıya gösterilen metin
                cmbOduncIslemleri.ValueMember = "IslemID"; //arkaplanda saklanan gerçek değer
            }
        }

        private void btnIadeAl_Click(object sender, EventArgs e)
        {
            if (cmbOduncIslemleri.SelectedValue == null)
            {
                MessageBox.Show("Lütfen iade edilecek kitabı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } //seçildi mi diye kontrol

            int islemID = Convert.ToInt32(cmbOduncIslemleri.SelectedValue); //seçilen kitabın islemıd si alınır

            using (SqlConnection conn = DatabaseHelper.GetConnection())//sql bağlantısı
            {
                SqlCommand cmd = new SqlCommand("sp_KitapIadeAl", conn);//sp çağır
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IslemID", islemID); 

                try
                {
                    conn.Open(); //bağlantıyı aç
                    cmd.ExecuteNonQuery();//sp çalıştır
                    MessageBox.Show("Kitap iade alındı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OduncListesiGetir(); // Listeyi yenile
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
