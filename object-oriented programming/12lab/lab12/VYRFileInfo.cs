using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class VYRFileInfo
    {
        public static Info FullPath(string file)
        {
            FileInfo fileInfo = new FileInfo(file);

            if (fileInfo.Exists)
            {
                Console.WriteLine(fileInfo.FullName);
                Info obj = new Info("Найден полный путь",
                                    file,
                                    fileInfo.FullName,
                                    VYRLog.WriteFile("Полный путь", file, fileInfo.FullName));
                return obj;
            }
            else
            {
                throw new Exception("Ошибка метода \"FullPath\": указанного файла не существует");
            }


        }
        public static Info AboutFile(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Размер: {fileInfo.Length}");
                Console.WriteLine($"Разширение: {fileInfo.Extension}");
                Console.WriteLine($"Имя: {fileInfo.Name}");
                Info obj = new Info("Найдена информация о файле",
                                    fileInfo.Name,
                                    path,
                                    VYRLog.WriteFile("Информация о файле", fileInfo.Name, path));
                return obj;
            }
            else
            {
                throw new Exception("Ошибка метода \"AboutFile\": указанного файла не существует");
            }
        }
        public static Info EditFileInfo(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Дата создания: {fileInfo.CreationTime}");
                Console.WriteLine($"Дата изменения: {fileInfo.LastWriteTime}");
                Info obj = new Info("Найдена информация о дате создания и изменения файла",
                                fileInfo.Name,
                                path,
                                VYRLog.WriteFile("Информация о дате создания и изменения файла", fileInfo.Name, path));
                return obj;
            }
            else
            {
                throw new Exception("Ошибка метода \"EditFileInfo\": указанного файла не существует");
            }
        }
    }
}
