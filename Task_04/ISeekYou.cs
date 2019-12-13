using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Task_04
{
    class ISeekYou
    {
        public static int numberOfTimes = 1000;
        public static int arraySize = 500;
        public static int[] array = new int[arraySize];
        static public void Init()
        {
            Console.WriteLine("\nTask 4.6. I seek you\n" +
                "Count of numbers in each array: {0};" +
                "\nNumber of Times: {1}",arraySize,numberOfTimes);
            RandomizeArray(array);
            TestStandartMethod();
            Console.WriteLine();
            TestDelegateInstance();
            Console.WriteLine();
            TestAninymousMethod();
            Console.WriteLine();
            TestLambdaExtension();
            Console.WriteLine();
            TestLinq();
            Console.ReadKey();
        }
        static void RandomizeArray(int[] array)
        {
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(-100, 100);
            }
        }
        public static bool Func1(int i)
        {
            return i > 0;
        }
        static IEnumerable<int> SearchPositive(int[] array)
        {
            List<int> positiveCount = new List<int>();
            foreach (var item in array)
            {
                if (item > 0)
                {
                    positiveCount.Add(item);
                }
            }
            return positiveCount;
        }
        public static IEnumerable<int> SearchPositive(int[] array, Predicate<int> predic)
        {
            List<int> positiveCount = new List<int>();
            foreach (var item in array)
            {
                if (predic(item))
                {
                    positiveCount.Add(item);
                }
            }
            return positiveCount;
        }
        static void TestStandartMethod()
        {
            Stopwatch timer = new Stopwatch();
            TimeSpan[] times = new TimeSpan[numberOfTimes];
            for (int i = 0; i < numberOfTimes; i++)
            {
                timer.Start();
                SearchPositive(array);
                timer.Stop();
                times[i] = timer.Elapsed;
            }
            Array.Sort(times);
            Console.WriteLine("Test№1 - Standart Method\nSlowest: {0}; Fastest: {1}; Median: {2}", times[numberOfTimes - 1], times[0], times[numberOfTimes / 2]);

        }
        static void TestDelegateInstance()
        {
            Stopwatch timer = new Stopwatch();
            TimeSpan[] times = new TimeSpan[numberOfTimes];
            for (int i = 0; i < numberOfTimes; i++)
            {
                timer.Start();
                SearchPositive(array, Func1);
                timer.Stop();
                times[i] = timer.Elapsed;
            }
            Array.Sort(times);
            Console.WriteLine("Test№2 - Delegate instance\nSlowest: {0}; Fastest: {1}; Median: {2}", times[numberOfTimes - 1], times[0], times[numberOfTimes / 2]);

        }
        static void TestAninymousMethod()
        {
            Stopwatch timer = new Stopwatch();
            TimeSpan[] times = new TimeSpan[numberOfTimes];
            for (int i = 0; i < numberOfTimes; i++)
            {
                timer.Start();
                SearchPositive(array, delegate (int x) { return x > 0; });
                timer.Stop();
                times[i] = timer.Elapsed;
            }
            Array.Sort(times);
            Console.WriteLine("Test№3  - Anonymous Method\nSlowest: {0}; Fastest: {1}; Median: {2}", times[numberOfTimes - 1], times[0], times[numberOfTimes / 2]);

        }
        static void TestLambdaExtension()
        {
            Stopwatch timer = new Stopwatch();
            TimeSpan[] times = new TimeSpan[numberOfTimes];
            for (int i = 0; i < numberOfTimes; i++)
            {
                timer.Start();
                SearchPositive(array, (x) => x > 0);
                timer.Stop();
                times[i] = timer.Elapsed;
            }
            Array.Sort(times);
            Console.WriteLine("Test№4  - Lambda Expression\nSlowest: {0}; Fastest: {1}; Median: {2}", times[numberOfTimes - 1], times[0], times[numberOfTimes / 2]);

        }
        static void TestLinq()
        {
            Stopwatch timer = new Stopwatch();
            TimeSpan[] times = new TimeSpan[numberOfTimes];
            for (int i = 0; i < numberOfTimes; i++)
            {
                timer.Start();
                IEnumerable<int> posiv = array.Where(x => x > 0);
                timer.Stop();
                times[i] = timer.Elapsed;
            }
            Array.Sort(times);
            Console.WriteLine("Test№5  - LINQ\nSlowest: {0}; Fastest: {1}; Median: {2}", times[numberOfTimes - 1], times[0], times[numberOfTimes / 2]);

        }
    }
}
