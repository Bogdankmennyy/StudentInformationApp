//Реалізуйте клас «Точка». Необхідно зберігати координати
//x, y, z в змінних-членах класу. Реалізуйте функції-члени
//класу для введення даних, виведення даних, реалізуйте
//аксесор для доступу до змінних-членів, реалізуйте збереження в файл і завантаження даних з файлу




using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace PointApp
{
    public class Point : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double z;

        public double X
        {
            get { return x; }
            set
            {
                if (x != value)
                {
                    x = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                if (y != value)
                {
                    y = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Z
        {
            get { return z; }
            set
            {
                if (z != value)
                {
                    z = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine($"{X},{Y},{Z}");
            }
        }

        public void LoadFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                string[] data = File.ReadAllText(filename).Split(',');
                if (data.Length == 3)
                {
                    X = double.Parse(data[0]);
                    Y = double.Parse(data[1]);
                    Z = double.Parse(data[2]);
                }
            }
            else
            {
                MessageBox.Show("Файл не існує.");
            }
        }
    }
}

