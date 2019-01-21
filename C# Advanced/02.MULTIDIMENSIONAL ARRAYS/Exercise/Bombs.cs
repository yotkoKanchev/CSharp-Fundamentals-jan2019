﻿namespace _03._Bombs
{
    using System;
    using System.Linq;

    class Bombs
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentMatrixRow = Console.ReadLine().
                    Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentMatrixRow[col];
                }
            }

            string[] bombsCoordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var pair in bombsCoordinates)
            {
                int bombRow = pair.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()[0];
                int bombCol = pair.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()[1];

                int bombValue = matrix[bombRow, bombCol];

                if (bombValue > 0)
                {
                    matrix[bombRow, bombCol] = 0;

                    if (bombRow > 0)
                    {
                        if (matrix[bombRow - 1, bombCol] > 0)
                        {
                            matrix[bombRow - 1, bombCol] -= bombValue;
                        }
                    }

                    if (bombRow < matrix.GetLength(0) - 1)
                    {
                        if (matrix[bombRow + 1, bombCol] > 0)
                        {
                            matrix[bombRow + 1, bombCol] -= bombValue;
                        }
                    }

                    if (bombCol > 0)
                    {
                        if (matrix[bombRow, bombCol - 1] > 0)
                        {
                            matrix[bombRow, bombCol - 1] -= bombValue;
                        }
                    }

                    if (bombCol < matrix.GetLength(1) - 1)
                    {
                        if (matrix[bombRow, bombCol + 1] > 0)
                        {
                            matrix[bombRow, bombCol + 1] -= bombValue;
                        }
                    }

                    if (bombRow > 0 && bombCol > 0)
                    {
                        if (matrix[bombRow - 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow - 1, bombCol - 1] -= bombValue;
                        }
                    }

                    if (bombRow < matrix.GetLength(0) - 1 && bombCol < matrix.GetLength(1) - 1)
                    {
                        if (matrix[bombRow + 1, bombCol + 1] > 0)
                        {
                            matrix[bombRow + 1, bombCol + 1] -= bombValue;
                        }
                    }

                    if (bombRow < matrix.GetLength(0) - 1 && bombCol > 0)
                    {
                        if (matrix[bombRow + 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow + 1, bombCol - 1] -= bombValue;
                        }
                    }

                    if (bombRow > 0 && bombCol < matrix.GetLongLength(1) - 1)
                    {
                        if (matrix[bombRow - 1, bombCol + 1] > 0)
                        {
                            matrix[bombRow - 1, bombCol + 1] -= bombValue;
                        }
                    }
                }
            }
            int aliveCells = 0;
            int aliveCellsSum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        aliveCellsSum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {aliveCellsSum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
