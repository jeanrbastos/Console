using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bastos.Console
{
    /// <summary>
    /// Implement this interface for represent a command.
    /// </summary>
    public interface IConsoleCommand
    {
        /// <summary>
        /// Called when command registered is passed.
        /// </summary>
        void Execute();
    }
}
