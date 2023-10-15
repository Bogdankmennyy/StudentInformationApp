//Реалізуйте клас «Дріб». Необхідно зберігати чисельник
//і знаменник як змінні-члени. Реалізуйте функції-члени для
//введення даних в змінні-члени, для виконання арифметичних операцій (додавання, віднімання, множення,
//ділення, і т.д.).


using System;
using System.ComponentModel;
using System.Windows;

namespace FractionCalculatorApp
{
    public class Fraction : INotifyPropertyChanged
    {
        private int numerator;
        private int denominator;

        public int Numerator
        {
            get { return numerator; }
            set
            {
                if (numerator != value)
                {
                    numerator = value;
                    OnPropertyChanged("Numerator");
                }
            }
        }

        public int Denominator
        {
            get { return denominator; }
            set
            {
                if (denominator != value)
                {
                    if (value == 0)
                    {
                        MessageBox.Show("Знаменник не може бути рівним нулю.");
                    }
                    else
                    {
                        denominator = value;
                        OnPropertyChanged("Denominator");
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Add(Fraction otherFraction)
        {
            int newNumerator = (numerator * otherFraction.Denominator) + (otherFraction.Numerator * denominator);
            int newDenominator = denominator * otherFraction.Denominator;
            Simplify(ref newNumerator, ref newDenominator);
            Numerator = newNumerator;
            Denominator = newDenominator;
        }

        public void Subtract(Fraction otherFraction)
        {
            int newNumerator = (numerator * otherFraction.Denominator) - (otherFraction.Numerator * denominator);
            int newDenominator = denominator * otherFraction.Denominator;
            Simplify(ref newNumerator, ref newDenominator);
            Numerator = newNumerator;
            Denominator = newDenominator;
        }

        public void Multiply(Fraction otherFraction)
        {
            int newNumerator = numerator * otherFraction.Numerator;
            int newDenominator = denominator * otherFraction.Denominator;
            Simplify(ref newNumerator, ref newDenominator);
            Numerator = newNumerator;
            Denominator = newDenominator;
        }

        public void Divide(Fraction otherFraction)
        {
            int newNumerator = numerator * otherFraction.Denominator;
            int newDenominator = denominator * otherFraction.Numerator;
            Simplify(ref newNumerator, ref newDenominator);
            Numerator = newNumerator;
            Denominator = newDenominator;
        }

        private void Simplify(ref int num, ref int denom)
        {
            int gcd = GCD(num, denom);
            num /= gcd;
            denom /= gcd;
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }
    }
}

