using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 2.1 Round
            StartRound();

            //Task 2.2 Trinangle
            StartTrinangle();

            //Task 2.3 User
            StartUser();

            //Task 2.4 MyString
            StartMyString();

            //Task 2.5 Employee
            StartEmployee();

            //Task 2.6 Ring
            StartRing();

            //Task 2.7 GraphicsEditor
            Console.WriteLine("\nTask 2.7 GraphicsEditor");
            GraphicsEditor.GraphicsEditor gr1 = new GraphicsEditor.GraphicsEditor();
            gr1.StartUp();

            //Task 2.8 Game находится в папке Game
            Console.ReadKey();
        }
        static void StartRound()
        {
            Console.WriteLine("Task 2.1 Round");
            Round r1 = new Round(0, 0, 10);
            Console.WriteLine("Radius: " + r1.Radius);
            Console.WriteLine("Legth of Round: " + r1.Lenth);
            Console.WriteLine("Area of Round: " + r1.Area);
        }
        static void StartTrinangle()
        {
            Console.WriteLine("\nTask 2.2 Trinangle");
            Trinangle t1 = new Trinangle(6, 4, 3);
            Console.WriteLine("Side A: {0}; Side B: {1}; Side C: {2}", t1.A, t1.B, t1.C);
            Console.WriteLine("Perimeter: " + t1.Perimeter);
            Console.WriteLine("Area of Trinangle: " + t1.Area);
        }
        static void StartUser()
        {
            Console.WriteLine("\nTask 2.3 User");
            User u1 = new User("Ivan", "Ivanov", "Ivanovich", DateTime.Parse("10/10/1990"));
            Console.WriteLine("First Name: " + u1.FirstName);
            Console.WriteLine("Last Name: " + u1.LastName);
            Console.WriteLine("Patronum: " + u1.Patronum);
            Console.WriteLine("Date of the Birth: " + u1.BirthDay.ToShortDateString());
            Console.WriteLine("Age: " + u1.Age);
        }
        static void StartMyString()
        {
            Console.WriteLine("\nTask 2.4 MyString");
            MyString ms1 = new MyString(new char[] { 'м', 'о', 'я' });
            MyString ms2 = new MyString("строка");
            Console.WriteLine("Strng 1: " + ms1 + "; Length: " + ms1.Length);
            Console.WriteLine("Strng 2: " + ms2 + "; Length: " + ms2.Length);
            Console.WriteLine("Equals: " + ms1.Equals(ms2));
            Console.WriteLine("Concat: " + ms1 + ms2);
            Console.WriteLine("Index of к: " + (ms1 + ms2).IndexOf('к'));
            Console.WriteLine("index Substring of ок: " + (ms1 + ms2).Contains("ок"));
        }
        static void StartEmployee()
        {
            Console.WriteLine("\nTask 2.5 Employee");
            Employee emp1 = new Employee("Ivan", "Ivanov", "Ivanovich", DateTime.Parse("10/10/1990"), PositionEnum.Manager, 10);
            Console.WriteLine("First Name: " + emp1.FirstName);
            Console.WriteLine("Last Name: " + emp1.LastName);
            Console.WriteLine("Patronum: " + emp1.Patronum);
            Console.WriteLine("Date of the Birth: " + emp1.BirthDay.ToShortDateString());
            Console.WriteLine("Age: " + emp1.Age);
            Console.WriteLine("Position: " + emp1.currentPosition);
            Console.WriteLine("Experience: " + emp1.ExperienceAge);
        }
        static void StartRing()
        {
            Console.WriteLine("\nTask 2.6 Ring");
            Ring ring1 = new Ring(0, 0, 15, 10);
            Console.WriteLine("Outer Radius: " + ring1.Radius);
            Console.WriteLine("Inner Radius: " + ring1.InnerRadius);
            Console.WriteLine("Length of Ring: " + ring1.Lenth);
            Console.WriteLine("Area of Ring: " + ring1.Area);
        }
    }
}
