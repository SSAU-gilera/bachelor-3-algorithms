﻿using System;
using System.Diagnostics;

namespace Algoritm_lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ArrayGenerator(int length, int seed)
            {
                Random rand = new Random(seed);
                int[] result = new int[length];
                for (int i = 0; i < length; i++)
                {
                    result[i] = rand.Next(-25000, 25000);
                }

                return result;
            }

            void ShakerSort(int length, int seed)
            {
                int[] arr = ArrayGenerator(length, seed);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                int left = 0;
                int right = arr.Length - 1;

                while (left < right)
                {
                    for (int i = left; i < right; i++)
                    {
                        if (arr[i] > arr[i + 1])
                        {
                            int tmp = arr[i];
                            arr[i] = arr[i + 1];
                            arr[i + 1] = tmp;

                        }
                    }

                    right--;

                    for (int i = right; i > left; i--)
                    {
                        if (arr[i] < arr[i - 1])
                        {
                            int tmp = arr[i];
                            arr[i] = arr[i - 1];
                            arr[i - 1] = tmp;

                        }
                    }

                    left++;

                }
                sw.Stop();
                Console.WriteLine("На массиве из {0} элементов время работы ShakerSort: {1}", length, sw.Elapsed);
            }

            int Partition(int[] array, int start, int end)
            {
                int tmp;
                int marker = start;
                for (int i = start; i < end; i++)
                {
                    if (array[i] < array[end])
                    {
                        tmp = array[marker];
                        array[marker] = array[i];
                        array[i] = tmp;
                        marker++;
                    }
                }

                tmp = array[marker];
                array[marker] = array[end];
                array[end] = tmp;
                return marker;
            }

            void QSortWrapper(int length, int seed)
            {
                int[] array = ArrayGenerator(length, seed);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                QSort(array, 0, array.Length - 1);
                sw.Stop();
                Console.WriteLine("На массиве из {0} элементов время работы QuickSort: {1}", length, sw.Elapsed);
            }

            void QSort(int[] array, int start, int end)
            {

                if (start >= end) return;
                int pivot = Partition(array, start, end);
                QSort(array, start, pivot - 1);
                QSort(array, pivot + 1, end);

            }

            Console.WriteLine("Лабораторная работа #1 по курсу \"Алгоритмы и анализ сложности\" \n" +
                              "Студентки группы 6213-020302D\n" +
                              "Гижевской Валерии Дмитриевны \n" +
                              "Вариант 3 - ShakerSort и QSort");

            for (int i = 10000; i <= 100000; i += 10000)
            {
                int now = DateTime.Now.Millisecond;

                ShakerSort(i, now);
                QSortWrapper(i, now);
            }

            Console.ReadLine();
        }
    }
}
