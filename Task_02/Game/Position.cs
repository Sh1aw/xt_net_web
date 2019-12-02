using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Game
{
    public class Position
    {
        private int _x;
        private int _y;
        public int X
        {
            get => _x;
            set
            {
                if (value > Field.Width || value < 0)
                {
                    throw new ArgumentException("Incorrecrt position;");
                }
                _x = value;
            }
        }
        public int Y
        {
            get => _y;
            set
            {
                if (value > Field.Height || value < 0)
                {
                    throw new ArgumentException("Incorrecrt position;");
                }
                _y = value;
            }
        }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
