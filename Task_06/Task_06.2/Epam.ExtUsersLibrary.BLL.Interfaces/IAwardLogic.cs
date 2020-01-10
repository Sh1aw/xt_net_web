using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.Entities;

namespace Epam.ExtUsersLibrary.BLL.Interfaces
{
    public interface IAwardLogic
    {
        Award Add(Award award);
        Award GetById(int id);
        IEnumerable<Award> GetAll();
    }
}
