namespace _09._Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;

    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            Stack<string> latestStates = new Stack<string>();

            string resultString = string.Empty;

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                switch (command)
                {
                    case "1":
                        if (tokens.Length > 1)
                        {
                            string currentText = tokens[1];
                            latestStates.Push(resultString);
                            resultString += currentText;
                        }                        
                        break;

                    case "2":
                        int count = int.Parse(tokens[1]);

                        if (count > resultString.Length)
                        {
                            count = Math.Min(count, resultString.Length);
                        }
                        latestStates.Push(resultString);
                        resultString = resultString.Substring(0, resultString.Length - count);
                        break;

                    case "3":
                        int index = int.Parse(tokens[1]);
                        Console.WriteLine(resultString[index - 1]);
                        break;

                    case "4":
                        resultString = latestStates.Pop();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
