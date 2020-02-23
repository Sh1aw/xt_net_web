using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ExtUsersLibrary.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public Role(string name)
        {
            Name = name;
        }
    }
}
