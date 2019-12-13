using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_04
{
    static class Extensions
    {
        public static int SumOfArray(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static bool IsPositiveInt(this string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            s = s.Replace(" ", "");
            if (s.Length == 0)
            {
                return false;
            }
            foreach (var item in s)
            {
                if (!char.IsDigit(item))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
