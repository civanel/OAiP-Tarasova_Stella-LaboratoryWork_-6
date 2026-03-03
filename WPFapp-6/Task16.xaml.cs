using System;
using System.Windows;
using System.Windows.Media;

namespace WPFapp_6
{
    public partial class Task16 : Window
    {
        public Task16()
        {
            InitializeComponent();
        }
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            tbResult.Text = "";
            tbResult.Foreground = Brushes.Black;

            if (string.IsNullOrWhiteSpace(txtA.Text) || string.IsNullOrWhiteSpace(txtN.Text))
            {
                tbResult.Text = "Заполните оба поля";
                return;
            }

            if (!double.TryParse(txtA.Text, out double a) || a == 0 || a < 1000000)
            {
                tbResult.Text = "a - ненулевое число!";
                return;
            }

            if (!int.TryParse(txtN.Text, out int n) || n < 1)
            {
                tbResult.Text = "n >= 1 и целое!";
                return;
            }

            double sum = 1.0 / a;

            for (int k = 1; k <= n; k++)
            {
                double step = Math.Pow(a, Math.Pow(2, k));

                //проверка на переполнение
                if (double.IsInfinity(step))
                {
                    tbResult.Text = "слишком большое число! Уменьшите a или n";
                    return;
                }
                sum += 1.0 / step;
            }
            tbResult.Text = sum.ToString("F6");
            tbResult.Foreground = Brushes.DarkGreen;
        }
    }
}
