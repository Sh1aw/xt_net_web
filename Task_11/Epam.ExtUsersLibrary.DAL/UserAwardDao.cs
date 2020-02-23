using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Epam.ExtUsersLibrary.Dao.Interfaces;
using Epam.ExtUsersLibrary.Entities;

namespace Epam.ExtUsersLibrary.DAL
{
    public class UserAwardDao : IUserAwardDao
    {
        private static readonly string FolderName = ConfigurationManager.AppSettings.Get("DestFolder");
        private static readonly string FileName = ConfigurationManager.AppSettings.Get("NameUserAwardRelFile");
        internal static readonly string _path = Path.Combine(FolderName, FileName);

        internal static readonly List<KeyValuePair<int, int>> _rels = JsonSynchronizer.GetJSONData(_path, FolderName);

        public int GiveUserAward(int idu, int ida)
        {
            if (IsUserAwardRel(idu, ida))
            {
                return 8;
            }
            KeyValuePair<int, int> pare = new KeyValuePair<int, int>(idu, ida);
            _rels.Add(pare);
            JsonSynchronizer.SynchronizeJSON(_path, _rels);
            return 200;
        }

        public int RemoveUserAward(int idu, int ida)
        {
            if (IsUserAwardRel(idu, ida))
            {
                KeyValuePair<int, int> pare = new KeyValuePair<int, int>(idu, ida);
                _rels.Remove(pare);
                JsonSynchronizer.SynchronizeJSON(_path, _rels);
                return 200;
            }

            return 400;

        }

        public bool IsUserAwardRel(int idu, int ida)
        {
            KeyValuePair<int,int> pare = new KeyValuePair<int, int>(idu,ida);
            if (_rels.Contains(pare))
            {
                return true;
            }
            return false;
        }

        public IEnumerable<UserAward> GetAll()
        {
            List<UserAward> list = new List<UserAward>();
            foreach (var rels in _rels)
            {
                list.Add(new UserAward(rels.Key, rels.Value));
            }

            return list;
        }
    }
}
