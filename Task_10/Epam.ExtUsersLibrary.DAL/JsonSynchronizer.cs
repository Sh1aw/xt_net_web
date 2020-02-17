using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Epam.ExtUsersLibrary.DAL
{
    static class JsonSynchronizer
    {
        public static void SynchronizeJSON<T>(string path, IEnumerable<T> values)
        {
            using (StreamWriter myStreamWriter = File.CreateText(path))
            {
                myStreamWriter.WriteLine(JsonConvert.SerializeObject(values, Formatting.Indented));
            }
        }

        public static Dictionary<int, T> GetJSONData<T>(String path,String FolderName)
        {
            Directory.CreateDirectory(FolderName);
            Stream myStream;
            using (myStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                StreamReader myStreamReader = new StreamReader(myStream);
                string s = myStreamReader.ReadToEnd();
                var valueList = new Dictionary<int, T>();
                if (!(s.Length > 0))
                {
                    return valueList;
                }
                valueList = new Dictionary<int, T>(JsonConvert.DeserializeObject<Dictionary<int, T>>(s));
                return valueList;
            }
        }
    }
}
