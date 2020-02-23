using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ExtUsersLibrary.Entities
{
    public class UserAward
    {
        public UserAward(int userId, int awardId)
        {
            UserId = userId;
            AwardId = awardId;
        }

        public int UserId { get; set; }
        public int AwardId { get; set; }
    }
}
