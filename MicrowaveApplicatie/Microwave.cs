using System.Windows;

namespace MicrowaveApplicatie
{
    internal class Microwave
    {

        public void OpenDoor()
        {
            MainWindow.Main.MediaPlayerClose.Close();
            MainWindow.Main.Label.Content = "OPEN";
            MainWindow.Main.DoorButton.Content = "Close";
            MainWindow.Main.MediaPlayerOpen.Visibility = Visibility.Visible;
            MainWindow.Main.MediaPlayerClose.Visibility = Visibility.Hidden;
            MainWindow.Main.MediaPlayerOpen.Play();
        }

        public void CloseDoor()
        {
            MainWindow.Main.MediaPlayerOpen.Close();
            MainWindow.Main.MediaPlayerOpen.Visibility = Visibility.Hidden;
            MainWindow.Main.MediaPlayerClose.Visibility = Visibility.Visible;
            MainWindow.Main.MediaPlayerClose.Play();
            MainWindow.Main.DoorButton.Content = "Open";
            MainWindow.Main.Label.Content = "00:00";
        }
    }
}