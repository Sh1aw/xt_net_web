using System;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05
{
    class Git
    {
        //default location of target directory: bin\Debug\MyGit
        private const string DIR = "MyGit";
        private const string LOG_FILE = "log.json";
        static List<MyFile> logList;

        public Git()
        {
            logList = new List<MyFile>();
        }

        public void Watching()
        {
            CreateDir(DIR);
            CreateLogFile(LOG_FILE);
            InitWatchers();

            Console.WriteLine("App in track mode now!...." +
                                "\nTo exit tracking mode(and application), press Escape");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            { }
            ReWriteLog();
        }

        public void BackUp()
        {
            CreateDir(DIR);
            CreateLogFile(LOG_FILE);
            InitWatchers();

            using (StreamReader sr = new StreamReader(LOG_FILE))
            {
                string s = sr.ReadToEnd();
                if (!(s.Length > 0))
                {
                    Console.WriteLine("List is empty!");
                    Console.ReadKey();
                    return;
                }
                logList = new List<MyFile>(JsonConvert.DeserializeObject<List<MyFile>>(s));
            }
            Console.WriteLine("App in BackUp mode now!");
            while (true)
            {
                Console.WriteLine("\nEnter target date and time!" +
                                " Target date format is: dd\\mm\\yyyy hh:mm:ss");
                DateTime dataInput = GetDataUserInput();

                List<MyFile> OutlogList = new List<MyFile>();
                ClearDir(DIR);

                lock (logList)
                {
                    OutlogList = logList.Where(x => x.TimeOfCreation < dataInput).ToList();
                }
                GetLastStateFileHandler(OutlogList, GetLastStateFile);

                var newListGroups = OutlogList.GroupBy(x => x.Name);
                foreach (var item in newListGroups)
                {
                    var temp1 = item.LastOrDefault();
                    if (temp1.Reason != "Deleted")
                    {
                        CreateStateFile(temp1);
                    }
                }
                using (StreamWriter w = new StreamWriter(LOG_FILE, false))
                {
                    lock (logList)
                    {
                        w.WriteLine(JsonConvert.SerializeObject(logList, Formatting.Indented));
                    }
                }
                Console.WriteLine("BackUp was done! Current directory state: " + dataInput);
            }
        }

        private static void UnicFileHandler(object sender, FileSystemEventArgs args)
        {
            string value = "";
            if (args.ChangeType.ToString() == "Changed" || args.ChangeType.ToString() == "Created")
            {
                value = ReadNewValue(args.FullPath);
            }
            lock (logList)
            {
                logList.Add(new MyFile(args.Name, value, DateTime.Now,
                    args.ChangeType.ToString(), args.FullPath, args.Name, args.FullPath));
            }
        }
        private static void RenamedFileHandler(object sender, RenamedEventArgs args)
        {
            lock (logList)
            {
                logList.Add(new MyFile(args.Name, ReadNewValue(args.FullPath),
                    DateTime.Now, args.ChangeType.ToString(), args.FullPath, args.OldName, args.OldFullPath));
            }
        }

        private static void InitWatchers()
        {
            FileSystemWatcher fw = new FileSystemWatcher(DIR, "*.txt");
            fw.EnableRaisingEvents = true;
            fw.IncludeSubdirectories = true;
            fw.Deleted += new FileSystemEventHandler(UnicFileHandler);
            fw.Created += new FileSystemEventHandler(UnicFileHandler);
            fw.Changed += new FileSystemEventHandler(UnicFileHandler);
            fw.Renamed += new RenamedEventHandler(RenamedFileHandler);
        }

        //Append new part of logs in log file
        private static void ReWriteLog()
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
        private static void CreateDir(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }
        private static void CreateLogFile(string logFilePath)
        {
            Stream myStream;
            using (myStream = File.Open(logFilePath, FileMode.OpenOrCreate, FileAccess.Write)) ;
        }
        private static DateTime GetDataUserInput()
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
                        "follow this date format: dd/mm/yyyy hh:mm:ss");
                }
            }
            return date;
        }

        //Get value from file
        private static string ReadNewValue(string path)
        {
            string value = "";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    value = sr.ReadToEnd();
                }
            }
            catch
            {
                Thread.Sleep(100);
            }
            return value;
        }

        //Deleting all files in Directory, for creating target Directory-State in future
        private static bool ClearDir(string dir)
        {

            DirectoryInfo di = new DirectoryInfo(dir);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo d in di.GetDirectories())
            {
                d.Delete(true);
            }
            return true;
        }

        // Creating file with target state
        private static void CreateStateFile(MyFile file)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(file.FullPath));
            using (StreamWriter sr = new StreamWriter(file.FullPath, append: false))
            {
                sr.Write(file.Value);
            }
            FileInfo ifn = new FileInfo(file.FullPath);
            try
            {
                ifn.LastWriteTime = file.TimeOfCreation;
            }
            catch
            {
                Thread.Sleep(100);
            }
        }

        //Searching target state of file
        private static bool GetLastStateFile(MyFile myF1, MyFile myF2)
        {
            if (myF1.Name == myF2.OldName)
            {
                return myF1.TimeOfCreation < myF2.TimeOfCreation;
            }
            return false;
        }
        private static void GetLastStateFileHandler(List<MyFile> filesList, Func<MyFile, MyFile, bool> func)
        {

            for (int i = 0; i < filesList.Count(); i++)
            {
                for (int j = 0; j < filesList.Count(); j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (func(filesList[i], filesList[j]))
                    {
                        filesList.Remove(filesList[i]);
                        i--;
                        break;
                    }
                }
            }
        }
    }
}
