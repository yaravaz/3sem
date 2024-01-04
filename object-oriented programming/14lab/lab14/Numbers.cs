using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace lab14
{
    public class Numbers
    {
        private int N;
        public StreamWriter file = new StreamWriter("file2.txt", false);
        public Numbers(int n)
        {
            N = n;
        }
        public void OddNumbers()  // нечетные
        {
            if (file.BaseStream == null)
                file = new StreamWriter("file2.txt", true);
            for (int i = 1; i < N; i++)
            {
                if (i % 2 != 0)
                {
                    if (file.BaseStream == null)
                        file = new StreamWriter("file2.txt", true);
                    file.WriteLine(i);
                    WriteLine("Нечетное число " + i);
                }
            }
            if (file.BaseStream != null)
                file.Close();
        }
        public void EvenNumbers() // четные
        {
            lock (this)
            {
                for (int i = 1; i < N; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (file.BaseStream == null)
                            file = new StreamWriter("file2.txt", true);
                        file.WriteLine(i);
                        WriteLine("Четное число " + i);
                    }
                    if (file.BaseStream != null)
                        file.Close();
                }
            }
        }
        public void OddNumbers1()
        {
            Monitor.Enter(this);
            {
                if (file.BaseStream == null)
                    file = new StreamWriter("file2.txt", true);
                for (int i = 1; i < N; i++)
                {

                    if (i % 2 != 0)
                    {

                        if (file.BaseStream == null)
                            file = new StreamWriter("file2.txt", true);
                        file.WriteLine(i);
                        WriteLine("Нечетное " + i);
                        Monitor.Pulse(this);
                        Monitor.Wait(this);
                    }
                }
                if (file.BaseStream != null)
                    file.Close();
                Monitor.Exit(this);
            }
        }
        public void EvenNumbers1()
        {
            Monitor.Enter(this);
            {
                if (file.BaseStream == null)
                    file = new StreamWriter("file2.txt", true);
                for (int i = 1; i < N; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (file.BaseStream == null)
                            file = new StreamWriter("file2.txt", true);
                        file.WriteLine(i);
                        WriteLine("Четное " + i);
                        Monitor.Pulse(this);
                        Monitor.Wait(this);
                    }
                }
                if (file.BaseStream != null)
                    file.Close();
                Monitor.Exit(this);
            }
        }
        public void ForTimer(object obj)
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }

    }
}
