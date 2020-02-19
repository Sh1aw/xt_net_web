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

        public int Remove(int id)
        {
            var current = _awardDao.GetById(id);
            if (current!=null)
            {
                if (current.UserIds.Count>0)
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

        public Award Update(int awardId, string name, string picPath)
        {
            var current = _awardDao.GetById(awardId);
            if (current!=null)
            {
                if (!String.IsNullOrEmpty(name))
                {
                    if (String.IsNullOrEmpty(picPath) && !String.IsNullOrEmpty(current.PicPath))
                    {
                        picPath = current.PicPath;
                    }
                    return _awardDao.Update(awardId, name, picPath);
                }

                return null;
            }

            return null;
        }

    }
}
