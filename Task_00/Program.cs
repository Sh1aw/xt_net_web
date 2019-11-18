using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_00
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 0.1: ");
            Console.WriteLine(Seq(7));
            Console.WriteLine();

            Console.WriteLine("Task 0.2: ");
            Console.WriteLine(IsSimple(7));
            Console.WriteLine();

            Console.WriteLine("Task 0.3: ");
            MakeSquare(7);
            Console.WriteLine();

            Console.WriteLine("Task 0.4: ");
            int[][] arr1 = MakeArray();
            Console.WriteLine("\nНесортированный массив: ");
            OutArray(arr1);
            Console.WriteLine("\n");
            SortArray(arr1);
            Console.WriteLine("Отсортированный массив: ");
            OutArray(arr1);
            Console.ReadKey();
        }

        //task 0.1
        static String Seq(int n)
        {
            if (n < 1)
            {
                return "Число n должно быть больше чем 0";
            }
            StringBuilder s = new StringBuilder();
            for (int i = 1; i < n; i++)
            {
                s.Append(i + ", ");
            }
            s.Append(n); //добавляем последнее число в строку без запятой
            return s.ToString();
        }

        //task 0.2
        static bool IsSimple(int n)
        {
            if (n < 2)
            {
                return false;
            }
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        //task 0.3
        static void MakeSquare(int n)
        {
            if (n % 2 == 0 || n < 3)
            {
                Console.WriteLine("Для формирования квадрата значение N должно быть больше 2 и являться нечетным");
                return;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i == (n / 2)) && ((j == (n / 2))))
                    {
                        Console.Write(" ");         //убираем звездочку из середины квадрата
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }
        }

        //task 0.4
        static int[][] MakeArray()
        {
            Random r = new Random();
            Console.WriteLine("Введите размерность массива массивов");
            int sizeGen = Convert.ToInt32(Console.ReadLine());
            CheckSizeArray(ref sizeGen);
            int[][] arrayOfArrays = new int[sizeGen][];
            int sizeOfUnderArray = 0;
            for (int i = 0; i < sizeGen; i++)
            {
                Console.WriteLine("Введите размерность " + i + "го массива");
                sizeOfUnderArray = Convert.ToInt32(Console.ReadLine());
                CheckSizeArray(ref sizeOfUnderArray);
                arrayOfArrays[i] = new int[sizeOfUnderArray];
                for (int j = 0; j < sizeOfUnderArray; j++)
                {
                    arrayOfArrays[i][j] = r.Next(0, 100);
                }
            }
            return arrayOfArrays;

        }

        static void OutArray(int[][] arr)
        {
            Console.Write("{");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{");
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + ",");
                }
                Console.Write("},");

            }
            Console.Write("}");
        }

        static void SortArray(int[][] arr)
        {
            int temp, j, i, count = 0;
            int[] cur;

            for (i = 0; i < arr.Length; i++)
            {
                cur = arr[i];
                count += arr[i].Length; // счет общего количества элементов в массиве
                j = i;
                while (j > 0 && cur.Length < arr[j - 1].Length) // сортировка массива по размеру подмассивов;
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = cur;
            }

            int[] allArr = new int[count];
            count = 0;

            for (i = 0; i < arr.Length; i++)        // перевод зубчатого массива в одномерный, для дальнейшей сортировки;
            {
                for (j = 0; j < arr[i].Length; j++)
                {
                    allArr[count] = arr[i][j];
                    count++;
                }
            }

            for (i = 0; i < allArr.Length; i++)     // сортировка одномерного массива;
            {
                temp = allArr[i];
                j = i;
                while (j > 0 && temp < allArr[j - 1])
                {
                    allArr[j] = allArr[j - 1];
                    j--;
                }
                allArr[j] = temp;
            }

            count = 0;

            for (i = 0; i < arr.Length; i++)         // перевод отсортированного одномерного массива обратно в зубчатый;
            {
                for (j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = allArr[count];
                    count++;
                }
            }

        }

        static void CheckSizeArray(ref int size)
        {
            if (size < 0)
            {
                Console.WriteLine("Размерность массива не может быть отрицательной");
                size = 0;
            }
        }
    }
}
