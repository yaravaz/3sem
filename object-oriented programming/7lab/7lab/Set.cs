using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _7lab
{
    internal class Set<T> : ICollectionType<T> where T : class
    {
        private List<T> listset = new List<T>();


        public List<T> Listset
        {
            get => listset;
        }
        public Set() { }

        public void Show()
        {
            Console.WriteLine(string.Join("; ", listset));
        }

        public void Add(T obj)
        {
            if (!Listset.Contains(obj))
                listset.Add(obj);
            else
                Console.WriteLine("Элемент уже есть в множестве");
        }

        public bool Remove(T obj)
        {
            return listset.Remove(obj);
        }
        public void Find(T item)
        {
            if (listset.Contains(item))
            {
                Console.WriteLine("Такой элемент есть");
            }
            else
            {
                Console.WriteLine("Элемент не найден");
            }
        }
        public static void Save(T obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream("D:\\лабы\\ООП\\7lab\\7lab\\7lab\\save.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, obj);

                Console.WriteLine("Object has been serialized");
            }
        }

        public static void Upload(string currentFile)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(currentFile, FileMode.OpenOrCreate))
            {
                T obj = xmlSerializer.Deserialize(fs) as T;
                Console.WriteLine($"Object: {obj}");
            }
        }
        public T this[int index]
        {
            get => listset[index];
            set => Listset[index] = value;
        }

        public int Count { get => listset.Count; }

        public override string ToString()
        {
            return string.Join("; ", listset);
        }

    }
}
