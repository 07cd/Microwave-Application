using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace MicrowaveApplicatie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Microwave cd07 = new Microwave();
        int Time = 0;
        public int index = 0;
        System.Timers.Timer aTimer = new System.Timers.Timer();
        Watt watt = new Watt();


        public MainWindow()
        {

            InitializeComponent();

            
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;

        }





        private void addTen(object sender, MouseButtonEventArgs e)
        {
            Time += 600;
            Label.Content = Refresh();

        }
        private void addOne(object sender, MouseButtonEventArgs e)
        {
            Time += 60;
            Label.Content = Refresh();
        }

        private void addHalf(object sender, MouseButtonEventArgs e)
        {
            Time += 30;
            Label.Content = Refresh();
        }


        private void startTimer(object sender, RoutedEventArgs e)
        {
            aTimer.Start();
            
        }
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Time--;
            this.Dispatcher.Invoke(() =>
            {
                Label.Content = Refresh();
            });
           
        }

        public string Refresh()
        {
            var timeSpan = TimeSpan.FromSeconds(Time);
            var result = string.Format("{0:D2}:{1:D2}", (int)timeSpan.TotalMinutes, timeSpan.Seconds);
            return result;
        }

        private void stopTimer(object sender, RoutedEventArgs e)
        {
            aTimer.Stop();
            Time = 0;
            Label.Content = Refresh();
        }
        private void pauseTimer(object sender, RoutedEventArgs e)
        {
            aTimer.Stop();
           
        }

        private void wattDown(object sender, RoutedEventArgs e)
        {
            if (index == 0)
            {

            }
            else
            {
                index--;
            }
            Label.Content = watt.Wattage[index];
            int currentWatt = watt.Wattage[index];
            test();

        }

        private void wattUp(object sender, RoutedEventArgs e)
        {
            if (index == 4)
            {

            }
            else
            {
                index++;
            }

            Label.Content = watt.Wattage[index];
            int currentWatt = watt.Wattage[index];
            test();




        }

        private void test()
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                Label.Content = Refresh();
            };
        }


        private void startBot(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Under development");
        }




        private void openMicrowave(object sender, MouseButtonEventArgs e)
        {
            
        }


    }
}
