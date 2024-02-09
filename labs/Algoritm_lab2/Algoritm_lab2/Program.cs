using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algoritm_lab2
{
    class Program
    {
        public static void Mul(ulong a, ulong b)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ulong c = a * b;
            sw.Stop();
            Console.WriteLine("Результат - " + c);
            Console.WriteLine("Время - " + sw.Elapsed);
        }

        public static void Sum(ulong a, ulong b)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ulong c = 0;
            while (b != 0)
            {
                c +=a;
                b--;
            }
            sw.Stop();
            Console.WriteLine("Результат - " + c);
            Console.WriteLine("Время - " + sw.Elapsed);
        }
        static double Task7(int x, int y, int N)
        {
            double res = 0;
            if (N > 0)
                res = Math.Sqrt(x + y * Task7(x + 1, y + 1, N - 1));
            return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа #3 по курсу \"Алгоритмы и анализ сложности\" \n" +
                              "Студентки группы 6213-020302D\n" +
                              "Гижевской Валерии Дмитриевны \n" +
                              "Вариант 2 и вариант 7");
            Console.WriteLine("\n\nВариант 2:");
            Console.WriteLine("\nВведите два числа:");
            ulong a = Convert.ToUInt64(Console.ReadLine());
            ulong b = Convert.ToUInt64(Console.ReadLine());
            Console.WriteLine("\nТрадиционная функция:");
            Mul(a, b);
            Console.WriteLine("\nТолько операция сложения:");
            Sum(a, b);
            Console.WriteLine("\n\nВариант 7:");
            Console.WriteLine("\nВведите количество повторений:");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nЗначение выражения при {0} рекурсивных повторений - {1} ", N, Task7(6, 2, N));
            Console.ReadKey();
        }
    }
}
