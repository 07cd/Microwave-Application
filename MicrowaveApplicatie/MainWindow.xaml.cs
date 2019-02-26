using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
//        Microwave cd07 = new Microwave();

        
       Timer tests = new Timer(0);
        
        Watt watt = new Watt(0);






        public MainWindow()
        {

            InitializeComponent();

          

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
                    tests.pauseTimer();
                    MessageBox.Show(sender.ToString());
                    break;
                case "System.Windows.Controls.Button: Start":
                    tests.startTimer();
                    MessageBox.Show(sender.ToString());
                    break;
                case "System.Windows.Controls.Button: Stop":
                    tests.StopTimer();
                    MessageBox.Show(sender.ToString());
                    break;
                case "System.Windows.Controls.Button: Open":
                    MessageBox.Show(sender.ToString());
                    break;



                case "System.Windows.Controls.Button: >":
                    if (watt.index == 4)
                    {

                    }
                    else
                    {
                        watt.index++;

                    }

                    Label.Content = watt.currWatt;
                    //                    int currentWatt = watt.wattage[watt.index];
                    //            test();

                    MessageBox.Show(sender.ToString());
                    break;

                case "System.Windows.Controls.Button: <":
                    if (watt.index == 0)
                    {

                    }
                    else
                    {
                        watt.index--;
                    }

                    Label.Content = watt.currWatt;
                    
                    //            test();

                    MessageBox.Show(sender.ToString());
                    break;
                case "System.Windows.Controls.Button: +1/2":
                    tests.Add(30);
                    Label.Content = tests.TimeString;
                    
                    break;
                case "System.Windows.Controls.Button: +1":
                    tests.Add(60);
                    Label.Content = tests.TimeString;
                    
                    break;
                case "System.Windows.Controls.Button: +10":
                    tests.Add(600);
                    Label.Content = tests.TimeString;
                    
                    break;
                case "System.Windows.Controls.Button: *":
                    MessageBox.Show(sender.ToString());
                    break;
                default:
                    MessageBox.Show("Error");
                    MessageBox.Show(sender.ToString());
                    break;


            }
        }

     


  





    }
}
