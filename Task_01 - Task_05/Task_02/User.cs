using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class User
    {
        public string LastName
        {
            get
            {
                if (String.IsNullOrEmpty(_lastName))
                {
                    throw new ArgumentException("Lastname is not set");
                }
                return _lastName;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Lastname cant be empty");
                }
                _lastName = value;
            }
        }
        public string FirstName
        {
            get
            {
                if (String.IsNullOrEmpty(_firstName))
                {
                    throw new ArgumentException("FirstName is not set");
                }
                return _firstName;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Firstname cant be empty");
                }
                _firstName = value;
            }
        }
        public string Patronum
        {
            get
            {
                if (String.IsNullOrEmpty(_patronum))
                {
                    throw new ArgumentException("Patronum is not set");
                }
                return _patronum;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Patronum cant be empty");
                }
                _patronum = value;
            }
        }
        public DateTime BirthDay
        {
            get => _birthDay;
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("BirthDay isnt correct");
                }
                _birthDay = value;
            }
        }

        private DateTime _birthDay;
        private string _firstName;
        private string _lastName;
        private string _patronum;


        public int Age
        {
            get => (DateTime.Now - BirthDay).Days / 365;
        }

        public User(string lastName, string firstName, string patronum, DateTime bDay)
        {
            LastName = lastName;
            FirstName = firstName;
            Patronum = patronum;
            BirthDay = bDay;
        }
        public User(string lastName, string firstName, DateTime bDay)
        {
            LastName = lastName;
            FirstName = firstName;
            BirthDay = bDay;
        }
        public User(string firstName, DateTime bDay)
        {
            FirstName = firstName;
            BirthDay = bDay;
        }
    }
}
