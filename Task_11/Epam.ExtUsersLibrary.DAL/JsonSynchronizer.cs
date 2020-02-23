using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.Entities;
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

        public static Dictionary<int, Role> GetJSONFakeData<T>(String path, String FolderName, params Role[] startItems)
        {
            Directory.CreateDirectory(FolderName);
            Stream myStream;
            var valueList = new Dictionary<int, Role>();
            using (myStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                StreamReader myStreamReader = new StreamReader(myStream);
                string s = myStreamReader.ReadToEnd();
                
                if (!(s.Length > 0))
                {
                    valueList = new Dictionary<int, Role>();
                    int count = 0;
                    for (int i = 0; i < startItems.Length; i++)
                    {
                        count = count + 1;
                        startItems[i].Id = count;
                        valueList.Add(count, startItems[i]);

                    }
                    return valueList;
                }
                valueList = new Dictionary<int, Role>(JsonConvert.DeserializeObject<Dictionary<int, Role>>(s));
            }
            return valueList;
        }

        public static List<KeyValuePair<int,int>> GetJSONData(String path, String FolderName)
        {
            Directory.CreateDirectory(FolderName);
            Stream myStream;
            using (myStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                StreamReader myStreamReader = new StreamReader(myStream);
                string s = myStreamReader.ReadToEnd();
                var valueList = new List<KeyValuePair<int, int>>();
                if (!(s.Length > 0))
                {
                    return valueList;
                }
                valueList = new List<KeyValuePair<int, int>>(JsonConvert.DeserializeObject<List<KeyValuePair<int, int>>>(s));
                return valueList;
            }
        }
    }
}
