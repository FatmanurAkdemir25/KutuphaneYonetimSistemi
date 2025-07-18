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
            //kullanıcı adı ve şifre alınır

            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(parola)) //boş alan kontrolü
            {
                lblMesaj.Text = "Kullanıcı adı ve parola boş olamaz.";
                return;
            }
            byte[] hashedPassword = HashPassword(parola); //kullanıcının girdiği şifre hashlanir

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_KullaniciGirisKontrol", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@KullaniciAdi", txtKullaniciAdi.Text);
                cmd.Parameters.AddWithValue("@Parola", hashedPassword);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();  //sp çalışır ve kayıt varsa satır döner

                    if (reader.Read())
                    {
                        Session.KullaniciID = reader.GetInt32(0);
                        Session.AdSoyad = $"{reader.GetString(1)} {reader.GetString(2)}";

                        this.Hide();
                        new MainForm().Show(); //login form gizlenir main form açılır
                    }
                    else
                    {
                        lblMesaj.Text = "Geçersiz kullanıcı adı veya şifre!";
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

