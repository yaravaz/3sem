using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Info> list = new List<Info>();
                // класс для работы с дисками

                list.Add(VYRDiskInfo.FreeDataInfo());
                list.Add(VYRDiskInfo.DriverInfo());
                list.Add(VYRDiskInfo.FileSystemInfo());

                // класс для работы с файлами

                list.Add(VYRFileInfo.FullPath("forsearch.txt"));
                list.Add(VYRFileInfo.AboutFile("forsearch.txt"));
                list.Add(VYRFileInfo.EditFileInfo("forsearch.txt"));

                // класс для работы с дерикториями

                list.Add(VYRDirInfo.CountFile("Directory"));
                list.Add(VYRDirInfo.CreatureTime("Directory"));
                list.Add(VYRDirInfo.CountDir("Directory"));
                list.Add(VYRDirInfo.ParentDir("Directory"));

                // класс для редактирования папок и файлов

                list.Add(VYRFileManager.ReadInfo("D:\\"));
                list.Add(VYRFileManager.CreateDir("VYRInspect", "D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\"));
                list.Add(VYRFileManager.CreateTxt("vyrdirinfo.txt", "D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\VYRInspect"));
                list.Add(VYRFileManager.AddText("some text", "D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\VYRInspect\\vyrdirinfo.txt"));
                list.Add(VYRFileManager.CreateCopyFile("newfile.txt", "D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\VYRInspect\\vyrdirinfo.txt", "D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\VYRInspect\\"));
                list.Add(VYRFileManager.DeleteFile("D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\VYRInspect\\vyrdirinfo.txt"));

                list.Add(VYRFileManager.CreateDir("VYRFiles", "D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\"));
                list.Add(VYRFileManager.CopyFileExtension("D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\Directory", "D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\VYRFiles"));
                list.Add(VYRFileManager.MoveDir("D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\VYRFiles", "D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\VYRInspect\\VYRFiles"));

                list.Add(VYRFileManager.ZipDir("D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\VYRInspect\\VYRFiles\\"));
                list.Add(VYRFileManager.UnZipDir("D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\VYRInspect\\ZipedDir.zip", "D:\\лабы\\ООП\\12lab\\lab12\\lab12\\bin\\Debug\\VYRInspect\\"));

                using (StreamReader reader = new StreamReader("vyrlog.txt"))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }

                // работа с файлом

                VYRLog.CurrDate("12.11.2023", "vyrlog.txt");
                VYRLog.CurrTime("vyrlog.txt");
                VYRLog.CurrWord("vyrlog.txt", "файл");
                VYRLog.CountLines("vyrlog.txt");
                VYRLog.DeleteAtHour("vyrlog.txt", list);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
