using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bastos.Console.Core
{
    public abstract class ParameterManagerBase<TCommand> : Core.IParameterManager 
        where TCommand : IItemCommand
    {
        protected Dictionary<string, IItemCommand> _commadsDictionary;

        public bool CaseSensitive { get; private set; }        

        public ParameterManagerBase(bool caseSensitive)
        {
            this.CaseSensitive = caseSensitive;
            _commadsDictionary = new Dictionary<string, IItemCommand>();
        }

        public virtual void RegisterCommand(string argName, Func<IConsoleCommand> customActivator, string description = null)
        {
            if (argName == null)
                throw new ArgumentNullException("argName");
            if (customActivator == null)
                throw new ArgumentNullException("customActivator");

            if (!CaseSensitive)
                argName = argName.ToLower();

            var item = Activator.CreateInstance<TCommand>();
            item.Activator = customActivator;
            item.Description = description;
            _commadsDictionary.Add(argName, item);
        }

        public virtual void RegisterCommand<T>(string argName, string description = null) where T : IConsoleCommand
        {
            Func<IConsoleCommand> activator = () => Activator.CreateInstance<T>();
            RegisterCommand(argName, activator, description);
        }

        public virtual void ShowHelp()
        {
            foreach (var item in _commadsDictionary)
            {
                System.Console.WriteLine("\t{0} - {1}", item.Key, item.Value.Description);
            }
        }

        public abstract void Process(string[] args);
    }
}
