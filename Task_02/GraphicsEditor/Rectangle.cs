using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.GraphicsEditor
{
    class Rectangle : Shape
    {
        private int _a;
        private int _b;

        public int A
        {
            get => _a;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Inccorect value of side A!");
                }
                _a = value;
            }
        }
        public int B
        {
            get => _b;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Inccorect value of side A!");
                }
                _b = value;
            }
        }

        public double Area { get => A * B; }
        public int Perimiter { get => 2 * (A + B); }
        public override void printFigure()
        {
            Console.WriteLine("Type of Figure: {0};\nCentral [X,Y]: [{1},{2}];\nSide A: {5}; Side B: {6};\nPerimeter: {3};\nArea: {4};", GetType().Name, X, Y, Perimiter, Area, A, B);
        }

        public Rectangle(int x, int y, int a, int b)
            : base(x, y)
        {
            A = a;
            B = b;
        }
    }
}
