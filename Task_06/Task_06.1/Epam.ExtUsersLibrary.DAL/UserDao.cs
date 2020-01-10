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
    public class UserDao : IUserDao
    {
        private static string _path = "users.JSON"; //default path is Epam.ExtUsersLibrary.ConsolePL\bin\Debug\
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

        private static void SynchronizeJSON()
        {
            using (StreamWriter myStreamWriter = File.CreateText(_path))
            {
                myStreamWriter.WriteLine(JsonConvert.SerializeObject(_users));
            }
        }
        private static Dictionary<int,User> GetJSONData(String path)
        {
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
