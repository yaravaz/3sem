using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lab17_18
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    public class Reading
    {
        public void Read()
        {
            WriteLine("Читатель читает");
        }
        public void Stop()
        {
            WriteLine("Читатель остановился");
        }
    }
    public class DoReadingCommand : ICommand
    {
        Reading _reading;
        public DoReadingCommand(Reading reading)
        {
            _reading = reading;
        }
        public void Execute()
        {
            _reading.Read();
        }
        public void Undo()
        {
            _reading.Stop();
        }
    }
    public class AnotherReader
    {
        ICommand _command;
        public void SetCommand(ICommand command)
        {
            _command = command;
        }
        public void Go()
        {
            _command.Execute();
        }
        public void Stoped()
        {
            _command.Undo();
        }
    }
}
