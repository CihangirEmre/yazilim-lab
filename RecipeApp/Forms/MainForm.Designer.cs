using System.Drawing;
using System.Windows.Forms;

namespace yaz1lab1.Forms
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRemoveRecipe = new System.Windows.Forms.Button();
            this.btnAddRecipe = new System.Windows.Forms.Button();
            this.dgvRecipes = new System.Windows.Forms.DataGridView();
            this.btnUpdateRecipe = new System.Windows.Forms.Button();
            this.btnRecipeAdvice = new System.Windows.Forms.Button();
            this.cbshowSomeRecipes = new System.Windows.Forms.CheckBox();
            this.txtSearchRecipes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clbMalzeme = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnResetSorting = new System.Windows.Forms.Button();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.cbSection = new System.Windows.Forms.ComboBox();
            this.cbCostRange = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nupMalzemeSayisi = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMalzemeSayisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRemoveRecipe
            // 
            this.btnRemoveRecipe.BackColor = System.Drawing.Color.OrangeRed;
            this.btnRemoveRecipe.Location = new System.Drawing.Point(23, 477);
            this.btnRemoveRecipe.Name = "btnRemoveRecipe";
            this.btnRemoveRecipe.Size = new System.Drawing.Size(118, 39);
            this.btnRemoveRecipe.TabIndex = 0;
            this.btnRemoveRecipe.Text = "Tarif Sil";
            this.btnRemoveRecipe.UseVisualStyleBackColor = false;
            this.btnRemoveRecipe.Click += new System.EventHandler(this.btnRemoveRecipe_Click);
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnAddRecipe.Location = new System.Drawing.Point(23, 349);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.Size = new System.Drawing.Size(118, 35);
            this.btnAddRecipe.TabIndex = 1;
            this.btnAddRecipe.Text = "Tarif Ekle";
            this.btnAddRecipe.UseVisualStyleBackColor = false;
            this.btnAddRecipe.Click += new System.EventHandler(this.btnAddRecipe_Click);
            // 
            // dgvRecipes
            // 
            this.dgvRecipes.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Moccasin;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.SeaGreen;
            this.dgvRecipes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecipes.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipes.GridColor = System.Drawing.Color.Crimson;
            this.dgvRecipes.Location = new System.Drawing.Point(400, 223);
            this.dgvRecipes.Name = "dgvRecipes";
            this.dgvRecipes.RowHeadersWidth = 51;
            this.dgvRecipes.Size = new System.Drawing.Size(879, 576);
            this.dgvRecipes.TabIndex = 2;
            this.dgvRecipes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecipes_CellContentClick);
            // 
            // btnUpdateRecipe
            // 
            this.btnUpdateRecipe.BackColor = System.Drawing.Color.Salmon;
            this.btnUpdateRecipe.Location = new System.Drawing.Point(23, 413);
            this.btnUpdateRecipe.Name = "btnUpdateRecipe";
            this.btnUpdateRecipe.Size = new System.Drawing.Size(118, 42);
            this.btnUpdateRecipe.TabIndex = 3;
            this.btnUpdateRecipe.Text = "Tarif Güncelle";
            this.btnUpdateRecipe.UseVisualStyleBackColor = false;
            this.btnUpdateRecipe.Click += new System.EventHandler(this.btnUpdateRecipe_Click);
            // 
            // btnRecipeAdvice
            // 
            this.btnRecipeAdvice.Location = new System.Drawing.Point(393, 28);
            this.btnRecipeAdvice.Name = "btnRecipeAdvice";
            this.btnRecipeAdvice.Size = new System.Drawing.Size(610, 23);
            this.btnRecipeAdvice.TabIndex = 4;
            this.btnRecipeAdvice.Text = "Tarif Önerisi";
            this.btnRecipeAdvice.UseVisualStyleBackColor = true;
            this.btnRecipeAdvice.Click += new System.EventHandler(this.btnRecipeAdvice_Click);
            // 
            // cbshowSomeRecipes
            // 
            this.cbshowSomeRecipes.AutoSize = true;
            this.cbshowSomeRecipes.Location = new System.Drawing.Point(1031, 802);
            this.cbshowSomeRecipes.Name = "cbshowSomeRecipes";
            this.cbshowSomeRecipes.Size = new System.Drawing.Size(248, 20);
            this.cbshowSomeRecipes.TabIndex = 5;
            this.cbshowSomeRecipes.Text = "Yapılabilir/Yapılamaz Tarfileri Göster";
            this.cbshowSomeRecipes.UseVisualStyleBackColor = true;
            this.cbshowSomeRecipes.CheckedChanged += new System.EventHandler(this.cbshowSomeRecipes_CheckedChanged);
            // 
            // txtSearchRecipes
            // 
            this.txtSearchRecipes.BackColor = System.Drawing.Color.Salmon;
            this.txtSearchRecipes.Location = new System.Drawing.Point(403, 169);
            this.txtSearchRecipes.Name = "txtSearchRecipes";
            this.txtSearchRecipes.Size = new System.Drawing.Size(115, 22);
            this.txtSearchRecipes.TabIndex = 6;
            this.txtSearchRecipes.TextChanged += new System.EventHandler(this.txtSearchRecipes_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(616, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tarif Araması";
            // 
            // clbMalzeme
            // 
            this.clbMalzeme.BackColor = System.Drawing.Color.Tomato;
            this.clbMalzeme.FormattingEnabled = true;
            this.clbMalzeme.Location = new System.Drawing.Point(977, 102);
            this.clbMalzeme.Name = "clbMalzeme";
            this.clbMalzeme.Size = new System.Drawing.Size(302, 106);
            this.clbMalzeme.TabIndex = 8;
            this.clbMalzeme.ThreeDCheckBoxes = true;
            this.clbMalzeme.SelectedIndexChanged += new System.EventHandler(this.clbMalzeme_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1053, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Malzemeye göre arama";
            // 
            // btnResetSorting
            // 
            this.btnResetSorting.BackColor = System.Drawing.Color.PeachPuff;
            this.btnResetSorting.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetSorting.Location = new System.Drawing.Point(400, 802);
            this.btnResetSorting.Name = "btnResetSorting";
            this.btnResetSorting.Size = new System.Drawing.Size(84, 42);
            this.btnResetSorting.TabIndex = 10;
            this.btnResetSorting.Text = "Sıralamayı Sıfırla";
            this.btnResetSorting.UseVisualStyleBackColor = false;
            this.btnResetSorting.Click += new System.EventHandler(this.btnResetSorting_Click);
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.BackColor = System.Drawing.Color.PeachPuff;
            this.btnResetFilters.Location = new System.Drawing.Point(490, 802);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(92, 42);
            this.btnResetFilters.TabIndex = 11;
            this.btnResetFilters.Text = "Filtreleri Sıfırla";
            this.btnResetFilters.UseVisualStyleBackColor = false;
            this.btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // cbSection
            // 
            this.cbSection.BackColor = System.Drawing.Color.MistyRose;
            this.cbSection.FormattingEnabled = true;
            this.cbSection.Location = new System.Drawing.Point(524, 169);
            this.cbSection.Name = "cbSection";
            this.cbSection.Size = new System.Drawing.Size(121, 24);
            this.cbSection.TabIndex = 12;
            this.cbSection.SelectedIndexChanged += new System.EventHandler(this.cbSection_SelectedIndexChanged_1);
            // 
            // cbCostRange
            // 
            this.cbCostRange.BackColor = System.Drawing.Color.MistyRose;
            this.cbCostRange.FormattingEnabled = true;
            this.cbCostRange.Location = new System.Drawing.Point(653, 169);
            this.cbCostRange.Name = "cbCostRange";
            this.cbCostRange.Size = new System.Drawing.Size(121, 24);
            this.cbCostRange.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tarif İsmi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(526, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Katogeri";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(653, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Maliyet";
            // 
            // nupMalzemeSayisi
            // 
            this.nupMalzemeSayisi.BackColor = System.Drawing.Color.LightCoral;
            this.nupMalzemeSayisi.Location = new System.Drawing.Point(781, 168);
            this.nupMalzemeSayisi.Name = "nupMalzemeSayisi";
            this.nupMalzemeSayisi.Size = new System.Drawing.Size(120, 22);
            this.nupMalzemeSayisi.TabIndex = 17;
            this.nupMalzemeSayisi.ValueChanged += new System.EventHandler(this.nupMalzemeSayisi_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(780, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Malzeme Sayısı";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Linen;
            this.pictureBox2.Location = new System.Drawing.Point(12, 271);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(142, 295);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.MintCream;
            this.label7.Location = new System.Drawing.Point(64, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "Menü";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(1838, 924);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nupMalzemeSayisi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbCostRange);
            this.Controls.Add(this.cbSection);
            this.Controls.Add(this.btnResetFilters);
            this.Controls.Add(this.btnResetSorting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clbMalzeme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchRecipes);
            this.Controls.Add(this.cbshowSomeRecipes);
            this.Controls.Add(this.btnRecipeAdvice);
            this.Controls.Add(this.btnUpdateRecipe);
            this.Controls.Add(this.dgvRecipes);
            this.Controls.Add(this.btnAddRecipe);
            this.Controls.Add(this.btnRemoveRecipe);
            this.Controls.Add(this.pictureBox2);
            this.Name = "MainForm";
            this.Text = "Tarifler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMalzemeSayisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveRecipe;
        private System.Windows.Forms.Button btnAddRecipe;
        private System.Windows.Forms.Button btnUpdateRecipe;
        private System.Windows.Forms.Button btnRecipeAdvice;
        private System.Windows.Forms.CheckBox cbshowSomeRecipes;
        private System.Windows.Forms.TextBox txtSearchRecipes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox clbMalzeme;
        private System.Windows.Forms.Label label2;
        private Button btnResetSorting;
        private Button btnResetFilters;
        private ComboBox cbSection;
        private ComboBox cbCostRange;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericUpDown nupMalzemeSayisi;
        private Label label6;
        private PictureBox pictureBox2;
        private Label label7;
    }
}