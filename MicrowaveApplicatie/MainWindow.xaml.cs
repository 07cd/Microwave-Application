using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
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

        



        public MainWindow()
        {
            Main = this;
            InitializeComponent();
            DataContext = this;
            InitializeComponent();
            person = new ObservableCollection<Dish>()
            {


            };
            ComboBox1.ItemsSource = null;
            //            ComboBox1.ItemsSource = Dish.GetAllPersons();



        }








        //        private void test()
        //        {
        //            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
        //            timer.Start();
        //            timer.Tick += (sender, args) =>
        //            {
        //                timer.Stop();
        //        
        //            };
        //        }


        private void KeyBindings(object sender, RoutedEventArgs e)
        {
            switch (sender.ToString())
            {
                case "System.Windows.Controls.Button: Pause":
                    _timer.pauseTimer();
                    MessageBox.Show(sender.ToString());
                    break;
                case "System.Windows.Controls.Button: Start":
                    _timer.startTimer();
                    //Met een lamp aan + animatie?
                    //Image.Source = new BitmapImage(new Uri(@"Assets/"));
                    
                    break;
                case "System.Windows.Controls.Button: Stop":
                    _timer.StopTimer();
                    
                    break;
                case "System.Windows.Controls.Button: Open":
                    _microwave.OpenDoor();
                    break;

                case "System.Windows.Controls.Button: Close":
                    _microwave.CloseDoor();
                    break;

                case "System.Windows.Controls.Button: >":
                    if (_watt.index == 4)
                    {
                    }
                    else
                    {
                        _watt.index++;
                    }

                    Label.Content = _watt.currWatt;
                    //                    int currentWatt = _watt.Wattage[_watt.index];
                    //            _test();

                    break;

                case "System.Windows.Controls.Button: <":
                    if (_watt.index == 0)
                    {
                    }
                    else
                    {
                        _watt.index--;
                    }

                    Label.Content = _watt.currWatt;

                    //            _test();

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
            var name = TextBox1.Text;
            ComboBox1.ItemsSource = person;
            person.Add(new Dish(name, image, time));
            //            cbItems.Add(new ComboBoxItem {Content = Test.ToString()});
            //            cbItems.Add(new ComboBoxItem { Content = Test });
            //
            //
            //
            //            var cbItem = new ComboBoxItem { Content = "<--Select-->" };
            //            SelectedcbItem = cbItem;
            //            cbItems.Add(cbItem);
            //            cbItems.Add(new ComboBoxItem { Content = "Option 1" });
            //            cbItems.Add(new ComboBoxItem { Content = "Option 2" });
            //   





            //            MessageBox.Show($"Image URL: {image} Time: {time} Name: {name}");
            //            if (TextBox1.Text != "")
            //            {
            //                D
            //
            //               
            //                cbItems.Add(new ComboBoxItem());
            //                
            //            }
        }


        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            person.RemoveAt(ComboBox1.SelectedIndex);

            //            ItemsControl.ItemsSourceProperty
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
            //            var selectedItem = sender as ComboBox;
            //            string name = selectedItem.SelectedItem.ToString();
            //            MessageBox.Show(name);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }









    }
}
