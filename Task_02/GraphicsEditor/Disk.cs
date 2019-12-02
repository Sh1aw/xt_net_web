using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.GraphicsEditor
{
    class Disk : Circle
    {
        public virtual double Area
        {
            get => Math.PI * Radius * Radius;
        }

        public Disk(int x, int y, int r)
            : base(x, y, r) { }
        public override void printFigure()
        {
            base.printFigure();
            Console.WriteLine("Area: {0};", Area);
        }
    }
}
