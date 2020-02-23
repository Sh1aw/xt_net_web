using System;
using System.Collections.Generic;
using Epam.ExtUsersLibrary.Entities;

namespace Epam.ExtUsersLibrary.BLL.Interfaces
{
    public interface IAwardLogic
    {
        Award Add(Award award);
        Award GetById(int id);

        int Remove(int id,bool surelyDeleting);
        IEnumerable<Award> GetAll();
        Award Update(int awardId, string name, byte[] imgbBytes);
    }
}
