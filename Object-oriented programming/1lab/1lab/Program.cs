using System;
using System.Linq;
using System.Text;

namespace _1lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*     Типы     */

            // обьявление
            byte valueByte;
            /*sbyte Sbyte;*/
            short valueShort;
            /*ushort Ushort;*/
            int valueInt;
            /*uint UInt;*/
            long valueLong;
            /*ulong Ulong;*/
            float valueFloat;
            double valueDouble;
            decimal valueDecimal = 234567654322345;
            char valueChar;
            string valueString;
            bool valueBool;

            // ввод, явное преобразование
            Console.WriteLine("Впишите значение для типа byte: ");
            valueByte = Convert.ToByte(Console.ReadLine());

            Console.WriteLine("Впишите значение для типа short: ");
            valueShort = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Впишите значение для типа int: ");
            valueInt = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Впишите значение для типа long: ");
            valueLong = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Впишите значение для типа float: ");
            valueFloat = float.Parse(Console.ReadLine());

            Console.WriteLine("Впишите значение для типа double: ");
            valueDouble = double.Parse(Console.ReadLine());

            Console.WriteLine("Впишите значение для типа char: ");
            valueChar = char.Parse(Console.ReadLine());

            Console.WriteLine("Впишите значение для типа string: ");
            valueString = Console.ReadLine();

            Console.WriteLine("Впишите значение для типа bool: ");
            valueBool = Convert.ToBoolean(Console.ReadLine());

            // вывод
            Console.WriteLine("\t- - - ТИПЫ - - -\n Byte:   \t{0}\n Short:  \t{1}\n " +
                "Int:    \t{2}\n Long:   \t{3}\n Float:  \t{4}\n Double: \t{5}\n " +
                "Char:   \t{6}\n String: \t{7}\n Bool:   \t{8}",
                valueByte, valueShort, valueInt, valueLong, valueFloat, valueDouble, valueChar, valueString, valueBool);

            // неявное преобразование
            valueDecimal = valueInt;
            valueDouble = valueFloat;
            valueLong = valueInt;
            valueInt = valueShort;
            valueShort = valueByte;

            // упаковка, распаковка значимых типов
            object forByte = valueByte;
            byte valueByte2 = (byte)forByte;

            object forInt = valueInt;
            int valueInt2 = (int)forInt;

            // работа с неявно типизированной переменной
            var simpleNumber = 123;
            var simpleWord = "lilies";
            Console.WriteLine("{0} {1} grow in a pond", simpleNumber, simpleWord);

            // работа с Nullable
            int? Nullable = null;
            if (Nullable == null)
            {
                Console.WriteLine("True");
            }
            Console.WriteLine(Nullable);
            Nullable = 123;
            Console.WriteLine(Nullable);
            Nullable<int> anotherNumber = null;

            // ошибка типов
            var checkError = 123;
            /*checkError = 23,3;*/

            /*     Строки     */

            // сравнение строковых литералов
            string firstString = "qwerty";
            string secondString = "asdfgh";
            string thirdString = "zxcvbn";
            string fourthString = "qwerty";

            int result1 = string.Compare(firstString, secondString);
            int result2 = string.Compare(firstString, thirdString);
            int result3 = string.Compare(firstString, fourthString);
            if (result1 > 0)
            {
                Console.WriteLine("Вторая строка стоит перед первой");
            }
            if (result2 < 0)
            {
                Console.WriteLine("Первая строка стоит перед третьей");
            }
            if (result3 == 0)
            {
                Console.WriteLine("Первая строка индентична четвёртой");
            }

            // работа со строками
            string string1 = "Привет ";
            string string2 = "Мир";
            string string3 = string1 + string2;
            string3 = string.Concat(string3, "!!!");
            Console.WriteLine(string3);

            string1 = string.Copy(string3);
            Console.WriteLine(string1);

            Console.WriteLine(string1.Substring(7));

            string1 = "история началась в чаще леса";
            string[] words = string1.Split(new char[] { ' ' });
            foreach (string each in words)
            {
                Console.WriteLine(each);
            }

            Console.WriteLine(string1.Insert(8, "эта "));

            Console.WriteLine(string3.Remove(7, string2.Length));
            Console.WriteLine(string3.Replace(string2, ""));

            Console.WriteLine($"{string3} Эта {string1}, где стоял домик лесника", string3, string1);

            // пустые и null строки
            string emptyString1 = "";
            string emptyString2 = string.Empty;
            string emptyString3 = null;
            Console.WriteLine(emptyString1.Length == 0);
            Console.WriteLine(emptyString3 == null);
            Console.WriteLine(string.IsNullOrEmpty(emptyString3));

            // stringBuilder
            // using System.Text
            StringBuilder stringBuilder = new StringBuilder("Hello sdsdsd World");
            Console.WriteLine(stringBuilder.ToString());// строка
            Console.WriteLine(stringBuilder);// объект
            stringBuilder.Remove(5, 7);
            stringBuilder.Insert(0, " ");
            stringBuilder.Append("!!!");
            Console.WriteLine(stringBuilder);

            /*     Массивы     */

            int[,] numbers1 = { { 1, 2, 3}, { 4, 5, 6}, { 7, 8, 9 } };
            int rowsInMatrix = numbers1.GetUpperBound(0) + 1;
            int columnsInMatrix = numbers1.Length / rowsInMatrix;
            for(int i = 0; i < rowsInMatrix; i++)
            {
                for(int j = 0; j < columnsInMatrix; j++)
                {
                    Console.Write(numbers1[i, j] + " ");
                }
                Console.WriteLine();
            }

            int[] numbers2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach(int number in numbers2)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine("Размер: " + numbers2.Length);
            Console.Write("\nВведите индекс элемента, который нужно поменять:");
            int bufferIndex = int.Parse(Console.ReadLine());
            Console.Write("Введите элемент, на который нужно поменять:");
            int bufferNumber = int.Parse(Console.ReadLine());
            numbers2[bufferIndex] = bufferNumber;
            foreach (int number in numbers2)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine("\nВведите массив(9 элементов):");
            float[][] numbers3 = new float[3][] { new float[2], new float[3], new float[4] };
            for(int i = 0; i < numbers3.Length; i++)
            {
                for(int j = 0; j < numbers3[i].Length; j++)
                {
                    numbers3[i][j] = float.Parse(Console.ReadLine()); 
                }
            }
            int rowsInMatrix2 = numbers3.GetUpperBound(0) + 1;
            for (int i = 0; i < rowsInMatrix2; i++)
            {
                for (int j = 0; j < numbers3[i].GetLength(0); j++)
                {
                    Console.Write(numbers3[i][j] + " ");
                }
                Console.WriteLine();
            }

            // неявное типизированные массивы и строки
            var array1 = new[] { 12, 23, 34, 45, 56, 67 };
            var array2 = new[] { "asd", "sdf", "dfg" };

            /*     Кортежи     */

            // создание и вывод
            (int, string, char, string, ulong) tuple = (123, " sdffgf ", 'd', " xcvbh ", 18446744073709551615);
            Console.Write(tuple.Item1 + tuple.Item2 + tuple.Item3 + tuple.Item4 + tuple.Item5);
            Console.Write(tuple.Item1 + tuple.Item3 + tuple.Item4);
            Console.WriteLine();

            // распаковка в переменные
            var birthday = (day:19, month:" september ", year:2004);
            Console.WriteLine(birthday.day + birthday.month + birthday.year);
            (int day, string month, int year) secondBirthday = (25, " october ", 2004);
            Console.WriteLine(secondBirthday.day + secondBirthday.month + secondBirthday.year);
            var (day, month, year) = (12, " december ", 2004);
            Console.WriteLine(day + month + year);

            // сравнение
            var tupleA = (1, 2, 3);
            var tupleB = (1, 2, 3);
            if(tupleA == tupleB)
            {
                Console.WriteLine("Значения кортежей равны");
            }

            /*     Функции     */

            (int maximumArray, int minimumArray, int sumArray, char firstLetter) FindQuantityInformation(int[] array, string bookName)
            {
                return (array.Max(), array.Min(), array.Sum(), bookName[0]);
            }

            (_, _, int sumArray, char firstLetter) = FindQuantityInformation(new int[] { 3, 123, 87, 45, 98 }, "The Complete Book of Poses for Artists");
            Console.WriteLine(FindQuantityInformation(new int[] { 3, 123, 87, 45, 98 }, "The Complete Book of Poses for Artists"));
            Console.WriteLine(sumArray + " " + firstLetter);

            /*     Checked/unchecked     */

            int CheckedFunction()
            {
                checked
                {
                    int maxInt = Int32.MaxValue/* + 1*/;
                    return (maxInt);
                }
            }
            int UncheckedFunction()
            {
                unchecked
                {
                    int maxInt = Int32.MaxValue + 1;
                    return (maxInt);
                }
            }
            Console.WriteLine(CheckedFunction());
            Console.WriteLine(UncheckedFunction());

        }
    }
}