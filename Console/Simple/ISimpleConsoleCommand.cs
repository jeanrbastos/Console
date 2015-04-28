using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bastos.Console.Simple
{
    /// <summary>
    /// Implement this interface for represent a command.
    /// </summary>
    public interface ISimpleConsoleCommand : Core.IConsoleCommand
    {
        /// <summary>
        /// Called when command registered is passed.
        /// </summary>
        void Execute();
    }
}
