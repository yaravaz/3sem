using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab9
{
    internal class Worker : IEnumerable<Worker>, MyInterface<Worker>
    {
        public string Name { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }
        public string Field { get; set; }

        public static int Count = 0;
        public static int Id = 0;

        public Worker() 
        {
            Name = "undefined";
            Experience = 0;
            Salary = 0;
            Field = "undefined";
            Count++;
        }

        public Worker(string name, int experience, int salary, string field) 
        {
            Name = name;
            Experience = experience;
            Salary = salary;
            Field = field;
            Count++;
        }        

        public void Promote()
        {
            Salary += 100;
            Console.WriteLine($"Сотрудника {Name} повысили");
        }
        public void Fine()
        {
            Salary -= 100;
            Console.WriteLine($"Сотрудник {Name} выплатил штраф");
        }
        public void Info()
        {
            Console.WriteLine($"Информация о сотруднике:\n" +
                $"Имя:       {Name}\n" +
                $"Зарплата:  {Salary}\n" +
                $"Сфера:     {Field} \n");
        }

        public void GetHash()
        {
            Console.WriteLine(GetHashCode());
        }

        public override string ToString()
        {
            return $"{Name} - {Salary} - {Field}";
        }

        public void AddElement(Hashtable hashtable, Worker elem)
        {
            hashtable.Add(++Id, elem);
        }

        public void Delete(Hashtable hashtable, int key)
        {
            hashtable.Remove(key);
            Id--;
        }

        public void Find(Hashtable hashtable, int key)
        {
            ICollection keys = hashtable.Keys;
            bool finded = false;

            foreach(int ikey in keys)
            {
                if(ikey == key)
                {
                    Console.WriteLine($"Такой элемент есть: " + key + " - " + hashtable[key]);
                    finded = true;
                }
            }
            if (!finded)
            {
                Console.WriteLine("Такого элемента нет");
            }
        }

        public void Print(Hashtable hashtable)
        {
            ICollection keys = hashtable.Keys;

            foreach(int key in keys)
            {
                Console.WriteLine(key + ": " + hashtable[key]);
            }
        }

        public List<Worker> items = new List<Worker>();

        public void Add(Worker item)
        {
            items.Add(item);
        }

        public IEnumerator<Worker> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

       
    }
}