using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class Trinangle
    {
        int _a;
        int _b;
        int _c;

        public int A
        {
            get => _a;
            private set
            {
                CheckSideOfTrinangle(value);
                _a = value;
            }
        }
        public int B
        {
            get => _b;
            private set
            {
                CheckSideOfTrinangle(value);
                _b = value;
            }
        }
        public int C
        {
            get => _c;
            private set
            {
                CheckSideOfTrinangle(value);
                _c = value;
            }
        }
        static void CheckSideOfTrinangle(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Side of Trinangle cant be <0 or 0");
            }
        }
        public Trinangle(int a, int b, int c)
        {
            if (a + b <= c || a + c <= b || c + b <= a)
            {
                throw new ArgumentException("We cant create imposible trinangle!");
            }
            A = a;
            B = b;
            C = c;

        }
        public double Area
        {
            get => Math.Sqrt((Perimeter / 2) * ((Perimeter / 2) - A) * ((Perimeter / 2) - B) * ((Perimeter / 2) - C));

        }
        public double Perimeter
        {
            get => A + B + C;
        }
    }
}
