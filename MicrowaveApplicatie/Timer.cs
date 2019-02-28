using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MicrowaveApplicatie
{

    class Timer
    {
        System.Timers.Timer aTimer = new System.Timers.Timer();


        public Timer(int initialTime)
        {
            Time = initialTime;
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            
        }

        public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
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
                var result = string.Format("{0:D2}:{1:D2}", (int)timeSpan.TotalMinutes, timeSpan.Seconds);
                return result;
            }
            set { TimeString = value; }
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
            if (Time+seconds <= 5400)
            {
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
}
