namespace yaz1lab1.Forms
{
    partial class UpdateRecipeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMalzemeler = new System.Windows.Forms.Label();
            this.boxTalimatlar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.boxTarifAdı = new System.Windows.Forms.TextBox();
            this.boxKategori = new System.Windows.Forms.TextBox();
            this.boxHazırlamaSuresi = new System.Windows.Forms.TextBox();
            this.btnSaveRecipe = new System.Windows.Forms.Button();
            this.btnCancelUpdate = new System.Windows.Forms.Button();
            this.flowLayoutPanelMalzemeler = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tarif Adı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kategori :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hazırlanma Suresi (dk) :";
            // 
            // lblMalzemeler
            // 
            this.lblMalzemeler.AutoSize = true;
            this.lblMalzemeler.Location = new System.Drawing.Point(694, 23);
            this.lblMalzemeler.Name = "lblMalzemeler";
            this.lblMalzemeler.Size = new System.Drawing.Size(77, 16);
            this.lblMalzemeler.TabIndex = 4;
            this.lblMalzemeler.Text = "Malzemeler";
            // 
            // boxTalimatlar
            // 
            this.boxTalimatlar.BackColor = System.Drawing.Color.Linen;
            this.boxTalimatlar.Location = new System.Drawing.Point(30, 195);
            this.boxTalimatlar.Multiline = true;
            this.boxTalimatlar.Name = "boxTalimatlar";
            this.boxTalimatlar.Size = new System.Drawing.Size(250, 186);
            this.boxTalimatlar.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Talimatlar :";
            // 
            // boxTarifAdı
            // 
            this.boxTarifAdı.BackColor = System.Drawing.Color.Linen;
            this.boxTarifAdı.Location = new System.Drawing.Point(96, 23);
            this.boxTarifAdı.Name = "boxTarifAdı";
            this.boxTarifAdı.Size = new System.Drawing.Size(114, 22);
            this.boxTarifAdı.TabIndex = 7;
            // 
            // boxKategori
            // 
            this.boxKategori.BackColor = System.Drawing.Color.Linen;
            this.boxKategori.Location = new System.Drawing.Point(96, 76);
            this.boxKategori.Name = "boxKategori";
            this.boxKategori.Size = new System.Drawing.Size(114, 22);
            this.boxKategori.TabIndex = 8;
            // 
            // boxHazırlamaSuresi
            // 
            this.boxHazırlamaSuresi.BackColor = System.Drawing.Color.Linen;
            this.boxHazırlamaSuresi.Location = new System.Drawing.Point(181, 120);
            this.boxHazırlamaSuresi.Name = "boxHazırlamaSuresi";
            this.boxHazırlamaSuresi.Size = new System.Drawing.Size(114, 22);
            this.boxHazırlamaSuresi.TabIndex = 9;
            // 
            // btnSaveRecipe
            // 
            this.btnSaveRecipe.Location = new System.Drawing.Point(859, 466);
            this.btnSaveRecipe.Name = "btnSaveRecipe";
            this.btnSaveRecipe.Size = new System.Drawing.Size(75, 23);
            this.btnSaveRecipe.TabIndex = 10;
            this.btnSaveRecipe.Text = "Kaydet";
            this.btnSaveRecipe.UseVisualStyleBackColor = true;
            this.btnSaveRecipe.Click += new System.EventHandler(this.btnSaveRecipe_Click);
            // 
            // btnCancelUpdate
            // 
            this.btnCancelUpdate.Location = new System.Drawing.Point(12, 466);
            this.btnCancelUpdate.Name = "btnCancelUpdate";
            this.btnCancelUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnCancelUpdate.TabIndex = 11;
            this.btnCancelUpdate.Text = "İptal";
            this.btnCancelUpdate.UseVisualStyleBackColor = true;
            this.btnCancelUpdate.Click += new System.EventHandler(this.btnCancelUpdate_Click);
            // 
            // flowLayoutPanelMalzemeler
            // 
            this.flowLayoutPanelMalzemeler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelMalzemeler.AutoScroll = true;
            this.flowLayoutPanelMalzemeler.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMalzemeler.Location = new System.Drawing.Point(517, 54);
            this.flowLayoutPanelMalzemeler.Name = "flowLayoutPanelMalzemeler";
            this.flowLayoutPanelMalzemeler.Size = new System.Drawing.Size(421, 406);
            this.flowLayoutPanelMalzemeler.TabIndex = 12;
            // 
            // UpdateRecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(950, 503);
            this.Controls.Add(this.flowLayoutPanelMalzemeler);
            this.Controls.Add(this.btnCancelUpdate);
            this.Controls.Add(this.btnSaveRecipe);
            this.Controls.Add(this.boxHazırlamaSuresi);
            this.Controls.Add(this.boxKategori);
            this.Controls.Add(this.boxTarifAdı);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.boxTalimatlar);
            this.Controls.Add(this.lblMalzemeler);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UpdateRecipeForm";
            this.Text = "UpdateRecipeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMalzemeler;
        private System.Windows.Forms.TextBox boxTalimatlar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox boxTarifAdı;
        private System.Windows.Forms.TextBox boxKategori;
        private System.Windows.Forms.TextBox boxHazırlamaSuresi;
        private System.Windows.Forms.Button btnSaveRecipe;
        private System.Windows.Forms.Button btnCancelUpdate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMalzemeler;
    }
}