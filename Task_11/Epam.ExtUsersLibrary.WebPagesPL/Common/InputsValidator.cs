using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.ExtUsersLibrary.WebPagesPL.Common
{
    public class InputsValidator
    {
        public static bool ValidateId(string id)
        {
            int num;
            bool succses = Int32.TryParse(id, out num);
            if (succses)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidateDate(string date)
        {
            DateTime dateV;
            bool succses = DateTime.TryParse(date, out dateV);
            if (succses)
            {
                if (dateV<DateTime.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}