using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Task_07
{
    class Program
    {
        static void Main(string[] args)
        {
            DateExistance();
            HtmlReplacer();
            EmailFinder();
            NumberValidator();
            TimeCounter();
            Console.ReadLine();
        }

        private static void DateExistance()
        {
            Console.WriteLine("\nTask 7.1 Date Existance\nEnter text with date in format dd-mm-yyyy:");
            string text = Console.ReadLine();
            if (RegexTools.CheckDataContains(text))
            {
                Console.WriteLine($"Text \"{text}\n CONTAINS date with format dd-mm-yyyy!");
            }
            else
            {
                Console.WriteLine("The text does NOT CONTAIN a date");
            }
        }

        private static void HtmlReplacer()
        {
            Console.WriteLine("\nTask 7.2 Html Replacer\nEnter text with html tags:");
            string text = Console.ReadLine();
            string afterReplace = RegexTools.ReplaceHtmlTags(text);
            Console.WriteLine("Text after replacing:");
            Console.WriteLine(afterReplace);
        }

        private static void EmailFinder()
        {
            Console.WriteLine("\nTask 7.3 Email Finder\nEnter text with emails:");
            string text = Console.ReadLine();
            List<String> emailsList = RegexTools.EmailFinder(text);
            Console.WriteLine("Emails:");
            foreach (var email in emailsList)
            {
                Console.WriteLine(email);
            }
        }

        private static void NumberValidator()
        {
            Console.WriteLine("\nTask 7.4 Number Validator\nEnter number:");
            string number = Console.ReadLine();
            TypesOfNumber currenNumber = RegexTools.CheckNumber(number);
            if (currenNumber == TypesOfNumber.SimpleNumber)
            {
                Console.WriteLine("This number is number in Normal notation");
            }
            else if(currenNumber == TypesOfNumber.ScienceNumber)
            {
                Console.WriteLine("This number is number in Scientific notation");
            }
            else
            {
                Console.WriteLine("Its not a number");
            }
        }

        private static void TimeCounter()
        {
            Console.WriteLine("\nTask 7.5 TimeCounter\nEnter text with time in format hh:ss or h:ss:");
            string text = Console.ReadLine();
            int count = RegexTools.TimeMatchesCounter(text);
            Console.WriteLine("Count of time matches: "+count);
        }
    }
}
