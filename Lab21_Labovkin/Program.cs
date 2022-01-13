using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab21_Labovkin
{
    class Program
    {
        //объявляем константы
        const int n = 5;
        const int m = 10;
        //объявляем двумерный массив и инициализируем его, для понимания за какое время каждый из садовников обработает ячейку
        private static int[,] garden = new int[n, m]{ { 2, 5, 7, 0, 20, 1, 7, 8, 25, 3 }, { 10, 15,2, 0, 30, 11, 5, 21, 2, 13 },
             { 4, 11, 27, 36, 12, 11, 0, 9, 17, 0 }, { 30, 5, 27, 8, 19, 21, 17, 0, 1, 3 }, { 3, 13, 0, 26, 0, 31, 7, 15, 35, 4 }};
        static void Main(string[] args)
        {
            //основной поток
            //создаем переменную делегата
            ThreadStart threadStart = new ThreadStart(Gardener1);
            //создаем экземпляр класса thread
            Thread thread = new Thread(threadStart);
            //запускаем поток на исполнение
            thread.Start();

            //запускаем садовника2 отдельным методом,в текущем потоке
            Gardener2();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    //выводим на экран резульат работы садовников
                    Console.Write($"{garden[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        //пишем статический метод для садовника1
        private static void Gardener1()
        {
            //перебираем массив
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    //проверяем условие для садовника1, что здесь еще не был садовник2
                    if (garden[i, j] >= 0)
                    {
                        int delay = garden[i, j];
                        garden[i, j] = -1;
                        //задерживаемся на delay количество милисекунд в этой клетке
                        Thread.Sleep(delay);
                    }
                }
            }
        }
        //пишем статический метод для садовника1
        private static void Gardener2()
        {
            //перебираем массив
            for (int i = m - 1; i > 0; i--)
            {
                for (int j = n - 1; j > 0; j--)
                {
                    //проверяем условие для садовника1, что здесь еще не был садовник2
                    if (garden[j, i] >= 0)
                    {
                        int delay = garden[j, i];
                        garden[j, i] = -2;
                        //задерживаемся на delay количество милисекунд в этой клетке
                        Thread.Sleep(delay);
                    }
                }
            }
        }
    }
}
