using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Git myGit = new Git();
            Console.WriteLine("Select app mode:\n1." +
                " Track changes in target directory;\n2." +
                " Restore directory-state by date and time;\n[1/2]\n");
            var userChoice = GetUserChoiceInput();
            myGit.InitGit();
            switch (userChoice)
            {
                case 1:
                    {
                        myGit.Watching();
                        break;
                    }
                case 2:
                    {
                        myGit.BackUp();
                        break;
                    }
            }

            Console.ReadLine();
        }
        private static int GetUserChoiceInput()
        {
            int choice = 0;
            bool flag = true;
            while (flag)
            {
                string stringData = Console.ReadLine();
                if (int.TryParse(stringData, out choice) && (choice == 1 || choice == 2))
                {

                    flag = false;
                }
                else
                {
                    Console.WriteLine("Incorrect input! Please try again");
                }
            }
            return choice;
        }    
    }
}
