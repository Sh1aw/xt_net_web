using System;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05
{
    class Git
    {
        /*
        Default location of target directory: bin\Debug\MyGit 
        (folder created when you choose watching mode in 1st time,
        or you can create your own folder and specify path in App.config)
        Default location of log file is directory: bin\Debug\
        You can change git folder path and log file path in App.Config
        */
        private static readonly string Dir = ConfigurationManager.AppSettings.Get("GitFolderPath");
        private static readonly string LogFile = ConfigurationManager.AppSettings.Get("DestLogFilePath");
        private static List<MyFile> _logList;

        public Git()
        {
            _logList = GetJSONData(LogFile);
        }

        public void Watching()
        {
            Console.WriteLine("App in track mode now!.... " +
                              "\nTracking folder location: "+ Path.GetFullPath(Dir)+
                              "\nTo exit tracking mode(and application), press Escape");
            while (Console.ReadKey().Key != ConsoleKey.Escape){};
        }

        public void BackUp()
        {
            lock (_logList)
            {
                if (_logList.Count < 1)
                {
                    Console.WriteLine("Log file is empty. You need to use Watching mode first!");
                    return;
                }
            }
            Console.WriteLine("App in BackUp mode now!");
            while (true)
            {
                Console.WriteLine("\nEnter target date and time!" +
                                  "Target date format is: dd.mm.yyyy hh:mm:ss");
                DateTime dataInput = GetDataUserInput();
                List<MyFile> OutlogList = new List<MyFile>();
                ClearDir(Dir);
                lock (_logList)
                {
                    OutlogList = _logList.Where(x => x.TimeOfCreation < dataInput).ToList();
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
                Console.WriteLine("BackUp was done! Current directory state: " + dataInput);
            }
        }

        private static void UnifiedFileHandler(object sender, FileSystemEventArgs args)
        {
            string value = "";
            if (args.ChangeType.ToString() == "Changed" || args.ChangeType.ToString() == "Created")
            {
                value = ReadNewValue(args.FullPath);
            }
            lock (_logList)
            {
                _logList.Add(new MyFile(args.Name, value, DateTime.Now,
                    args.ChangeType.ToString(), args.FullPath, args.Name, args.FullPath));
            }
            SynchronizeJSON(LogFile);
        }
        private static void RenamedFileHandler(object sender, RenamedEventArgs args)
        {
            lock (_logList)
            {
                _logList.Add(new MyFile(args.Name, ReadNewValue(args.FullPath),
                    DateTime.Now, args.ChangeType.ToString(), args.FullPath, args.OldName, args.OldFullPath));
            }
            SynchronizeJSON(LogFile);
        }

        public void InitGit()
        {
            CreateDir(Dir);
            FileSystemWatcher fw = new FileSystemWatcher(Dir, "*.txt");
            fw.EnableRaisingEvents = true;
            fw.IncludeSubdirectories = true;
            fw.Deleted += new FileSystemEventHandler(UnifiedFileHandler);
            fw.Created += new FileSystemEventHandler(UnifiedFileHandler);
            fw.Changed += new FileSystemEventHandler(UnifiedFileHandler);
            fw.Renamed += new RenamedEventHandler(RenamedFileHandler);
        }

        private static void SynchronizeJSON(String path)
        {
            using (StreamWriter myStreamWriter = File.CreateText(path))
            {
                lock (_logList)
                {
                    myStreamWriter.WriteLine(JsonConvert.SerializeObject(_logList, Formatting.Indented));
                }
                
            }
        }

        private static List<MyFile> GetJSONData(String path)
        {
            Stream myStream;
            using (myStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                StreamReader myStreamReader = new StreamReader(myStream);
                string s = myStreamReader.ReadToEnd();
                var logListTemp = new List<MyFile>();
                if (!(s.Length > 0))
                {
                    return logListTemp;
                }
                logListTemp = new List<MyFile>(JsonConvert.DeserializeObject<List<MyFile>>(s));
                return logListTemp;
            }
        }
        private static void CreateDir(string dirPath)
        {
            Directory.CreateDirectory(dirPath);
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
