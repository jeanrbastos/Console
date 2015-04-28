using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bastos.Console.Core
{
    public interface IItemCommand
    {
        Func<IConsoleCommand> Activator { get; set; }

        string Description { get; set; }
    }
}
