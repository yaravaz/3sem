using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Объявление объектов пользовательнских классов

            Worker worker = new Worker("Никитин Павел Анатольевич", 12, 12000, "UX-дизайн");
            Customer customer = new Customer("Сумозбродин", "Антон", 2233, 4100);

            // Для класса Worker

            Type type = typeof(Worker);

            Reflector.GetAssemblyName(type);
            if (Reflector.HasPublicConstructors(type))
            {
                Reflector.WriteFile("Есть публичный конструктор\n");
                Console.WriteLine("Есть публичный конструктор\n");
            }
            else
            {
                Reflector.WriteFile("Нет публичных конструкторов\n");
                Console.WriteLine("Нет публичных конструкторов\n");
            }

            Console.WriteLine("МЕТОДЫ:\n");
            foreach (var item in Reflector.GetAllMethods(type))
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine("\nПОЛЯ И СВОЙСТВА\n");
            foreach(var item in Reflector.GetFieldsProperties(type))
            {
                Console.WriteLine($"{item} ");
            }

            Console.WriteLine("\nИНТЕРФЕЙСЫ\n");
            foreach (var item in Reflector.GetInterfaces(type))
            {
                Console.WriteLine($"{item} ");
            }

            Console.WriteLine("\nМЕТОДЫ С ПАРАМЕТРОМ ТИПА STRING\n");
            Reflector.GetMethodsOfClass(type, "String");
            
            // Для класса Customer

            type = typeof(Customer);

            Reflector.GetAssemblyName(type);
            if (Reflector.HasPublicConstructors(type))
            {
                Reflector.WriteFile("Есть публичный конструктор\n");
                Console.WriteLine("Есть публичный конструктор\n");
            }
            else
            {
                Reflector.WriteFile("Нет публичных конструкторов\n");
                Console.WriteLine("Нет публичных конструкторов\n");
            }

            Console.WriteLine("МЕТОДЫ:\n");
            foreach (var item in Reflector.GetAllMethods(type))
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine("\nПОЛЯ И СВОЙСТВА\n");
            foreach (var item in Reflector.GetFieldsProperties(type))
            {
                Console.WriteLine($"{item} ");
            }

            Console.WriteLine("\nИНТЕРФЕЙСЫ\n");
            foreach (var item in Reflector.GetInterfaces(type))
            {
                Console.WriteLine($"{item} ");
            }

            Console.WriteLine("\nМЕТОДЫ С ПАРАМЕТРОМ ТИПА STRING\n");
            Reflector.GetMethodsOfClass(type, "String");

            // Работа с Invoke и Create

            Console.WriteLine("\nКОНКАТЕНАЦИЯ\n");
            var obj = Reflector.Create(typeof(Worker));
            Reflector.Invoke(obj, "ConcatText", "D:\\лабы\\ООП\\11lab\\lab11\\lab11\\params.txt");

            Console.WriteLine("\nПОЛУЧЕНИЕ ОБЪЕКТА\n");
            Console.WriteLine(obj);
        }
    }
}
