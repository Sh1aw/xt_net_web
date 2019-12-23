using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05
{
    class FileTools
    {
        //Get value from file
        public static string ReadNewValue(string path)
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

        // Creating file with target state
        public static void CreateStateFile(MyFile file)
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

        //Deleting all files in Directory, for creating target Directory-State in future
        public static bool ClearDir(string dir)
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

        //Searching target state of file
        public static bool GetLastStateFile(MyFile myF1, MyFile myF2)
        {
            if (myF1.Name == myF2.OldName)
            {
                return myF1.TimeOfCreation < myF2.TimeOfCreation;
            }
            return false;
        }
        public static void GetLastStateFileHandler(List<MyFile> filesList, Func<MyFile, MyFile, bool> func)
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
