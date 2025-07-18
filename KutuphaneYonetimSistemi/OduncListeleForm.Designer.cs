namespace KutuphaneYonetimSistemi
{
    partial class OduncListeleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OduncListeleForm));
            this.dgvOdunc = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdunc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOdunc
            // 
            this.dgvOdunc.BackgroundColor = System.Drawing.Color.RosyBrown;
            this.dgvOdunc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOdunc.Location = new System.Drawing.Point(58, 49);
            this.dgvOdunc.Name = "dgvOdunc";
            this.dgvOdunc.RowHeadersWidth = 51;
            this.dgvOdunc.RowTemplate.Height = 24;
            this.dgvOdunc.Size = new System.Drawing.Size(694, 362);
            this.dgvOdunc.TabIndex = 0;
            // 
            // OduncListeleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvOdunc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OduncListeleForm";
            this.Text = "OduncListeleForm";
            this.Load += new System.EventHandler(this.OduncListeleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdunc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOdunc;
    }
}