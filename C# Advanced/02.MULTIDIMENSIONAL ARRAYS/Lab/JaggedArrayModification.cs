namespace _6._Jagged_Array_Modification
{
    using System;
    using System.Linq;

    class JaggedArrayModification
    {
        static void Main(string[] args)
        {
            int matrixRows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[matrixRows][];

            for (int row = 0; row < matrixRows; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = currentRow;
            }

            string inputLine = Console.ReadLine();

            while (inputLine?.ToLower() != "end")
            {
                string[] commandTokens = inputLine.Split();
                string command = commandTokens[0];
                int targetRow = int.Parse(commandTokens[1]);
                int targetCol = int.Parse(commandTokens[2]);
                int value = int.Parse(commandTokens[3]);

                if (targetRow < 0 || targetCol < 0)
                {
                    Console.WriteLine($"Invalid coordinates");
                }
                else
                {
                    if (targetRow < matrixRows && targetCol < matrix[targetRow].Length)
                    {
                        if (command.ToLower() == "add")
                        {
                            matrix[targetRow][targetCol] += value;
                        }
                        else if (command.ToLower() == "subtract")
                        {
                            matrix[targetRow][targetCol] -= value;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid coordinates");
                    }
                }

                inputLine = Console.ReadLine();
            }

            for (int row = 0; row < matrixRows; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}
