using RecipesApp.Models;
using System.Data.SqlClient;
using System;
using System.Windows.Forms;
using yaz1lab1.Helpers;

namespace yaz1lab1.Forms
{
    public partial class RecipeDetailsForm : Form
    {
        private Tarif _tarif;

        public RecipeDetailsForm(Tarif tarif)
        {
            InitializeComponent();
            _tarif = tarif;
            DisplayRecipeDetails();
        }
        // Gerekirse malzeme listesi ve diğer detayları ekleyebilirsiniz
        private void DisplayRecipeDetails()
        {
            string connectionString = "Server=DESKTOP-N511VU1\\SQLEXPRESS;Database=RecipesApp;Integrated Security=True;";
            string recipeQuery = "SELECT TarifAdi, Kategori, HazirlamaSuresi, Talimatlar FROM Tarifs WHERE TarifID = @TarifID";
            string ingredientsQuery = "SELECT m.MalzemeAdi, tm.MalzemeMiktar FROM TarifMalzemes tm JOIN Malzemes m ON tm.MalzemeID = m.MalzemeID WHERE tm.TarifID = @TarifID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand recipeCommand = new SqlCommand(recipeQuery, connection);
                recipeCommand.Parameters.AddWithValue("@TarifID", _tarif.TarifID);

                SqlCommand ingredientsCommand = new SqlCommand(ingredientsQuery, connection);
                ingredientsCommand.Parameters.AddWithValue("@TarifID", _tarif.TarifID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = recipeCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblTarifAdi.Text = reader["TarifAdi"].ToString();
                            lblKategori.Text = reader["Kategori"].ToString();
                            lblHazirlamaSuresi.Text = reader["HazirlamaSuresi"].ToString();
                            lblMaliyet.Text = AppHelper.CalCost(_tarif.TarifID).ToString("N2");
                            txtTalimatlar.Text = reader["Talimatlar"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Tarif bulunamadı.");
                        }
                    }

                    using (SqlDataReader ingredientReader = ingredientsCommand.ExecuteReader())
                    {
                        listBoxIngredients.Items.Clear();
                        while (ingredientReader.Read())
                        {
                            string malzemeAdi = ingredientReader["MalzemeAdi"].ToString();
                            string malzemeMiktar = ingredientReader["MalzemeMiktar"].ToString();
                            listBoxIngredients.Items.Add($"{malzemeAdi} - {malzemeMiktar}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message);
                }
            }
        }


    }
}