using Epam.ExtUsersLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ExtUsersLibrary.BLL.Interfaces
{
    public interface IUserLogic
    {
        User Add(User user);

        User GetById(int id);

        int Remove(int id);
        IEnumerable<User> GetAll();
        void GiveUserAward(int userId, int awardId);
    }
}
