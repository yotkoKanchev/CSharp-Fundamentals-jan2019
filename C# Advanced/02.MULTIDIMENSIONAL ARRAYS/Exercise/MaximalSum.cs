namespace _3._Maximal_Sum
{
    using System;
    using System.Linq;

    class MaximalSum
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currrentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currrentRow[col];
                }
            }

            int maxSum = int.MinValue;
            int rowIndex = -1;
            int colIndex = -1;

            for (int row = 0; row < rows-2; row++)
            {
                for (int col = 0; col < cols-2; col++)
                {
                    int currentSum = 0;
                    for (int i = row; i < row+3; i++)
                    {
                        for (int j = col; j < col+3; j++)
                        {
                            currentSum += matrix[i, j];
                        }
                    }

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = rowIndex; i < rowIndex + 3; i++)
            {
                for (int j = colIndex; j < colIndex + 3; j++)
                {
                    Console.Write($"{matrix[i,j] + " "}");
                }
                Console.WriteLine();
            }
        }
    }
}
