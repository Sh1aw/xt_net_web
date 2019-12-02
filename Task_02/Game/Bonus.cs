using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Game
{
    abstract class Bonus : ILocatable
    {
        private int _experience;
        public int Experience 
        {
            get => _experience;
            set
            {
                if (value<=0||value>100)
                {
                    throw new ArgumentException("Incorrect value of exp!");
                }
                _experience = value;
            }
        }
        public Position CurrentPosition { get; set; }
        protected Bonus(Position p, int exp)
        {
            CurrentPosition = p;
            Experience = exp;
        }
    }
}
