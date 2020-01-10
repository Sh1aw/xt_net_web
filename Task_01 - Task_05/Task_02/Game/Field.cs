using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Game
{
    class Field
    {
        private static int _height;
        private static int _width;
        public Field(int h, int w)
        {
            Height = h;
            Width = w;
        }
        public static int Height 
        {
            get => _height;
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Height cant be <0");
                }
                _height = value;
            }
        }
        public static int Width
        {
            get => _width;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width cant be <0");
                }
                _width = value;
            }
        }
    }
}
