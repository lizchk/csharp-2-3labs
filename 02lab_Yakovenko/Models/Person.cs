using _01lab_Yakovenko.Tools;
using KMA.Lab02.Yakovenko.Tools;
using System;
using System.Windows;

namespace KMA.Lab02.Yakovenko.Models
{
    internal class Person
    {
        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _dateOfBirth;
        private bool _isAdult;
        private SunSign _sunSign;
        private ChineseSign _chineseSign;
        private bool _isBirthday;
        #endregion

        #region Constructors
        public Person()
        {
        }
        public Person(string name, string surname, string email, DateTime dateOfBirth)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _dateOfBirth = dateOfBirth;
        }
        public Person(string name, string surname, string email) : this(name, surname, email, default)
        {

        }
        public Person(string name, string surname, DateTime dateOfBirth) : this(name, surname, null, dateOfBirth)
        {

        }
        #endregion

        #region Properties
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public bool IsAdult
        {
            get { return _isAdult; }
            set { _isAdult = value; }
        }
        public SunSign SunSign
        {
            get { return _sunSign; }
            set { _sunSign = value; }
        }
        public ChineseSign ChineseSign
        {
            get { return _chineseSign; }
            set { _chineseSign = value; }
        }
        public bool IsBirthday
        {
            get { return _isBirthday; }
            set { _isBirthday = value; }
        }
        #endregion

    }
}
