namespace KutuphaneYonetimSistemi
{
    partial class MainForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kitaplarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kitapEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kitapListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kitapAraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.üyelerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uyeEkleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uyeListeleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ödünçİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oduncVerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iadeadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeleToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.yazarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ekleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcılarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcıEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.kitaplarToolStripMenuItem,
            this.üyelerToolStripMenuItem,
            this.ödünçİşlemleriToolStripMenuItem,
            this.yazarlarToolStripMenuItem,
            this.kullanıcılarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.çıkışToolStripMenuItem});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // kitaplarToolStripMenuItem
            // 
            this.kitaplarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kitapEkleToolStripMenuItem,
            this.kitapListeleToolStripMenuItem,
            this.kitapAraToolStripMenuItem});
            this.kitaplarToolStripMenuItem.Name = "kitaplarToolStripMenuItem";
            this.kitaplarToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.kitaplarToolStripMenuItem.Text = "Kitaplar";
            // 
            // kitapEkleToolStripMenuItem
            // 
            this.kitapEkleToolStripMenuItem.Name = "kitapEkleToolStripMenuItem";
            this.kitapEkleToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.kitapEkleToolStripMenuItem.Text = "Ekle";
            this.kitapEkleToolStripMenuItem.Click += new System.EventHandler(this.kitapEkleToolStripMenuItem_Click);
            // 
            // kitapListeleToolStripMenuItem
            // 
            this.kitapListeleToolStripMenuItem.Name = "kitapListeleToolStripMenuItem";
            this.kitapListeleToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.kitapListeleToolStripMenuItem.Text = "Listele";
            this.kitapListeleToolStripMenuItem.Click += new System.EventHandler(this.kitapListeleToolStripMenuItem_Click);
            // 
            // kitapAraToolStripMenuItem
            // 
            this.kitapAraToolStripMenuItem.Name = "kitapAraToolStripMenuItem";
            this.kitapAraToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.kitapAraToolStripMenuItem.Text = "Ara";
            this.kitapAraToolStripMenuItem.Click += new System.EventHandler(this.kitapAraToolStripMenuItem_Click);
            // 
            // üyelerToolStripMenuItem
            // 
            this.üyelerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uyeEkleToolStripMenuItem1,
            this.uyeListeleToolStripMenuItem1});
            this.üyelerToolStripMenuItem.Name = "üyelerToolStripMenuItem";
            this.üyelerToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.üyelerToolStripMenuItem.Text = "Üyeler";
            // 
            // uyeEkleToolStripMenuItem1
            // 
            this.uyeEkleToolStripMenuItem1.Name = "uyeEkleToolStripMenuItem1";
            this.uyeEkleToolStripMenuItem1.Size = new System.Drawing.Size(134, 26);
            this.uyeEkleToolStripMenuItem1.Text = "Ekle";
            this.uyeEkleToolStripMenuItem1.Click += new System.EventHandler(this.uyeEkleToolStripMenuItem1_Click);
            // 
            // uyeListeleToolStripMenuItem1
            // 
            this.uyeListeleToolStripMenuItem1.Name = "uyeListeleToolStripMenuItem1";
            this.uyeListeleToolStripMenuItem1.Size = new System.Drawing.Size(134, 26);
            this.uyeListeleToolStripMenuItem1.Text = "Listele";
            this.uyeListeleToolStripMenuItem1.Click += new System.EventHandler(this.uyeListeleToolStripMenuItem1_Click);
            // 
            // ödünçİşlemleriToolStripMenuItem
            // 
            this.ödünçİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oduncVerToolStripMenuItem,
            this.iadeadeToolStripMenuItem,
            this.listeleToolStripMenuItem2});
            this.ödünçİşlemleriToolStripMenuItem.Name = "ödünçİşlemleriToolStripMenuItem";
            this.ödünçİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.ödünçİşlemleriToolStripMenuItem.Text = "Ödünç İşlemleri";
            // 
            // oduncVerToolStripMenuItem
            // 
            this.oduncVerToolStripMenuItem.Name = "oduncVerToolStripMenuItem";
            this.oduncVerToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.oduncVerToolStripMenuItem.Text = "Ver";
            this.oduncVerToolStripMenuItem.Click += new System.EventHandler(this.oduncVerToolStripMenuItem_Click);
            // 
            // iadeadeToolStripMenuItem
            // 
            this.iadeadeToolStripMenuItem.Name = "iadeadeToolStripMenuItem";
            this.iadeadeToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.iadeadeToolStripMenuItem.Text = "İade";
            this.iadeadeToolStripMenuItem.Click += new System.EventHandler(this.iadeToolStripMenuItem_Click);
            // 
            // listeleToolStripMenuItem2
            // 
            this.listeleToolStripMenuItem2.Name = "listeleToolStripMenuItem2";
            this.listeleToolStripMenuItem2.Size = new System.Drawing.Size(134, 26);
            this.listeleToolStripMenuItem2.Text = "Listele";
            this.listeleToolStripMenuItem2.Click += new System.EventHandler(this.listeleToolStripMenuItem2_Click);
            // 
            // yazarlarToolStripMenuItem
            // 
            this.yazarlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ekleToolStripMenuItem,
            this.listeleToolStripMenuItem});
            this.yazarlarToolStripMenuItem.Name = "yazarlarToolStripMenuItem";
            this.yazarlarToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.yazarlarToolStripMenuItem.Text = "Yazarlar";
            // 
            // ekleToolStripMenuItem
            // 
            this.ekleToolStripMenuItem.Name = "ekleToolStripMenuItem";
            this.ekleToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.ekleToolStripMenuItem.Text = "Yazar Ekle";
            this.ekleToolStripMenuItem.Click += new System.EventHandler(this.yazarEkleToolStripMenuItem_Click);
            // 
            // listeleToolStripMenuItem
            // 
            this.listeleToolStripMenuItem.Name = "listeleToolStripMenuItem";
            this.listeleToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.listeleToolStripMenuItem.Text = "Yazar Listele";
            this.listeleToolStripMenuItem.Click += new System.EventHandler(this.yazarListeleToolStripMenuItem_Click);
            // 
            // kullanıcılarToolStripMenuItem
            // 
            this.kullanıcılarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kullanıcıEkleToolStripMenuItem});
            this.kullanıcılarToolStripMenuItem.Name = "kullanıcılarToolStripMenuItem";
            this.kullanıcılarToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.kullanıcılarToolStripMenuItem.Text = "Kullanıcılar";
            // 
            // kullanıcıEkleToolStripMenuItem
            // 
            this.kullanıcıEkleToolStripMenuItem.Name = "kullanıcıEkleToolStripMenuItem";
            this.kullanıcıEkleToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.kullanıcıEkleToolStripMenuItem.Text = "Kullanıcı Ekle";
            this.kullanıcıEkleToolStripMenuItem.Click += new System.EventHandler(this.kullanıcıEkleToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kitaplarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kitapEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kitapListeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kitapAraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem üyelerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uyeEkleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem uyeListeleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ödünçİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oduncVerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iadeadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeleToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem yazarlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ekleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullanıcılarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullanıcıEkleToolStripMenuItem;
    }
}

