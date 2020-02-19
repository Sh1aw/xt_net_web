using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ExtUsersLibrary.Dao.Interfaces
{
    public interface IUserAwardDao
    {
        bool GiveUserAward(int userId, int awardId);
        bool RemoveUserAward(int userId, int awardId);
    }
}
