using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using yaz1lab1.Forms;

namespace yaz1lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Form kenarlığını kaldır ve ekranın ortasında açılmasını sağla
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = false;

            // Timer'ı elle ekleyelim
            timer1 = new Timer();
            timer1.Interval = 1000; // 1 saniye
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop(); // Timer'ı durdur
            this.Hide();   // Form1'i gizle

            MainForm mainForm = new MainForm(); // MainForm aç
            mainForm.Show();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose(); // Tüm bileşenleri temizle
            }
            base.Dispose(disposing); // Formu serbest bırak
        }
    }

}