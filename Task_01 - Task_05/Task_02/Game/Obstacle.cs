using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Game
{
    abstract class Obstacle : ILocatable
    {
        public Position CurrentPosition { get; set; }
        protected Obstacle (Position p)
        {
            CurrentPosition = p;
        }
    }
}
