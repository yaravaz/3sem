using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _7lab
{
    [Serializable]
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Set<string> setlist1 = new Set<string>();
                Set<object> setlist2 = new Set<object>();
                Set<object> setlist3 = new Set<object>();
                setlist1.Add("Слово");
                setlist1.Add("Слово");
                setlist1.Add("Привет");
                setlist1.Add("Мир");

                setlist2.Add(1);
                setlist2.Add(2);
                setlist2.Add(3);

                setlist3.Add(2.3);
                setlist3.Add(4.6);
                setlist3.Add(4.8);

                setlist1.Show();
                setlist2.Show();
                setlist3.Show();

                setlist1.Find("Привет");
                setlist2.Remove(2);
                setlist2.Show();

                Set<Paper> newPaper = new Set<Paper>() { };
                newPaper.Add(new Paper("pink", 1));
                Console.WriteLine(newPaper);

                object obj = 123;
                Set<object>.Save(obj);
                Set<object>.Upload("D:\\лабы\\ООП\\7lab\\7lab\\7lab\\save.xml");
            }
            finally
            {
                Console.WriteLine("Finally");
            }
        }
    }
}
