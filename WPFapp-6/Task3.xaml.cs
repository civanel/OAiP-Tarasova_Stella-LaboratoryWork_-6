using System;
using System.Text;
using System.Windows;
using System.Windows.Media;
namespace WPFapp_6
{
    public partial class Task3 : Window
    {
        public Task3()
        {
            InitializeComponent();
        }
        private void Process_Click(object sender, RoutedEventArgs e)
        {
            tbResult.Text = "";
            tbResult.Foreground = Brushes.Black;
            //проверки на пустоту + числа
            if (string.IsNullOrWhiteSpace(txtM.Text))
            {
                tbResult.Text = "Введите количество строк m";
                return;
            }
            if (string.IsNullOrWhiteSpace(txtK.Text))
            {
                tbResult.Text = "Введите количество столбцов k";
                return;
            }

            if (!int.TryParse(txtM.Text, out int m) || m < 1 || m > 10)
            {
                tbResult.Text = "m должно быть целым числом от 1 до 10!";
                return;
            }

            if (!int.TryParse(txtK.Text, out int k) || k < 1 || k > 20)
            {
                tbResult.Text = "k должно быть целым числом от 1 до 20!";
                return;
            }

            //создание матрицы
            Random rnd = new Random();
            double[,] matrix = new double[m, k];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    matrix[i, j] = Math.Round(rnd.NextDouble() * 20 - 10, 2); //диапазон (-10,10) и округление до 2 знаков
                }
            }
            //оригинальная матрица (вывод)
            StringBuilder sb = new StringBuilder("Оригинальная матрица:\n");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    sb.Append($"{matrix[i, j],8:F2} ");
                }
                sb.AppendLine();
            }
            //отражение по вертикали
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < k / 2; j++)
                {
                    double temp = matrix[i, j];
                    matrix[i, j] = matrix[i, k - 1 - j];
                    matrix[i, k - 1 - j] = temp;
                }
            }
            //итоговый вывод
            sb.AppendLine("\nРезультат отражения по вертикальной оси:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    sb.Append($"{matrix[i, j],8:F2} ");
                }
                sb.AppendLine();
            }
            tbResult.Text = sb.ToString();
            tbResult.Foreground = Brushes.DarkGreen;
        }
    }
}