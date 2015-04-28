using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bastos.Console.KeyValue
{
    /// <summary>
    /// Manage Key Value parameter.
    /// Eg.: arg1:value1 arg2:value2
    /// </summary>
    public class KeyValueParameterManager : Core.ParameterManagerBase<KeyValueItemCommand>
    {
        public char SeparatorValue { get; set; } = ':';

        /// <summary>
        /// Used when exists multiples values
        /// </summary>
        public char MultiSeparatorValue { get; set; } = ';';

        public KeyValueParameterManager() : this(true) { }

        public KeyValueParameterManager(bool caseSensitive) : base(caseSensitive) { }

        public override void Process(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException("args");

            // the parameters without separator is used as command
            IEnumerable<string> commands = GetCommands(args);
            Dictionary<string, string> values = GetParametersValue(args);

            foreach (var command in commands)
            {
                var commandName = CaseSensitive ? command : command.ToLower();

                if (_commadsDictionary.ContainsKey(commandName))
                {
                    var itemCommand = _commadsDictionary[commandName];
                    var commad = (IKeyValueConsoleCommand)itemCommand.Activator();
                    commad.Execute(values);
                }
            }
        }

        private Dictionary<string, string> GetParametersValue(string[] args)
        {
            var parameters = args.Where(item => item.Contains(SeparatorValue));

            var values = new Dictionary<string, string>();
            foreach (var item in parameters)
            {
                var splitValues = item.Split(SeparatorValue);
                values.Add(splitValues[0], splitValues[1]);
            }

            return values;
        }

        private IEnumerable<string> GetCommands(string[] args)
        {
            return args.Where(item => !item.Contains(SeparatorValue) &&
                                      !String.IsNullOrWhiteSpace(item));
        }
    }
}
