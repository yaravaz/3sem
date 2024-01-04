using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using System.IO;
using static System.Console;


namespace lab14
{
    internal class Program
    {
        #region [третье задание(2)]

        public static void start(object n)
        {
            WriteLine($"Thread name: {Thread.CurrentThread.Name}");
            WriteLine($"Thread priority: {Thread.CurrentThread.Priority.ToString()}");
            WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId.ToString()}");
            WriteLine($"Thread status: {Thread.CurrentThread.ThreadState.ToString()}");
            StreamWriter outFile = new StreamWriter("file.txt");
            bool flag;
            for(int i = 1; i < (int)n+1; i++)
            {
                Thread.Sleep(10);
                outFile.WriteLine(i.ToString());
                WriteLine(i.ToString());
            }
            outFile.Close();

        }

        #endregion
        static void Main(string[] args)
        {
            #region [первое задание]

            // все запущенные процессы
            foreach (Process process in Process.GetProcesses())
            {
                WriteLine($"ID: {process.Id} " +
                          $"Name: {process.ProcessName} " +
                          $"Priority: {process.BasePriority} " +
                          $"Current status: {process.Responding} \n" +
                          $"--------------------------------------------");
            }
            #endregion

            #region [второе задание]

            AppDomain domain = AppDomain.CurrentDomain;
            WriteLine($"Name: {domain.FriendlyName}");
            WriteLine($"Сonfiguration details: {domain.SetupInformation.ConfigurationFile}");
            foreach (Assembly assembly in domain.GetAssemblies())
            {
                WriteLine($"Uploaded assemblies: {assembly.FullName}");

            }
            WriteLine();

            // создание нового домена и загрузка сборки
            AppDomain newDomain = AppDomain.CreateDomain("NewDomain");

            Assembly buf = null;
            foreach (Assembly x in domain.GetAssemblies())
            {
                if (x.GetName().Name == "lab14")
                    buf = x;
                WriteLine(x.ToString());
            }

            Assembly buf2 = newDomain.Load(buf.GetName());
            AppDomain.Unload(newDomain);
            WriteLine(buf2.ToString());

            #endregion

            #region [третье задание]

            int n;
            bool flag;
            while (true)
            {
                WriteLine("Enter n: ");
                flag = int.TryParse(ReadLine(), out n);

                if (!flag)
                {
                    WriteLine("Incorrect value.");
                }
                else break;
            }

            Thread myThread = new Thread(new ParameterizedThreadStart(start));
            myThread.Name = "Новый поток start";
            myThread.Priority = ThreadPriority.Highest;
            myThread.Start(n);

            #endregion

            #region [четвёртое задание]
            Thread.Sleep(10);
            Thread thread1, thread2;
            Numbers numbers = new Numbers(n);

            thread1 = new Thread(numbers.OddNumbers);
            thread2 = new Thread(numbers.EvenNumbers);

            thread1.IsBackground = true;
            thread2.IsBackground = true;

            thread1.Priority = ThreadPriority.AboveNormal;

            thread1.Start();
            thread2.Start();


            Thread thread3 = new Thread(numbers.OddNumbers1);
            Thread thread4 = new Thread(numbers.EvenNumbers1);

            thread3.IsBackground = true;
            thread4.IsBackground = true;

            thread3.Priority = ThreadPriority.AboveNormal;

            thread3.Start();
            thread4.Start();

            #endregion

            #region [пятое задание]
            Thread.Sleep(3000);
            WriteLine("\n\t\tВремя пошло");
            Thread.Sleep(5000);

            TimerCallback a = new TimerCallback(numbers.ForTimer);
            Timer timer = new Timer(a, null, 0, 1000);

            WriteLine("Нажмите чтобы выйти");
            ReadLine();
            #endregion
        }
    }
}
