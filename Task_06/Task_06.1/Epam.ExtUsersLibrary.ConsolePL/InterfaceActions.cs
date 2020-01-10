using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.BLL.Interfaces;
using Epam.ExtUsersLibrary.BLL.Ioc;
using Epam.ExtUsersLibrary.Entities;

namespace Epam.ExtUsersLibrary.ConsolePL
{
    public static class InterfaceActions
    {
        private static readonly IUserLogic userLogic = DependencyResolver.UserLogic;
        private static void GetFullAwardInfo(IEnumerable<User> AllUsers)
        {
            Console.WriteLine("\n\tList of Users:");
            var SortedUSers = AllUsers.OrderBy(t => t.Id);
            if (AllUsers.Count()<1)
            {
                Console.WriteLine("List of Users is empty. Please add new user");
                return;
            }
            foreach (var user in SortedUSers)
            {
                Console.WriteLine(user);
                Console.WriteLine("\n");
            }
        }
        private static void GetUserInput()
        {
            Console.WriteLine("Enter username:");
            String name = Tools.GetValidName();
            Console.WriteLine("Enter the user`s date of birth," +
                              " in this format: dd.mm.yyyy");
            DateTime dob = Tools.GetValidDob();
            userLogic.Add(new User(name, dob));
            Console.WriteLine("User was added");
        }
        private static void DeleteUser()
        {
            Console.WriteLine("Enter the user ID you want to delete!");
            int id = Tools.ParseUserIntInput();
            userLogic.Remove(id);
            Console.WriteLine("User has been deleted.");
        }
        private static void UserCreation()
        {
            Console.WriteLine("User creation:");
            bool flag = true;
            while (flag)
            {
                GetUserInput();
                Console.WriteLine("Do you want to add another user?[y/n]");
                String userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "n":
                    {
                        flag = false;
                        break;
                    }
                    case "y":
                    {
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Wrong input");
                        return;
                        break;
                    }
                }
            }
            
        }

        public static void MainMenu()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\n_________________________\n\t\tMenu\n\t" +
                                  "1 - Show all users\n\t" +
                                  "2 - Add User;\n\t" +
                                  "3 - Delete User;\n\t" +
                                  "4 - Exit;");
                Console.WriteLine("Select menu item!");
                int a = Tools.ParseUserIntInput();
                switch (a)
                {
                    case 1:
                    {
                        GetFullAwardInfo(userLogic.GetAll());
                        break;
                    }
                    case 2:
                    {
                        UserCreation();
                        break;
                    }
                    case 3:
                    {
                        DeleteUser();
                        break;
                    }
                    case 4:
                    {
                        flag = false;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Wrong user input, try again");
                        break;
                    }

                }
            }
        }
    }
}
