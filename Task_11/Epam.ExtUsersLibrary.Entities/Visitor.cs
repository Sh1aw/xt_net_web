using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ExtUsersLibrary.Entities
{
    public class Visitor
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public  string Password { get; set; }

        public int? IdRole { get; set; }

        public Visitor(string login, string password,int? idRole)
        {
            Login = login;
            Password = password;
            IdRole = idRole;
        }
    }
}
