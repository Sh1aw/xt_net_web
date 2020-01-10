using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.Dao.Interfaces;
using Epam.ExtUsersLibrary.Entities;
using Newtonsoft.Json;

namespace Epam.ExtUsersLibrary.DAL
{
    public class AwardDao : IAwardDao
    {
        private static string _path = "awards.json"; //default path is Epam.ExtUsersLibrary.ConsolePL\bin\Debug\
        internal static readonly Dictionary<int, Award> _awards = GetJSONData(_path);

        public Award Add(Award award)
        {
            var lastId = _awards.Keys.Count > 0
                ? _awards.Keys.Max()
                : 0;
            award.Id = lastId + 1;
            _awards.Add(award.Id, award);
            SynchronizeJSON();
            return award;
        }
        public Award GetById(int id)
        {
            _awards.TryGetValue(id, out var award);

            return award;
        }
        public IEnumerable<Award> GetAll()
        {
            return _awards.Values;
        }


        private static void SynchronizeJSON()
        {
            using (StreamWriter myStreamWriter = File.CreateText(_path))
            {
                myStreamWriter.WriteLine(JsonConvert.SerializeObject(_awards,Formatting.Indented));
            }
        }

        private static Dictionary<int, Award> GetJSONData(String path)
        {
            Stream myStream;
            using (myStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                StreamReader myStreamReader = new StreamReader(myStream);
                string s = myStreamReader.ReadToEnd();
                var awardsList = new Dictionary<int, Award>();
                if (!(s.Length > 0))
                {
                    return awardsList;
                }
                awardsList = new Dictionary<int, Award>(JsonConvert.DeserializeObject<Dictionary<int, Award>>(s));
                return awardsList;
            }
        }
    }
}
