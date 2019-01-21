namespace _2._Squares_in_Matrix
{
    using System;
    using System.Linq;

    class SquaresInMatrix
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int equalCharsMatrixCount = 0;

            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    int firstChar = matrix[row, col];
                    int secondChar = matrix[row, col + 1];
                    int thirdChar = matrix[row + 1, col];
                    int fourthChar = matrix[row + 1, col + 1];

                    if (firstChar == secondChar && firstChar == thirdChar && firstChar == fourthChar)
                    {
                        equalCharsMatrixCount++;
                    }
                }
            }

            Console.WriteLine(equalCharsMatrixCount);
        }
    }
}
