using System;
using System.Collections.Generic;
using Epam.ExtUsersLibrary.Dao.Interfaces;
using Epam.ExtUsersLibrary.Entities;

namespace Epam.ExtUsersLibrary.DAL
{
    public class UserAwardDao : IUserAwardDao
    {
        private static readonly string _userPath = UserDao._path;
        private static readonly string _awardPath = AwardDao._path;


        internal static readonly Dictionary<int, User> dictionaryU = UserDao._users;
        internal static readonly Dictionary<int, Award> dictionaryA = AwardDao._awards;

        public bool GiveUserAward(int idu, int ida)
        {
            if (!IsUserAwardRel(idu,ida))
            {
                dictionaryU[idu].AwardsIds.Add(ida);
                JsonSynchronizer.SynchronizeJSON(_userPath, dictionaryU);
                dictionaryA[ida].UserIds.Add(idu);
                JsonSynchronizer.SynchronizeJSON(_awardPath, dictionaryA);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveUserAward(int idu, int ida)
        {
            
            if (IsUserAwardRel(idu,ida))
            {
                dictionaryU[idu].AwardsIds.Remove(ida);
                JsonSynchronizer.SynchronizeJSON(_userPath, dictionaryU);
                dictionaryA[ida].UserIds.Remove(idu);
                JsonSynchronizer.SynchronizeJSON(_awardPath, dictionaryA);
                return true;
            }
            return false;
        }

        public bool IsUserAwardRel(int idu, int ida)
        {
            if ((!dictionaryU[idu].AwardsIds.Contains(ida)) && (!dictionaryA[ida].UserIds.Contains(idu)))
            {
                return false;
            }

            return true;
        }

    }
}
