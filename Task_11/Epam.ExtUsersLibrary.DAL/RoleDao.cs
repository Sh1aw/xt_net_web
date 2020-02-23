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
    public class RoleDao : IRoleDao
    {
        private static readonly string FolderName = ConfigurationManager.AppSettings.Get("DestFolder");
        private static readonly string FileName = ConfigurationManager.AppSettings.Get("NameRolesFile");
        internal static readonly string _path = Path.Combine(FolderName, FileName);

        internal static readonly Dictionary<int, Role> _roles = 
            JsonSynchronizer.GetJSONFakeData<Role>(_path, FolderName,new Role[]{new Role("user"),new Role("admin"),});
        public Role AddRole()
        {
            throw new NotImplementedException();
        }

        public Role GetRoleById(int id)
        {
            JsonSynchronizer.SynchronizeJSON(_path,_roles);
            _roles.TryGetValue(id, out var role);

            return role;
        }
    }
}
