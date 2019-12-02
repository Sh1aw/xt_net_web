using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.GraphicsEditor
{
    class Ring : Circle
    {
        int _innerRadius;
        public int InnerRadius
        {
            get => _innerRadius;
            private set
            {
                if (value <= 0 || value >= Radius)
                {
                    throw new ArgumentException("Inner Radius cant be bigger than outer");
                }
                _innerRadius = value;
            }

        }
        public Ring(int x, int y, int outerR, int innerR)
            : base(x, y, outerR)
        {
            InnerRadius = innerR;
        }
        public override double Length
        {
            get => base.Length + (Math.PI * 2 * InnerRadius);
        }
        public double Area
        {
            get => (Math.PI * Radius * Radius) - (Math.PI * InnerRadius * InnerRadius);
        }
        public override void printFigure()
        {
            base.printFigure();
            Console.WriteLine("Inner Radius: {0};\nArea: {1};", InnerRadius, Area);
        }
    }
}
