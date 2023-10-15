//Розробіть додаток, який вміє запускати дочірній процес і чекати
//на його завершення. Коли дочірній процес завершено,
//батьківський додаток має відобразити код завершення.


using System;
using System.Diagnostics;
using System.Windows;

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
            // Шлях до виконуваного файлу дочірнього процесу
            string processPath = "ШЛЯХ_ДО_ФАЙЛУ_ДОЧІРНОГО_ПРОЦЕСУ.exe";

            // Створення процесу та його налаштування
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = processPath,
                UseShellExecute = false, // Використовувати прямий запуск (не через оболонку)
                RedirectStandardOutput = true, // Перенаправити стандартний вивід
                CreateNoWindow = true, // Не створювати вікно дочірнього процесу
            };

            Process process = new Process { StartInfo = startInfo };

            process.EnableRaisingEvents = true; // Дозволити обробку подій завершення

            // Обробник події для завершення дочірнього процесу
            process.Exited += (s, args) =>
            {
                int exitCode = process.ExitCode;
                Dispatcher.Invoke(() =>
                {
                    ResultTextBlock.Text = $"Код завершення: {exitCode}";
                });
                process.Dispose();
            };

            // Запускаємо дочірній процес
            process.Start();
        }
    }
}

