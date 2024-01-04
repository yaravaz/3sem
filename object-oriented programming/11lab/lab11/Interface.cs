using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    interface IMyInterface<T>
    {
        void AddElement(T e);
        void Delete(int key);
        void Find(int key);
        void Print();
    }
}
