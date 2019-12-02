using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Game
{
    public abstract class Enemy : IMovable, ILocatable, IAttackable
    {
        private int _strenghtOfAttack;

        public int StrenghtOfAttack 
        {
            get => _strenghtOfAttack;
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Strenght value cant be negative or null");
                }
                _strenghtOfAttack = value;
            }
        }
        public int Health { get; set; }
        public Position CurrentPosition { get; set; }
        public void Attack(IMovable imv, int strength)
        {
            throw new NotImplementedException();
        }
        public void Move(Position p)
        {
            throw new NotImplementedException();
        }
        public void Move(ILocatable ilc)
        {
            throw new NotImplementedException();
        }

        protected Enemy(int strg, int health, Position p)
        {
            Health = health;
            StrenghtOfAttack = strg;
            CurrentPosition = p;
        }

    }
}
