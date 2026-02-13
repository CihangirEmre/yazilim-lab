using RecipesApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace yaz1lab1.Forms
{
    public partial class UpdateRecipeForm : Form
    {
        private Tarif _tarif;
        private List<ComboBox> malzemeComboBoxes = new List<ComboBox>();
        private List<TextBox> malzemeMiktarTextBoxes = new List<TextBox>();
        private List<Button> malzemeSilButtons = new List<Button>();

        public UpdateRecipeForm(Tarif tarif)
        {
            InitializeComponent();
            _tarif = tarif;
            LoadRecipeDetails();
            LoadRecipeIngredients();
        }

        // Tarif bilgilerini TextBox'lara yükler
        private void LoadRecipeDetails()
        {
            string connectionString = "Server=DESKTOP-N511VU1\\SQLEXPRESS;Database=RecipesApp;Integrated Security=True;";
            string showRecipeQuery = "SELECT TarifAdi, Kategori, HazirlamaSuresi, Talimatlar FROM Tarifs WHERE TarifID = @TarifID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(showRecipeQuery, connection);
                command.Parameters.AddWithValue("@TarifID", _tarif.TarifID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            boxTarifAdı.Text = reader["TarifAdi"].ToString();
                            boxKategori.Text = reader["Kategori"].ToString();
                            boxHazırlamaSuresi.Text = reader["HazirlamaSuresi"].ToString();
                            boxTalimatlar.Text = reader["Talimatlar"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Tarif bulunamadı.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası.", ex.Message);
                }
            }
        }

        // Tarif malzemelerini ekrana yükler
        private void LoadRecipeIngredients()
        {
            string connectionString = "Server=DESKTOP-N511VU1\\SQLEXPRESS;Database=RecipesApp;Integrated Security=True;";
            string getIngredientsQuery = "SELECT m.MalzemeID, m.MalzemeAdi, tm.MalzemeMiktar FROM TarifMalzemes tm JOIN Malzemes m ON tm.MalzemeID = m.MalzemeID WHERE tm.TarifID = @TarifID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(getIngredientsQuery, connection);
                command.Parameters.AddWithValue("@TarifID", _tarif.TarifID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        flowLayoutPanelMalzemeler.Controls.Clear();
                        malzemeComboBoxes.Clear();
                        malzemeMiktarTextBoxes.Clear();
                        malzemeSilButtons.Clear();

                        while (reader.Read())
                        {
                            ComboBox cbMalzeme = new ComboBox { Text = reader["MalzemeAdi"].ToString(), Width = 150 };
                            TextBox txtMalzemeMiktar = new TextBox { Text = reader["MalzemeMiktar"].ToString(), Width = 60 };
                            Button btnSil = new Button { Text = "Sil", Width = 60 };

                            int selectedMalzemeID = (int)reader["MalzemeID"];
                            LoadMalzemelerToComboBox(cbMalzeme, selectedMalzemeID);
                            
                            malzemeComboBoxes.Add(cbMalzeme);
                            malzemeMiktarTextBoxes.Add(txtMalzemeMiktar);
                            malzemeSilButtons.Add(btnSil);

                            btnSil.Click += (s, ev) => SilMalzeme(cbMalzeme, txtMalzemeMiktar);

                            flowLayoutPanelMalzemeler.Controls.Add(new Label { Text = "Malzeme:", AutoSize = true });
                            flowLayoutPanelMalzemeler.Controls.Add(cbMalzeme);
                            flowLayoutPanelMalzemeler.Controls.Add(new Label { Text = "Miktar:", AutoSize = true });
                            flowLayoutPanelMalzemeler.Controls.Add(txtMalzemeMiktar);
                            flowLayoutPanelMalzemeler.Controls.Add(btnSil);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası.", ex.Message);
                }
            }
        }


        // Malzemeleri ComboBox'a yükler
        private void LoadMalzemelerToComboBox(ComboBox comboBox, int? selectedMalzemeID = null)
        {
            using (var context = new TarifDbContext())
            {
                // Malzemeleri veritabanından çekiyoruz
                var malzemeler = context.Malzemeler
                    .Select(m => new { MalzemeID = m.MalzemeID, MalzemeAdi = m.MalzemeAdi })
                    .ToList();

                // BindingSource kullanarak veriyi ComboBox'a bağlıyoruz
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = malzemeler;
                comboBox.DataSource = bindingSource;
                comboBox.DisplayMember = "MalzemeAdi";
                comboBox.ValueMember = "MalzemeID";

                // Seçili malzemeyi belirlemek için SelectedValueChanged olayını kullanıyoruz
                comboBox.SelectedValueChanged += (s, e) =>
                {
                    if (selectedMalzemeID.HasValue)
                    {
                        comboBox.SelectedValue = selectedMalzemeID;
                    }
                };

                // Eğer `selectedMalzemeID` null değilse seçili hale getir
                if (selectedMalzemeID.HasValue)
                {
                    comboBox.SelectedValue = selectedMalzemeID;
                }
            }
        }






        // Sil butonuna basıldığında malzemeyi kaldırır
        private void SilMalzeme(ComboBox cbMalzeme, TextBox txtMiktar)
        {
            int selectedMalzemeId = (int)cbMalzeme.SelectedValue;
            string deleteIngredientQuery = "DELETE FROM TarifMalzemes WHERE TarifID = @TarifID AND MalzemeID = @MalzemeID";

            using (var connection = new SqlConnection("Server=DESKTOP-N511VU1\\SQLEXPRESS;Database=RecipesApp;Integrated Security=True;"))
            {
                SqlCommand command = new SqlCommand(deleteIngredientQuery, connection);
                command.Parameters.AddWithValue("@TarifID", _tarif.TarifID);
                command.Parameters.AddWithValue("@MalzemeID", selectedMalzemeId);

                connection.Open();
                command.ExecuteNonQuery();

                flowLayoutPanelMalzemeler.Controls.Remove(cbMalzeme);
                flowLayoutPanelMalzemeler.Controls.Remove(txtMiktar);
                flowLayoutPanelMalzemeler.Controls.Remove(malzemeSilButtons[malzemeComboBoxes.IndexOf(cbMalzeme)]);
                malzemeComboBoxes.Remove(cbMalzeme);
                malzemeMiktarTextBoxes.Remove(txtMiktar);
            }
        }

        private void btnYeniMalzemeEkle_Click(object sender, EventArgs e)
        {
            ComboBox cbMalzeme = new ComboBox { Width = 150 };
            TextBox txtMiktar = new TextBox { Width = 60 };

            LoadMalzemelerToComboBox(cbMalzeme);

            malzemeComboBoxes.Add(cbMalzeme);
            malzemeMiktarTextBoxes.Add(txtMiktar);

            flowLayoutPanelMalzemeler.Controls.Add(new Label { Text = "Malzeme:", AutoSize = true });
            flowLayoutPanelMalzemeler.Controls.Add(cbMalzeme);
            flowLayoutPanelMalzemeler.Controls.Add(new Label { Text = "Miktar:", AutoSize = true });
            flowLayoutPanelMalzemeler.Controls.Add(txtMiktar);
        }

        // Tarif ve malzeme güncelleme işlemi
        private void btnSaveRecipe_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                string connectionString = "Server=DESKTOP-N511VU1\\SQLEXPRESS;Database=RecipesApp;Integrated Security=True;";
                string updateRecipeQuery = "UPDATE Tarifs SET TarifAdi = @TarifAdi, Kategori = @Kategori, HazirlamaSuresi = @HazirlamaSuresi, Talimatlar = @Talimatlar WHERE TarifID = @TarifID";
                string updateIngredientQuery = "UPDATE TarifMalzemes SET MalzemeMiktar = @MalzemeMiktar WHERE TarifID = @TarifID AND MalzemeID = (SELECT MalzemeID FROM Malzemes WHERE MalzemeAdi = @MalzemeAdi)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand updateRecipeCommand = new SqlCommand(updateRecipeQuery, connection);
                    updateRecipeCommand.Parameters.AddWithValue("@TarifID", _tarif.TarifID);
                    updateRecipeCommand.Parameters.AddWithValue("@TarifAdi", boxTarifAdı.Text);
                    updateRecipeCommand.Parameters.AddWithValue("@Kategori", boxKategori.Text);
                    updateRecipeCommand.Parameters.AddWithValue("@HazirlamaSuresi", decimal.Parse(boxHazırlamaSuresi.Text));
                    updateRecipeCommand.Parameters.AddWithValue("@Talimatlar", boxTalimatlar.Text);

                    try
                    {
                        connection.Open();
                        updateRecipeCommand.ExecuteNonQuery();

                        // Malzeme miktarlarını güncelle
                        for (int i = 0; i < malzemeComboBoxes.Count; i++)
                        {
                            if (malzemeComboBoxes[i].SelectedValue is int malzemeID)
                            {
                                SqlCommand updateIngredientCommand = new SqlCommand(updateIngredientQuery, connection);
                                updateIngredientCommand.Parameters.AddWithValue("@TarifID", _tarif.TarifID);
                                updateIngredientCommand.Parameters.AddWithValue("@MalzemeAdi", malzemeComboBoxes[i].Text);
                                updateIngredientCommand.Parameters.AddWithValue("@MalzemeMiktar", decimal.Parse(malzemeMiktarTextBoxes[i].Text));
                                updateIngredientCommand.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Tarif başarıyla güncellendi.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Güncelleme işlemi başarısız oldu: " + ex.Message);
                    }
                }
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(boxTarifAdı.Text) ||
                string.IsNullOrWhiteSpace(boxKategori.Text) ||
                string.IsNullOrWhiteSpace(boxHazırlamaSuresi.Text) ||
                string.IsNullOrWhiteSpace(boxTalimatlar.Text))
            {
                MessageBox.Show("Tüm alanları doldurmalısınız.");
                return false;
            }

            if (!decimal.TryParse(boxHazırlamaSuresi.Text, out _))
            {
                MessageBox.Show("Hazırlama süresi yalnızca sayısal bir değer olmalıdır.");
                return false;
            }

            foreach (var txtMiktar in malzemeMiktarTextBoxes)
            {
                if (string.IsNullOrWhiteSpace(txtMiktar.Text) || !decimal.TryParse(txtMiktar.Text, out _))
                {
                    MessageBox.Show("Malzeme miktarları yalnızca sayısal değer olmalıdır ve boş olamaz.");
                    return false;
                }
            }
            return true;
        }

        private void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Yaptığınız değişiklikler kaydedilmeyecek. Güncellemeyi iptal etmek istediğinizden emin misiniz?",
                                 "Güncellemeyi İptal Et",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Kullanıcı "Evet" derse, formu kapat
                this.Close();
            }
            // Eğer kullanıcı "Hayır" derse, form açık kalır ve kullanıcı değişiklikleri kaydetmeye devam edebilir

        }
    }
}
