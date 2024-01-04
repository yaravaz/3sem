using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab12
{
    class VYRDirInfo
    {
        public static Info CountFile(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                DirectoryInfo toName = new DirectoryInfo(dirName);
                string[] files = Directory.GetFiles(dirName);
                Console.WriteLine($"Количество файлов: {files.Length}");
                Info obj = new Info("Найдено количество файлов каталога",
                                    toName.Name,
                                    dirName,
                                    VYRLog.WriteFile("Количесво файлов каталога", toName.Name, dirName));
                return obj;
            }
            else
            {
                throw new Exception("Ошибка метода \"CountFile\": указанного каталога не существует");
            }
        }
        public static Info CreatureTime(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                Console.WriteLine($"Дата создания: {dirInfo.CreationTime}");
                Info obj = new Info("Найдено время создания каталога",
                                    dirInfo.Name,
                                    dirName,
                                    VYRLog.WriteFile("Время создания каталога", dirInfo.Name, dirName));
                return obj;
            }
            else
            {
                throw new Exception("Ошибка метода \"CreatureTime\": указанного каталога не существует");
            }



        }
        public static Info CountDir(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                DirectoryInfo toName = new DirectoryInfo(dirName);
                string[] files = Directory.GetDirectories(dirName);
                Console.WriteLine($"Количество папок: {files.Length}");
                Info obj = new Info("Найдено количество папок в каталоге",
                                    toName.Name,
                                    dirName,
                                    VYRLog.WriteFile("Количесво папок каталога", toName.Name, dirName));
                return obj;
            }
            else
            {
                throw new Exception("Ошибка метода \"CountDir\": указанного каталога не существует");
            }
        }
        public static Info ParentDir(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                DirectoryInfo toName = new DirectoryInfo(dirName);
                Console.WriteLine($"Родительская папка: {Directory.GetParent(dirName)}");
                Info obj = new Info("Найден родительский каталог",
                                    toName.Name,
                                    dirName,
                                    VYRLog.WriteFile("Родительская папка", toName.Name, dirName));
                return obj;
            }
            else
            {
                throw new Exception("Ошибка метода \"ParentDir\": указанного каталога не существует");
            }
        }
    }
}
