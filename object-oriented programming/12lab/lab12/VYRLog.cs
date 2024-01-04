using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Web;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;

namespace lab12
{
    class Info
    {
        public string Action { get; set; }
        public string NameFileDir { get; set; }
        public string Path { get; set; }
        public DateTime Data { get; set; }

        public Info(string action, string name, string path, DateTime data)
        {
            Action = action;
            NameFileDir = name;
            Path = path;
            Data = data;
        }

        public override string ToString()
        {
            return ($"{Data} {Action} {NameFileDir} {Path}");
        }
    }
    class VYRLog
    {
        public static DateTime WriteFile(string message, string name, string path)
        {
            using (StreamWriter writer = new StreamWriter("vyrlog.txt", true))
            {
                DateTime time;

                time = DateTime.Now;
                writer.Write(time + "\t");
                writer.Write(message + "\t");
                writer.WriteLine(name);
                return time;
            }
        }

        public static void CurrDate(string currDate, string path)
        {
            string[] lines = File.ReadAllLines(path);
            Console.WriteLine();

            foreach (string line in lines)
            {
                string[] parts = line.Split('\t');
                string day = parts[0].Trim();
                string[] date = day.Split(' ');
                string _date = date[0].Trim();
                string message = date[1].Trim() + parts[1].Trim() + parts[2].Trim();

                if (_date == currDate)
                {
                    Console.WriteLine(message);
                }
            }
        }

        public static void CurrTime(string path)
        {
            DateTime startDate = new DateTime(2023, 11, 1, 0, 0, 0);
            DateTime endDate = new DateTime(2023, 11, 20, 23, 59, 59);
            string[] lines = File.ReadAllLines(path);
            Console.WriteLine();

            foreach (string line in lines)
            {
                string[] parts = line.Split('\t');
                string dateString = parts[0].Trim();
                string action = parts[1].Trim();

                DateTime date = DateTime.Parse(dateString);

                if (date >= startDate && date <= endDate)
                {
                    Console.WriteLine(action);
                }
            }
        }

        public static void CurrWord(string path, string word)
        {
            string[] lines = File.ReadAllLines(path);
            Console.WriteLine();

            foreach (string line in lines)
            {
                string[] parts = line.Split('\t');
                string dateString = parts[0].Trim();
                string action = parts[1].Trim();

                foreach(var localWord in action.Split(' '))
                {
                    if(localWord == word)
                    {
                        Console.WriteLine(action);
                    }
                }
            }
        }

        public static void CountLines(string path)
        {
            string[] lines = File.ReadAllLines(path);
            Console.WriteLine();
            int counter = 0;

            foreach (string line in lines)
            {
                counter++;
            }
            Console.WriteLine(counter);
        }

        public static void DeleteAtHour(string path, List<Info> list)
        { 
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                DateTime dateTime = DateTime.Now;
                DateTime startOfCurrentHour = dateTime.AddHours(-1);
                DateTime endOfCurrentHour = dateTime.AddHours(1);
                Console.WriteLine();

                foreach (Info line in list)
                {

                    if (line.Data >= startOfCurrentHour && line.Data <= endOfCurrentHour)
                    {
                        writer.WriteLine(line);
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}

