//Реалізуйте клас «Студент». Необхідно зберігати в
//змінних-членах класу: ПІБ, дату народження, контактний
//телефон, місто, країну, назву навчального закладу, місто
//та країну (де знаходиться навчальний заклад), номер
//групи.Реалізуйте функції-члени класу для введення даних, виведення даних, реалізуйте аксесор для доступу до
//окремих змінних-членів.


using System;
using System.ComponentModel;
using System.Windows;

namespace StudentInfoWPF
{
    public class Student : INotifyPropertyChanged
    {
        private string fullName;
        private DateTime birthDate;
        private string phoneNumber;
        private string city;
        private string country;
        private string schoolName;
        private string schoolCity;
        private string schoolCountry;
        private string groupNumber;

        public string FullName
        {
            get { return fullName; }
            set
            {
                if (fullName != value)
                {
                    fullName = value;
                    OnPropertyChanged("FullName");
                }
            }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                if (birthDate != value)
                {
                    birthDate = value;
                    OnPropertyChanged("BirthDate");
                }
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                if (city != value)
                {
                    city = value;
                    OnPropertyChanged("City");
                }
            }
        }

        public string Country
        {
            get { return country; }
            set
            {
                if (country != value)
                {
                    country = value;
                    OnPropertyChanged("Country");
                }
            }
        }

        public string SchoolName
        {
            get { return schoolName; }
            set
            {
                if (schoolName != value)
                {
                    schoolName = value;
                    OnPropertyChanged("SchoolName");
                }
            }
        }

        public string SchoolCity
        {
            get { return schoolCity; }
            set
            {
                if (schoolCity != value)
                {
                    schoolCity = value;
                    OnPropertyChanged("SchoolCity");
                }
            }
        }

        public string SchoolCountry
        {
            get { return schoolCountry; }
            set
            {
                if (schoolCountry != value)
                {
                    schoolCountry = value;
                    OnPropertyChanged("SchoolCountry");
                }
            }
        }

        public string GroupNumber
        {
            get { return groupNumber; }
            set
            {
                if (groupNumber != value)
                {
                    groupNumber = value;
                    OnPropertyChanged("GroupNumber");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
