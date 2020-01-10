using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomSortDemo();
            NumberArraySum();
            ToIntOrNotToInt();
            SortingUnit();
            ISeekYou.Init();
            Console.ReadKey();
        }

        //Task 4.1 Custom Sort
        static T[] MySort<T>(in T[] array, Func<T, T, Boolean> predict)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (predict == null)
            {
                throw new ArgumentNullException();
            }
            T temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (predict(array[i], array[j]))
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }

            }
            return array;
        }

        //Task 4.2 Custom Sort Demo
        public static void CustomSortDemo()
        {
            Console.WriteLine("Task 4.2. Custom sort demo:");
            string[] stringArray = new string[] { "aabcdf", "dcv", "abcdsf", "fds" };
            OutEnum(MySort(stringArray, sortString));
        }
        public static bool sortString(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return s1.Length < s2.Length;
            }
            else
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1[i] != s2[i])
                    {
                        return s1[i] < s2[i];
                    }
                }
                return true;
            }
        }
        static void OutEnum<T>(IEnumerable<T> en)
        {
            foreach (var item in en)
            {
                Console.WriteLine(item.ToString());
            }
        }


        // Task 4.3 Sorting unit
        public static void SortingUnit()
        {
            int[] arr = new int[] { 1, 24, 56, 2, 4, 6 };
            Console.WriteLine("\nTask 4.3. Sorting Unit:");
            Notify += NotifyHandler;
            string[] sarr = new string[] { "fsfds", "dasdad", "dsa" };
            StartSortInNewThread(arr, (x, j) => x < j);
            StartSortInNewThread(sarr, sortString);
            Console.WriteLine("Press Enter for out arrays");
            Console.ReadLine();
            Console.WriteLine("\narray 1:");
            OutEnum(arr);
            Console.WriteLine("\narray 2:");
            OutEnum(sarr);
        }
        public static void NotifyHandler(String s)
        {
            Console.WriteLine(s);
        }
        public static event Action<string> Notify = delegate { };
        static void StartSortInNewThread<T>(T[] array, Func<T, T, bool> deleg)
        {
            new Thread(() => {
                MySort(array, deleg);
                Notify?.Invoke("Sort was done!");
            }).Start();

        }

        // Task 4.4 Number Array Sum
        public static void NumberArraySum()
        {
            int[] arr = new int[] { 1, 24, 56, 2, 4, 6 };
            Console.WriteLine("\nTask 4.4. Number Array Sum:");
            OutEnum(arr);
            Console.WriteLine("Sum of Array: " + arr.SumOfArray());
        }
        // Task 4.5 To Int Or Not To Int
        public static void ToIntOrNotToInt()
        {
            Console.WriteLine("\nTask 4.5. To Int Or Not To Int");
            string s1 = "54wdsax";
            string s2 = "-54";
            string s3 = "21";
            Console.WriteLine(s1 + " : " + s1.IsPositiveInt());
            Console.WriteLine(s2 + " : " + s2.IsPositiveInt());
            Console.WriteLine(s3 + " : " + s3.IsPositiveInt());
        }
    }
}
