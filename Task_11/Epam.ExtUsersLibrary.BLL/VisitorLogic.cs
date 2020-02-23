﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.BLL.Interfaces;
using Epam.ExtUsersLibrary.Dao.Interfaces;
using Epam.ExtUsersLibrary.Entities;

namespace Epam.ExtUsersLibrary.BLL
{
    public class VisitorLogic : IVisitorLogic
    {
        private readonly IVisitorDao _visitorDao;
        public VisitorLogic(IVisitorDao visitorDao)
        {
            _visitorDao = visitorDao;
        }
        public Visitor Add(Visitor visitor)
        {
            return _visitorDao.Add(visitor);
        }

        public IEnumerable<Visitor> GetAll()
        {
            return _visitorDao.GetAll();
        }

        public Visitor GetById(int id)
        {
            return _visitorDao.GetById(id);
        }

        public Visitor GetByLogin(string login)
        {
            return _visitorDao.GetByLogin(login);
        }
        public int GiveRole(int id,int idRole)
        {
            return _visitorDao.GiveRole(id,idRole);
        }

        public void DepriveRole(int id,int idRole)
        {
            _visitorDao.DepriveRole(id,idRole);
        }

        public int Remove(int id)
        {
            return _visitorDao.Remove(id);
        }
    }
}
