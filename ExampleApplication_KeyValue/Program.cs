using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bastos.Console.KeyValue;

namespace ExampleApplication_KeyValue
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new KeyValueParameterManager();
            manager.RegisterCommand<Worker1>("arg1");
            manager.RegisterCommand<Worker2>("arg2");

            manager.Process(args);
        }
    }
}
