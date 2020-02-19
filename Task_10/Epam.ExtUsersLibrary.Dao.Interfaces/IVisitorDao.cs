using Epam.ExtUsersLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ExtUsersLibrary.Dao.Interfaces
{
    public interface IVisitorDao
    {
        Visitor Add(Visitor user);

        Visitor GetById(int id);

        int Remove(int id);
        IEnumerable<Visitor> GetAll();
        Visitor GetByLogin(string login);
        void GiveRole(int id,string role);
        void DepriveRole(int id,string role);
    }
}
