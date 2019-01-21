namespace _1._Reverse_Strings
{
    using System;
    using System.Collections.Generic;

    class ReverseStrings
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();

            var reversedSymbols = new Stack<char>();

            foreach (var symbol in inputText)
            {
                reversedSymbols.Push(symbol);
            }

            while (reversedSymbols.Count > 0)
            {
                Console.Write(reversedSymbols.Pop());
            }
            Console.WriteLine();
        }
    }
}
