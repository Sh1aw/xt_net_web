﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.BLL.Interfaces;
using Epam.ExtUsersLibrary.Dao.Interfaces;

namespace Epam.ExtUsersLibrary.BLL
{
    public class UserAwardLogic :IUserAwardLogic
    {
        private readonly IUserDao _userDao;
        private readonly IAwardDao _awardDao;
        private readonly IUserAwardDao _userAwardDao;

        public UserAwardLogic(IUserDao userDao, IAwardDao awardDao, IUserAwardDao userAwardDao)
        {
            _userDao = userDao;
            _awardDao = awardDao;
            _userAwardDao = userAwardDao;
        }

        public bool GiveUserAward(int userId, int awardId)
        {
            var User = _userDao.GetById(userId);
            var Award = _awardDao.GetById(awardId);
            if (User!=null && Award!=null)
            {
               return _userAwardDao.GiveUserAward(userId, awardId);
            }

            return false;
        }

        public bool RemoveUserAward(int userId, int awardId)
        {
            var User = _userDao.GetById(userId);
            var Award = _awardDao.GetById(awardId);
            if (User != null && Award != null)
            {
                return _userAwardDao.RemoveUserAward(userId, awardId);
            }

            return false;
        }
    }
}
