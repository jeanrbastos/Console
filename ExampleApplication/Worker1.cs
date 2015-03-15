using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApplication
{
    public class Worker1 : Bastos.Console.IConsoleCommand
    {
        public void Execute()
        {
            Console.WriteLine("Do somethink 1");
        }
    }
}
