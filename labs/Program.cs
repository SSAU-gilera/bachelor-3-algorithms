using System;

namespace Lab2
{
    class Program
    {
        static int FibRecursive(int n)
        {
            if (n < 2) return n;
            return FibRecursive(n - 1) + FibRecursive(n - 2);
        }

        static int FibIterative(int n)
        {
            int n0 = 0, n1 = 1, sum;
            for (int i = 0; i < n; ++i)
            {
                sum = n0 + n1;
                n0 = n1;
                n1 = sum;
            }
            return n0;
        }

        static int Multiply(int a, int b)
        {
            return a * b;
        }

        static int MultiplyBySum(int a, int b)
        {
            int result = 0;
            if (b > 0)
            {
                for (; b > 0; b--, result += a) ;
            }
            else
            {
                for (; b < 0; b++, result -= a) ;
            }
            return result;
        }

        static float TestTime(Action action, Action callback)
        {
            var start = DateTime.Now;
            action();
            var diff = (float)(DateTime.Now - start).TotalMilliseconds;
            callback();
            return diff;
        }

        static void Main(string[] args)
        {
            string action;
            do
            {
                Console.Clear();
                Console.WriteLine("Алгоритмы и анализ сложности. 3 семестр. Лабораторная работа №2.");
                Console.WriteLine("Алгоритмы вычисления ряда Фибоначчи (в. 1), алгоритмы умножения (в. 2).");
                Console.WriteLine("Бавыкин Александр, группа 6214-020302D\n");
                Console.Write("1 - вычисление n-го числа последовательности Фибоначчи;\n"
                    + "2 - умножение через операцию сложения и традиционным способом\n>");
                switch (action = Console.ReadLine())
                {
                    case "1":
                    {
                        Console.Write("Введите номер числа Фибоначчи: ");
                        int n = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        int result = 0;
                        Console.WriteLine("Итеративный алгоритм: " + TestTime(() =>
                        {
                            result = FibIterative(n);
                        }, () =>
                        {
                            Console.WriteLine($"Результат: {result}");
                        }) + "ms");
                        Console.WriteLine("Рекурсивный алгоритм: " + TestTime(() =>
                        {
                            result = FibRecursive(n);
                        }, () =>
                        {
                            Console.WriteLine($"Результат: {result}");
                        }) + "ms");
                        break;
                    }
                    case "2":
                    {
                        Console.Write("Введите первое число: ");
                        int a = int.Parse(Console.ReadLine());
                        Console.Write("Введите второе число: ");
                        int b = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        int result = 0;
                        Console.WriteLine("Умножение через сложение: " + TestTime(() =>
                        {
                            result = MultiplyBySum(a, b);
                        }, () =>
                        {
                            Console.WriteLine($"Результат: {result}");
                        }) + "ms");
                        Console.WriteLine("Умножение традиционным способом: " + TestTime(() =>
                        {
                            result = Multiply(a, b);
                        }, () =>
                        {
                            Console.WriteLine($"Результат: {result}");
                        }) + "ms");
                        break;
                    }
                    default:
                        return;
                }
                Console.WriteLine("\nPress any key to continue . . .");
                Console.ReadKey();
            } 
            while (action != "0");
        }
    }
}
