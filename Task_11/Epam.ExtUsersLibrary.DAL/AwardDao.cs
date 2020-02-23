﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Epam.ExtUsersLibrary.Dao.Interfaces;
using Epam.ExtUsersLibrary.Entities;
using Newtonsoft.Json;

namespace Epam.ExtUsersLibrary.DAL
{
    public class AwardDao : IAwardDao
    {
        private static readonly string FolderName = ConfigurationManager.AppSettings.Get("DestFolder");
        private static readonly string FileName = ConfigurationManager.AppSettings.Get("NameAwardFile");
        internal static readonly string  _path = Path.Combine(FolderName,FileName); //default path is "C:\\dataStorage,
                                                                                   //you can change folder path and files names in web.config
        internal static readonly Dictionary<int, Award> _awards = JsonSynchronizer.GetJSONData<Award>(_path,FolderName);

        public Award Add(Award award)
        {
            var lastId = _awards.Keys.Count > 0
                ? _awards.Keys.Max()
                : 0;
            award.Id = lastId + 1;
            _awards.Add(award.Id, award);
            JsonSynchronizer.SynchronizeJSON(_path, _awards);
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

        public Award Update(int awardId, string name, byte[] imgBytes)
        {
            var current = GetById(awardId);
            if (current == null)
            {
                throw new ArgumentOutOfRangeException("Invalid Award ID!");
            }
            current.Name = name;
            current.ImageBytes = imgBytes;
            JsonSynchronizer.SynchronizeJSON(_path, _awards);
            return current;
        }

        public int Remove(int id)
        {
            if (!_awards.ContainsKey(id))
            {
                throw new ArgumentOutOfRangeException("Invalid User ID!");
            }
            CleanRels(id);
            _awards.Remove(id);
            JsonSynchronizer.SynchronizeJSON(_path, _awards);
            return id;
        }

        private void CleanRels(int aid)
        {
            foreach (var rel in UserAwardDao._rels.ToArray())
            {
                if (rel.Value.Equals(aid))
                {
                    KeyValuePair<int,int> pare = new KeyValuePair<int, int>(rel.Key,rel.Value); 
                    UserAwardDao._rels.Remove(pare);
                }
            }
            JsonSynchronizer.SynchronizeJSON(UserAwardDao._path, UserAwardDao._rels);
        }
    }
}
