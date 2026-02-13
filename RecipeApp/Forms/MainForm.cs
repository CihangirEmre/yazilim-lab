using RecipesApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using yaz1lab1.Helpers;

namespace yaz1lab1.Forms
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.DataGridView dgvRecipes;

        public MainForm()
        {
            InitializeComponent();
            
        }

        // Form yüklendiğinde kullanıcının karşısına çıkanlar
        private void MainForm_Load(object sender, EventArgs e)
        {
            AddMisCostColumn();
            dgvRecipes.ColumnHeaderMouseClick += dgvRecipes_ColumnHeaderMouseClick;
            cbCostRange.SelectedIndexChanged += cbCostRange_SelectedIndexChanged;
            LoadRecipes();
            LoadIngredients();
            LoadKatogeriToCombobox();
            LoadCostRangesToCombobox();
        }

        private void LoadKatogeriToCombobox()
        {
            cbSection.Items.Clear();
            cbSection.Items.Add("Seçiniz");

            var categories = AppHelper.GetAllCategories();
            foreach (var category in categories)
            {
                cbSection.Items.Add(category);
            }

            cbSection.SelectedIndex = 0;
        }

        // Tüm tarifleri yükler (varsayılan listeleme)
        public void LoadRecipes()
        {
            var tarifler = AppHelper.GetAllRecipes();
            if (tarifler == null || tarifler.Count == 0)
            {
                MessageBox.Show("Hiçbir tarif bulunamadı.");
            }
            else
            {
                DisplayRecipes(tarifler);
            }
        }

        // Tarifleri görüntüler ve checkbox durumuna göre renklendirir
        private void DisplayRecipes(List<dynamic> recipes)
        {
            dgvRecipes.DataSource = null;

            // Eğer "MatchPercentage" sütununa göre sıralamak isteniyorsa
            if (recipes.Count > 0 && recipes.First().GetType().GetProperty("MatchPercentage") != null)
            {
                // MatchPercentage değerine göre büyükten küçüğe sıralıyoruz
                recipes = recipes.OrderByDescending(r => r.MatchPercentage).ToList();
            }

            // Veri kaynağını güncelle
            dgvRecipes.DataSource = recipes;

            if (recipes.Count > 0)
            {
                dgvRecipes.Columns["TarifID"].Visible = false;
                dgvRecipes.Columns["Maliyet"].HeaderText = "Maliyet";

                if (dgvRecipes.Columns.Contains("MatchPercentage"))
                {
                    dgvRecipes.Columns["MatchPercentage"].HeaderText = "Eşleşme Yüzdesi";
                }

                if (dgvRecipes.Columns.Contains("Yapilabilir"))
                {
                    dgvRecipes.Columns["Yapilabilir"].Visible = false;

                    foreach (DataGridViewRow row in dgvRecipes.Rows)
                    {
                        bool yapilabilirMi = Convert.ToBoolean(row.Cells["Yapilabilir"].Value);
                        decimal gerekenMaliyet = 0;

                        // Eğer tarif yapılamazsa eksik malzeme maliyetini hesapla ve renklendir
                        if (!yapilabilirMi)
                        {
                            int tarifId = Convert.ToInt32(row.Cells["TarifID"].Value);
                            gerekenMaliyet = AppHelper.CalMissingIng(tarifId);  // Eksik malzeme maliyetini hesapla
                            row.Cells["GerekenMaliyet"].Value = gerekenMaliyet;
                            row.DefaultCellStyle.BackColor = Color.Red; // Yapılamayan tarif kırmızıya boyanır
                        }
                        else
                        {
                            row.Cells["GerekenMaliyet"].Value = DBNull.Value; // Yapılabilen tarifler için eksik maliyet yok
                            row.DefaultCellStyle.BackColor = Color.LightGreen; // Yapılabilen tarif yeşile boyanır
                        }

                        // Checkbox false ise tüm renkleri varsayılan beyaz olarak ayarla
                        if (!cbshowSomeRecipes.Checked)
                        {
                            row.DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                }
            }
        }



        private void dgvRecipes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dgvRecipes.Columns[e.ColumnIndex].Name;
            bool ascending = true; // Varsayılan olarak artan sıralama

            if (dgvRecipes.Tag != null && dgvRecipes.Tag.ToString() == columnName)
            {
                ascending = false; // Aynı sütuna tıklarsak tersine sıralama yap
            }

            SortRecipes(columnName, ascending);

            dgvRecipes.Tag = ascending ? columnName : ""; // Sıralama yönünü kaydediyoruz
        }

        private void SortRecipes(string columnName, bool ascending)
        {
            List<dynamic> recipes = (List<dynamic>)dgvRecipes.DataSource;

            switch (columnName)
            {
                case "HazirlamaSuresi":
                    if (ascending)
                        recipes = recipes.OrderBy(r => r.HazirlamaSuresi).ToList();
                    else
                        recipes = recipes.OrderByDescending(r => r.HazirlamaSuresi).ToList();
                    break;

                case "Maliyet":
                    if (ascending)
                        recipes = recipes.OrderBy(r => r.Maliyet).ToList();
                    else
                        recipes = recipes.OrderByDescending(r => r.Maliyet).ToList();
                    break;

                default:
                    break;
            }

            DisplayRecipes(recipes);
        }

        // Filtreleri uygular (arama, malzeme filtreleme ve yapılabilir tarifler)
        private void ApplyFilters()
        {
            var searchText = txtSearchRecipes.Text;
            var selectedIngredients = clbMalzeme.CheckedItems.Cast<string>().ToList();
            bool showOnlyProducible = cbshowSomeRecipes.Checked;
            string selectedCategory = cbSection.SelectedItem.ToString() ?? "Seçiniz";
            

            string selectedCostRange = cbCostRange.SelectedItem != null ? cbCostRange.SelectedItem.ToString() : "Seçiniz";
            decimal minCost = 0, maxCost = 0;
            if (selectedCostRange != "Seçiniz")
            {
                var costRangeParts = selectedCostRange.Split('-');
                minCost = decimal.Parse(costRangeParts[0]);
                maxCost = decimal.Parse(costRangeParts[1]);
            }

            int selectedMalzemeSayisi = (int)nupMalzemeSayisi.Value;
            List<int> tarifIds = AppHelper.ingredientNumber(selectedMalzemeSayisi);

            var filteredRecipes = AppHelper.ApplyFilters(searchText, selectedIngredients, showOnlyProducible, selectedCategory, minCost, maxCost);
            
            if(selectedMalzemeSayisi > 0)
            {
                filteredRecipes = filteredRecipes.Where(r => tarifIds.Contains((int)r.TarifID)).ToList();
            }
            else
            {
                //Tasarımı hoş bir mesaj gönder bu malzeme sayısında tarif olmadığına dair
            }
            
            DisplayRecipes(filteredRecipes);
        }

        // Malzemeleri CheckBoxList'e yükler
        private void LoadIngredients()
        {
            var malzemeler = AppHelper.GetAllIngredients();
            foreach (var malzeme in malzemeler)
            {
                clbMalzeme.Items.Add(malzeme);
            }
        }

        // Her bir harf girişinde filtreleme yapar
        private void txtSearchRecipes_TextChanged(object sender, EventArgs e)
        {
            txtSearchRecipes.Text = new string(txtSearchRecipes.Text.Where(char.IsLetter).ToArray());
            txtSearchRecipes.SelectionStart = txtSearchRecipes.Text.Length;
            ApplyFilters();
        }

        // Checkbox değiştiğinde tarifleri filtreler ve renklendirme durumunu kontrol eder
        private void cbshowSomeRecipes_CheckedChanged(object sender, EventArgs e)
        {
            dgvRecipes.Columns["GerekenMaliyet"].Visible = cbshowSomeRecipes.Checked;
            ApplyFilters();  // Tarife göre filtreleri uygular ve renklendirme durumunu günceller
        }

        // Malzemeye göre filtreleme yapar
        private void clbMalzeme_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                ApplyFilters();
            });
        }

        // Seçili tarifi silme işlemi
        private void btnRemoveRecipe_Click(object sender, EventArgs e)
        {
            if (dgvRecipes.SelectedRows.Count > 0)
            {
                int selectedTarifId = (int)dgvRecipes.SelectedRows[0].Cells["TarifID"].Value;
                AppHelper.RemoveRecipe(selectedTarifId);
                LoadRecipes();
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz bir tarifi seçin.");
            }
        }

        // Tarif güncelleme işlemi
        private void btnUpdateRecipe_Click(object sender, EventArgs e)
        {
            if (dgvRecipes.SelectedRows.Count > 0)
            {
                int selectedTarifId = (int)dgvRecipes.SelectedRows[0].Cells["TarifID"].Value;
                showUpdateRecipe(selectedTarifId);
            }
        }

        // Tarif güncelleme formunu açar
        private void showUpdateRecipe(int tarifId)
        {
            using (TarifDbContext context = new TarifDbContext())
            {
                var tarif = context.Tarifler.Find(tarifId);
                if (tarif != null)
                {
                    UpdateRecipeForm updateRecipeForm = new UpdateRecipeForm(tarif);
                    updateRecipeForm.FormClosed += (s, args) => LoadRecipes();
                    updateRecipeForm.ShowDialog();
                }
            }
        }

        // MainForm kapanınca uygulama kapatma
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Tarif ekleme işlemi
        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            AddRecipeForm addRecipeForm = new AddRecipeForm();
            if (addRecipeForm.ShowDialog() == DialogResult.OK)
            {
                LoadRecipes();
            }
        }

        // Tarif önerisi işlemi
        private void btnRecipeAdvice_Click(object sender, EventArgs e)
        {
            RecipeAdviceForm recipeAdviceForm = new RecipeAdviceForm();
            recipeAdviceForm.ShowDialog();
        }

        // Tarif detayları
        private void dgvRecipes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedTarifId = (int)dgvRecipes.Rows[e.RowIndex].Cells["TarifID"].Value;
                ShowRecipeDetails(selectedTarifId);
            }
        }

        private void ShowRecipeDetails(int tarifId)
        {
            using (TarifDbContext context = new TarifDbContext())
            {
                var tarif = context.Tarifler.Find(tarifId);
                if (tarif != null)
                {
                    RecipeDetailsForm detailsForm = new RecipeDetailsForm(tarif);
                    detailsForm.ShowDialog();
                }
            }
        }

        private void btnResetSorting_Click(object sender, EventArgs e)
        {
            LoadRecipes();
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            txtSearchRecipes.Clear();//Tarifi isim ile arama sıfırla

            if (cbSection.Items.Count > 0) { cbSection.SelectedIndex = 0; }//Kategoriye göre aramayı sıfırla

            for (int i = 0; i < clbMalzeme.Items.Count; i++) { clbMalzeme.SetItemChecked(i, false); }//malzemeye göre aramayı sıfırla
            
            cbshowSomeRecipes.Checked = false;//Tarif Önerisi metodunu durdur

            LoadRecipes();//Bütün tarifleri listeye yükle
        }

        private void cbSection_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void nupMalzemeSayisi_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void LoadCostRangesToCombobox()
        {
            cbCostRange.Items.Clear();
            cbCostRange.Items.Add("Seçiniz");

            var (minCost, maxCost) = AppHelper.GetMinMaxCost();

            decimal rangeStep = 100;
            for (decimal currentCost = minCost; currentCost <= maxCost; currentCost += rangeStep)
            {
                decimal nextCost = currentCost + rangeStep;
                cbCostRange.Items.Add($"{currentCost}-{nextCost}");
            }

            cbCostRange.SelectedIndex = 0;
        }

        private void cbCostRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCostRange.SelectedItem != null && cbCostRange.SelectedItem.ToString() != "Seçiniz")
            {
                string selectedCostRange = cbCostRange.SelectedItem.ToString();
                decimal minCost = 0, maxCost = 0;
                var costRangeParts = selectedCostRange.Split('-');
                minCost = decimal.Parse(costRangeParts[0]);
                maxCost = decimal.Parse(costRangeParts[1]);

                // Uygulama filtrelerini maliyete göre uygula
                ApplyFilters();
            }
            else
            {
                LoadRecipes();
            }
        }

        private void AddMisCostColumn()
        {
            if (!dgvRecipes.Columns.Contains("GerekenMaliyet"))
            {
                DataGridViewTextBoxColumn missingCostColumn = new DataGridViewTextBoxColumn();
                missingCostColumn.Name = "GerekenMaliyet";
                missingCostColumn.HeaderText = "Gereken Maliyet";
                missingCostColumn.Visible = false;
                dgvRecipes.Columns.Add(missingCostColumn);
            }
        }

    }
}
