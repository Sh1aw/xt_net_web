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

        public byte[] ImageBytes { get; set; }
        public Award(String name, byte[] img)
        {
            Name = name;
            ImageBytes = img;
        }
        public override string ToString()
        {
            return $"Id: {Id}; Name: {Name};";
        }
    }
}
