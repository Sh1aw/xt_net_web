using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.Dao.Interfaces;
using Epam.ExtUsersLibrary.Entities;
using Newtonsoft.Json;

namespace Epam.ExtUsersLibrary.DAL
{
    public class UserDao : IUserDao
    {
        private static readonly string FolderName = ConfigurationManager.AppSettings.Get("DestFolder");
        private static readonly string FileName = ConfigurationManager.AppSettings.Get("NameUserFile");
        private static readonly string _path = Path.Combine(FolderName,FileName); //default path is Epam.ExtUsersLibrary.ConsolePL\bin\Debug\dataStorage,
                                                                                  //you can change folder path and files names in App.config
        private static readonly Dictionary<int, User> _users = GetJSONData(_path);

        public User Add(User user)
        {
            var lastId = _users.Keys.Count > 0
                ? _users.Keys.Max()
                : 0;
            user.Id = lastId + 1;
            _users.Add(user.Id, user);
            SynchronizeJSON();
            return user;
        }

        public User GetById(int id)
        {
            _users.TryGetValue(id, out var user);

            return user;
        }

        public int Remove(int id)
        {
            if (!_users.ContainsKey(id))
            {
                throw new ArgumentOutOfRangeException("Invalid User ID!");
            }
            _users.Remove(id);
            SynchronizeJSON();
            return id;
        }

        public IEnumerable<User> GetAll()
        {
            return _users.Values;
        }

        public void GiveUserAward(int userId, int awardId)
        {
            if (_users.ContainsKey(userId) && AwardDao._awards.ContainsKey(awardId))
            {
                if (_users[userId].AwardsIds.Contains(awardId))
                {
                    throw new ArgumentException("This user already have this award");
                }
                _users[userId].AwardsIds.Add(awardId);
                SynchronizeJSON();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid User or Award IDs!");
            }
        }


        private static void SynchronizeJSON()
        {
            using (StreamWriter myStreamWriter = File.CreateText(_path))
            {
                myStreamWriter.WriteLine(JsonConvert.SerializeObject(_users, Formatting.Indented));
            }
        }
        private static Dictionary<int,User> GetJSONData(String path)
        {
            Directory.CreateDirectory(FolderName);
            Stream myStream;
            using (myStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                StreamReader myStreamReader = new StreamReader(myStream);
                string s = myStreamReader.ReadToEnd();
                var userList = new Dictionary<int, User>();
                if (!(s.Length > 0))
                {
                    return userList;
                }
                userList = new Dictionary<int, User>(JsonConvert.DeserializeObject<Dictionary<int, User>>(s));
                return userList;
            }
        }
    }
}
