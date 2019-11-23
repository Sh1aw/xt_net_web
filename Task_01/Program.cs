using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            RectangleArea();
            Console.WriteLine();
            DrawTrinangle();
            Console.WriteLine();
            DrawAnotherTrinangle();
            Console.WriteLine();
            DrawXMASTree();
            Console.WriteLine();
            Console.WriteLine(SumOfNumbers(1000));
            Console.WriteLine();
            FontAdjusment();
            Console.WriteLine();
            ArrayProcessing();
            Console.WriteLine("\n");
            Array3DElementsToNull();
            Console.WriteLine();
            NonNegativeSum();
            Console.WriteLine();
            Array2D();
            Console.WriteLine();
            AverageWordSize();
            Console.WriteLine();
            CharDoubler();
            Console.ReadKey();
        }

        // Task 1.1 Rectangle
        static void RectangleArea()
        {
            Console.WriteLine("Task 1.1\nВведите значение стороны A прямоугольника:");
            int a = ParseUserIntInput();
            Console.WriteLine("Введите значение стороны B прямоугольника:");
            int b = ParseUserIntInput();
            int area = a * b;
            Console.WriteLine("Площадь прямоугольника равна: " + area);
        }
        static int ParseUserIntInput()
        {
            int IntUnput = 0;
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out IntUnput) && IntUnput > 0)
                {
                    return IntUnput;
                }
                else
                {
                    Console.WriteLine("Введенное значение некоректно! Повторите ввод!");
                }
            }
        }

        // Task 1.2 Trinangle
        static void DrawTrinangle()
        {
            Console.WriteLine("Task 1.2\nВведите значение N для отрисовки треугольника:");
            int n = ParseUserIntInput();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        //Task 1.3 Another Trinangle
        static void DrawAnotherTrinangle()
        {
            Console.WriteLine("Task 1.3\nВведите значение N для отрисовки другого треугольника:");
            int n = ParseUserIntInput();
            for (int i = 1; i <= n * 2; i = i + 2)
            {
                for (int j = 0; j < (n * 2 - i) / 2; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < i; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        //Task 1.4 XMASTree
        static void DrawXMASTree()
        {
            Console.WriteLine("Task 1.4\nВведите значение N для отрисовки ёлки");
            int n = ParseUserIntInput();
            for (int o = 1; o <= n; o++)
            {
                for (int i = 1; i <= o * 2; i = i + 2)
                {
                    for (int j = 0; j < (n * 2 - i) / 2; j++)
                    {
                        Console.Write(" ");
                    }
                    for (int k = 0; k < i; k++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
        }

        //Task 1.5 Sum Of Numbers
        static int SumOfNumbers(int n)
        {
            Console.WriteLine("Task 1.5\nСумма чисел кратных 3 и 5 в интервале от 0 до " + n + " равняется:");
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

        //Task 1.6 FontAdjusment
        static void FontAdjusment()
        {
            Console.WriteLine("Task 1.6");
            FontStyles fontStyles = FontStyles.none;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Введите параметр для редактирования стиля:\n 1. - bold;\n 2. - italic;\n 3. - underline;\n 4. - выход из данного таска\n");
                int param = ParseUserIntInput();
                switch (param)
                {
                    case 1:
                        {
                            fontStyles = fontStyles.HasFlag(FontStyles.bold) ? fontStyles = fontStyles ^ FontStyles.bold : fontStyles = fontStyles | FontStyles.bold;
                            break;
                        }
                    case 2:
                        {
                            fontStyles = fontStyles.HasFlag(FontStyles.italic) ? fontStyles = fontStyles ^ FontStyles.italic : fontStyles = fontStyles | FontStyles.italic;
                            break;
                        }
                    case 3:
                        {
                            fontStyles = fontStyles.HasFlag(FontStyles.underline) ? fontStyles = fontStyles ^ FontStyles.underline : fontStyles = fontStyles | FontStyles.underline;
                            break;
                        }
                    case 4:
                        {
                            flag = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                Console.WriteLine("Текущий набор стилей: " + fontStyles);

            }

        }
        [Flags]
        enum FontStyles
        {
            none = 0,
            bold = 1,
            italic = 2,
            underline = 4,
        }

        //Task 1.7 ArrayProcessing
        static void ArrayProcessing()
        {
            Console.WriteLine("Task 1.7\nИзначальный массив:");
            int[] array = Generate1DArray(10);
            int minElem = array[0];
            int maxElem = array[array.Length - 1];
            OutArray(array);

            //Нахождение максимального и минимального элемента
            for (int i = 0; i < array.Length; i++)
            {
                if (minElem > array[i])
                {
                    minElem = array[i];
                    continue;
                }
                if (maxElem < array[i])
                {
                    maxElem = array[i];
                }
            }
            Console.WriteLine("\nMin: {0}, Max: {1};", minElem, maxElem);

            //Сортировка массива
            int temp = 0;
            for (int i = 0; i < array.Length; i++)
            {
                temp = array[i];
                int j = i;
                while (j > 0 && temp < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = temp;
            }
            Console.WriteLine("Отсортированный массив:");
            OutArray(array);
        }
        //Генерация одномерного массива
        static int[] Generate1DArray(int n)
        {
            Random r = new Random();
            int[] array = new int[n];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(-30, 30);
            }
            return array;
        }
        //Вывод одномерного массива
        static void OutArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ", ");
            }
        }

        //Task 1.8 No Positive
        static void Array3DElementsToNull()
        {
            int[,,] array = Generate3DArray(2);
            Console.WriteLine("Task 1.8\nИзначальный массив:");
            Out3DArray(array);
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        if (array[i, j, k] > 0)
                        {
                            array[i, j, k] = 0;
                        }
                    }
                }
            }
            Console.WriteLine("\nМассив после обнуления положительных значений:");
            Out3DArray(array);

        }
        //Генерация трехмерного массива
        static int[,,] Generate3DArray(int n)
        {
            Random r = new Random();
            int[,,] array = new int[n, n, n];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = r.Next(-10, 10);
                    }
                }
            }
            return array;
        }
        //Вывод трехмерного массива
        static void Out3DArray(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        Console.WriteLine("[{0}, {1}, {2}] = {3}; ", i, j, k, array[i, j, k]);
                    }
                }
            }
        }

        //Task 1.9 Non-Negative Sum
        static void NonNegativeSum()
        {
            int[] array = Generate1DArray(15);
            Console.WriteLine("Task 1.9\nИзначальный массив:");
            OutArray(array);
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    sum += array[i];
                }
            }
            Console.WriteLine("\nСумма положительных элементов: " + sum);
        }

        //Task 1.10 2D Array
        static void Array2D()
        {
            Console.WriteLine("Task 1.10\n");
            int[,] array = Generate2Darray(3);
            Out2DArray(array);
            int sum = SumOf2Numbers(array);
            Console.WriteLine("Сумма элементов на четных позициях равна: " + sum);

        }
        //Суммирование эелементов находящихся на четных позициях
        static int SumOf2Numbers(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += arr[i, j];
                    }
                }
            }
            return sum;
        }
        //Генерация двумерного массива
        static int[,] Generate2Darray(int n)
        {
            Random r = new Random();
            int[,] array = new int[n, n];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = r.Next(-30, 30);
                }
            }
            return array;
        }
        //Вывод двумерного массива
        static void Out2DArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.WriteLine("[{0}, {1}] = {2};", i, j, array[i, j]);
                }
            }
        }

        //Task 1.11 Average String Length
        static void AverageWordSize()
        {
            Console.WriteLine("Task 1.11\nВведите строку для подсчета средней длины слова в ней:");
            String s = Console.ReadLine();
            string[] array = s.Split(' ');
            double sum = 0;
            foreach (string item in array)
            {
                foreach (char underItem in item)
                {
                    if (!Char.IsPunctuation(underItem))
                    {
                        sum++;
                    }
                }
            }
            sum = sum / (array.Length);
            Console.WriteLine("Средняя длина слова в строке: " + sum);
        }

        //Task 1.12 Char Doubler
        //В условиях задачи не было указанно на счет регистрозависимости строк, в данной реализации заглавный и строчный символы учитываются как различные.
        static void CharDoubler()
        {
            Console.WriteLine("Task 1.12\nВведите первую строку:");
            String s1 = ParseUserStringInput();
            Console.WriteLine("Введите вторую строку:");
            String s2 = ParseUserStringInput();
            StringBuilder outString = new StringBuilder();
            foreach (char ch1 in s1)
            {
                if (s2.Contains(ch1) && !Char.IsSeparator(ch1))
                {
                    outString.Append(ch1);
                    outString.Append(ch1);
                }
                else
                {
                    outString.Append(ch1);
                }
            }

            Console.WriteLine(outString);
        }
        static String ParseUserStringInput()
        {
            String s;
            while (true)
            {
                s = Console.ReadLine();
                if (s.Length > 0)
                {
                    return s;
                }
                else
                {
                    Console.WriteLine("Строка не может быть пустой");
                }
            }
        }
    }
}
