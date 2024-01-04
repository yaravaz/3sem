using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.CodeDom;
using Microsoft.SqlServer.Server;

namespace lab11
{
    static class Reflector
    {
        // запись в файл
        public static void WriteFile(string text)
        {
            string path = "output.txt";
            File.AppendAllText(path, text);
        }

        // получить имя ассемблера
        public static void GetAssemblyName(Type type)
        {
            Assembly a = type.Assembly;
            WriteFile(a.FullName + "\n\n");
            Console.WriteLine(a.FullName + "\n");
        }

        // публичные конструкторы
        public static bool HasPublicConstructors(Type type)
        {
            return type.GetConstructors().Any(x => x.IsPublic);
        }

        // общедоступные методы
        public static IEnumerable<string> GetAllMethods(Type type)
        {

            List<string> methods = new List<string>();
            
            foreach(var method in type.GetMethods())
            {
                methods.Add(method.Name);
                WriteFile($"{method} ");
                WriteFile("\n\n");
            }
            WriteFile("\n\n");
            return methods as IEnumerable<string>;
        }

        // получить поля и свойства
        public static IEnumerable<string> GetFieldsProperties(Type type)
        {

            List<string> fieldAndProperties = new List<string>();

            WriteFile("Поля класса:\n");
            foreach (var field in type.GetFields())
            {
                fieldAndProperties.Add(field.Name);
                WriteFile($"{field.Name} ");
            }
            WriteFile("\n\n");

            WriteFile("Свойства класса:\n");
            foreach (var property in type.GetProperties())
            {
                fieldAndProperties.Add(property.Name);
                WriteFile($"{property.Name} ");
            }
            WriteFile("\n\n");

            return fieldAndProperties as IEnumerable<string>;
        }

        // публичные интерфейсы
        public static IEnumerable<string> GetInterfaces(Type type)
        {
            List<string> interfaceList = new List<string>();

            foreach (var iface in type.GetInterfaces())
            {
                interfaceList.Add(iface.Name);
                WriteFile($"{iface.Name}");
            }
            WriteFile("\n\n");

            return interfaceList as IEnumerable<string>; 
        }

        // методы с определённым возвращающим значением
        public static void GetMethodsOfClass(Type type, string currentType)
        {
            MethodInfo[] methodInfo = type.GetMethods();


            foreach(var method in methodInfo)
            {
                ParameterInfo[] parameters = method.GetParameters();

                foreach(var parameter in parameters)
                {
                    if(parameter.ParameterType.Name == currentType)
                    {
                        Console.WriteLine($"{method.ReturnType.Name} {method.Name}");
                        WriteFile($"{method.ReturnType.Name} {method.Name}\n");

                        break;
                    }
                }
            }
        }

        public static void Invoke(object obj, string methodName, string paramsFilePath)
        {
            object[] param = new object[2];

            /*Random rnd = new Random();
            object[] paramerters = { rnd.Next(0, 100), rnd.Next(0, 100) };*/

            using (StreamReader read = new StreamReader(paramsFilePath))
            {
                param = read.ReadToEnd().Split(new char[] { ' ' });
            }

            var method = obj.GetType().GetMethod(methodName);
            method?.Invoke(obj, param);

        }

        public static object Create(Type type) => Activator.CreateInstance(type);
    }
}
