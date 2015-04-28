# Console
This library (for .NET) it is a helper to manage the parameters on a console application.

Simple Example
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
            var manager = new SimpleParameterManager();
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

With Parameters
=======

If you need pass parameters for the works class do it:

``` csharp
    static void Main(string[] args)
    {
        var changer = new Changer();
        var manager = new Bastos.Console.SimpleParameterManager();

        manager.RegisterCommand("file", () => new File(changer));
        manager.RegisterCommand("webservice", () => new WebService(changer));

        manager.Process(args);
    }
```

Key Value Parameters
=======

```csharp
    static void Main(string[] args)
    {
        var manager = new KeyValueParameterManager();
        manager.RegisterCommand<Worker1>("arg1");
        manager.RegisterCommand<Worker2>("arg2");

        manager.Process(args);
    }
```
