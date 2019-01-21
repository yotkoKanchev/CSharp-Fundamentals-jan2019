namespace _4._Symbol_in_Matrix
{
    using System;
    using System.Linq;

    class SymbolInMatrix
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                string currentLine = Console.ReadLine();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = currentLine[col];
                }
            }

            char symbolToLookFor = char.Parse(Console.ReadLine());
            
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row,col] == symbolToLookFor)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbolToLookFor} does not occur in the matrix");
        }
    }
}
