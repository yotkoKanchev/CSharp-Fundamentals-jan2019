namespace _4._Matrix_shuffling
{
    using System;
    using System.Linq;

    class MatrixShuffling
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string inputLine = Console.ReadLine();

            while (inputLine.ToLower() != "end")
            {
                string[] commandTokens = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandTokens[0];
                if (command.ToLower() != "swap" || commandTokens.Length != 5)
                {
                    Console.WriteLine("Invalid input!");                    
                }
                else
                {
                    int row1 = int.Parse(commandTokens[1]);
                    int col1 = int.Parse(commandTokens[2]);
                    int row2 = int.Parse(commandTokens[3]);
                    int col2 = int.Parse(commandTokens[4]);

                    if (row1 < 0 || row1 > rows-1 || row2 < 0 || row2 > rows-1 ||
                        col1 < 0 || col1 > cols-1 || col2 < 0 || col2 > cols-1)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        string firstValue = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = firstValue;

                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }                    
                }

                inputLine = Console.ReadLine();
            }
        }
    }
}
