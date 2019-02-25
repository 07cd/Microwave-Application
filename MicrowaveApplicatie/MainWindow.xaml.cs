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

namespace MicrowaveApplicatie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int timer = 0;
        public MainWindow()
        {

            InitializeComponent();
            Label.Content = timer;
        }

        private void addTen(object sender, MouseButtonEventArgs e)
        {
            timer += 600;
            Label.Content = timer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addOne(object sender, MouseButtonEventArgs e)
        {
            timer += 60;
            Label.Content = timer;
        }

        private void addHalf(object sender, MouseButtonEventArgs e)
        {
            timer += 30;
            Label.Content = timer;
        }
    }
}
