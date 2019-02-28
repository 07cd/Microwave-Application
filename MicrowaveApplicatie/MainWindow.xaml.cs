using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MicrowaveApplicatie
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
//        Microwave cd07 = new Microwave();

        private readonly Timer _timer = new Timer(0);

        private readonly Watt _watt = new Watt(0);

        private readonly Microwave _microwave = new Microwave();

        internal static MainWindow Main;

        private ObservableCollection<Dish> dish;

        public MainWindow()
        {
            Main = this;
            InitializeComponent();
            DataContext = this;
            InitializeComponent();
            dish = new ObservableCollection<Dish>()
            {
                new Dish("Koffie", "https://www.kahlua.com/globalassets/images/cocktails/2018/opt/kahluadrinks_wide_coffee1.png", "Test"),
                new Dish("Burger", "https://frontierburger.com/sites/default/files/styles/large/public/item_photos/2018-07/menuitem-hamburger.png?itok=QZG0Argx", "Test"),
                new Dish("MicrowaveCeption", "https://thegoodguys.sirv.com/products/50046601/50046601_496424.PNG?scale.height=505&scale.width=773&canvas.height=505&canvas.width=773&canvas.opacity=0&format=png&png.optimize=true","test")

            };
            ComboBox1.ItemsSource = dish;



        }



        private async Task test()
        {
            if (_timer.Enabled)
            {
                Label.Content = _watt.currWatt;
                _timer.wattState = true;
                await Task.Delay(1000);
                _timer.wattState = false;

            }
            else
            {
                Label.Content = _watt.currWatt;
                await Task.Delay(1000);
                Label.Content = _timer.TimeString;
            }

        }


        private void KeyBindings(object sender, RoutedEventArgs e)
        {
            switch (sender.ToString())
            {
                case "System.Windows.Controls.Button: Pause":
                    _timer.pauseTimer();
                    
                    break;
                case "System.Windows.Controls.Button: Start":
                    if (!_microwave.State)
                    {
                        _timer.startTimer();
                    }
                    
                    //Met een lamp aan + animatie?
                    //Image.Source = new BitmapImage(new Uri(@"Assets/"));
                    
                    break;
                case "System.Windows.Controls.Button: Stop":
                    _timer.StopTimer();
                    
                    break;
                case "System.Windows.Controls.Button: Open":
                    _microwave.OpenDoor();

                    _timer.pauseTimer();
                    
                    MicrowaveItem.Opacity = 0.8;
                    break;

                case "System.Windows.Controls.Button: Close":
                    _microwave.CloseDoor();
                    Label.Opacity = 1;
                    MicrowaveItem.Opacity = 0.3;
                    break;

                case "System.Windows.Controls.Button: >":
                    if (_watt.index != 4)
                    {
                        _watt.index++;
                    }


                    test();
                    
                    break;

                case "System.Windows.Controls.Button: <":
                    if (_watt.index != 0)
                    {
                        _watt.index--;
                    }


                    test();


                    break;
                case "System.Windows.Controls.Button: +1/2":
                    _timer.Add(30);
                    Label.Content = _timer.TimeString;

                    break;
                case "System.Windows.Controls.Button: +1":
                    _timer.Add(60);
                    Label.Content = _timer.TimeString;

                    break;
                case "System.Windows.Controls.Button: +10":
                    _timer.Add(600);
                    Label.Content = _timer.TimeString;

                    break;
                case "System.Windows.Controls.Button: *":
                    break;
                default:
                    MessageBox.Show("Error");
                    break;

            }
        }
        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var image = Url.Text;
            var time = Tijd.Text;
            var name = Name.Text;
            
            dish.Add(new Dish(name, image, time));

        }


        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            dish.RemoveAt(ComboBox1.SelectedIndex);
        }

        private void SelectFile_OnClick(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*)|*";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {

                // Open document
                Url.Text = dlg.FileName;
                string filename = dlg.FileName;

            }

        }

        private void ComboBox1_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InsertButton.IsEnabled = true;
            DeleteButton.IsEnabled = true;
        }

//        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
//        {
//
//        }


        private void InsertButton_OnClick(object sender, RoutedEventArgs e)
        {
             Name.Clear();
             Tijd.Clear();
             Url.Clear();

             string URL = dish[ComboBox1.SelectedIndex].URL;
             MicrowaveItem.Source = new BitmapImage(new Uri(URL));           
             MicrowaveItem.Opacity = 0.3;
        }
    }
}
