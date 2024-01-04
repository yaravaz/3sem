using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Worker worker1 = new Worker("Иван", 10, 160000, "IT");
            Worker worker2 = new Worker("Алиса", 3, 2000, "Инженер");
            Worker worker3 = new Worker("Кирилл", 8, 2200, "Менеджмент");
            Worker worker4 = new Worker("Ольга", 11, 5000, "Точные науки");
            Worker worker5 = new Worker("Руслан", 5, 1000, "Дизайн");

            worker1.Info();
            worker2.Promote();
            worker5.Fine();

            Hashtable workers = new Hashtable();

            worker1.AddElement(workers, worker1);
            worker2.AddElement(workers, worker2);
            worker3.AddElement(workers, worker3);
            worker4.AddElement(workers, worker4);
            worker5.AddElement(workers, worker5);

            worker3.Delete(workers, 3);

            worker3.Find(workers, 3);
            worker3.Find(workers, 2);

            worker1.Print(workers);

            // ------------------------------------------------

            Person person1 = new Person("Иван", "Юрьев");
            Person person2 = new Person("Егор", "Белоусов");
            Person person3 = new Person("Юля", "Стрыкало");
            Person person4 = new Person("Лиза", "Петрова");
            Person person5 = new Person("Павел", "Кот");
            Person person6 = new Person("Сергей", "Подкопаев");
            Person person7 = new Person("Дмитрий", "Курсак");

            Dictionary<int, Person> people = new Dictionary<int, Person>();

            people.Add(1, person1);
            people.Add(2, person5);
            people.Add(3, person2);
            people.Add(5, person3);
            people.Add(7, person4);
            people.Add(8, person6);
            people.Add(9, person7);

            Person.PrintCollection(people);
            Console.WriteLine("Удаление элементов");
            Person.DeleteElemOfCollection(people, 3);
            Person.PrintCollection(people);

            Folk peopleFolk = new Folk(people);
            
            Folk.PrintCollection(peopleFolk);

            Console.WriteLine(peopleFolk.peopleList.Find(p => p.Name == "Юля"));

            // ----------------------------------------------------

            ObservableCollection<Worker> newCollection = new ObservableCollection<Worker>();
            
            void newCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Worker newWorker = e.NewItems[0] as Worker;
                        Console.WriteLine("Нанят новый сотрудник " + newWorker.Name);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Worker oldWorker = e.OldItems[0] as Worker;
                        Console.WriteLine("Уволен сотрудник " + oldWorker.Name);
                        break;
                }
            }

            newCollection.CollectionChanged += newCollectionChanged;

            newCollection.Add(worker1);
            newCollection.Add(worker2);
            newCollection.Add(worker3);
            newCollection.Remove(worker2);

            Console.Write("\n");

            foreach(var i in newCollection)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
} 
