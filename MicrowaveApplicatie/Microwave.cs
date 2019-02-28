using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MicrowaveApplicatie
{
    internal class Microwave
    {
        public bool State;


        private async void Blink(bool test)
        {
            while (State)
            {

                await Task.Delay(500);

                if (MainWindow.Main.Label.Foreground.Opacity == 0)
                    MainWindow.Main.Label.Foreground.Opacity = 1;
                else
                    MainWindow.Main.Label.Foreground.Opacity = 0;
            }
            
        }

        public void OpenDoor()
        {
            State = true;
        

            MainWindow.Main.MediaPlayerClose.Close();
            
            Blink(true);
            MainWindow.Main.DoorButton.Content = "Close";
            MainWindow.Main.MediaPlayerOpen.Visibility = Visibility.Visible;
            MainWindow.Main.MediaPlayerClose.Visibility = Visibility.Hidden;
            MainWindow.Main.MediaPlayerOpen.Play();
        }

        public void CloseDoor()
        {
            Blink(false);
            State = false;
            MainWindow.Main.MediaPlayerOpen.Close();
            MainWindow.Main.MediaPlayerOpen.Visibility = Visibility.Hidden;
            MainWindow.Main.MediaPlayerClose.Visibility = Visibility.Visible;
            MainWindow.Main.MediaPlayerClose.Play();
            MainWindow.Main.DoorButton.Content = "Open";
            MainWindow.Main.Label.Foreground.Opacity = 1;


        }
    }
}