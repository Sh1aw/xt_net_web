using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ExtUsersLibrary.ConsolePL
{
    class Tools
    {
        public static string GetValidName()
        {
            while (true)
            {
                String input = Console.ReadLine();
                if ((input.Trim(' ') != ""))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Name cant be empty");
                }
            }
        }

        public static DateTime GetValidDob()
        {
            DateTime date = new DateTime();
            bool flag = true;
            while (flag)
            {
                string stringData = Console.ReadLine();
                if (DateTime.TryParse(stringData, out date))
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Incorrect input! Try again and " +
                                      "follow this date format: dd.mm.yyyy");
                }
            }
            return date;
        }

        public static int ParseUserIntInput()
        {
            int IntUnput = 0;
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out IntUnput))
                {
                    return IntUnput;
                }
                else
                {
                    Console.WriteLine("Wrong user input, try again");
                }
            }
        }
    }
}
