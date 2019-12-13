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
        public static int[] arr = new int[] { 1, 24, 56, 2, 4, 6 };
        static void Main(string[] args)
        {
            CustomSortDemo();
            NumberArraySum();
            ToIntOrNotToInt();
            SortingUnit();
            Console.ReadKey();
        }

        //Task 4.1 Custom Sort
        static T[] MySort<T>(in T[] array, Func<T, T, Boolean> predict)
        {
            if (array == null)
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
                Console.WriteLine(item);
            }
        }


        // Task 4.3 Sorting unit
        public static void SortingUnit()
        {
            Console.WriteLine("\nTask 4.3. Sorting Unit:");
            Notify += NotifyHandler;
            StartSortInNewThread(arr, (x, j) => x < j);
        }
        public static void NotifyHandler(String s)
        {
            Console.WriteLine(s);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
        public static event Action<string> Notify;
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
