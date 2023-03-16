using _01lab_Yakovenko.Tools;
using KMA.Lab02.Yakovenko.Models;
using KMA.Lab02.Yakovenko.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace KMA.Lab02.Yakovenko.ViewModels
{
    internal class FormViewModel : INotifyPropertyChanged
    {
        private Person person = new Person();
        private RelayCommand<object> _signCommand;

        #region Properties
        public DateTime DateOfBirth
        {
            get { return person.DateOfBirth; }
            set
            {
                person.DateOfBirth = value;
                NotifyPropertyChanged();
            }
        }
        public string Name
        {
            get { return person.Name; }
            set
            {
                person.Name = value;
                NotifyPropertyChanged();
            }
        }
        public string Surname
        {
            get { return person.Surname; }
            set
            {
                person.Surname = value;
                NotifyPropertyChanged();
            }
        }
        public string Email
        {
            get { return person.Email; }
            set
            {
                person.Email = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsAdult
        {
            get { return person.IsAdult; }
            private set
            {
                person.IsAdult = value;
                NotifyPropertyChanged();
            }

        }
        public SunSign SunSign
        {
            get { return person.SunSign; }
            private set
            {
                person.SunSign = value;
                NotifyPropertyChanged();
            }
        }
        public ChineseSign ChineseSign
        {
            get { return person.ChineseSign; }
            private set
            {
                person.ChineseSign = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsBirthday
        {
            get { return person.IsBirthday; }
            private set
            {
                person.IsBirthday = value;
                NotifyPropertyChanged();
            }
        } 
        #endregion

        #region CalcAge
        private void CalcAdult()
        {
            IsAdult = CalcAge() >= 18;
        }
        private void CalcBirthday()
        {
            IsBirthday = CalcBirth();
        }
        private int CalcAge()
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateTime.Now.Month < DateOfBirth.Month || (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day))
            {
                age--;
            }
            if (age < 0 || age > 135)
            {
                MessageBox.Show("Date of birth entered incorrectly! Try again.");
            }
            return age;
        }
        private bool CalcBirth()
        {
            if (DateTime.Now.Day == DateOfBirth.Day && DateTime.Now.Month == DateOfBirth.Month)
            {
                MessageBox.Show("💖");
                return true;
            }
            return false;

        }
        #endregion

        #region CalcSign
        private void CalcChineseSign()
        {
            ChineseSign = CalcChinSign();
        }
        private void CalcSunSign()
        {
            SunSign = CalcWestSign();
        }
        private ChineseSign CalcChinSign()
        {
            return (ChineseSign)(DateOfBirth.Year % 12);
        }
        private SunSign CalcWestSign()
        {

            int month = DateOfBirth.Month;
            int day = DateOfBirth.Day;

            switch (month)
            {
                case 1:
                    return (day <= 19) ? SunSign.Capricorn : SunSign.Aquarius;
                case 2:
                    return (day <= 18) ? SunSign.Aquarius : SunSign.Pisces;
                case 3:
                    return (day <= 20) ? SunSign.Pisces : SunSign.Aries;
                case 4:
                    return (day <= 19) ? SunSign.Aries : SunSign.Taurus;
                case 5:
                    return (day <= 20) ? SunSign.Taurus : SunSign.Gemini;
                case 6:
                    return (day <= 20) ? SunSign.Gemini : SunSign.Cancer;
                case 7:
                    return (day <= 22) ? SunSign.Cancer : SunSign.Leo;
                case 8:
                    return (day <= 22) ? SunSign.Leo : SunSign.Virgo;
                case 9:
                    return (day <= 22) ? SunSign.Virgo : SunSign.Libra;
                case 10:
                    return (day <= 22) ? SunSign.Libra : SunSign.Scorpio;
                case 11:
                    return (day <= 21) ? SunSign.Scorpio : SunSign.Sagittarius;
                default:
                    return (day <= 21) ? SunSign.Sagittarius : SunSign.Capricorn;
            }
        }
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
