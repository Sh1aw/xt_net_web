using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Epam.ExtUsersLibrary.WebPagesPL.Common
{
    public class DefaultAdminChecker
    {
        public static bool CheckDefault(string name, string password)
        {
            if (name.Equals(ConfigurationManager.AppSettings.Get("DefaultLogin")) 
                && password.Equals(ConfigurationManager.AppSettings.Get("DefaultPassword")))
            {
                return true;
            }

            return false;
        }
        public static bool CheckDefault(string name)
        {
            if (name.Equals(ConfigurationManager.AppSettings.Get("DefaultLogin")))
            {
                return true;
            }

            return false;
        }
    }
}