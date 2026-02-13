namespace yaz1lab1.Forms
{
    partial class RecipeDetailsForm
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
            this.lblTarifAdi = new System.Windows.Forms.Label();
            this.lblKategori = new System.Windows.Forms.Label();
            this.lblHazirlamaSuresi = new System.Windows.Forms.Label();
            this.txtTalimatlar = new System.Windows.Forms.TextBox();
            this.listBoxIngredients = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaliyet = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTarifAdi
            // 
            this.lblTarifAdi.AutoSize = true;
            this.lblTarifAdi.Location = new System.Drawing.Point(12, 9);
            this.lblTarifAdi.Name = "lblTarifAdi";
            this.lblTarifAdi.Size = new System.Drawing.Size(60, 16);
            this.lblTarifAdi.TabIndex = 3;
            this.lblTarifAdi.Text = "Tarif Adı:";
            // 
            // lblKategori
            // 
            this.lblKategori.AutoSize = true;
            this.lblKategori.Location = new System.Drawing.Point(12, 40);
            this.lblKategori.Name = "lblKategori";
            this.lblKategori.Size = new System.Drawing.Size(60, 16);
            this.lblKategori.TabIndex = 2;
            this.lblKategori.Text = "Kategori:";
            // 
            // lblHazirlamaSuresi
            // 
            this.lblHazirlamaSuresi.AutoSize = true;
            this.lblHazirlamaSuresi.Location = new System.Drawing.Point(12, 70);
            this.lblHazirlamaSuresi.Name = "lblHazirlamaSuresi";
            this.lblHazirlamaSuresi.Size = new System.Drawing.Size(112, 16);
            this.lblHazirlamaSuresi.TabIndex = 1;
            this.lblHazirlamaSuresi.Text = "Hazırlama Süresi:";
            // 
            // txtTalimatlar
            // 
            this.txtTalimatlar.BackColor = System.Drawing.Color.DarkSalmon;
            this.txtTalimatlar.Location = new System.Drawing.Point(12, 130);
            this.txtTalimatlar.Multiline = true;
            this.txtTalimatlar.Name = "txtTalimatlar";
            this.txtTalimatlar.ReadOnly = true;
            this.txtTalimatlar.Size = new System.Drawing.Size(237, 129);
            this.txtTalimatlar.TabIndex = 0;
            this.txtTalimatlar.Text = "Tarif Talimatları:";
            // 
            // listBoxIngredients
            // 
            this.listBoxIngredients.BackColor = System.Drawing.Color.DarkSalmon;
            this.listBoxIngredients.FormattingEnabled = true;
            this.listBoxIngredients.ItemHeight = 16;
            this.listBoxIngredients.Location = new System.Drawing.Point(431, 47);
            this.listBoxIngredients.Name = "listBoxIngredients";
            this.listBoxIngredients.Size = new System.Drawing.Size(247, 212);
            this.listBoxIngredients.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(522, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Malzemeler";
            // 
            // lblMaliyet
            // 
            this.lblMaliyet.AutoSize = true;
            this.lblMaliyet.Location = new System.Drawing.Point(12, 98);
            this.lblMaliyet.Name = "lblMaliyet";
            this.lblMaliyet.Size = new System.Drawing.Size(53, 16);
            this.lblMaliyet.TabIndex = 6;
            this.lblMaliyet.Text = "Maliyet:";
            // 
            // RecipeDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(690, 272);
            this.Controls.Add(this.lblMaliyet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxIngredients);
            this.Controls.Add(this.txtTalimatlar);
            this.Controls.Add(this.lblHazirlamaSuresi);
            this.Controls.Add(this.lblKategori);
            this.Controls.Add(this.lblTarifAdi);
            this.Name = "RecipeDetailsForm";
            this.Text = "RecipeDetailsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTarifAdi;
        private System.Windows.Forms.Label lblKategori;
        private System.Windows.Forms.Label lblHazirlamaSuresi;
        private System.Windows.Forms.TextBox txtTalimatlar;
        private System.Windows.Forms.ListBox listBoxIngredients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaliyet;
    }
}