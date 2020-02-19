using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ExtUsersLibrary.BLL.Interfaces
{
    public interface IUserAwardLogic
    {
        bool GiveUserAward(int userId, int awardId);
        bool RemoveUserAward(int userId, int awardId);
    }
}
