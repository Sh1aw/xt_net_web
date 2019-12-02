using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class Employee : User
    {
        private int _experienceAge;
        public int ExperienceAge
        {
            get
            {
                return _experienceAge;
            }
            set
            {
                if (value > base.Age || value < 0)
                {
                    throw new ArgumentException("Not correct Experience Value");
                }
                _experienceAge = value;
            }
        }
        public PositionEnum currentPosition;

        public Employee(string lastName, string firstName, string patronum, DateTime bDay, PositionEnum curPos, int expAge)
            : base(lastName, firstName, patronum, bDay)
        {
            currentPosition = curPos;
            ExperienceAge = expAge;
        }
        public Employee(string lastName, string firstName, DateTime bDay, PositionEnum curPos, int expAge)
            : base(lastName, firstName, bDay)
        {
            currentPosition = curPos;
            ExperienceAge = expAge;
        }
        public Employee(string firstName, DateTime bDay, PositionEnum curPos, int expAge)
            : base(firstName, bDay)
        {
            currentPosition = curPos;
            ExperienceAge = expAge;
        }
    }
    enum PositionEnum
    {
        Director,
        Manager,
        Worker,
    }
}
