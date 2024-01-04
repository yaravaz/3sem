using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Set setlist1 = new Set();
            Set setlist2 = new Set();
            Set setlist3 = new Set();
            Set setlist4 = new Set();
            setlist1.Add("Слово");
            setlist1.Add("Слово");
            setlist1.Add("Привет");
            setlist1.Add("Мир");
            setlist1.Add("давно");
            setlist1.Add("не");
            setlist1.Add("виделись");

            //  тестирование удаления из элементва
            setlist1 = setlist1 - setlist1[0];
            Console.WriteLine(setlist1);

            setlist2.Add("Привет");
            setlist2.Add("Мир");
            setlist2.Add("Питон");

            // тестирование пересечения множеств
            setlist2 = setlist1 * setlist2;
            Console.WriteLine(setlist2);

            setlist3.Add(1);
            setlist3.Add(2);
            setlist3.Add(3);
            setlist3.Add(4);
            setlist3.Add(5);

            setlist4.Add(2);
            setlist4.Add(4);

            // тестирование сравнения

            Console.WriteLine("\nСтроки");
            if (setlist1 < setlist2)
            {
                Console.WriteLine("Первое множество МЕНЬШЕ второго");
            }
            else
            {
                Console.WriteLine("Первое множество БОЛЬШЕ второго");
            }
            Console.WriteLine("\nЧисла");
            if (setlist3 < setlist4)
            {
                Console.WriteLine("Первое множество МЕНЬШЕ второго");
            }
            else
            {
                Console.WriteLine("Первое множество БОЛЬШЕ второго");
            }

            Console.WriteLine("\n");

            // тестирование проверки на подмножество

            if (setlist1 > setlist2)
            {
                Console.WriteLine("Второе множество является пожмножеством первого");
            }
            else
            {
                Console.WriteLine("Второе множество не является пожмножеством первого");
            }

            if (setlist2 > setlist1)
            {
                Console.WriteLine("Второе множество является пожмножеством первого");
            }
            else
            {
                Console.WriteLine("Второе множество не является пожмножеством первого");
            }

            if (setlist3 > setlist4)
            {
                Console.WriteLine("Второе множество является пожмножеством первого");
            }
            else
            {
                Console.WriteLine("Второе множество не является пожмножеством первого");
            }

            if (setlist4 > setlist3)
            {
                Console.WriteLine("Второе множество является пожмножеством первого");
            }
            else
            {
                Console.WriteLine("Второе множество не является пожмножеством первого");
            }

            Console.WriteLine("\n");

            // проверка типов

            if (setlist1 & setlist2)
            {
                Console.WriteLine("Множества одинаковых типов");
            }
            else
            {
                Console.WriteLine("Множества различных типов");
            }

            if (setlist1 & setlist3)
            {
                Console.WriteLine("Множества одинаковых типов");
            }
            else
            {
                Console.WriteLine("Множества различных типов");
            }

            // product

            setlist1.product = new Production();
            setlist1.product.Id = 12345;
            setlist1.product.NameOrganization = "qwerty";

            // developer

            Set.Developer developer = new Set.Developer();
            developer.Surname = "qwerty";
            developer.Name = "qwerty";
            developer.Patronymic = "qwerty";
            developer.Id = 12345;
            developer.Department = "qwerty";

            // методы расширения

            Console.WriteLine(setlist1[0].ToString().AddPointToTheEnd());
            
            Set setlist5 = new Set();
            setlist5.Add(null);
            setlist5.Add("sdcv5");
            setlist5.Add("cvfgt45e");
            setlist5.Add("dc43");
            Console.WriteLine(setlist5.DeleteNullElements());

            // тестирование операций

            Console.WriteLine(StatisticOperation.Sum(setlist1));
            Console.WriteLine(StatisticOperation.Sum(setlist3));

            Console.WriteLine(StatisticOperation.ListCount(setlist1));
            Console.WriteLine(StatisticOperation.ListCount(setlist3));

            Console.WriteLine(StatisticOperation.MaxMinDifferent(setlist1));
            Console.WriteLine(StatisticOperation.MaxMinDifferent(setlist3));
        }
    }
}
