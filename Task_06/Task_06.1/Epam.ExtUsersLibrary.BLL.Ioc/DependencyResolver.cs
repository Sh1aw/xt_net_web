using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.BLL.Interfaces;
using Epam.ExtUsersLibrary.DAL;
using Epam.ExtUsersLibrary.Dao.Interfaces;

namespace Epam.ExtUsersLibrary.BLL.Ioc
{
    public static class DependencyResolver
    {
		private static IUserDao _userDao;
        public static IUserDao UserDao => _userDao ?? (_userDao = new UserDao());


        private static IUserLogic _userLogic;
        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDao));
    }
}
