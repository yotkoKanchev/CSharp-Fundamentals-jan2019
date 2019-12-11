namespace CommandPattern.Core
{
    using Contracts;
    using System;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            try
            {
                Console.WriteLine(commandInterpreter.Read(Console.ReadLine()));
                this.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message) ;
                this.Run();
            }
        }
    }
}
