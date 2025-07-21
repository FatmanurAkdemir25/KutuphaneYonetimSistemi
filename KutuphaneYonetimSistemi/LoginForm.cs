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
using System.Security.Cryptography;


namespace KutuphaneYonetimSistemi
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private byte[] HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));  //ComputeHash UTF-8 byte dizisini SHA256 ile 32 byte uzunluğunda hash'e çevirir
            }
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtParola.UseSystemPasswordChar = true; //karakterleri gizli gösterir
        }

        private void lblMesaj_Click(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string parola = txtParola.Text;

            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(parola))
            {
                lblMesaj.Text = "Kullanıcı adı ve parola boş olamaz.";
                return;
            }

            byte[] hashedPassword = HashPassword(parola);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand("sp_KullaniciGirisKontrol", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // AddWithValue yerine tip belirterek eklemek daha güvenli
                cmd.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar, 50).Value = kullaniciAdi;
                cmd.Parameters.Add("@Parola", SqlDbType.VarBinary, 32).Value = hashedPassword;

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //int kullaniciID = (int)reader["KullaniciID"];
                           //string ad = reader["Ad"].ToString();
                           // string soyad = reader["Soyad"].ToString();  bu da doğru bir kullanım ancak aşağıdaki göntem daha hızlı. aşağıda index numarasına döre 
                            int kullaniciID = reader.GetInt32(0);
                            string ad = reader.GetString(1);
                            string soyad = reader.GetString(2);

                            Session.KullaniciID = kullaniciID;
                            Session.AdSoyad = $"{ad} {soyad}";

                            this.Hide();
                            new MainForm().Show(); 
                        }
                        else
                        {
                            lblMesaj.Text = "Geçersiz kullanıcı adı veya şifre!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
    }
}

