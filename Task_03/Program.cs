using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 3.1
            Lost();
            Console.WriteLine();
            //Task 3.2
            WordFrequency();
            Console.ReadKey();

        }

        //Task 3.1

        public static void Lost()
        {
            Console.WriteLine("\nTask 3.1 Lost:");
            List<String> list = new List<String>() { "1st.", "2nd.", "3rd.", "4th.", "5th.", "6th.", "7th.", "8th.", "9th." };
            Console.WriteLine("Starting items: ");
            OutList(list);
            Console.Write("\nLast is: ");
            OutList(DeleteEverySecond(list));
        }
        public static List<T> DeleteEverySecond<T>(List<T> list)
        {

            int count = 1;
            while (list.Count() > 1)
            {
                List<T> temp = new List<T>();
                foreach (var item in list)
                {
                    if (count % 2 != 0)
                    {
                        temp.Add(item);
                    }
                    count++;
                }
                list = temp;

            }
            return list;
        }
        public static void OutList<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }


        //Task 3.2

        public static void WordFrequency()
        {
            Console.WriteLine("\nTask 3.2 WordFrequency:");
            Console.WriteLine("[Word] : [Frequency]");
            String englishText = "The announcement did not include any specific" +
                " titles or dates to look forward to, " +
                "but did state that “multiple titles” were in development." +
                " There was also no confirmation about which developers will be working with Riot Forge, though that information" +
                " will likely come in the future, along with game announcements." +
                " The first game will be announced at The Game Awards on Dec. 12";
            OutDictionary(GetWordStats(englishText));


        }
        public static Dictionary<String, int> GetWordStats(String englishText)
        {
            Dictionary<string, int> wordStats = new Dictionary<string, int>();
            StringBuilder cleanText = new StringBuilder();

            for (int i = 0; i < englishText.Length; i++)
            {
                if (englishText[i] == '.')
                {
                    cleanText.Append(englishText[i]);
                }
                else if (Char.IsPunctuation(englishText[i]))
                {

                }
                else
                {
                    cleanText.Append(englishText[i]);
                }
            }

            var everyWord = cleanText.ToString().Split(' ', '.');
            for (int i = 0; i < everyWord.Length; i++)
            {
                int wordCounter = 0;
                for (int j = 0; j < everyWord.Length; j++)
                {
                    if (everyWord[j].ToLower() == everyWord[i].ToLower())
                    {
                        wordCounter++;
                    }
                }
                if (!wordStats.ContainsKey(everyWord[i].ToLower()) && (!String.IsNullOrEmpty(everyWord[i])))
                {
                    wordStats.Add(everyWord[i].ToLower(), wordCounter);
                }
            }
            return wordStats;

        }
        public static void OutDictionary(Dictionary<String, int> dictionary)
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine("{0} : {1}", item.Key, item.Value);
            }
        }
    }
}
