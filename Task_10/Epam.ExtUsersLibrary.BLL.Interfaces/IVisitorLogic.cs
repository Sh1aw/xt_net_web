using Epam.ExtUsersLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ExtUsersLibrary.BLL.Interfaces
{
    public interface IVisitorLogic
    {
        Visitor Add(Visitor user);

        Visitor GetById(int id);

        int Remove(int id);
        IEnumerable<Visitor> GetAll();
        void GiveRole(int id,string role);
        Visitor GetByLogin(string login);
        void DepriveRole(int id,string role);
    }
}
