using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lab8.StringMethods;

namespace lab8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Director programmer1 = new Director(1400, "Программист1");
            Director programmer2 = new Director(1000, "Программист2");
            Director teacher1 = new Director(800, "Учитель1");
            Director teacher2 = new Director(300, "Учитель2");
            Director assistant1 = new Director(700, "Ассистент1");
            Director assistant2 = new Director(200, "Ассистент2");

            Console.WriteLine("Программист №1");
            programmer1.NotifyPromotion += programmer1.Promote;
            programmer1.NotifyFine += programmer1.Fine;
            programmer1.DoPromote();
            programmer1.DoFine();

            Console.WriteLine("Программист №2");
            programmer2.NotifyFine += programmer2.Fine;
            programmer2.DoFine();
            programmer2.DoFine();
            programmer2.DoFine();

            Console.WriteLine("Учитель №2");
            teacher1.NotifyPromotion += teacher1.Promote;
            teacher1.DoPromote();

            Console.WriteLine("Ассистент №2");
            assistant2.NotifyPromotion += assistant2.Promote;
            assistant2.NotifyFine += assistant2.Fine;
            assistant2.DoPromote();
            assistant2.DoFine();

            Console.WriteLine(programmer1);
            Console.WriteLine(programmer2);
            Console.WriteLine(teacher1);
            Console.WriteLine(assistant2);

            string ExampleString = "kjdbskjlvkjlidfnidbdfkjldbkjl kjsbg dfkjdfs kjldf n";

            StringOperations stringOperations = new StringOperations(TaskToLower);
            stringOperations += TaskToUpper;
            stringOperations += StringReverse;
            stringOperations += Change;

            stringOperations?.Invoke(ref ExampleString);
            Console.WriteLine(ExampleString);
        }
    }
}