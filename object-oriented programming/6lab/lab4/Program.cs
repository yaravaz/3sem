using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{

    enum Seasons
    {
        Winter = 1,
        Spring,
        Summer,
        Autum,
    }

    struct Buyer
    {
        public string Name;
        public short Age;
        public Buyer(string name, short age)
        {
            Name = name;
            Age = age;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Покупатель {Name}:{Age}");
        }
    }
    interface IRemove
    {
        void Delete();
    }
    class Printer
    {
        public void IAmPrinting(Plant obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Flower newFlower = new Flower("Нарцисс", "Однолетний", "Жёлтый", "Взрослый", 123);
            Cactus newCactus = new Cactus("Шлюмбергера", "Многолетний", "Розовый", "Взрослый", 23, true);

            // Исключение коричневого цвета
            try
            {
                newFlower.Color = "Коричневый";
            }
            catch(UniqueExceptions.CantBeBrown e)
            {
                Console.WriteLine(e.Message);
            }

            // Исключение цены равной 0
            try
            {
                newFlower.Price = 0;
            }
            catch (UniqueExceptions.CostIsZeroException e)
            {
                Console.WriteLine(e.Message);
            }

            // Исключение наличия цветов на кактусе
            try
            {
                newCactus.HasFlowers = false;
            }
            catch (UniqueExceptions.HasFlowersException e)
            {
                Console.WriteLine(e.Message);
            }

            // Исключение деления на ноль

            try
            {
                int a = 7;
                int b =  a / 0;
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Хватит пытаться делить на ноль!");
            }

            // Исключение неверного индекса

            try
            {
                int[] numbs = new int[4];
                int b = numbs[7];
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            // Исключение выхода на допустимый размер

            try
            {
                int a = int.MaxValue;
                a++;
            }
            catch(OverflowException e)
            {
                Console.WriteLine(e.Message); 
            }

            // Проброс исключения

            try
            {
                try
                {
                    newFlower.Color = "Коричневый";
                }
                catch(UniqueExceptions.CantBeBrown e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
            catch(UniqueExceptions.CantBeBrown e)
            {
                Console.WriteLine("Исключение, полученное в ходе проброса по стеку catch");
            }
        }
    }
}
