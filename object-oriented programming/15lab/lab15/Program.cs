using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace lab15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region [fourth task]

            Task<int> newTask = Task.Run(() => Enumerable.Range(1, 100).
                                        Count(n => (n % 2 != 0)));
            // получение объекта ожидания
            var awaiter = newTask.GetAwaiter();

            awaiter.OnCompleted(() =>
            {
                int odd = awaiter.GetResult();
                WriteLine(odd);
            });

            #endregion

            #region [first task]
            //множество Мандельброта
            Thread.Sleep(1000);
            Stopwatch stopwatch = new Stopwatch();

            int width = 1500;
            int height = 800;
            int maxIterations = 1000;

            double xmin = -2.0;
            double xmax = 1.0;
            double ymin = -1.5;
            double ymax = 1.5;

            int[,] result = new int[width, height];

            for (int i = 1; i < 4; i++)
            {
                WriteLine("Прогон " + i);
                Task task1 = Task.Run(() =>
                {
                    stopwatch.Start();
                    Parallel.For(0, width, x =>
                    {
                        for (int y = 0; y < height; y++)
                        {
                            // Преобразование координат пикселей в комплексную плоскость
                            double cx = xmin + (xmax - xmin) * x / width;
                            double cy = ymin + (ymax - ymin) * y / height;

                            // Вычисление значения для точки в множестве Мандельброта
                            double zx = 0;
                            double zy = 0;
                            int iteration = 0;

                            while (zx * zx + zy * zy < 4 && iteration < maxIterations)
                            {
                                double tmp = zx * zx - zy * zy + cx;
                                zy = 2 * zx * zy + cy;
                                zx = tmp;
                                iteration++;
                            }

                            result[x, y] = iteration;
                        }
                    });
                    stopwatch.Stop();
                    return stopwatch.ElapsedMilliseconds;
                }).ContinueWith(task =>
                {
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                           /* Write(result[x, y] == maxIterations ? " " : "*");*/
                        }
                       /* WriteLine();*/
                    }
                });

                WriteLine($"Идентификатор: {task1.Id}");
                WriteLine("Завершена: " + task1.IsCompleted);
                WriteLine($"Статус: {task1.Status}");
                /*ReadLine();*/

                stopwatch.Reset();
            }

            #endregion

            WriteLine("--------------------------------------");

            #region [second task]

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            int[,] result2 = new int[width, height];

            Task task2 = Task.Run(() =>
            {

                while (!cancellationToken.IsCancellationRequested)
                {
                    Parallel.For(0, width, x =>
                    {
                        for (int y = 0; y < height; y++)
                        {
                            // Преобразование координат пикселей в комплексную плоскость
                            double cx = xmin + (xmax - xmin) * x / width;
                            double cy = ymin + (ymax - ymin) * y / height;

                            // Вычисление значения для точки в множестве Мандельброта
                            double zx = 0;
                            double zy = 0;
                            int iteration = 0;

                            while (zx * zx + zy * zy < 4 && iteration < maxIterations)
                            {
                                double tmp = zx * zx - zy * zy + cx;
                                zy = 2 * zx * zy + cy;
                                zx = tmp;
                                iteration++;
                            }

                            result[x, y] = iteration;
                        }
                    });
                }

                cancellationToken.ThrowIfCancellationRequested();

            }, cancellationToken);


            Thread.Sleep(2000);
            cancellationTokenSource.Cancel();

            try
            {
                task2.Wait();
            }
            catch (AggregateException e)
            {
                foreach (Exception ex in e.InnerExceptions)
                {
                    if (ex is AggregateException)
                    {
                        WriteLine("Отмена задачи");
                    }
                    else
                    {
                        WriteLine(ex.Message);
                    }
                }
            }

            #endregion

            WriteLine("--------------------------------------");

            #region [third task]

            Task<int> Task1 = Task.Run(() => Formula(4));
            Task<int> Task2 = Task.Run(() => Formula(6));
            Task<int> Task3 = Task.Run(() => Formula(10));

            Task<int> Task4 = Task.Run(() =>
            {
                int sum = Task1.Result + Task2.Result + Task3.Result;
                return sum;
            });

            WriteLine("Получилось " + Task4.Result);

            #endregion

            WriteLine("--------------------------------------");

            #region [fifth task]

            List<int> numbers = Enumerable.Range(1, 10000).ToList();

            Stopwatch toList = new Stopwatch();
            int res = 0;
            toList.Start();
            Parallel.ForEach(numbers, x =>
            {
                res += x;
            });
            toList.Stop();
            WriteLine("Первое время: " + toList.ElapsedMilliseconds);

            toList.Restart();
            toList.Start();
            res = 0;
            foreach(var item in numbers)
            {
                res += item;
            }
            toList.Stop();
            WriteLine("Второе время: " + toList.ElapsedMilliseconds);

            toList.Restart();

            int countArr = 10;
            int size = 1000000;

            toList.Start();

            Parallel.For(0, countArr, i =>
            {
                int[] array = CreateArray(size);

            });

            toList.Stop();
            WriteLine("Третье время: " + toList.ElapsedMilliseconds);

            toList.Restart();
            toList.Start();

            for(int i = 0; i < countArr; i++)
            {
                int[] array = CreateArray(size);
            }

            toList.Stop();
            WriteLine("Четвёртое время: " + toList.ElapsedMilliseconds);
            #endregion

            WriteLine("--------------------------------------");

            #region [sixth task]

            Parallel.Invoke(
                () => WriteLine("Вывод №1"),
                () => WriteLine(Formula(2)),
                () => WriteLine("Вывод №2")
                );

            #endregion

            WriteLine("--------------------------------------");

            #region [seventh task]

            BlockingCollection.Check();

            #endregion

            WriteLine("--------------------------------------");

            #region [eighth task]

            int[] numbs = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Sum(numbs);

            #endregion

        }

        public static async void Sum(int[] numbers)
        {
            var result = Task<int>.Factory.StartNew(() => Processing(numbers));
            int value = await result;
            WriteLine("Вышло " + value);
        }

        public static int Processing(int[] numbers)
        {
            int sum = 0;
            foreach(var number in numbers)
            {
                sum += number;
            }
            return sum;
        }
        public static int Formula(int x)
        {
            int result = 3 * x ^ 2 + 4 * x + 8;
            return result;
        }

        public static int[] CreateArray(int size)
        {
            int[] numbers = new int[size];

            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                numbers[i] = rnd.Next();
            }

            return numbers;
        }
    }
}
