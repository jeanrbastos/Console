using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bastos.Console.Core
{
    /// <summary>
    /// Represents a parameter manager.
    /// </summary>
    public interface IParameterManager
    {
        void RegisterCommand<T>(string argName, string description = null) where T : IConsoleCommand;

        void RegisterCommand(string argName, Func<IConsoleCommand> customActivator, string description = null);

        void Process(string[] args);

        /// <summary>
        /// Show the list of commands with description when exists
        /// </summary>
        void ShowHelp();
    }
}
