using System;
using System.Timers;

namespace MicrowaveApplicatie
{
    internal class Timer
    {
        private readonly System.Timers.Timer aTimer = new System.Timers.Timer();


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
                Time--;
                Console.WriteLine(Time);
            }
            else
            {
                Console.WriteLine(Time);
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
            Console.WriteLine(Time);
        }

        public void pauseTimer()
        {
            aTimer.Stop();
            Console.WriteLine(Time);
        }

        public void startTimer()
        {
            aTimer.Start();
            Console.WriteLine(Time);
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