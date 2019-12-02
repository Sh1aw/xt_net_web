using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.GraphicsEditor
{
    class GraphicsEditor
    {
        List<Shape> ListOfShapes = new List<Shape>();
        public void StartUp()
        {
            bool flag = true;
            Console.WriteLine("Menu:\n1. Add Line\n2. Add Circle\n3. Add Disk\n4. Add Ring\n5. Add Rectangle\n6. Show Figures;\n7.Exit from task");
            while (flag)
            {
                Console.WriteLine("\n\nEnter the number for adding new Figure:");
                int n = ReadUserInput();
                switch (n)
                {
                    case 1:
                        {
                            ListOfShapes.Add(new Line(ReadUserInput("X1"), ReadUserInput("Y1"), ReadUserInput("X2"), ReadUserInput("Y2")));
                            Console.Write("Line was added");
                            break;
                        }
                    case 2:
                        {
                            ListOfShapes.Add(new Circle(ReadUserInput("X"), ReadUserInput("Y"), ReadUserInput("Radius")));
                            Console.Write("Circle was added");
                            break;
                        }
                    case 3:
                        {
                            ListOfShapes.Add(new Disk(ReadUserInput("X"), ReadUserInput("Y"), ReadUserInput("Radius")));
                            Console.Write("Disk was added");
                            break;
                        }
                    case 4:
                        {
                            ListOfShapes.Add(new Ring(ReadUserInput("X"), ReadUserInput("Y"), ReadUserInput("OuterRadius"), ReadUserInput("Inner Radius")));
                            Console.Write("Ring was added");
                            break;
                        }
                    case 5:
                        {
                            ListOfShapes.Add(new Rectangle(ReadUserInput("X"), ReadUserInput("Y"), ReadUserInput("Side A"), ReadUserInput("Side B")));
                            Console.Write("Rectangle was added");
                            break;
                        }
                    case 6:
                        {
                            OutAllFigures(ListOfShapes);
                            break;
                        }
                    case 7:
                        {
                            flag = false;
                            break;
                        }
                }
            }

        }
        public static void OutAllFigures(List<Shape> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Figure №" + i);
                list[i].printFigure();
            }
        }
        static int ReadUserInput(string name)
        {
            Console.WriteLine("Enter " + name + ":");
            int userInput;
            while (!Int32.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Wrong value! Number value is needed");
            }
            return userInput;
        }
        static int ReadUserInput()
        {
            int userInput;
            while (!Int32.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Wrong value! Number value is needed");
            }
            return userInput;
        }
    }
}
