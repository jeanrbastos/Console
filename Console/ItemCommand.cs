using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bastos.Console
{
    internal sealed class ItemCommand
    {
        public Func<IConsoleCommand> Activator { get; set; }

        public string Description { get; set; }
    }
}
