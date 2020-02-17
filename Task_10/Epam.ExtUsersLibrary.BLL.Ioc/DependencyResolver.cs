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



        private static IAwardDao _awardDao;
        public static IAwardDao AwardDao => _awardDao ?? (_awardDao = new AwardDao());


        private static IAwardLogic _awardLogic;
        public static IAwardLogic AwardLogic => _awardLogic ?? (_awardLogic = new AwardLogic(AwardDao));



        private static IVisitorDao _visitorDao;
        public static IVisitorDao VisitorDao => _visitorDao ?? (_visitorDao = new VisitorDao());


        private static IVisitorLogic _visitorLogic;
        public static IVisitorLogic VisitorLogic => _visitorLogic ?? (_visitorLogic = new VisitorLogic(VisitorDao));

        
    }
}
