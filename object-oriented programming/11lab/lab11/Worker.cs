using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab11
{
    public class Worker : IMyInterface<Worker>
    {
        private string fio;
        private int experience;
        private int salary;
        private string field;

        public string FIO { get => fio; set => fio = value; }
        public int Experience { get => experience; set => experience = value; }
        public int Salary { get => salary; set => salary = value; }
        public string Field { get => field; set => field = value; }

        public static int Count = 0;
        public static int Id = 0;

        public Worker()
        {
            FIO = "undefined";
            Experience = 0;
            Salary = 0;
            Field = "undefined";
            Count++;
        }

        public Worker(string name, int experience, int salary, string field)
        {
            FIO = name;
            Experience = experience;
            Salary = salary;
            Field = field;
            Count++;
        }

        public void Promote()
        {
            Salary += 100;
            Console.WriteLine($"Сотрудника {FIO} повысили");
        }
        public void Fine()
        {
            Salary -= 100;
            Console.WriteLine($"Сотрудник {FIO} выплатил штраф");
        }
        public void Info()
        {
            Console.WriteLine($"Информация о сотруднике:\n" +
                $"Имя:       {FIO}\n" +
                $"Зарплата:  {Salary}\n" +
                $"Сфера:     {Field} \n");
        }

        public void GetHash()
        {
            Console.WriteLine(GetHashCode());
        }
        
        Hashtable hashList = new Hashtable();

        public override string ToString()
        {
            return $"{FIO} - {Salary} - {Field}";
        }

        public void AddElement(Worker elem)
        {
            hashList.Add(++Id, elem);
        }

        public void Delete(int key)
        {
            hashList.Remove(key);
            Id--;
        }

        public void Find(int key)
        {
            ICollection keys = hashList.Keys;
            bool finded = false;

            foreach (int ikey in keys)
            {
                if (ikey == key)
                {
                    Console.WriteLine($"Такой элемент есть: " + key + " - " + hashList[key]);
                    finded = true;
                }
            }
            if (!finded)
            {
                Console.WriteLine("Такого элемента нет");
            }
        }

        public void Print()
        {
            ICollection keys = hashList.Keys;

            foreach (int key in keys)
            {
                Console.WriteLine(key + ": " + hashList[key]);
            }
        }

        public void ConcatText(string text, string text2)
        {
            Console.WriteLine(text + text2);
        }

        public List<Worker> items = new List<Worker>();

    }
}
