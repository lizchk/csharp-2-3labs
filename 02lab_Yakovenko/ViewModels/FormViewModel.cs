using KMA.Lab02.Yakovenko.Models;
using KMA.Lab02.Yakovenko.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace KMA.Lab02.Yakovenko.ViewModels
{
    internal class FormViewModel : INotifyPropertyChanged
    {
        private Person person;
        private RelayCommand<object> _proceedCommand;
        private bool _isEnabled = true;

        #region Properties
        public DateTime DateOfBirth
        {
            get;
            set;
        } = DateTime.Today;
        public string Name
        {
            get;
            set;
        }
        public string Surname
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                NotifyPropertyChanged();
            }
        }
        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ??= new RelayCommand<object>(_ => Proceed(), CanExecute);
            }
        }
        #endregion
        private bool CanExecute(object o)
        {
            return !String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(Surname) && !String.IsNullOrWhiteSpace(Email);
        }
        internal async void Proceed()
        {
            IsEnabled = false;
            Person p = new Person(Name, Surname, Email, DateOfBirth);
            try
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    MessageBox.Show($"First name: {Name} \nLast name: {Surname} \nEmail: {Email} \nDate of birth: {DateOfBirth.ToShortDateString()}" +
                        $"\nIs adult: {p.IsAdult} \nSun sign: {p.SunSign} \nChinese sign: {p.ChineseSign} \nIs birthday: {p.IsBirthday}");
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                IsEnabled = true;
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
