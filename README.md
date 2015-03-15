# Console
This library (for .NET) it is a helper to manage the parameters on a console application.

Example
=======

Install using Nuget

```
Install-Package Bastos.Console
```

The class that will do the job should implement interface IConsoleCommand.

``` csharp
    public class Worker1 : Bastos.Console.IConsoleCommand
    {
        public void Execute()
        {
            Console.WriteLine("Do somethink 1");
        }
    }
```

Now just create and configure the parameter manager.

``` csharp
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

The result in console is it:

```
    C:\ExampleApplication\bin\Debug>YouProject.exe arg1
    Do somethink 1
```
