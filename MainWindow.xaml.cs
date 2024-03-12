using System;
using System.Windows;
using System.Windows.Threading;

namespace PomodoroTimer
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private TimeSpan remainingTime;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;

            remainingTime = TimeSpan.FromMinutes(0.5); // Domyślny czas w minutach
            UpdateUI();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (remainingTime.TotalSeconds > 0)
            {
                remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));
                UpdateUI();
            }
            else
            {
                timer.Stop();
                MessageBox.Show("Czas sesji Pomodoro minął!", "Koniec sesji", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void UpdateUI()
        {
            timeTextBox.Text = remainingTime.ToString(@"mm\:ss");
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            remainingTime = TimeSpan.FromMinutes(25);
            UpdateUI();
        }
    }
}
