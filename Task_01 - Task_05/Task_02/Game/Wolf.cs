using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Game
{
    class Wolf : Enemy
    {
        public Wolf(int strg, int health, Position p)
            : base(strg, health, p) { }
    }
}
