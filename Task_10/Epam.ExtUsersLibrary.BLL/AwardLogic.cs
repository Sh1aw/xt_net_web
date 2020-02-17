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
    public class AwardLogic : IAwardLogic
    {
        private readonly IAwardDao _awardDao;

        public AwardLogic(IAwardDao awardDao)
        {
            _awardDao = awardDao;
        }

        public Award Add(Award award)
        {
            return _awardDao.Add(award);
        }

        public IEnumerable<Award> GetAll()
        {
            return _awardDao.GetAll();
        }

        public int Remove(int id)
        {
            return _awardDao.Remove(id);
        }

        public Award GetById(int id)
        {
            return _awardDao.GetById(id);
        }

        public Award Update(int awardId, string name, string picPath)
        {
            return _awardDao.Update(awardId, name, picPath);
        }

        public void GiveAwardUser(int awardId, int userId)
        {
            _awardDao.GiveAwardUser(awardId,userId);
        }

        public void RemoveAwardUser(int awardId, int userId)
        {
            _awardDao.RemoveAwardUser(awardId,userId);
        }
    }
}
