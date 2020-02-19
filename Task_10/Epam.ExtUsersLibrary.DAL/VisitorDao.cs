using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.Dao.Interfaces;
using Epam.ExtUsersLibrary.Entities;

namespace Epam.ExtUsersLibrary.DAL
{
    public class VisitorDao : IVisitorDao
    {
        private static readonly string FolderName = ConfigurationManager.AppSettings.Get("DestFolder");
        private static readonly string FileName = ConfigurationManager.AppSettings.Get("NameVisitorFile");
        private static readonly string _path = Path.Combine(FolderName, FileName);
        internal static readonly Dictionary<int, Visitor> _visitors = JsonSynchronizer.GetJSONData<Visitor>(_path,FolderName);
        public Visitor Add(Visitor visitor)
        {
            var lastId = _visitors.Keys.Count > 0
                ? _visitors.Keys.Max()
                : 0;
            visitor.Id = lastId + 1;
            _visitors.Add(visitor.Id, visitor);
            JsonSynchronizer.SynchronizeJSON(_path, _visitors);
            return visitor;
        }

        public IEnumerable<Visitor> GetAll()
        {
            return _visitors.Values;
        }

        public Visitor GetById(int id)
        {
            _visitors.TryGetValue(id, out var visitor);

            return visitor;
        }

        public Visitor GetByLogin(string login)
        {
            return _visitors.Where(v => v.Value.Login.Equals(login)).FirstOrDefault().Value;
        }

        public void GiveRole(int id, string role)
        {
            var current = GetById(id);
            if (current!= null && !current.Roles.Contains(role))
            {
                current.Roles.Add(role);
                JsonSynchronizer.SynchronizeJSON(_path, _visitors);
            }
            
        }

        public void DepriveRole(int id, string role)
        {
            var current = GetById(id);
            if (current != null && current.Roles.Contains(role))
            {
                current.Roles.Remove(role);
                JsonSynchronizer.SynchronizeJSON(_path, _visitors);
            }
            
        }

        public int Remove(int id)
        {
            if (!_visitors.ContainsKey(id))
            {
                throw new ArgumentOutOfRangeException("Invalid Visitor ID!");
            }
            _visitors.Remove(id);
            JsonSynchronizer.SynchronizeJSON(_path, _visitors);
            return id;
        }
    }
}
