namespace _3._Primary_Diagonal
{
    using System;
    using System.Linq;

    class PrimaryDiagonal
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int primaryDiagonalSum = 0;

            for (int row = 0; row < matrixSize; row++)
            {                
                primaryDiagonalSum += matrix[row, row];                
            }

            Console.WriteLine(primaryDiagonalSum);
        }
    }
}
