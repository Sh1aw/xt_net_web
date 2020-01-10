using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.Entities;

namespace Epam.ExtUsersLibrary.Dao.Interfaces
{
    public interface IAwardDao
    {
        Award Add(Award award);

        Award GetById(int id);
        IEnumerable<Award> GetAll();
    }
}
