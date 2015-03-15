# Console
This library (for .NET) it is a helper to manage the parameters on a console application.

# Example

Install using Nuget

//TODO :(


```
class Program
    {
        static void Main(string[] args)
        {
            SimpleParameterManager manager = new SimpleParameterManager();
            manager.RegisterCommand<Worker1>("arg1");
            manager.RegisterCommand<Worker2>("arg2");

            manager.Process(args);
        }
    }
```
