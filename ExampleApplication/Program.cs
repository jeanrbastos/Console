using Bastos.Console.KeyValue;
using Bastos.Console.Simple;

namespace ExampleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new SimpleParameterManager();
            manager.RegisterCommand<Worker1>("arg1");
            manager.RegisterCommand<Worker2>("arg2");

            manager.Process(args);
        }
    }
}
