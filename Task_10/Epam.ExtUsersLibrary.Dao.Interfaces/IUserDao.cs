using Epam.ExtUsersLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ExtUsersLibrary.Dao.Interfaces
{
    public interface IUserDao
    {
        User Add(User user);

        User GetById(int id);

        int Remove(int id);
        IEnumerable<User> GetAll();
        User Update(int userId, string name, DateTime dob, string upic);
        void GiveUserAward(int userId, int awardId);
        void RemoveUserAward(int userId, int awardId);
    }
}
