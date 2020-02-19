using Epam.ExtUsersLibrary.BLL.Interfaces;
using Epam.ExtUsersLibrary.Dao.Interfaces;
using Epam.ExtUsersLibrary.Entities;
using System;
using System.Collections.Generic;

namespace Epam.ExtUsersLibrary.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;

        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public User Add(User user)
        {
            if (!String.IsNullOrEmpty(user.Name) && user.DateOfBirth<DateTime.Today)
            {
                return _userDao.Add(user);
            }

            return null;
        }

        public User GetById(int id)
        {
            return _userDao.GetById(id);
        }

        public int Remove(int id)
        {
            return _userDao.Remove(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userDao.GetAll();
        }

        public User Update(int userId, string name, DateTime dob,string upic)
        {
            var current = _userDao.GetById(userId);
            if (current!=null)
            {
                if (!String.IsNullOrEmpty(name) && dob<DateTime.Today)
                {
                    if (string.IsNullOrEmpty(upic) && !string.IsNullOrEmpty(current.UserPicPath))
                    {
                        upic = current.UserPicPath;
                    }
                    return _userDao.Update(userId, name, dob, upic);
                }
                return null;
            }
            return null;
        }

    }
}
