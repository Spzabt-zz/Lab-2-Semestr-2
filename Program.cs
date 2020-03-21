using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Варіант №4
            int[,] myArr = new int[0, 0];
            int[] array = new int[0];
            int[][] jaggedArray = new int[0][];
            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine("1 - Задание 1.");
                Console.WriteLine("2 - Задание 2.");
                Console.WriteLine("3 - Задание 3.");
                Console.WriteLine("4 - Задание 4.");
                Console.WriteLine("5 - Выход.");
                Console.WriteLine();
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        ZeroCount(myArr);
                        Console.WriteLine("\n\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        FirstOfMaxElements(myArr);
                        Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        DestroyElement(array);
                        break;
                    case 4:
                        AddRowInStart(jaggedArray);
                        Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        isOpen = false;
                        Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                        break;
                    default:
                        Console.WriteLine("Ошибка, неправильная команда!");
                        break;
                }
            }

            Console.ReadKey();
        }

        static void UserInput(ref int[,] myArr)
        {
            Console.Write("\nВведите размерность двумерного массива: ");
            int elementCount = int.Parse(Console.ReadLine());
            myArr = new int[elementCount, elementCount];

            Random rand = new Random();
            Console.WriteLine("\nНажмите 1 для рандомного ввода.");
            Console.WriteLine("Нажмите 2 для ввода с клавиатуры.\n");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    for (int x = 0; x < myArr.GetLength(0); x++)
                    {
                        for (int y = 0; y < myArr.GetLength(1); y++)
                        {
                            myArr[x, y] = rand.Next(0, 100);
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("\nВведите элементы массива:");
                    for (int x = 0; x < myArr.GetLength(0); x++)
                    {
                        for (int y = 0; y < myArr.GetLength(1); y++)
                        {
                            myArr[x, y] = int.Parse(Console.ReadLine());
                        }
                        Console.WriteLine();
                    }
                    break;
                default:
                    Console.WriteLine("Неизвестная команда!");
                    break;
            }
        }

        static void UserOutput(int[,] myArr)
        {
            Console.WriteLine("\nВывод:");
            for (int x = 0; x < myArr.GetLength(0); x++)
            {
                for (int y = 0; y < myArr.GetLength(1); y++)
                {
                    Console.Write(myArr[x, y] + "\t");
                }
                Console.WriteLine();
            }
        }
        //Завдання №1
        static void ZeroCount(int[,] myArr)
        {
            UserInput(ref myArr);
            UserOutput(myArr);

            Console.WriteLine("\nЗадание 1.");
            int rowCount = 0;

            for (int x = 0; x < myArr.GetLength(0); x++)
            {
                for (int y = 0; y < myArr.GetLength(1); y++)
                {
                    if (myArr[x, y] == 0)
                    {
                        rowCount++;
                        break;
                    }
                }
            }

            Console.Write("Кол-во рядов, в которых есть хотя б один ноль: " + rowCount);
        }
        //Завдання №2
        static void FirstOfMaxElements(int[,] myArr)
        {
            UserInput(ref myArr);
            UserOutput(myArr);

            int maxNumber = int.MinValue, tempNum, j = 0;
            Console.WriteLine("\nЗадание 2.");
            Console.Write("Первые из максимальных чисел в каждом ряду и их" +
                " замена местами с элементами главной диагонали.");

            for (int x = 0; x < myArr.GetLength(0); x++)
            {
                for (int y = 0; y < myArr.GetLength(1); y++)
                {
                    if (maxNumber < myArr[x, y])
                    {
                        maxNumber = myArr[x, y];
                        j = y;
                    }
                }
                if (maxNumber > myArr[x, x])
                {
                    tempNum = myArr[x, x];
                    myArr[x, x] = maxNumber;
                    myArr[x, j] = tempNum;
                }
                maxNumber = 0;
            }

            UserOutput(myArr);
        }
        //Знизу завдання №3 та методи до нього.
        static void DestroyElement(int[] array)
        {
            bool isOpen = true;
            int count;
            Console.WriteLine("\nЗадание 3.");
            Console.WriteLine("Изменение кол-ва элементов массива.\n");

            while (isOpen)
            {
                Random rand = new Random();
                int n, destroyElement;

                Console.WriteLine("1 - Уменьшить кол-во элементов массива.");
                Console.WriteLine("2 - Увеличить кол-во элементов массива.");
                Console.WriteLine("3 - Выход на главное меню.");
                Console.WriteLine();

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        InputDestroyElement(ref array, out n);

                        Console.Write("\n\nУменьшите массив (было 5 - стало 4): ");
                        count = Convert.ToInt32(Console.ReadLine());
                        Array.Resize(ref array, count);

                        RandDestroyElement(array, ref rand, ref n);

                        OutputDestroyElement(array);
                        DestroyElement(array, out destroyElement);

                        Console.WriteLine("\nВывод:");
                        for (int i = 0; i < array.Length - 1; i++)
                        {
                            Console.Write(array[i] + " ");
                        }

                        Console.WriteLine("\n\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        InputDestroyElement(ref array, out n);

                        Console.Write("\n\nРасширьте массив (было 5 - стало 6): ");
                        count = Convert.ToInt32(Console.ReadLine());
                        Array.Resize<int>(ref array, count);

                        RandDestroyElement(array, ref rand, ref n);

                        OutputDestroyElement(array);
                        DestroyElement(array, out destroyElement);

                        Console.WriteLine("\nВывод:");
                        for (int i = 0; i < array.Length - 1; i++)
                        {
                            Console.Write(array[i] + " ");
                        }

                        Console.WriteLine("\n\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        isOpen = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка, неправильная команда!");
                        break;
                }
            }

            Console.Clear();
        }

        static void InputDestroyElement(ref int[] array, out int n)
        {
            Random rand = new Random();
            Console.Write("\nВведите размерность массива: ");
            n = Convert.ToInt32(Console.ReadLine());
            array = new int[n];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(0, 100);
                Console.Write(array[i] + " ");
            }
        }

        static void RandDestroyElement(int[] array, ref Random rand, ref int n)
        {
            rand = new Random();

            for (int i = n; i < array.Length; i++)
            {
                array[i] = rand.Next(0, 100);
            }
        }

        static void DestroyElement(int[] array, out int destroyElement)
        {
            Console.Write("\nВведите номер элемента который вы хотите удалить: ");
            destroyElement = Convert.ToInt32(Console.ReadLine());

            for (int i = destroyElement - 1; i < array.Length-1; i++)
            {
                array[i] = array[i + 1];
            }
        }

        static void OutputDestroyElement(int[] array)
        {
            Console.WriteLine("\nВывод:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        //Знизу завдання №4 та методи до нього.
        static void AddRowInStart(int[][] jaggedArray)
        {
            Random rand = new Random();
            int n = 0;
            int count = 0;
            Console.WriteLine("\nЗадание 4.");
            Console.WriteLine("Добавить K-строк в начало матрицы.\n");

            InputJaggedArray(ref jaggedArray, ref n, ref rand);

            int[][] tempArray;
            tempArray = jaggedArray;

            Console.Write("\nРасширьте массив (было 5 - стало 6): ");
            n = Convert.ToInt32(Console.ReadLine());
            Array.Resize<int[]>(ref jaggedArray, n);

            ExtendingArray(jaggedArray, ref tempArray, ref count, ref rand);

            Console.WriteLine();
            OutputJaggedArray(jaggedArray);
        }

        static void InputJaggedArray(ref int[][] jaggedArray, ref int n, ref Random rand)
        {
            rand = new Random();
            Console.Write("Введите кол-во строк массива: ");
            n = Convert.ToInt32(Console.ReadLine());
            jaggedArray = new int[n][];

            Console.WriteLine();

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write("Введите кол-во элементов в строке №" + (i + 1) + ": ");
                int numCount = Convert.ToInt32(Console.ReadLine());
                jaggedArray[i] = new int[numCount];

                for (int j = 0; j < jaggedArray[i].GetLength(0); j++)
                {
                    jaggedArray[i][j] = rand.Next(0, 100);
                }
            }

            Console.WriteLine();

            OutputJaggedArray(jaggedArray);
        }

        static void ExtendingArray(int[][] jaggedArray, ref int[][] tempArray, ref int count, ref Random rand)
        {
            for (int i = 0; i < jaggedArray.Length - tempArray.Length; i++)
            {
                Console.Write("Введите кол-во элементов в строке №" + (i + 1) + ": ");
                int numCount = Convert.ToInt32(Console.ReadLine());
                jaggedArray[i] = new int[numCount];

                for (int j = 0; j < jaggedArray[i].GetLength(0); j++)
                {
                    jaggedArray[i][j] = rand.Next(0, 100);
                }
            }
            for (int i = jaggedArray.Length - tempArray.Length; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = tempArray[count];
                count++;
            }
        }

        static void OutputJaggedArray(int[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].GetLength(0); j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}