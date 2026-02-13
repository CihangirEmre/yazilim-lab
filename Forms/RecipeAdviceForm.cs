using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using yaz1lab1.Helpers;

namespace yaz1lab1.Forms
{
    public partial class RecipeAdviceForm : Form
    {
        public RecipeAdviceForm()
        {
            InitializeComponent();
            LoadRecipeAdvice();
        }

        private void LoadRecipeAdvice()
        {
            
            List<Tuple<string, bool>> recipeAdvices = AppHelper.RecipeAdvice();

            // DataGridView'i yapılandır
            dgvRecipeAdvice.Columns.Clear();
            dgvRecipeAdvice.Columns.Add("TarifAdi", "Tarif Adı");
            //dgvRecipeAdvice.Columns.Add("YapabilirMi", "Yapılabilir Mi");

            foreach (var recipe in recipeAdvices)
            {
                int rowIndex = dgvRecipeAdvice.Rows.Add(recipe.Item1, recipe.Item2 ? "Evet" : "Hayır");

                // Satır rengini belirle: Yeşil (yapılabilir) veya Kırmızı (yapılamaz)
                dgvRecipeAdvice.Rows[rowIndex].DefaultCellStyle.BackColor = recipe.Item2 ? Color.LightGreen : Color.LightCoral;
            }

            dgvRecipeAdvice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
