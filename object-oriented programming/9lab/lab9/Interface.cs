using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab9
{
    interface MyInterface<T>
    {
        void AddElement(Hashtable table, T e);
        void Delete(Hashtable table, int key);
        void Find(Hashtable table, int key);
        void Print(Hashtable table);
    }

    public class Person
    {
        private int Id { get; set; }
        public string Name { get; set; }
        public string Surname{ get; set; }

        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public static void PrintCollection(Dictionary<int, Person> people)
        {
            foreach(var person in people)
            {
                Console.WriteLine($"key: {person.Key}  value: {person.Value}");
            }
        }

        public static void DeleteElemOfCollection(Dictionary<int, Person> people, int n)
        {
            for(int i = 0; i < n; i++)
            {
                people.Remove(people.FirstOrDefault().Key);
            }
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }

    public class Folk
    {
        public List<Person> peopleList = new List<Person>();
        public static int CountInFolk = 0;

        public Folk(Dictionary<int, Person> people)
        {
            foreach(var person in people)
            {
                peopleList.Add(person.Value);
                CountInFolk++;
            }
        }

        public Person this[int index]
        {
            get => peopleList[index];
            set => peopleList[index] = value;
        }

        public static void PrintCollection(Folk people)
        {
            for(int i = 0; i < CountInFolk; i++)
            {
                Console.WriteLine($"key: {i + 1}, value: {people[i]}");
            }
        }
    }


}
