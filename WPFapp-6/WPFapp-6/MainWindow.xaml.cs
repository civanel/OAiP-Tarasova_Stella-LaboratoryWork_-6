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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFapp_6
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenTask22(object sender, RoutedEventArgs e) => new Task22().Show();
        private void OpenTask16(object sender, RoutedEventArgs e) => new Task16().Show();
        private void OpenTask19(object sender, RoutedEventArgs e) => new Task19().Show();
        private void OpenTask10(object sender, RoutedEventArgs e) => new Task10().Show();
        private void OpenTask3(object sender, RoutedEventArgs e) => new Task3().Show();
        private void OpenTask7(object sender, RoutedEventArgs e) => new Task7().Show();
    }
}
