using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bastos.Console
{
    /// <summary>
    /// Manage simple parameters.
    /// Example: yourProgram.exe arg1 arg2
    /// Look at project site to get a use example.
    /// </summary>
    public class SimpleParameterManager : IParameterManager
    {
        private Dictionary<string, ItemCommand> _commadsDictionary;

        public bool CaseSensitive { get; private set; }

        public SimpleParameterManager()
            : this(true)
        { }

        public SimpleParameterManager(bool caseSensitive)
        {
            this.CaseSensitive = caseSensitive;
            _commadsDictionary = new Dictionary<string, ItemCommand>();
        }

        public void RegisterCommand<T>(string argName, string description = null) where T : IConsoleCommand
        {
            Func<IConsoleCommand> activator = () => Activator.CreateInstance<T>();
            RegisterCommand(argName, activator, description);
        }

        public void RegisterCommand(string argName, Func<IConsoleCommand> customActivator, string description = null)
        {
            if (argName == null)
                throw new ArgumentNullException("argName");
            if (customActivator == null)
                throw new ArgumentNullException("customActivator");

            if (!CaseSensitive)
                argName = argName.ToLower();

            var item = new ItemCommand() { Activator = customActivator, Description = description };
            _commadsDictionary.Add(argName, item);
        }

        public void Process(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException("args");

            foreach (var arg in args)
            {
                if (!String.IsNullOrWhiteSpace(arg))
                {
                    var itemName = CaseSensitive ? arg : arg.ToLower();

                    if (_commadsDictionary.ContainsKey(itemName))
                    {
                        var itemCommand = _commadsDictionary[itemName];
                        var commad = itemCommand.Activator();
                        commad.Execute();
                    }
                }
            }
        }

        public void ShowHelp()
        {
            foreach (var item in _commadsDictionary)
            {
                System.Console.WriteLine("\t{0} - {1}", item.Key, item.Value.Description);
            }
        }
    }
}
