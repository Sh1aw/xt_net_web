using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Epam.ExtUsersLibrary.Dao.Interfaces;
using Epam.ExtUsersLibrary.Entities;
using Newtonsoft.Json;

namespace Epam.ExtUsersLibrary.DAL
{
    public class UserDao : IUserDao
    {
        private static readonly string FolderName = ConfigurationManager.AppSettings.Get("DestFolder");
        private static readonly string FileName = ConfigurationManager.AppSettings.Get("NameUserFile");
        internal static readonly string _path = Path.Combine(FolderName,FileName); //default path is "C:\\dataStorage",
                                                                                  //you can change folder path and files names in Web.config
        internal static readonly Dictionary<int, User> _users = JsonSynchronizer.GetJSONData<User>(_path,FolderName);

        public User Add(User user)
        {
            var lastId = _users.Keys.Count > 0
                ? _users.Keys.Max()
                : 0;
            user.Id = lastId + 1;
            _users.Add(user.Id, user);
            JsonSynchronizer.SynchronizeJSON(_path, _users);
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
            JsonSynchronizer.SynchronizeJSON(_path, _users);
            return id;
        }

        public IEnumerable<User> GetAll()
        {
            return _users.Values;
        }

        public User Update(int userId,string name, DateTime dob, string upic)
        {
            var current = GetById(userId);
            if (current==null)
            {
                throw new ArgumentOutOfRangeException("Invalid User ID!");
            }

            current.Name = name;
            current.DateOfBirth = dob;
            current.UserPicPath = upic;
            JsonSynchronizer.SynchronizeJSON(_path, _users);
            return current;
        }

    }
}
