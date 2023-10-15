//Розробіть додаток, який відображає список процесів. Користувач
//може вказати інтервал часу для оновлення списку. Обов'язково
//створіть віконний інтерфейс додатка.


using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace ProcessListApp
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private Process[] processes;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1); // Інтервал оновлення у секундах
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateProcessList();
        }

        private void StartUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(IntervalTextBox.Text, out int intervalSeconds))
            {
                timer.Interval = TimeSpan.FromSeconds(intervalSeconds);
                timer.Start();
            }
            else
            {
                MessageBox.Show("Введіть коректний інтервал оновлення (у секундах).");
            }
        }

        private void UpdateProcessList()
        {
            processes = Process.GetProcesses();
            ProcessDataGrid.ItemsSource = processes;
        }
    }
}

