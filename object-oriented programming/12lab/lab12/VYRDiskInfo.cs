using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab12
{
    class VYRDiskInfo
    {
        public static Info FreeDataInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    Console.WriteLine($"{drive.Name} - {(int)(drive.TotalFreeSpace / Math.Pow(10, 9))} Гб");

                }
            }
            Console.Write("\n");
            Info obj = new Info("Найдено свободное место на диске",
                                "C и D",
                                "С:\\ и D:\\",
                                VYRLog.WriteFile("Свободное место на дисках", "C и D", "С:\\ и D:\\"));
            return obj;
        }

        public static Info FileSystemInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
            }
            Console.Write("\n");
            Info obj = new Info("Найдена информация о файловой системе",
                                "-",
                                "-",
                                VYRLog.WriteFile("Информация о файловой системе", "-", "-"));
            return obj;
        }

        public static Info DriverInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объём диска: {(int)(drive.TotalSize / Math.Pow(10, 9))} Гб");
                    Console.WriteLine($"Свободного места на диске: {(int)(drive.TotalFreeSpace / Math.Pow(10, 9))} Гб");
                    Console.WriteLine($"Метка диска: {drive.VolumeLabel}");
                }
            }
            Console.Write("\n");
            Info obj = new Info("Найдена информация о дисках",
                                "C и D",
                                "С:\\ и D:\\",
                                VYRLog.WriteFile("Информация о дисках", "C и D", "С:\\ и D:\\"));
            return obj;
        }
    }
}
