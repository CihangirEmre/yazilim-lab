using System;

namespace yaz1lab1.Forms
{
    partial class AddRecipeForm
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
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRecipeCategory = new System.Windows.Forms.TextBox();
            this.txtRecipePrepTime = new System.Windows.Forms.TextBox();
            this.txtRecipeIns = new System.Windows.Forms.RichTextBox();
            this.numericUpDownMalzemeSayisi = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRecipeRegistery = new System.Windows.Forms.Button();
            this.flowLayoutPanelMalzemeler = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMalzemeSayisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRecipeName
            // 
            this.txtRecipeName.BackColor = System.Drawing.Color.Moccasin;
            this.txtRecipeName.Location = new System.Drawing.Point(31, 36);
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.Size = new System.Drawing.Size(100, 22);
            this.txtRecipeName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tarif Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kategori";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hazırlanma Süresi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Talimatlar";
            // 
            // txtRecipeCategory
            // 
            this.txtRecipeCategory.BackColor = System.Drawing.Color.Moccasin;
            this.txtRecipeCategory.Location = new System.Drawing.Point(34, 95);
            this.txtRecipeCategory.Name = "txtRecipeCategory";
            this.txtRecipeCategory.Size = new System.Drawing.Size(100, 22);
            this.txtRecipeCategory.TabIndex = 5;
            // 
            // txtRecipePrepTime
            // 
            this.txtRecipePrepTime.BackColor = System.Drawing.Color.Moccasin;
            this.txtRecipePrepTime.Location = new System.Drawing.Point(34, 149);
            this.txtRecipePrepTime.Name = "txtRecipePrepTime";
            this.txtRecipePrepTime.Size = new System.Drawing.Size(100, 22);
            this.txtRecipePrepTime.TabIndex = 6;
            // 
            // txtRecipeIns
            // 
            this.txtRecipeIns.BackColor = System.Drawing.Color.Moccasin;
            this.txtRecipeIns.Location = new System.Drawing.Point(31, 213);
            this.txtRecipeIns.Name = "txtRecipeIns";
            this.txtRecipeIns.Size = new System.Drawing.Size(228, 182);
            this.txtRecipeIns.TabIndex = 8;
            this.txtRecipeIns.Text = "";
            // 
            // numericUpDownMalzemeSayisi
            // 
            this.numericUpDownMalzemeSayisi.BackColor = System.Drawing.Color.PeachPuff;
            this.numericUpDownMalzemeSayisi.Location = new System.Drawing.Point(1029, 36);
            this.numericUpDownMalzemeSayisi.Name = "numericUpDownMalzemeSayisi";
            this.numericUpDownMalzemeSayisi.Size = new System.Drawing.Size(100, 22);
            this.numericUpDownMalzemeSayisi.TabIndex = 9;
            this.numericUpDownMalzemeSayisi.ValueChanged += new System.EventHandler(this.numericUpDownMalzemeSayisi_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1026, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Malzeme Sayısı";
            // 
            // btnRecipeRegistery
            // 
            this.btnRecipeRegistery.BackColor = System.Drawing.Color.MistyRose;
            this.btnRecipeRegistery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRecipeRegistery.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnRecipeRegistery.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRecipeRegistery.ForeColor = System.Drawing.Color.Black;
            this.btnRecipeRegistery.Location = new System.Drawing.Point(660, 494);
            this.btnRecipeRegistery.Name = "btnRecipeRegistery";
            this.btnRecipeRegistery.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRecipeRegistery.Size = new System.Drawing.Size(93, 39);
            this.btnRecipeRegistery.TabIndex = 12;
            this.btnRecipeRegistery.Text = "Tarifi Ekle";
            this.btnRecipeRegistery.UseVisualStyleBackColor = false;
            this.btnRecipeRegistery.Click += new System.EventHandler(this.btnRecipeRegistery_Click);
            // 
            // flowLayoutPanelMalzemeler
            // 
            this.flowLayoutPanelMalzemeler.Location = new System.Drawing.Point(701, 75);
            this.flowLayoutPanelMalzemeler.Name = "flowLayoutPanelMalzemeler";
            this.flowLayoutPanelMalzemeler.Size = new System.Drawing.Size(634, 413);
            this.flowLayoutPanelMalzemeler.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Cornsilk;
            this.pictureBox1.Location = new System.Drawing.Point(12, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(296, 414);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // AddRecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(1347, 545);
            this.Controls.Add(this.flowLayoutPanelMalzemeler);
            this.Controls.Add(this.btnRecipeRegistery);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownMalzemeSayisi);
            this.Controls.Add(this.txtRecipeIns);
            this.Controls.Add(this.txtRecipePrepTime);
            this.Controls.Add(this.txtRecipeCategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRecipeName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AddRecipeForm";
            this.Text = "AddRecipeForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMalzemeSayisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRecipeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRecipeCategory;
        private System.Windows.Forms.TextBox txtRecipePrepTime;
        private System.Windows.Forms.RichTextBox txtRecipeIns;
        private System.Windows.Forms.NumericUpDown numericUpDownMalzemeSayisi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRecipeRegistery;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMalzemeler;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}