using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApplication
{
    public class Worker2 : Bastos.Console.Simple.ISimpleConsoleCommand
    {
        public void Execute()
        {
            Console.WriteLine("Do somethink 2");
        }
    }
}
