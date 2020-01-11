using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_07
{
    class RegexTools
    {
        public static bool CheckDataContains(string text)
        {
            Regex r1 = new Regex(@"(((0[1-9]|[12]\d)-((0[1-9])|(1[012])))|(30-(0[13-9]|1[012]))|(31-(0[13578]|1[02])))-(\d{4})");
            return r1.IsMatch(text);
        }

        public static string ReplaceHtmlTags(string text)
        {
            StringBuilder strb = new StringBuilder(text);
            Regex r1 = new Regex(@"<.+?>");
            foreach (Match item in r1.Matches(text))
            {
                if (strb.ToString().Contains(item.Value))
                {
                    strb = strb.Replace(item.Value, "_");
                }
            }

            return strb.ToString();
        }

        public static List<String> EmailFinder(String text)
        {
            Regex r1 = new Regex(@"\b([a-z\d]([\w\.\-]*)([\da-z])@([\da-z]([\da-z\-]*)[\da-z]\.)+[a-z]{2,6})\b", RegexOptions.IgnoreCase);
            List<String> emails = new List<string>();
            foreach (Match item in r1.Matches(text))
            {
                emails.Add(item.Value);
            }
            return emails;
        }

        public static TypesOfNumber CheckNumber(String text)
        {
            Regex normal = new Regex(@"^(((-)?\d+)((\.)\d+)?)$");
            Regex scine = new Regex(@"^((-?\d+)(\.\d+)?)(e((-?\d)+)?)$");
            text = text.Trim(' ');
            if (normal.IsMatch(text))
            {
                return TypesOfNumber.SimpleNumber;
            }
            if(scine.IsMatch(text))
            {
                return TypesOfNumber.ScienceNumber;
            }

            return TypesOfNumber.NotANumber;
        }

        public static int TimeMatchesCounter(string text)
        {
            Regex r1 = new Regex(@"(\b(([0-1]?[0-9]|2[0-3]):[0-5][0-9])\b)");
            return r1.Matches(text).Count;
        }
    }
}
