using Epam.ExtUsersLibrary.Entities;
using System;
using System.Collections.Generic;

namespace Epam.ExtUsersLibrary.BLL.Interfaces
{
    public interface IUserLogic
    {
        User Add(User user);

        User GetById(int id);

        int Remove(int id);
        IEnumerable<User> GetAll();
        User Update(int userId, string name, DateTime dob,string upic);
    }
}
