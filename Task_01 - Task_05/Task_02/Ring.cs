using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class Ring : Round
    {
        public override int Radius
        {
            get
            {
                return base.Radius;
            }
            set
            {
                if (value <= InnerRadius)
                {
                    throw new ArgumentException("Outer radius cant be smaller than inner", "Ring");
                }
                else
                {
                    base.Radius = value;
                }
            }
        }
        int _innerRadius;
        public int InnerRadius
        {
            get => _innerRadius;
            set
            {
                if (value >= Radius || value <= 0)
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
        public override double Lenth
        {
            get => base.Lenth + (Math.PI * 2 * InnerRadius);
        }
        public override double Area
        {
            get => base.Area - (Math.PI *  InnerRadius * InnerRadius);
        }
    }
}
