namespace CommandPattern.Core
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var input = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var commandName = input[0];
            var commandArgs = input.Skip(1).ToArray();

            var types = Assembly.GetCallingAssembly().GetTypes();
            
            var type = types.FirstOrDefault(t => t.Name == commandName + "Command");

            if (type == null)
            {
                throw new ArgumentException("The command doesn't exist");
            }

            var instance = Activator.CreateInstance(type) as ICommand;
            var result = instance.Execute(commandArgs);
            return result;
        }
    }
}
