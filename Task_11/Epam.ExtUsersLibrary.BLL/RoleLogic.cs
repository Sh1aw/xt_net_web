using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.BLL.Interfaces;
using Epam.ExtUsersLibrary.Dao.Interfaces;
using Epam.ExtUsersLibrary.Entities;

namespace Epam.ExtUsersLibrary.BLL
{
    public class RoleLogic : IRoleLogic
    {
        private readonly IRoleDao _roleDao;

        public RoleLogic(IRoleDao roleDao)
        {
            _roleDao = roleDao;
        }
        public Role AddRole()
        {
            throw new NotImplementedException();
        }

        public Role GetRoleById(int id)
        {
            return _roleDao.GetRoleById(id);
        }
    }
}
