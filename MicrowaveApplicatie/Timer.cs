using System;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MicrowaveApplicatie
{
    internal class Timer
    {
        
        private readonly System.Timers.Timer aTimer = new System.Timers.Timer();

        // Boolean to check if timer is running or not
        public bool Enabled;
        // Boolean to check
        public bool wattState;
        // Constructor to set initialtime
        public Timer(int initialTime)
        {
            Time = initialTime;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Interval = 1000;
        }

        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            
            if (Time != 0)
            {
                //MainWindow.Main.Image.Source = new BitmapImage(new Uri("Assets/"));
                Time--;
                // Checks if thread is in use
                if (!MainWindow.Main.Label.Dispatcher.CheckAccess())
                {
                    // Execute this synchronously with the rest of the program
                    MainWindow.Main.Label.Dispatcher.Invoke(() =>
                    {
                        if (!wattState)
                        {
                            MainWindow.Main.Label.Content = TimeString;
                        }
                    });
                }
              
            }
            else
            {
                //Licht uit
            }
          
        }


        public int Time { get; set; }


        public string TimeString
        {
            get
            {
                // Creates a 00:00:00 format with the amount of seconds from time
                var timeSpan = TimeSpan.FromSeconds(Time);
                var result = string.Format("{0:D2}:{1:D2}", (int) timeSpan.TotalMinutes, timeSpan.Seconds);
                return result;
            }
            set => TimeString = value;
        }


        public void StopTimer()
        {
            aTimer.Stop();
            Time = 0;
            Enabled = false;
            MainWindow.Main.Label.Content = TimeString;
        }


        public void pauseTimer()
        {
            aTimer.Stop();
            Enabled = false;
        }


        public void startTimer()
        {
            aTimer.Start();
            Enabled = true;
        }

        // Add amount of seconds
        public void Add(int seconds)
        {
            if (Time + seconds <= 5400)
                switch (seconds)
                {
                    case 600:
                        Time += 600;
                        break;
                    case 60:
                        Time += 60;
                        break;
                    case 30:
                        Time += 30;
                        break;
                    default:
                        Time += 0;
                        break;
                }
        }
    }
}