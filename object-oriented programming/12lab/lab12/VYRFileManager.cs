using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO.Compression;
using System.Xml.Linq;

namespace lab12
{
    class VYRFileManager
    {
        public static Info ReadInfo(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                DirectoryInfo toName = new DirectoryInfo(dirName);
                List<string> fileAndDir = new List<string>();
                foreach (var item in Directory.GetFileSystemEntries(dirName))
                {
                    fileAndDir.Add(item);
                }

                foreach (var item in fileAndDir)
                {
                    Console.WriteLine(item);
                }
                Info obj = new Info("Получен список файлов и каталогов",
                                toName.Name,
                                dirName,
                                VYRLog.WriteFile("Список файлов и папок", toName.Name, dirName));
                return obj;
            }
            else
            {
                throw new Exception("Ошибка метода \"ReadInfo\": указанного каталога не существует");
            }
        }
        public static Info CreateDir(string nameDir, string path)
        {
            string fullPath = Path.Combine(path, nameDir);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
                Console.WriteLine($"Папка {nameDir} была создана");
                Info obj = new Info("Создание папки",
                                nameDir,
                                path,
                                VYRLog.WriteFile("Создание папки", nameDir, path));
                return obj;
            }
            else
            {
                throw new Exception("Ошибка метода \"CreateDir\": указанный каталог уже существует");
            }

        }
        public static Info CreateTxt(string nameTxt, string path)
        {
            string fullPath = Path.Combine(path, nameTxt);
            if (Directory.Exists(path) && !File.Exists(fullPath))
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(path, nameTxt))) { }
                Console.WriteLine("Файл txt был создан");
                Info obj = new Info("Создание текстового файла",
                                nameTxt,
                                path,
                                VYRLog.WriteFile("Создание текстового файла", nameTxt, path));
                return obj;
            }
            else
            {
                throw new Exception("Ошибка метода \"CreateTxt\": указанного каталога не существует или уже есть файл");
            }



        }
        public static Info AddText(string text, string path)
        {
            if (File.Exists(path))
            {
                File.WriteAllText(path, text);
                Console.WriteLine($"Была внесена информация в {Path.GetFileName(path)}");
                Info obj = new Info("Добавить информацию в файл",
                                Path.GetFileName(path),
                                path,
                                VYRLog.WriteFile("Добавить информацию в файл", Path.GetFileName(path), path));
                return obj;
            }
            else
            {
                throw new Exception("Ошибка метода \"AddText\": указанного файла не существует");
            }
        }
        public static Info CreateCopyFile(string newName, string oldPath, string newPath)
        {
            if (File.Exists(oldPath))
            {
                File.Copy(oldPath, Path.Combine(newPath, newName));
                Console.WriteLine($"Файл {Path.GetFileName(oldPath)} был скопирован и переименован в {newName}");
                Info obj = new Info("Создание копии файла",
                                newName,
                                Path.Combine(newPath, newName),
                                VYRLog.WriteFile("Создание копии файла", newName, Path.Combine(newPath, newName)));
                return obj;
            }
            else
            {
                throw new Exception("Ошибка метода \"CreateCopyFile\": копируемого файла не существует");
            }
        }
        public static Info DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine($"Файл {Path.GetFileName(path)} был удалён");
                Info obj = new Info("Удаление файла",
                                Path.GetFileName(path),
                                path,
                                VYRLog.WriteFile("Удаление файла", Path.GetFileName(path), path));
                return obj;
            }
            else
            {
                throw new Exception("Ошибка метода \"DeleteFile\": указанного файла не существует");
            }
        }
        public static Info CopyFileExtension(string firstPath, string secondPath)
        {
            if(Directory.Exists(firstPath) && Directory.Exists(secondPath))
            {
                string[] files = Directory.GetFiles(firstPath, "*.txt");

                string oldPath;
                string newPath;

                foreach (string file in files)
                {
                    oldPath = file;
                    newPath = Path.Combine(secondPath, Path.GetFileName(file));
                    File.Copy(oldPath, newPath);
                }
                Console.WriteLine("Копирование завершено");
                Info obj = new Info("Скопированы файлы с разширением",
                                "-",
                                secondPath,
                                VYRLog.WriteFile("Скопированы файлы с разширением", "-", secondPath));
                return obj;
            }
            else
            {
                throw new Exception("Ошибка метода \"CopyFileExtension\": копируемого каталога не существует или нет куда копировать");
            }
        }
        public static Info MoveDir(string oldPath, string newPath)
        {
            if(Directory.Exists(oldPath) && !Directory.Exists(newPath))
            {
                DirectoryInfo toName = new DirectoryInfo(oldPath);
                Directory.Move(oldPath, newPath);
                Console.WriteLine("Каталог был успешно перемещён");
                Info obj = new Info("Переместили папку",
                                toName.Name,
                                newPath,
                                VYRLog.WriteFile("Переместили папку", toName.Name, newPath));
                return obj;
            }
            else
            {
                throw new Exception("Ошибка метода \"MoveDir\": указанного каталога не существует или уже етсь калатог с таким названием");
            }
        }
        public static Info ZipDir(string path)
        {
            if (Directory.Exists(Path.GetDirectoryName(path)))
            {
                ZipFile.CreateFromDirectory(path, "D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\VYRInspect\\ZipedDir.zip");
                Console.WriteLine("Архивация была выполнена");
                Info obj = new Info("Архивация",
                                    "ZipedDir.zip",
                                    "D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\VYRInspect\\ZipedDir.zip",
                                VYRLog.WriteFile("Архивация", "ZipedDir.zip", "D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\VYRInspect\\ZipedDir.zip"));
                return obj;
            }
            else
            {
                throw new Exception("Ошибка метода \"ZipDir\": указанного каталога не существует");
            }
        }
        public static Info UnZipDir(string zipPath, string newPath)
        {
            if (File.Exists(zipPath))
            {
                ZipFile.ExtractToDirectory(zipPath, newPath);
                Console.WriteLine("Архив был разархивирован");
                Info obj = new Info("Разархивация",
                                "D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\VYRInspect\\ZipedDir.zip",
                                newPath,
                                VYRLog.WriteFile("Разархивация", "D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\VYRInspect\\ZipedDir.zip", newPath));
                return obj;
            }
            else
            {
                throw new Exception("Ошибка метода \"UnZipDir\": указанного файла не существует");
            }
        }
    }
}
