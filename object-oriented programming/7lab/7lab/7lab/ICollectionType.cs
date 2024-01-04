using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7lab
{
    internal interface ICollectionType<T>
    {
        void Add(T element);
        bool Remove(T element);
        void Show();
        void Find(T element);
    }
}
