using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFapp_6
{
    public partial class Task19 : Window
    {
        public Task19()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            tbResult.Text = "";
            tbResult.Foreground = Brushes.Black;

            if (string.IsNullOrWhiteSpace(txtN.Text))
            {
                ShowError("Введите размер массива");
                return;
            }
            if (!int.TryParse(txtN.Text, out int n) || n < 1 || n > 100)
            {
                ShowError("Размер n должен быть числом от 1 до 100");
                return;
            }
            //генерация + вывод оригинального массива 
            Random rnd = new Random();
            double[] array = new double[n];
            StringBuilder sb = new StringBuilder("Оригинальный массив:\n");
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(-10, 11);  // int для простоты
                sb.Append($"{array[i]} ");
            }
            sb.AppendLine("\n\nРезультат обработки:");
            //обработка индексов
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    array[i] = Math.Pow(array[i], 2);
                }
                else
                {
                    array[i] = Math.Pow(array[i], 3);
                }
                sb.Append($"{array[i]} ");//вывод 
            }
            tbResult.Text = sb.ToString();
            tbResult.Foreground = Brushes.DarkGreen;
        }
        private void ShowError(string message)
        {
            tbResult.Text = message;
            tbResult.Foreground = Brushes.DarkRed;
        }
    }
}