using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.BLL.Interfaces;
using Epam.ExtUsersLibrary.DAL;
using Epam.ExtUsersLibrary.Dao.Interfaces;
using Epam.ExtUsersLibrary.Entities;

namespace Epam.ExtUsersLibrary.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private readonly IAwardDao _awardDao;
        private readonly IUserAwardDao _userAwardDao;

        public AwardLogic(IAwardDao awardDao, IUserAwardDao userAwardDao)
        {
            _awardDao = awardDao;
            _userAwardDao= userAwardDao;
        }

        public Award Add(Award award)
        {
            if (!String.IsNullOrEmpty(award.Name))
            {
                return _awardDao.Add(award);
            }
            return null;
        }

        public IEnumerable<Award> GetAll()
        {
            return _awardDao.GetAll();
        }

        public int Remove(int id, bool surelyDeleting)
        {
            if(_awardDao.GetById(id)!=null)
            {
                if (_userAwardDao.GetAll().Where(ua=>ua.AwardId.Equals(id)).Any() && surelyDeleting==false)
                {
                    return 6;
                }
                else
                {
                    _awardDao.Remove(id);
                    return 200;
                }
            }
            return 400;
        }

        public Award GetById(int id)
        {
            return _awardDao.GetById(id);
        }

        public Award Update(int awardId, string name, byte[] imgBytes)
        {
            var current = _awardDao.GetById(awardId);
            if (current!=null)
            {
                if (!String.IsNullOrEmpty(name))
                {
                    if (current.ImageBytes!=null && imgBytes==null)
                    {
                        imgBytes = current.ImageBytes;
                    }
                    return _awardDao.Update(awardId, name, imgBytes);
                }

                return null;
            }

            return null;
        }

    }
}
