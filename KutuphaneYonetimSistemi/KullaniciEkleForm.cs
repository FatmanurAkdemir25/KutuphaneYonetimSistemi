using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneYonetimSistemi
{
    public partial class KullaniciEkleForm : Form
    {
        public KullaniciEkleForm()
        {
            InitializeComponent();  //form tasarımını başlatır
        }
        private byte[] HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        //geri dönüş tipi byte[] olan hashlama

        private void KullaniciEkleForm_Load(object sender, EventArgs e)
        {
            txtParola.UseSystemPasswordChar = true; //txtParola da gizli karakter aktif hale getirildi
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string parola = txtParola.Text.Trim();
            //textbox tan veriler alınır ve boşluklar trim() ile temizlenir


            if (string.IsNullOrWhiteSpace(kullaniciAdi) ||
                string.IsNullOrWhiteSpace(ad) ||
                string.IsNullOrWhiteSpace(soyad) ||
                string.IsNullOrWhiteSpace(parola))
            {
                lblMesaj.Text = "Tüm alanları doldurun.";
                return;
            }
            //herhangi bir alan boş bırakılırsa durdur

            byte[] hashedPassword = HashPassword(parola); //hashedPassword metodu çağrılır

            using (SqlConnection conn = DatabaseHelper.GetConnection()) //veritabanı bağlantısını al
            using (SqlCommand cmd = new SqlCommand("sp_KullaniciEkle_Hash", conn))  //sp yi çağır
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                cmd.Parameters.AddWithValue("@Ad", ad);
                cmd.Parameters.AddWithValue("@Soyad", soyad);
                cmd.Parameters.Add("@ParolaHash", SqlDbType.VarBinary, 32).Value = hashedPassword;
                //parametreleri ekle

                try
                {
                    conn.Open();  //bağlantı açılır
                    cmd.ExecuteNonQuery();  //sp çalıştırılır
                    lblMesaj.Text = "Kullanıcı başarıyla eklendi.";
                    Temizle();  //başarılıysa mesajı yazdır formu temizle
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);  //başarısızsa hatayı yazdır
                }
            }
        }
        private void Temizle()  //formdaki tüm alanları temizler
        {
            txtKullaniciAdi.Clear();
            txtAd.Clear();
            txtSoyad.Clear();
            txtParola.Clear();
        }
    }
}
