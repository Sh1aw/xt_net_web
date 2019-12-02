using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class Round
    {
        public int X { get; set; }
        public int Y { get; set; }

        private int _radius;
        public virtual int Radius
        {
            get
            {
                return this._radius;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Round radius must be positive!", "Round");
                }
                else
                {
                    this._radius = value;
                }
            }
        }

        public virtual double Lenth
        {
            get => Math.PI * 2 * Radius;
        }
        public virtual double Area
        {
            get => Math.PI * Radius * Radius;
        }

        public Round(int x, int y, int r)
        {
            X = x;
            Y = y;
            Radius = r;
        }
    }
}
