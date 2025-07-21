using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneYonetimSistemi
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Text = $"Kütüphane Yönetim - {Session.AdSoyad}";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kitapEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new KitapEkleForm().ShowDialog();
        }

        private void kitapListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new KitapListeleForm().ShowDialog();
        }

        private void uyeEkleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new UyeEkleForm().ShowDialog();
        }

        private void oduncVerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new OduncVerForm().ShowDialog();
        }

        private void kitapAraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new KitapAraForm().ShowDialog();
        }

        private void uyeListeleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new UyeListeleForm().ShowDialog();
        }

        private void iadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IadeForm().ShowDialog();
        }

        private void listeleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new RaporForm().ShowDialog();
        }

        private void yazarEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new YazarEkleForm().ShowDialog();
        }

        private void yazarListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new YazarListeleForm().ShowDialog();
        }

        private void kullanıcıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new KullaniciEkleForm().ShowDialog();
        }
    }
}
