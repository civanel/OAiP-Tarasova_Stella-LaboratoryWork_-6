using System;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace WPFapp_6
{
    public partial class Task10 : Window
    {
        public Task10()
        {
            InitializeComponent();
        }

        private void Process_Click(object sender, RoutedEventArgs e)
        {
            tbResult.Text = "";
            tbResult.Foreground = Brushes.Black;

            if (string.IsNullOrWhiteSpace(txtN.Text))
            {
                tbResult.Text = "Введите количество команд n!";
                return;
            }

            if (!int.TryParse(txtN.Text, out int n) || n < 2 || n > 10)
            {
                tbResult.Text = "n должно быть целым числом от 2 до 10!";
                return;
            }
            //создание матрицы
            Random rnd = new Random();
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = 0;
                    }
                    else
                    {
                        matrix[i, j] = rnd.Next(0, 3);
                    }
                }
            }
            //вывод матрицы
            StringBuilder sb = new StringBuilder("Таблица чемпионата:\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sb.Append($"{matrix[i, j],2} ");
                }
                sb.AppendLine();
            }
            int teamsWithMoreWins = 0;
            for (int i = 0; i < n; i++)
            {
                int wins = 0;
                int losses = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i == j) continue;
                    if (matrix[i, j] == 2) wins++;
                    if (matrix[i, j] == 0) losses++;
                }
                if (wins > losses) teamsWithMoreWins++;
            }
            sb.AppendLine($"\nКоманд с победами > поражений: {teamsWithMoreWins}");
            //команды без поражений
            sb.AppendLine("\nКоманды без поражений:");
            bool hasNoLoss = false;
            for (int i = 0; i < n; i++)
            {
                bool noLoss = true;
                for (int j = 0; j < n; j++)
                {
                    if (i != j && matrix[i, j] == 0)
                    {
                        noLoss = false;
                        break;
                    }
                }
                if (noLoss)
                {
                    sb.Append($"{i + 1} ");
                    hasNoLoss = true;
                }
            }
            if (!hasNoLoss)
            {
                sb.Append("Нет таких команд");
            }

            tbResult.Text = sb.ToString();
            tbResult.Foreground = Brushes.DarkGreen;
        }
    }
}
