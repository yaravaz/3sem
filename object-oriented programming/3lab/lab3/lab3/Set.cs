using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Set
    {
        public class Developer
        {
            public string Surname { get; set; }
            public string Name { get; set; }
            public string Patronymic { get; set; }
            public int Id { get; set; }
            public string  Department { get; set; }

        }
        private List<object> listset = new List<object>();

        public Production product;
        
        public List<object> Listset
        { 
            get => listset;
        }

        public Set() { }

        public void Add(object obj)
        {
            if (!Listset.Contains(obj))
                listset.Add(obj);
            else
                Console.WriteLine("Элемент уже есть в множестве");
        }

        public bool Remove(object obj)
        {
            return listset.Remove(obj);
        }

        public object this[int index]
        {
            get => listset[index];
            set => Listset[index] = value;
        }

        public int Count { get => listset.Count; }

        public override string ToString()
        {
            return string.Join(", ", listset);
        }

        public static Set operator -(Set set, object item)
        {
            if (!set.Remove(item))
            {
                Console.WriteLine("Удаляемого элемента не содержится в множестве");
            }
            else
            {
                Console.WriteLine("Элемент удалён");
            }
            return set;
        }

        public static Set operator *(Set set1, Set set2)
        {
            Set set = new Set();
            for(int i = 0; i < set1.Count; i++)
            {
                if (set2.listset.Contains(set1[i]))
                {
                    set.Add(set1[i]);
                }
            }
            return set;
        }

        public static bool operator <(Set set1, Set set2)
        { 
            if (set1[0] is int)
            {
                int sum1 = 0;
                int sum2 = 0;
                for(int i = 0; i < set1.Count; i++)
                {
                    sum1 += Convert.ToInt32(set1[i]);
                }
                for (int i = 0; i < set2.Count; i++)
                {
                    sum1 += Convert.ToInt32(set2[i]);
                }
                if (sum1 < sum2)
                    return true;
                return false;
            }
            if (set1[0] is string)
            {
                int length1 = 0;
                int length2 = 0;
                for (int i = 0; i < set1.Count; i++)
                {
                    length1 += Convert.ToInt32(set1[i].ToString().Length);
                }
                for (int i = 0; i < set2.Count; i++)
                {
                    length1 += Convert.ToInt32(set2[i].ToString().Length);
                }
                if (length1 < length2)
                    return true;
                return false;
            }
            return false;
        }

        public static bool operator >(Set set1, Set set2)
        {
            for (int i = 0; i < set2.Count; i++)
            {
                if (!set1.listset.Contains(set2[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator &(Set set1, Set set2)
        {
            return (set1[0].GetType() == set2[0].GetType());
        }

    }
}
