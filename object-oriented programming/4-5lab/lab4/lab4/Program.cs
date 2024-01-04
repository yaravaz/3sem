using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
            // создание объектов

            Bush bush = new Bush("Шиповник", "Многолетний");
            Flower flower = new Flower("Нарцисс", "Однолетний", "Белый", "Росток", 123);
            Rose rose = new Rose("Роза", "Многолетний", "Красный", "Взрослый", true, 23);
            Glasiolus glasiolus = new Glasiolus("Гладиолус", "Многолетний", "Розовый", "Взрослый", 14, Seasons.Autum, 14);
            Cactus cactus = new Cactus("Цереус", "Многолетний", "Белый", "Побег", 67);
            Paper paper = new Paper("Жёлтый", 2);
            Bouquet bouquet = new Bouquet("Цветная сказка", paper, rose, glasiolus, cactus);

            bouquet.GetInfo();

            Flower nasturtium = new Flower("Настурция", "Однолетний", "Красный", "Взрослый", 78);
            bouquet.AddFlower(nasturtium);
            bouquet.GetInfo();

            bouquet.DeleteFlower(cactus);
            bouquet.GetInfo();

            Controller.SortByName(bouquet);
            bouquet.GetInfo();

            Controller.FindByColor(bouquet, "Розовый");

            Controller.FindPriceOfBouquet(bouquet);

            // через ссылку на абстрактный класс

            Plant plant = new Bush("Смородина", "Многолетний");

            bush = plant as Bush;
            if (bush == null)
            {
                Console.WriteLine("Преобразование не удалось!!");
            }
            else
            {
                Console.WriteLine("Преобразование выполнено успешно");
            }

            // преобразование к предку

            if (rose is Flower)
            {
                flower = (Flower)rose;
                Console.WriteLine(flower.Name);
            }
            else
            {
                Console.WriteLine("Нельзя преобразовать");
            }

            // через ссылку на интерфейс

            IRemove bush2 = new Bush("Малина", "Многолетний");

            bush2.Delete();

            Plant newBash = bush2 as Plant;
            if (newBash == null)
            {
                Console.WriteLine("Преобразование не удалось!!");
            }
            else
            {
                Console.WriteLine(newBash.Name);
                newBash.Delete();
            }

            // работа с printer

            Printer printer = new Printer();
            dynamic[] array = new dynamic[] { plant, bush, flower, rose, glasiolus, cactus };
            foreach(var s in array)
            {
                printer.IAmPrinting(s);
            }

            // 6 lab

            //enum

            Console.WriteLine($"{(int)Seasons.Winter}:{Seasons.Winter}\n" +
                $"{(int)Seasons.Spring}:{Seasons.Spring}\n" +
                $"{(int)Seasons.Summer}:{Seasons.Summer}\n" +
                $"{(int)Seasons.Autum}:{Seasons.Autum}");

            //struct

            Buyer person1;
            person1.Name = "Jack";
            person1.Age = 32;
            person1.ShowInfo();

            Buyer person2 = new Buyer();
            person2.Name = "Lucy";
            person2.Age = 27;
            person2.ShowInfo();

            Buyer person3 = new Buyer("Mick", 13);
            person3.ShowInfo();


        }
    }
}
