using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using static System.Console;

namespace lab15
{
    public class BlockingCollection
    {
        static BlockingCollection<string> store = new BlockingCollection<string>(5);
        public static void Check()
        {
            Task[] sellers = new Task[5]
            {
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        store.Add("Электробритва");
                        foreach (var item in store)
                        {
                            Write($"{item}, ");
                        }
                        WriteLine();
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(2000);
                        store.Add("Холодильник");
                        foreach (var item in store)
                        {
                            Write($"{item}, ");
                        }
                        WriteLine();
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(900);
                        store.Add("Индукционная плита");
                        foreach (var item in store)
                        {
                            Write($"{item}, ");
                        }
                        WriteLine();
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(3000);
                        store.Add("Фрезер");
                        foreach (var item in store)
                        {
                            Write($"{item}, ");
                        }
                        WriteLine();
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1500);
                        store.Add("Блендер");
                        foreach (var item in store)
                        {
                            Write($"{item}, ");
                        }
                        WriteLine();
                    }
                })
            };
            foreach (var item in sellers)
            {
                if(item.Status != TaskStatus.Running)
                {
                    item.Start();
                }
            }
            for(int i = 0; i < 10; i++)
            {
                WriteLine("Кол-во: " + store.Count);
                Thread.Sleep(200);
                Thread thread = new Thread(Buyer);
                thread.Start();
            }
        }
        public static void Buyer()
        {
            if (store.Count == 0)
            {
                WriteLine("Покупателю ничего не досталось");
                return;
            }

            WriteLine($"Купили {store.Take()}");
        }
    }
}
