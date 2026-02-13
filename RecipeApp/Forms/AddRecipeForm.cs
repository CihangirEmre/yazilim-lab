using RecipesApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yaz1lab1.Forms
{
    public partial class AddRecipeForm : Form
    {
        private List<ComboBox> malzemeComboBoxes = new List<ComboBox>();
        private List<TextBox> malzemeMiktarTextBoxes = new List<TextBox>();

        public AddRecipeForm()
        {
            InitializeComponent();
        }

        private void numericUpDownMalzemeSayisi_ValueChanged(object sender, EventArgs e)
        {
            // Mevcut malzeme giriş alanlarını temizle
            flowLayoutPanelMalzemeler.Controls.Clear();
            malzemeComboBoxes.Clear();
            malzemeMiktarTextBoxes.Clear();

            int malzemeSayisi = (int)numericUpDownMalzemeSayisi.Value;

            for (int i = 0; i < malzemeSayisi; i++)
            {
                // Malzeme ComboBox ve Miktar TextBox oluşturma
                Label lblMalzeme = new Label { Text = $"Malzeme {i + 1}:", AutoSize = true };
                ComboBox cbMalzeme = new ComboBox { Width = 150 };
                Button btnYeniMalzeme = new Button { Text = "Yeni Ekle", Width = 80 };
                Label lblMiktar = new Label { Text = $"Miktar {i + 1}:", AutoSize = true };
                TextBox txtMalzemeMiktar = new TextBox { Width = 60 };

                // Var olan malzemeleri doldur
                LoadMalzemeler(cbMalzeme);

                // Yeni malzeme ekleme butonu olayı
                btnYeniMalzeme.Click += (s, ev) => YeniMalzemeEkle();

                malzemeComboBoxes.Add(cbMalzeme);
                malzemeMiktarTextBoxes.Add(txtMalzemeMiktar);

                // FlowLayoutPanel'e ekleyin
                flowLayoutPanelMalzemeler.Controls.Add(lblMalzeme);
                flowLayoutPanelMalzemeler.Controls.Add(cbMalzeme);
                flowLayoutPanelMalzemeler.Controls.Add(btnYeniMalzeme);
                flowLayoutPanelMalzemeler.Controls.Add(lblMiktar);
                flowLayoutPanelMalzemeler.Controls.Add(txtMalzemeMiktar);
            }
        }

        // Var olan malzemeleri ComboBox'a yükleyen fonksiyon
        private void LoadMalzemeler(ComboBox comboBox)
        {
            using (var context = new TarifDbContext())
            {
                var malzemeler = context.Malzemeler.Select(m => new { m.MalzemeID, m.MalzemeAdi }).ToList();
                comboBox.DataSource = malzemeler;
                comboBox.DisplayMember = "MalzemeAdi";
                comboBox.ValueMember = "MalzemeID";
            }
        }

        // Yeni malzeme ekleme işlemi
        private void YeniMalzemeEkle()
        {
            var (malzemeAdi, birimFiyat, malzemeBirim, toplamMiktar) = Prompt.ShowDialog("Yeni Malzeme Bilgilerini Girin:", "Yeni Malzeme Ekle");

            if (string.IsNullOrWhiteSpace(malzemeAdi))
            {
                // Eğer malzeme adı boşsa kayıt işlemi yapmadan geri dön
                //MessageBox.Show("Malzeme adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new TarifDbContext())
            {
                var existingMalzeme = context.Malzemeler.FirstOrDefault(m => m.MalzemeAdi == malzemeAdi);
                if (existingMalzeme == null)
                {
                    var newMalzeme = new Malzeme {
                        MalzemeAdi = malzemeAdi,
                        ToplamMiktar = toplamMiktar,
                        MalzemeBirim = malzemeBirim,
                        BirimFiyat = birimFiyat
                    };
                    context.Malzemeler.Add(newMalzeme);
                    context.SaveChanges();
                    MessageBox.Show("Malzeme başarıyla eklendi.","Bildiri",MessageBoxButtons.OK,MessageBoxIcon.Information);//İncele!!

                    // Yeni malzeme eklendiği için tüm ComboBox'ları güncelle
                    foreach (var cb in malzemeComboBoxes)
                    {
                        LoadMalzemeler(cb);
                    }
                }
                else
                {
                    MessageBox.Show("Bu malzeme zaten mevcut.");
                }
            }
        }

        private void btnRecipeRegistery_Click(object sender, EventArgs e)
        {
            using (var context = new TarifDbContext()) 
            {
                using (var transaction = context.Database.BeginTransaction()) 
                {
                    try
                    {
                        // Tarif ekleme işlemi
                        string InsertRecipeQuery = "INSERT INTO Tarifs(TarifAdi, Kategori, HazirlamaSuresi, Talimatlar) OUTPUT INSERTED.TarifID VALUES (@TarifAdi, @Kategori, @HazirlamaSuresi, @Talimatlar)";
                        var tarifAdiParameter = new SqlParameter("@TarifAdi", txtRecipeName.Text);
                        var tarifKatogeriParameter = new SqlParameter("@Kategori", txtRecipeCategory.Text);
                        var tarifHazirlanmaSuresiParameter = new SqlParameter("@HazirlamaSuresi", int.Parse(txtRecipePrepTime.Text));
                        var tarifTalimatlarParameter = new SqlParameter("@Talimatlar", txtRecipeIns.Text);

                        int newTarifId = context.Database.SqlQuery<int>(InsertRecipeQuery, tarifAdiParameter, tarifKatogeriParameter, tarifHazirlanmaSuresiParameter, tarifTalimatlarParameter).FirstOrDefault();

                        // Malzeme ekleme işlemi
                        string InsertIngredientQuery = "INSERT INTO TarifMalzemes (TarifID, MalzemeID, MalzemeMiktar) VALUES (@TarifID, @MalzemeID, @MalzemeMiktar)";

                        for (int i = 0; i < malzemeComboBoxes.Count; i++)
                        {
                            int malzemeID = (int)malzemeComboBoxes[i].SelectedValue;
                            decimal malzemeMiktar = decimal.Parse(malzemeMiktarTextBoxes[i].Text);

                            context.Database.ExecuteSqlCommand(InsertIngredientQuery,
                                new SqlParameter("@TarifID", newTarifId),
                                new SqlParameter("@MalzemeID", malzemeID),
                                new SqlParameter("@MalzemeMiktar", malzemeMiktar));
                        }

                        transaction.Commit();
                        MessageBox.Show("Tarif başarıyla kayıt edildi.");

                        Temizle();

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Tarif kayıt işlemi başarısız oldu: " + ex.Message);
                    }
                }
            }
        }

        private void Temizle()
        {
            // Metin kutularını temizle
            txtRecipeName.Clear();
            txtRecipeCategory.Clear();
            txtRecipePrepTime.Clear();
            txtRecipeIns.Clear();

            // NumericUpDown'u sıfırla
            numericUpDownMalzemeSayisi.Value = 0;

            // FlowLayoutPanel'deki bileşenleri temizle
            flowLayoutPanelMalzemeler.Controls.Clear();
        }
    }

    // Kullanıcıdan giriş almak için yardımcı sınıf
    public static class Prompt
    {
        public static (string malzemeAdi, decimal birimFiyat, string malzemeBirim, string toplamMiktar) ShowDialog(string text, string caption)
        {
            Form prompt = new Form() { Width = 400, Height = 300, Text = caption };

            // Malzeme Adı Girişi
            Label lblMalzemeAdi = new Label() { Left = 20, Top = 20, Text = "Malzeme Adı:", AutoSize = true };
            TextBox txtMalzemeAdi = new TextBox() { Left = 150, Top = 20, Width = 200 };

            // Birim Fiyat Girişi
            Label lblBirimFiyat = new Label() { Left = 20, Top = 60, Text = "Birim Fiyat:", AutoSize = true };
            TextBox txtBirimFiyat = new TextBox() { Left = 150, Top = 60, Width = 200 };

            // Malzeme Birimi Girişi
            Label lblMalzemeBirim = new Label() { Left = 20, Top = 100, Text = "Malzeme Birimi:", AutoSize = true };
            TextBox txtMalzemeBirim = new TextBox() { Left = 150, Top = 100, Width = 200 };

            // Toplam Miktar Girişi
            Label lblToplamMiktar = new Label() { Left = 20, Top = 140, Text = "Toplam Miktar:", AutoSize = true };
            TextBox txtToplamMiktar = new TextBox() { Left = 150, Top = 140, Width = 200 };

            // Onay Butonu
            Button confirmation = new Button() { Text = "OK", Left = 250, Width = 100, Top = 180 };
            confirmation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(lblMalzemeAdi);
            prompt.Controls.Add(txtMalzemeAdi);
            prompt.Controls.Add(lblBirimFiyat);
            prompt.Controls.Add(txtBirimFiyat);
            prompt.Controls.Add(lblMalzemeBirim);
            prompt.Controls.Add(txtMalzemeBirim);
            prompt.Controls.Add(lblToplamMiktar);
            prompt.Controls.Add(txtToplamMiktar);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            prompt.ShowDialog();

            // Dönüş verisi
            decimal birimFiyat = decimal.TryParse(txtBirimFiyat.Text, out var bf) ? bf : 0;
            return (txtMalzemeAdi.Text, birimFiyat, txtMalzemeBirim.Text, txtToplamMiktar.Text);
        }


    }

    


}
