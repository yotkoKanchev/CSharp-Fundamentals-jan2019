namespace _1._Diagonal_Difference
{
    using System;
    using System.Linq;

    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int leftDiagonalSum = 0;
            int rightDiagonalSum = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                leftDiagonalSum += matrix[i, i];
                rightDiagonalSum += matrix[i, matrixSize - 1 - i];
            }            

            Console.WriteLine(Math.Abs(leftDiagonalSum-rightDiagonalSum));
        }
    }
}
