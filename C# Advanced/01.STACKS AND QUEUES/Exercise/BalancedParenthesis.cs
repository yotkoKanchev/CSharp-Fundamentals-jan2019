namespace _08._Balanced_Parenthesis
{
    using System;
    using System.Collections.Generic;

    class BalancedParenthesis
    {
        static void Main(string[] args)
        {
            string inputSymbols = Console.ReadLine();
            Stack<char> brackets = new Stack<char>();

            if (inputSymbols.Length > 0)
            {
                foreach (var symbol in inputSymbols)
                {
                    if (symbol == '(' || symbol == '[' || symbol == '{')
                    {
                        brackets.Push(symbol);
                    }

                    if (brackets.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    if (symbol == ')' && brackets.Pop() != '(')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else if (symbol == ']' && brackets.Pop() != '[')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else if (symbol == '}' && brackets.Pop() != '{')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }

                if (brackets.Count == 0)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }            
        }
    }
}
