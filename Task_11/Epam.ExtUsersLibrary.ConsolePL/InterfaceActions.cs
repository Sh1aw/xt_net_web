﻿using System;
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
        private static readonly IAwardLogic awardLogic = DependencyResolver.AwardLogic;
        private static readonly IUserAwardLogic userAwardLogic = DependencyResolver.UserAwardLogic;
        private static void GetFullAwardInfo()
        {
            var allUsers = userLogic.GetAll();
            var allAwards = awardLogic.GetAll();
            var allRels = userAwardLogic.GetAll();
            Console.WriteLine("\n\tList of Users:");
            Dictionary<User, IEnumerable<Award>> diction = new Dictionary<User, IEnumerable<Award>>();
            foreach (var user in allUsers)
            {
                IEnumerable<Award> awardsObj2 =
                    allAwards.Where(a => allRels
                        .Where(al => al.UserId.Equals(user.Id))
                        .Select(all => all.AwardId)
                        .Contains(a.Id));
                diction.Add(user, awardsObj2);
            }
            if (!diction.Any())
            {
                Console.WriteLine("List of Users is empty. Please add new user");
                return;
            }
            foreach (KeyValuePair<User, IEnumerable<Award>> keyValue in diction)
            {

                Console.WriteLine(keyValue.Key);
                Console.WriteLine("Awards:");
                if (keyValue.Value.Any())
                {
                    foreach (var award in keyValue.Value)
                    {
                        Console.WriteLine("\t"+award);
                    }
                }
                else
                {
                    Console.Write("User has no awards");
                }

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
            userLogic.Add(new User(name, dob,null));
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

        private static void GiveUserAward()
        {
            Console.WriteLine("Enter user id you want to give an award");
            int userId = Tools.ParseUserIntInput();
            Console.WriteLine("Enter award id, which you want to give" +
                              " to user with id : " + userId);
            int awardId = Tools.ParseUserIntInput();
            userAwardLogic.GiveUserAward(userId,awardId);
            Console.WriteLine("User has been awarded!");
        }
        private static void GetAwardInput()
        {
            Console.WriteLine("Enter the name of award:");
            String name = Tools.GetValidName();
            String picPath = Tools.GetValidName();
            awardLogic.Add(new Award(name,null));
            Console.WriteLine("Award has been added.");
        }
        private static void GetAllAwards()
        {
            var Awards = awardLogic.GetAll();
            if (Awards.Count()<1)
            {
                Console.WriteLine("List of Awards is empty! Please Add Award");
                return;
            }
            Console.WriteLine("List of all Awards: id : name");
            foreach (var item in Awards)
            {
                Console.WriteLine(item);
            }
        }

        public static void MainMenu()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\n_________________________\n\t\tMenu\n\t" +
                                  "1 - Show all users\n\t" +
                                  "2 - Add User;\n\t3 - Delete User;\n\t" +
                                  "4 - Give some user - some award;\n\t" +
                                  "5 - Show all awards;\n\t" +
                                  "6 - Add new Award;\n\t" +
                                  "7 - Exit;");
                Console.WriteLine("Select menu item!");
                int a = Tools.ParseUserIntInput();
                switch (a)
                {
                    case 1:
                    {
                        GetFullAwardInfo();
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
                        GiveUserAward();
                        break;
                    }
                    case 5:
                    {
                        GetAllAwards();
                        break;
                    }
                    case 6:
                    {
                        GetAwardInput();
                        break;
                    }
                    case 7:
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
