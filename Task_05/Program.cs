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
        const string DIR = "MyGit";
        const string LOG_FILE = "log.json";
        static List<MyFile> logList = new List<MyFile>();

        static void Main(string[] args)
        {
            if (!Directory.Exists(DIR))
            {
                Directory.CreateDirectory(DIR);
            }

            FileSystemWatcher fw = new FileSystemWatcher(DIR, "*.txt");
            fw.EnableRaisingEvents = true;
            fw.IncludeSubdirectories = true;
            fw.Deleted += new FileSystemEventHandler(UnicFileHandler);
            fw.Created += new FileSystemEventHandler(UnicFileHandler);
            fw.Changed += new FileSystemEventHandler(UnicFileHandler);
            fw.Renamed += new RenamedEventHandler(RenamedFileHandler);

            Console.WriteLine("Select app mode:\n1." +
                " Track changes in target directory;\n2." +
                " Restore directory-state by date and time;\n[1/2]\n");
            int UserChoice = GetUserChoiceInput();
            switch (UserChoice)
            {
                case 1:
                    {
                        Watching();
                        break;
                    }
                case 2:
                    {
                        BackUp();
                        break;
                    }
            }

        }


        static void Watching()
        {
            Console.WriteLine("App in track mode now!...." +
                                "\nTo exit tracking mode(and application), press Escape");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            { }
            ReWriteLog();
        }

        static void BackUp()
        {
            using (StreamReader sr = new StreamReader(LOG_FILE))
            {
                logList = new List<MyFile>(JsonConvert.DeserializeObject<List<MyFile>>(sr.ReadToEnd()));
            }
            Console.WriteLine("App in BackUp mode now!");
            while (true)
            {
                Console.WriteLine("\nEnter target date and time!" +
                                " Target date format is: dd\\mm\\yyyy hh:mm:ss");
                DateTime dataInput = GetDataUserInput();

                List<MyFile> OutlogList = new List<MyFile>();
                FileTools.ClearDir(DIR);

                lock (logList)
                {
                    OutlogList = logList.Where(x => x.TimeOfCreation < dataInput).ToList();
                }
                FileTools.GetLastStateFileHandler(OutlogList, FileTools.GetLastStateFile);

                var newListGroups = OutlogList.GroupBy(x => x.Name);
                foreach (var item in newListGroups)
                {
                    var temp1 = item.LastOrDefault();
                    if (temp1.Reason != "Deleted")
                    {
                        FileTools.CreateStateFile(temp1);
                    }
                }
                using (StreamWriter w = new StreamWriter(LOG_FILE, false))
                {
                    w.WriteLine(JsonConvert.SerializeObject(logList, Formatting.Indented));
                }
                Console.WriteLine("BackUp was done! Current directory state: " + dataInput);
            }
        }

        

        static void UnicFileHandler(object sender, FileSystemEventArgs args)
        {
            string value = "";
            if (args.ChangeType.ToString() == "Changed" || args.ChangeType.ToString() == "Created")
            {
                value = FileTools.ReadNewValue(args.FullPath);
            }
            lock (logList)
            {
                logList.Add(new MyFile(args.Name, value, DateTime.Now, args.ChangeType.ToString(), args.FullPath, args.Name, args.FullPath));
            }
        }
        static void RenamedFileHandler(object sender, RenamedEventArgs args)
        {
            lock (logList)
            {
                logList.Add(new MyFile(args.Name, FileTools.ReadNewValue(args.FullPath), DateTime.Now, args.ChangeType.ToString(), args.FullPath, args.OldName, args.OldFullPath));
            }
        }


        //Append new part of logs in log file
        public static void ReWriteLog()
        {
            List<MyFile> tempList = new List<MyFile>();
            using (StreamReader sr = new StreamReader(LOG_FILE))
            {
                string s = sr.ReadToEnd();
                if (s.Length != 0)
                {
                    tempList = new List<MyFile>(JsonConvert.DeserializeObject<List<MyFile>>(s));
                    lock (logList)
                    {
                        foreach (var item in logList)
                        {
                            tempList.Add(item);
                        }
                    }
                }
            }
            using (StreamWriter w = new StreamWriter(LOG_FILE, append: false))
            {
                if (tempList.Count > 0)
                {
                    w.Write(JsonConvert.SerializeObject(tempList, Formatting.Indented));
                }
                else
                {
                    w.Write(JsonConvert.SerializeObject(logList, Formatting.Indented));
                }

            }
        }

        static DateTime GetDataUserInput()
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
                    Console.WriteLine("Incorrect input! Try again and follow this date format: dd/mm/yyyy hh:mm:ss");
                }
            }
            return date;
        }
        static int GetUserChoiceInput()
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
