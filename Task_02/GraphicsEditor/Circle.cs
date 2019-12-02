using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.GraphicsEditor
{
    class Circle : Shape
    {
        private int _radius;
        public int Radius
        {
            get
            {
                return this._radius;
            }
            private set
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
        public virtual double Length
        {
            get => Math.PI * 2 * Radius;
        }
        public Circle(int x, int y, int r)
            : base(x, y)
        {
            Radius = r;
        }
        public override void printFigure()
        {
            Console.WriteLine("Type of Figure: {0}\nCentral [X,Y]: [{1},{2}];\nRadius: {3}\nLength of {0}: {4}", GetType().Name, X, Y, Radius, Length);
        }
    }
}
