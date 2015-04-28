using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bastos.Console.Simple
{
    public sealed class SimpleItemCommand : Core.IItemCommand
    {
        public Func<Core.IConsoleCommand> Activator { get; set; }

        public string Description { get; set; }
    }
}
