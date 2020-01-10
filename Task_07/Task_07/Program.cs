using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_07
{
    class Program
    {
        static void Main(string[] args)
        {
            //RegexTools.CheckDataContains(Console.ReadLine());
            //string newS = RegexTools.ReplaceHtmlTags(Console.ReadLine());
            //Console.WriteLine(newS);

            //List<String> emailsList = RegexTools.EmailFinder(Console.ReadLine());
            //foreach (var VARIABLE in emailsList)
            //{
            //    Console.WriteLine(VARIABLE);
            //}
            int count = RegexTools.TimeMatchesCounter(Console.ReadLine());
            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
