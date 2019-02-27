using System;
using System.Windows;
using System.Windows.Media.Imaging;

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
        }





        //        private void _test()
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
                    break;
                case "System.Windows.Controls.Button: Start":
                    _timer.startTimer();
                    //Met een lamp aan + animatie?
                    Image.Source = new BitmapImage(new Uri(@"Assets/"));
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
    }
}