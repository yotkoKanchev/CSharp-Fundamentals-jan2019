namespace _01._Action_Print
{
    using System;
    using System.Linq;

    class ActionPrint
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}

