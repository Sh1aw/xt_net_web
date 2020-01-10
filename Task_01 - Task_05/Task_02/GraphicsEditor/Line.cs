using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.GraphicsEditor
{
    class Line : Shape
    {
        public int EndX { get; set; }
        public int EndY { get; set; }

        public double Length { get => Math.Sqrt((X - EndX) * (X - EndX) + (Y - EndY) * (Y - EndY)); }
        public Line(int x, int y, int ex, int ey)
            : base(x, y)
        {
            if (ex == X && ey == Y)
            {
                throw new ArgumentException("We cant create Line with same start/end coordinates");
            }
            EndX = ex;
            EndY = ey;
        }
        public override void printFigure()
        {
            Console.WriteLine("Type of Figure: {0}\nStart [X,Y]: [{1},{2}];\nEnd [X,Y]: [{3},{4}];\nLength of Line: {5}", GetType().Name, X, Y, EndX, EndY, Length);
        }
    }
}
