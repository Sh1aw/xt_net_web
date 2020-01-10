using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Game
{
    class Player : ILocatable, IMovable
    {
        public Position CurrentPosition { get; set; }
        public int Health { get; set; }
        public Player(int health, Position startPos)
        {
            Health = health;
            CurrentPosition = startPos;
        }
        public void UseBonus(Bonus b)
        {

        }
        public void Move(Position p)
        {
            throw new NotImplementedException();
        }
    }
}
