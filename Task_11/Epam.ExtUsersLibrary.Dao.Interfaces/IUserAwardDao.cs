using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.Entities;

namespace Epam.ExtUsersLibrary.Dao.Interfaces
{
    public interface IUserAwardDao
    {
        int GiveUserAward(int userId, int awardId);
        int RemoveUserAward(int userId, int awardId);
        IEnumerable<UserAward> GetAll();
    }
}
