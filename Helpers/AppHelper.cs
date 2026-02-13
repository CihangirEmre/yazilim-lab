using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace yaz1lab1.Helpers
{
    public static class AppHelper
    {
        private static string connectionString = "Server=DESKTOP-N511VU1\\SQLEXPRESS;Database=RecipesApp;Integrated Security=True;";

        // Tüm tarifleri çeker
        public static List<dynamic> GetAllRecipes()
        {
            List<dynamic> recipes = new List<dynamic>();
            string query = "SELECT t.TarifID, t.TarifAdi, t.HazirlamaSuresi FROM Tarifs t";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tarifId = Convert.ToInt32(reader["TarifID"]);
                            string tarifAdi = reader["TarifAdi"].ToString();
                            int hazirlamaSuresi = Convert.ToInt32(reader["HazirlamaSuresi"]);
                            decimal maliyet = CalCost(tarifId);
                            recipes.Add(new { TarifID = tarifId, TarifAdi = tarifAdi, HazirlamaSuresi = hazirlamaSuresi, Maliyet = maliyet });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata oluştu: " + ex.Message);
                }
            }

            return recipes;
        }

        // Malzemeleri çeker
        public static List<string> GetAllIngredients()
        {
            List<string> ingredients = new List<string>();
            string query = "SELECT MalzemeAdi FROM Malzemes";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ingredients.Add(reader["MalzemeAdi"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata oluştu: " + ex.Message);
                }
            }

            return ingredients;
        }

        // Filtreleri uygular (arama, malzemeye göre filtreleme, yapılabilir tarifler)
        public static List<dynamic> ApplyFilters(string searchText, List<string> selectedIngredients, bool showOnlyProducible, string selectedCategory, decimal minCost, decimal maxCost)
        {
            List<dynamic> filteredRecipes = new List<dynamic>();
            string query = @"
        SELECT t.TarifID, t.TarifAdi, t.HazirlamaSuresi, t.Kategori
        FROM Tarifs t
        JOIN TarifMalzemes tm ON t.TarifID = tm.TarifID
        JOIN Malzemes m ON tm.MalzemeID = m.MalzemeID
        WHERE t.TarifAdi LIKE @SearchText";

            if (selectedIngredients.Count > 0)
            {
                query += " AND m.MalzemeAdi IN (" + string.Join(",", selectedIngredients.Select((s, i) => "@ingredient" + i)) + ")";
            }

            if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "Seçiniz")
            {
                query += " AND t.Kategori = @SelectedCategory";
            }

            if (minCost > 0 && maxCost > 0)
            {
                query += " AND (SELECT SUM(tm.MalzemeMiktar * m.BirimFiyat) FROM TarifMalzemes tm JOIN Malzemes m ON tm.MalzemeID = m.MalzemeID WHERE tm.TarifID = t.TarifID) BETWEEN @MinCost AND @MaxCost";
            }

            query += " GROUP BY t.TarifID, t.TarifAdi, t.HazirlamaSuresi, t.Kategori";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                for (int i = 0; i < selectedIngredients.Count; i++)
                {
                    command.Parameters.AddWithValue("@ingredient" + i, selectedIngredients[i]);
                }

                if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "Seçiniz")
                {
                    command.Parameters.AddWithValue("@SelectedCategory", selectedCategory);
                }

                if (minCost > 0 && maxCost > 0)
                {
                    command.Parameters.AddWithValue("@MinCost", minCost);
                    command.Parameters.AddWithValue("@MaxCost", maxCost);
                }

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tarifId = Convert.ToInt32(reader["TarifID"]);
                            string tarifAdi = reader["TarifAdi"].ToString();
                            int hazirlamaSuresi = Convert.ToInt32(reader["HazirlamaSuresi"]);
                            decimal maliyet = CalCost(tarifId);

                            // Eşleşme yüzdesini hesapla
                            decimal matchPercentage = CalculateMatchPercentage(tarifId, selectedIngredients);

                            // Tarifin yapılabilir olup olmadığını kontrol et
                            bool yapilabilirMi = RecipeAdvice().FirstOrDefault(r => r.Item1 == tarifAdi)?.Item2 ?? true;
                            
                            filteredRecipes.Add(new
                            {
                                TarifID = tarifId,
                                TarifAdi = tarifAdi,
                                HazirlamaSuresi = hazirlamaSuresi,
                                Maliyet = maliyet,
                                MatchPercentage = matchPercentage, 
                                Yapilabilir = yapilabilirMi 
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata oluştu: " + ex.Message);
                }
            }

            return filteredRecipes.OrderByDescending(r => r.MatchPercentage).ToList(); // Eşleşme yüzdesine göre sıralama
        }



        private static decimal CalculateMatchPercentage(int tarifId, List<string> selectedIngredients)
        {
            // Tarifin malzemeleri ile seçilen malzemeler arasındaki eşleşme oranını hesaplar
            decimal matchPercentage = 0;
            int totalIngredients = selectedIngredients.Count;
            int matchingIngredients = 0;
            

            
            string query = "SELECT m.MalzemeAdi FROM TarifMalzemes tm JOIN Malzemes m ON tm.MalzemeID = m.MalzemeID WHERE tm.TarifID = @TarifID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifID", tarifId);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> recipeIngredients = new List<string>();
                        while (reader.Read())
                        {
                            recipeIngredients.Add(reader["MalzemeAdi"].ToString());
                        }

                        // Eşleşen malzemeleri sayalım
                        matchingIngredients = selectedIngredients.Intersect(recipeIngredients).Count();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata oluştu: " + ex.Message);
                }
            }

           
            if (totalIngredients > 0)
            {
                matchPercentage = ((decimal)matchingIngredients / totalIngredients) * 100;
            }

            return matchPercentage;
        }
        // Tarif maliyetini hesaplar
        public static decimal CalCost(int tarifId)
        {
            decimal toplamMaliyet = 0;
            string query = @"
                SELECT SUM(tm.MalzemeMiktar * m.BirimFiyat) AS ToplamMaliyet
                FROM TarifMalzemes tm
                JOIN Malzemes m ON tm.MalzemeID = m.MalzemeID
                WHERE tm.TarifID = @TarifID
                GROUP BY tm.TarifID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifID", tarifId);

                try
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    toplamMaliyet = result != null ? Math.Round(Convert.ToDecimal(result), 2) : 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata oluştu: " + ex.Message);
                }
            }

            return toplamMaliyet;
        }

        // RecipeAdvice algoritması (yapılabilir tarifleri hesaplar)
        public static List<Tuple<string, bool>> RecipeAdvice()
        {
            List<Tuple<string, bool>> recipeAdvices = new List<Tuple<string, bool>>();
            string query = @"
                SELECT t.TarifAdi, 
                    CASE WHEN COUNT(CASE WHEN m.ToplamMiktar < tm.MalzemeMiktar THEN 1 END) > 0 
                    THEN 0 ELSE 1 END AS YapabilirMi
                FROM Tarifs t
                JOIN TarifMalzemes tm ON t.TarifID = tm.TarifID
                JOIN Malzemes m ON tm.MalzemeID = m.MalzemeID
                GROUP BY t.TarifAdi";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tarifAdi = reader["TarifAdi"].ToString();
                            bool yapabilirMi = (int)reader["YapabilirMi"] == 1;
                            recipeAdvices.Add(new Tuple<string, bool>(tarifAdi, yapabilirMi));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata oluştu: " + ex.Message);
                }
            }

            return recipeAdvices;
        }

        // Tarif silme işlemi
        public static void RemoveRecipe(int tarifId)
        {
            string query = "DELETE FROM Tarifs WHERE TarifID = @TarifID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifID", tarifId);
                try
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    command.Transaction = transaction;

                    try
                    {
                        command.ExecuteNonQuery();
                        transaction.Commit(); 
                        Console.WriteLine("Tarif ve ilişkili veriler başarıyla silindi.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); 
                        Console.WriteLine("İşlem sırasında hata oluştu: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata oluştu: " + ex.Message);
                }
            }
        }
        //Kategoriye göre filtreleme
        public static List<string> GetAllCategories()
        {
            List<string> categories = new List<string>();
            string query = "SELECT DISTINCT Kategori FROM Tarifs";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(reader["Kategori"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata oluştu: " + ex.Message);
                }
            }
            return categories;
        }
        //Malzeme sayısına göre filtreleme
        public static List<int> ingredientNumber(int malzemeSayisi) 
        {
            List<int> numForIng = new List<int>();

            string query = @"
        SELECT t.TarifID, t.TarifAdi, COUNT(tm.MalzemeID) AS MalzemeSayisi
        FROM Tarifs t
        JOIN TarifMalzemes tm ON t.TarifID = tm.TarifID
        GROUP BY t.TarifID, t.TarifAdi
        HAVING COUNT(tm.MalzemeID) = @MalzemeSayisi;
    ";
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                SqlCommand command = new SqlCommand(query,connection);
                command.Parameters.AddWithValue("@MalzemeSayisi", malzemeSayisi);

                try 
                {
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tarifId = Convert.ToInt32(reader["TarifID"]);
                            numForIng.Add(tarifId);
                        }
                    }
                }
                catch(Exception ex) 
                {
                    Console.WriteLine("Hata: "+ex.Message);
                }
            }
            return numForIng;
        }
        //Maliyete göre filtreleme
        public static (decimal minCost, decimal maxCost) GetMinMaxCost()
        {
            decimal minCost = 0, maxCost = 0;
            string query = @"
    SELECT MIN(TarifMaliyetleri.Maliyet) AS MinCost, 
           MAX(TarifMaliyetleri.Maliyet) AS MaxCost
    FROM (
        SELECT SUM(tm.MalzemeMiktar * m.BirimFiyat) AS Maliyet
        FROM TarifMalzemes tm
        JOIN Malzemes m ON tm.MalzemeID = m.MalzemeID
        GROUP BY tm.TarifID
    ) AS TarifMaliyetleri";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("MinCost")))
                            {
                                minCost = Convert.ToDecimal(reader.GetDouble(reader.GetOrdinal("MinCost")));
                            }

                            if (!reader.IsDBNull(reader.GetOrdinal("MaxCost")))
                            {
                                maxCost = Convert.ToDecimal(reader.GetDouble(reader.GetOrdinal("MaxCost")));
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata oluştu: " + ex.Message);
                }
            }
            return (minCost, maxCost);
        }

        public static decimal CalMissingIng(int tarifId)
        {
            decimal missingCost = 0;

            string query = @"
        SELECT SUM((tm.MalzemeMiktar - COALESCE(m.ToplamMiktar, 0)) * m.BirimFiyat) AS MissingCost
        FROM TarifMalzemes tm
        JOIN Malzemes m ON tm.MalzemeID = m.MalzemeID
        WHERE tm.TarifID = @TarifID
        AND m.ToplamMiktar < tm.MalzemeMiktar";

            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@TarifID", tarifId);

                try 
                {
                    connection.Open();

                    var result = command.ExecuteScalar();

                    missingCost = result != null ? Math.Round(Convert.ToDecimal(result), 2) : 0;
                }

                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            return missingCost;//Hep sıfır oluyor koda tekrar bak
        }

    }
}
