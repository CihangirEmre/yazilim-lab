namespace yaz1lab1.Forms
{
    partial class RecipeAdviceForm
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
            this.dgvRecipeAdvice = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipeAdvice)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRecipeAdvice
            // 
            this.dgvRecipeAdvice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipeAdvice.Location = new System.Drawing.Point(12, 254);
            this.dgvRecipeAdvice.Name = "dgvRecipeAdvice";
            this.dgvRecipeAdvice.RowHeadersWidth = 51;
            this.dgvRecipeAdvice.RowTemplate.Height = 24;
            this.dgvRecipeAdvice.Size = new System.Drawing.Size(1004, 319);
            this.dgvRecipeAdvice.TabIndex = 0;
            // 
            // RecipeAdviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1028, 585);
            this.Controls.Add(this.dgvRecipeAdvice);
            this.Name = "RecipeAdviceForm";
            this.Text = "RecipeAdvice";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipeAdvice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRecipeAdvice;
    }
}