using System.Windows;
using System.Windows.Media;

namespace WPFapp_6
{
    public partial class Task7 : Window
    {
        public Task7()
        {
            InitializeComponent();
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            tbResult.Text = "";
            tbResult.Foreground = Brushes.Black;

            //проверки пустоты
            if (string.IsNullOrWhiteSpace(txtFirst.Text))
            {
                tbResult.Text = "Введите левую границу";
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSecond.Text))
            {
                tbResult.Text = "Введите правую границу";
                return;
            }
            if (string.IsNullOrWhiteSpace(txtValue.Text))
            {
                tbResult.Text = "Введите число для проверки";
                return;
            }

            //проверки чисел
            if (!double.TryParse(txtFirst.Text, out double first))
            {
                tbResult.Text = "Левая граница должна быть числом";
                return;
            }
            if (!double.TryParse(txtSecond.Text, out double second))
            {
                tbResult.Text = "Правая граница должна быть числом";
                return;
            }
            if (!double.TryParse(txtValue.Text, out double value))
            {
                tbResult.Text = "введено некорректное число!";
                return;
            }
            //поверка на first <= second
            if (first > second)
            {
                tbResult.Text = "Левая граница должна быть <= правой";
                return;
            }
            //метод RangeCheck
            bool inRange = value >= first && value <= second;
            tbResult.Text = inRange ? $"Число {value} принадлежит диапазону [{first}, {second}]" : $"Число {value} не принадлежит диапазону [{first}, {second}]";
            tbResult.Foreground = inRange ? Brushes.DarkGreen : Brushes.DarkRed;
        }
    }
}
