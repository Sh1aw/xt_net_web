using Epam.ExtUsersLibrary.Entities;
using System;
using System.Collections.Generic;

namespace Epam.ExtUsersLibrary.Dao.Interfaces
{
    public interface IUserDao
    {
        User Add(User user);

        User GetById(int id);

        int Remove(int id);
        IEnumerable<User> GetAll();
        User Update(int userId, string name, DateTime dob, byte[] imgBytes);
    }
}
