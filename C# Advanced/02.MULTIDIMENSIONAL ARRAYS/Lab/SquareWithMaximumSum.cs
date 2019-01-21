namespace _5._Square_With_Maximum_Sum
{
    using System;
    using System.Linq;

    class SquareWithMaximumSum
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int maxSum = int.MinValue;
            int maxStartRowIndex = -1;
            int maxStartColIndex = -1;

            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    if (matrix[row,col] + matrix[row,col+1] + matrix[row+1,col] + matrix[row+1,col+1] > maxSum)
                    {
                        maxSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                        maxStartRowIndex = row;
                        maxStartColIndex = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxStartRowIndex,maxStartColIndex]} {matrix[maxStartRowIndex,maxStartColIndex+1]}");
            Console.WriteLine($"{matrix[maxStartRowIndex+1,maxStartColIndex]} {matrix[maxStartRowIndex+1,maxStartColIndex+1]}");
            Console.WriteLine(maxSum);
        }
    }
}
