using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ExtUsersLibrary.Entities
{
    public class User
    {
        private DateTime _dateOfBirth;
        public List<int> AwardsIds;

        public User(String name, DateTime dateOfBirth,string userPic)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            AwardsIds = new List<int>();
            UserPicPath = userPic;
        }

        public int Id { get; set; }
        public String Name { get; set; }
        public String UserPicPath { get; set;}
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (value>=DateTime.Now)
                {
                    throw new ArgumentException("Date of Birth cant be greather then now");
                }
                _dateOfBirth = value;
            }
        }
        public int Age
        {
            get => (DateTime.Now - DateOfBirth).Days/365; 
        }

        public override string ToString()
        {
            return $"\nID: {Id}\nName:{Name}\nDate of Birth: {DateOfBirth}\nAge:{Age}";
        }
    }
}
