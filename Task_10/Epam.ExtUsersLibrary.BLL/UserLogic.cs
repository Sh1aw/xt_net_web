using Epam.ExtUsersLibrary.BLL.Interfaces;
using Epam.ExtUsersLibrary.DAL;
using Epam.ExtUsersLibrary.Dao.Interfaces;
using Epam.ExtUsersLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _userDao.Add(user);
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
            return _userDao.Update(userId, name, dob, upic);
        }
        public void GiveUserAward(int userId, int awardId)
        {
            _userDao.GiveUserAward(userId,awardId);
        }
        public void RemoveUserAward(int userId, int awardId)
        {
            _userDao.RemoveUserAward(userId,awardId);
        }

    }
}
