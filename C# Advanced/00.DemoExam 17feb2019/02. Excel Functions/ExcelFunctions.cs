namespace ExcelFunctions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExcelFunctionsm
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            string[][] table = new string[rows - 1][];

            string[] heatherRow = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int row = 0; row < rows - 1; row++)
            {
                table[row] = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            string[] commandArguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = commandArguments[0];
            string askedHeather = commandArguments[1];

            int colIndexToManipulate = Array.IndexOf(heatherRow, askedHeather);

            Console.WriteLine(string.Join(" | ", heatherRow));

            if (command?.ToLower() == "hide")
            {
                string[][] resultArray = new string[rows - 1][];

                for (int row = 0; row < table.Length; row++)
                {
                    List<string> currentRowAsList = table[row].ToList();
                    currentRowAsList.RemoveAt(colIndexToManipulate);
                    resultArray[row] = currentRowAsList.ToArray();
                }

                heatherRow = heatherRow.Where((source, index) => index != colIndexToManipulate).ToArray();
                
                foreach (var row in resultArray)
                {
                    Console.WriteLine(string.Join(" | ", row));
                }
            }
            else if (command?.ToLower() == "sort")
            {
                table = table.OrderBy(x => x[colIndexToManipulate]).ToArray();
                
                foreach (var row in table)
                {
                    Console.WriteLine(string.Join(" | ", row));
                }
            }
            else if (command?.ToLower() == "filter")
            {
                string askedInfo = commandArguments[2];

                for (int row = 0; row < table.Length; row++)
                {
                    for (int col = 0; col < table[row].Length; col++)
                    {
                        if (col == colIndexToManipulate && table[row][col] == askedInfo)
                        {
                            Console.WriteLine(string.Join(" | ", table[row]));
                        }
                    }
                }
            }
        }
    }
}
