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
            if (_userDao.GetById(id)!=null)
            {
                _userDao.Remove(id);
                return 200;
            }

            return 404;
        }

        public IEnumerable<User> GetAll()
        {
            return _userDao.GetAll();
        }

        public User Update(int userId, string name, DateTime dob, byte[] imgBytes)
        {
            var current = _userDao.GetById(userId);
            if (current!=null)
            {
                if (!String.IsNullOrEmpty(name) && dob<DateTime.Today)
                {
                    if (current.ImageBytes!=null && imgBytes==null)
                    {
                        imgBytes = current.ImageBytes;
                    }
                    return _userDao.Update(userId, name, dob, imgBytes);
                }
                return null;
            }
            return null;
        }

    }
}
