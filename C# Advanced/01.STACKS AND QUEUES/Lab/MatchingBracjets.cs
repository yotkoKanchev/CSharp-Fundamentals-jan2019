namespace _4._Matching_Brackets
{
    using System;
    using System.Collections.Generic;

    class MatchingBracjets
    {
        static void Main(string[] args)
        {

            string expression = Console.ReadLine();

            Stack<int> openingBracketsIndexes = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openingBracketsIndexes.Push(i);
                }
                else if (expression[i] == ')' && openingBracketsIndexes.Count > 0)
                {
                    int openingIndex = openingBracketsIndexes.Pop();
                    Console.WriteLine(expression.Substring(openingIndex,i - openingIndex + 1));
                }
            }         
        }
    }
}
