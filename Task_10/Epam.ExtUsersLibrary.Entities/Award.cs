using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ExtUsersLibrary.Entities
{
    public class Award
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public List<int> UserIds;
        public String PicPath { get; set; }
        public Award(String name, string picPath)
        {
            Name = name;
            UserIds = new List<int>();
            PicPath = picPath;
        }

        public override string ToString()
        {
            return $"Id: {Id}; Name: {Name};";
        }
    }
}
