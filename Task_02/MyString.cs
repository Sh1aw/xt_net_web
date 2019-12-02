using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class MyString
    {
        private char[] charArray;
        public int Length { get => charArray.Length; }
        public MyString(String s)
        {
            charArray = s.ToArray();
        }
        public MyString(char[] array)
        {
            this.charArray = array;
        }
        public char[] ToCharArray()
        {
            return charArray;
        }
        public static MyString ToMyString(char[] array)
        {
            return new MyString(array);
        }
        public int IndexOf(char ch)
        {
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == ch)
                {
                    return i;
                }
            }
            return -1;
        }
        public int Contains(MyString subString)
        {
            if (charArray.Length <= subString.charArray.Length)
            {
                Console.WriteLine("Substring shoud be smaller then string");
                return -1;
            }
            for (int i = 0; i < charArray.Length - subString.charArray.Length; i++)
            {
                for (int j = 0; j < subString.charArray.Length; j++)
                {
                    if (subString.charArray[j] != charArray[i + j])
                    { break; }
                    else if (j + 1 == subString.charArray.Length)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        public int Contains(String subString)
        {
            char[] subCharArray = subString.ToArray();
            if (charArray.Length <= subCharArray.Length)
            {
                Console.WriteLine("Substring shoud be smaller then string");
                return -1;
            }
            for (int i = 0; i < charArray.Length - subCharArray.Length; i++)
            {
                for (int j = 0; j < subCharArray.Length; j++)
                {
                    if (subCharArray[j] != charArray[i + j])
                    { break; }
                    else if (j + 1 == subCharArray.Length)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        public static MyString operator +(MyString s, MyString s1)
        {
            char[] charArrayS3 = new char[s.charArray.Length + s1.charArray.Length];
            for (int i = 0; i < s.charArray.Length; i++)
            {
                charArrayS3[i] = s.charArray[i];
            }
            for (int i = 0; i < s1.charArray.Length; i++)
            {
                charArrayS3[s.charArray.Length + i] = s1.charArray[i];
            }
            return new MyString(charArrayS3);

        }
        public static MyString operator +(MyString s, char[] charArray)
        {
            char[] charArrayS3 = new char[s.charArray.Length + charArray.Length];
            for (int i = 0; i < s.charArray.Length; i++)
            {
                charArrayS3[i] = s.charArray[i];
            }
            for (int i = 0; i < charArray.Length; i++)
            {
                charArrayS3[s.charArray.Length + i] = charArray[i];
            }
            return new MyString(charArrayS3);

        }
        public static MyString operator +(char[] charArray, MyString s1)
        {
            char[] charArrayS3 = new char[charArray.Length + s1.charArray.Length];
            for (int i = 0; i < charArray.Length; i++)
            {
                charArrayS3[i] = charArray[i];
            }
            for (int i = 0; i < s1.charArray.Length; i++)
            {
                charArrayS3[charArray.Length + i] = s1.charArray[i];
            }
            return new MyString(charArrayS3);

        }
        public bool Equals(MyString s2)
        {
            if (charArray.Length == s2.charArray.Length)
            {
                for (int i = 0; i < charArray.Length; i++)
                {
                    if (charArray[i] != s2.charArray[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder s1 = new StringBuilder();
            if (charArray != null)
            {
                foreach (var item in charArray)
                {
                    s1.Append(item);
                }
            }
            return s1.ToString();
        }
    }
}
