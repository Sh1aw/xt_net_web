using Epam.ExtUsersLibrary.BLL.Ioc;
using Epam.ExtUsersLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.BLL.Interfaces;

namespace Epam.ExtUsersLibrary.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            InterfaceActions.MainMenu();
            Console.ReadKey();
        }
    }
}
