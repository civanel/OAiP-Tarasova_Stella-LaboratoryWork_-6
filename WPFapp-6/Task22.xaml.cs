using System.Windows;
using System.Windows.Media;

namespace WPFapp_6
{
    public partial class Task22 : Window
    {
        public Task22()
        {
            InitializeComponent();
        }
        private void Check_Click(object sender, RoutedEventArgs e)
        {
            tbResult.Text = "";
            if (string.IsNullOrEmpty(txtMath.Text) || string.IsNullOrEmpty(txtLit.Text))
            {
                tbResult.Text = "Заполните оценки";
                return;
            }
            if (!int.TryParse(txtMath.Text, out int m) || m < 2 || m > 5)
            {
                tbResult.Text = "Введите корректную оценку";
                tbResult.Foreground = Brushes.DarkRed;
                return;
            }

            if (!int.TryParse(txtLit.Text, out int l) || l < 2 || l > 5)
            {
                tbResult.Text = "Введите корректную оценку";
                tbResult.Foreground = Brushes.DarkRed;
                return;
            }

            double avg = (m + l) / 2.0;
            string res = avg >= 4.5 ? "отлично" :
                         avg >= 3.5 ? "хорошо" :
                         avg >= 3.0 ? "удовлетворительно" :
                         "неудовлетворительно";

            tbResult.Text = $"Средний балл: {avg:F1}, {res}";
            tbResult.Foreground = avg >= 4.0 ? Brushes.DarkGreen : Brushes.OrangeRed;
        }
    }
}
