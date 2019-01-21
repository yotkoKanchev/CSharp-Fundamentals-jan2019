namespace _7._Pascal_Triangle
{
    using System;

    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int pascalTriangleRows = int.Parse(Console.ReadLine());

            long[][] matrix = new long[pascalTriangleRows][];

            matrix[0] = new long[1];
            matrix[0][0] = 1;
            for (int row = 1; row < pascalTriangleRows ; row++)
            {
                matrix[row] = new long[row+1];
                matrix[row][0] = 1;
                matrix[row][matrix[row].Length - 1] = 1;

                for (int col = 1; col < matrix[row].Length-1; col++)
                {
                    matrix[row][col] = matrix[row - 1][col - 1] + matrix[row - 1][col];
                }
            }

            for (int row = 0; row < pascalTriangleRows; row++)
            {
                Console.WriteLine(string.Join(" ",matrix[row]));
            }
        }
    }
}
