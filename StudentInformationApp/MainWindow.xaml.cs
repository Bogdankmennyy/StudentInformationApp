//Розробіть додаток, який вміє запускати дочірній процес. Залежно
//від вибору користувача, батьківський додаток має чекати
//завершення дочірнього процесу та відображати код завершення
//або примусово завершувати роботу дочірнього процесу.



using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace ProcessLauncherApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LaunchProcessButton_Click(object sender, RoutedEventArgs e)
        {
            string processPath = "ШЛЯХ_ДО_ВИКОНУВАНОГО_ФАЙЛУ.exe";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = processPath,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process = new Process { StartInfo = startInfo };

            RadioButton selectedRadioButton = GetSelectedRadioButton();

            if (selectedRadioButton == WaitForCompletionRadioButton)
            {
                process.EnableRaisingEvents = true;
                process.Exited += (s, args) =>
                {
                    int exitCode = process.ExitCode;
                    Dispatcher.Invoke(() =>
                    {
                        ResultTextBlock.Text = $"Код завершення: {exitCode}";
                    });
                    process.Dispose();
                };
            }
            else if (selectedRadioButton == ForceExitRadioButton)
            {
                process.EnableRaisingEvents = false;
                process.Exited += (s, args) =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        ResultTextBlock.Text = "Примусово завершено.";
                    });
                    process.Dispose();
                };
            }

            process.Start();
        }

        private RadioButton GetSelectedRadioButton()
        {
            if (WaitForCompletionRadioButton.IsChecked == true)
                return WaitForCompletionRadioButton;
            else
                return ForceExitRadioButton;
        }
    }
}

