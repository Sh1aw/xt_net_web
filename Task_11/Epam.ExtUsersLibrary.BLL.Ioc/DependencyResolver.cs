using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.BLL.Interfaces;
using Epam.ExtUsersLibrary.DAL;
using Epam.ExtUsersLibrary.DAL.DB;
using Epam.ExtUsersLibrary.Dao.Interfaces;

namespace Epam.ExtUsersLibrary.BLL.Ioc
{
    public static class DependencyResolver
    {
        private static IUserDao _userDao;
        private static IUserAwardDao _userAwardDao;
        private static IAwardDao _awardDao;
        private static IVisitorDao _visitorDao;
        private static IRoleDao _roleDao;

        private static IUserLogic _userLogic;
        private static IAwardLogic _awardLogic;
        private static IVisitorLogic _visitorLogic;
        private static IUserAwardLogic _userAwardLogic;
        private static IRoleLogic _roleLogic;

        public static IUserDao UserDao => _userDao;
        public static IUserLogic UserLogic => _userLogic;
        public static IUserAwardDao UserAwardDao => _userAwardDao;
        public static IUserAwardLogic UserAwardLogic => _userAwardLogic; 
        public static IAwardDao AwardDao => _awardDao;
        public static IAwardLogic AwardLogic => _awardLogic;
        public static IVisitorDao VisitorDao => _visitorDao;
        public static IVisitorLogic VisitorLogic => _visitorLogic;
        public static IRoleDao RoleDao => _roleDao;
        public static IRoleLogic RoleLogic => _roleLogic;



        static DependencyResolver()
        {
            var typeOfDal = ConfigurationManager.AppSettings.Get("TypeOfDAL");
            var dal = typeOfDal ?? "DB";
            switch (dal)
            {
                case "JSON":
                {
                    _userDao = new Epam.ExtUsersLibrary.DAL.UserDao();
                    _userAwardDao = new Epam.ExtUsersLibrary.DAL.UserAwardDao();
                     _awardDao = new Epam.ExtUsersLibrary.DAL.AwardDao();
                    _visitorDao = new Epam.ExtUsersLibrary.DAL.VisitorDao();
                     _roleDao = new Epam.ExtUsersLibrary.DAL.RoleDao();
                     break;
                }
                case "DB":
                default:
                {
                    _userDao = new Epam.ExtUsersLibrary.DAL.DB.UserDao();
                    _userAwardDao = new Epam.ExtUsersLibrary.DAL.DB.UserAwardDao();
                    _awardDao = new Epam.ExtUsersLibrary.DAL.DB.AwardDao();
                    _visitorDao = new Epam.ExtUsersLibrary.DAL.DB.VisitorDao();
                    _roleDao = new Epam.ExtUsersLibrary.DAL.DB.RoleDao();
                    break;
                }
            }

            _userLogic = (_userLogic = new UserLogic(_userDao));
            _awardLogic = new AwardLogic(_awardDao, _userAwardDao);
            _visitorLogic = new VisitorLogic(_visitorDao);
            _userAwardLogic = new UserAwardLogic(_userDao, _awardDao, _userAwardDao);
            _roleLogic = new RoleLogic(_roleDao);
        }

    }
}
