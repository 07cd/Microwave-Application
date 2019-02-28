using System;
using System.Timers;

namespace MicrowaveApplicatie
{
    internal class Timer
    {
        private readonly System.Timers.Timer aTimer = new System.Timers.Timer();
        public bool Enabled;
        public bool wattState;


        public Timer(int initialTime)
        {
            Time = initialTime;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Interval = 1000;
        }

        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Deur dicht

            if (Time != 0)
            {
                //Licht aan
                Time--;
                if (!MainWindow.Main.Label.Dispatcher.CheckAccess())
                {
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