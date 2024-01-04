using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17_18
{
    public class Director
    {
        readonly Builder _builder;
        public Director(Builder builder)
        {
            _builder = builder;
        }
        public void Construct(double partC = 0, string partA = "", string partB = "", int partD = 0)
        {
            _builder.BuildPartA(partA);
            _builder.BuildPartB(partB);
            _builder.BuildPartC(partC);
            _builder.BuildPartD(partD);
        }
    }
    public abstract class Builder
    {
        public abstract void BuildPartA(string partA);
        public abstract void BuildPartB(string partB);
        public abstract void BuildPartC(double partC);
        public abstract void BuildPartD(int partD);
        public abstract Book GetBook();

    }

    class CurrBuilder : Builder
    {
        private static readonly Book temp = new Book();
        public override void BuildPartA(string item) => temp.Name = item;
        public override void BuildPartB(string item) => temp.Author = item;
        public override void BuildPartC(double item) => temp.Price = item;
        public override void BuildPartD(int item) => temp.Quantity = item;
        public override Book GetBook()
        {
            Book.books.Add(temp);
            Console.WriteLine($"Книга: {temp.Name}, автор: {temp.Author}, цена: {temp.Price}, кол-во: {temp.Quantity}");
            return temp;
        }
    }
}
