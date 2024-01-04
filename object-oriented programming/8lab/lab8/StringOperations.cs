using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    internal class StringMethods
    {
        public delegate string StringOperations(ref string str);
        public static string StringFunc(string str, Func<string, string> func)
        {
            return func(str);
        }
        public static bool StringPredicate(char c, Predicate<char> predicate)
        {
            return predicate(c);
        }
        public static void StringAction(string str, Action<string> action)
        {
            action(str);
        }
        public static string TaskToLower(ref string str)
        {
            return str = StringFunc(str, x => x.ToLower());
        }
        public static string TaskToUpper(ref string str)
        {
            return str = StringFunc(str, x => x.ToUpper());
        }

        public static string StringReverse(ref string str)
        {
            StringAction(str, x => String.Join(" ", x.ToCharArray().Reverse()));
            return str;
        }

        public static string Change(ref string str)
        {
            for(int i = 0; i < str.Length; i++)
            {
                if (StringPredicate(str[i], x => x == 'I'))
                {
                    str.Replace(str[i], '!');
                }
            }
            return str;
        }
    }
}
