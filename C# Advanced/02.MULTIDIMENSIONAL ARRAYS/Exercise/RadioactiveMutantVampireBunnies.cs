namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    using System;
    using System.Linq;

    class RadioactiveMutantVampireBunnies
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            int playerRow = -1;
            int playerCol = -1;

            char[,] matrix = new char[rows, cols];
            char[,] resultMatrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    char currentChar = currentRow[col];
                    matrix[row, col] = currentChar;
                    resultMatrix[row, col] = currentChar;

                    if (currentChar == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string commands = Console.ReadLine();

            bool hasToDie = false;
            bool hasToWin = false;

            foreach (var letter in commands)
            {
                switch (letter)
                {
                    case 'R':
                        if (playerCol < cols - 1)
                        {
                            if (resultMatrix[playerRow, playerCol + 1] == '.')
                            {
                                resultMatrix[playerRow, playerCol] = '.';
                                resultMatrix[playerRow, playerCol + 1] = 'P';
                                playerCol += 1;
                            }
                            else if (resultMatrix[playerRow, playerCol + 1] == 'B')
                            {
                                playerCol += 1;
                                hasToDie = true;
                            }
                        }
                        else if (playerCol == cols - 1)
                        {
                            hasToWin = true;
                            resultMatrix[playerRow, playerCol] = '.';
                        }
                        break;
                    case 'L':
                        if (playerCol > 0)
                        {
                            if (resultMatrix[playerRow, playerCol - 1] == '.')
                            {
                                resultMatrix[playerRow, playerCol] = '.';
                                resultMatrix[playerRow, playerCol - 1] = 'P';
                                playerCol -= 1;
                            }
                            else if (resultMatrix[playerRow, playerCol - 1] == 'B')
                            {
                                playerCol -= 1;
                                hasToDie = true;
                            }
                        }
                        else if (playerCol == 0)
                        {
                            hasToWin = true;
                            resultMatrix[playerRow, playerCol] = '.';
                        }
                        break;
                    case 'U':
                        if (playerRow > 0)
                        {
                            if (resultMatrix[playerRow - 1, playerCol] == '.')
                            {
                                resultMatrix[playerRow, playerCol] = '.';
                                resultMatrix[playerRow - 1, playerCol] = 'P';
                                playerRow -= 1;
                            }
                            else if (resultMatrix[playerRow - 1, playerCol] == 'B')
                            {
                                playerRow -= 1;
                                hasToDie = true;
                            }
                        }
                        else if (playerRow == 0)
                        {
                            hasToWin = true;
                            resultMatrix[playerRow, playerCol] = '.';
                        }
                        break;
                    case 'D':
                        if (playerRow < rows - 1)
                        {
                            if (resultMatrix[playerRow + 1, playerCol] == '.')
                            {
                                resultMatrix[playerRow, playerCol] = '.';
                                resultMatrix[playerRow + 1, playerCol] = 'P';
                                playerRow += 1;
                            }
                            else if (resultMatrix[playerRow + 1, playerCol] == 'B')
                            {
                                playerRow += 1;
                                hasToDie = true;
                            }
                        }
                        else if (playerRow == rows - 1)
                        {
                            hasToWin = true;
                            resultMatrix[playerRow, playerCol] = '.';
                        }
                        break;
                    default:
                        break;
                }

                matrix = (char[,])resultMatrix.Clone();

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            if (row > 0)
                            {
                                if (matrix[row - 1, col] == 'P')
                                {
                                    hasToDie = true;
                                }
                                resultMatrix[row - 1, col] = 'B';
                            }

                            if (row < rows - 1)
                            {
                                if (matrix[row + 1, col] == 'P')
                                {
                                    hasToDie = true;
                                }
                                resultMatrix[row + 1, col] = 'B';
                            }

                            if (col > 0)
                            {
                                if (matrix[row, col - 1] == 'P')
                                {
                                    hasToDie = true;
                                }
                                resultMatrix[row, col - 1] = 'B';
                            }

                            if (col < cols - 1)
                            {
                                if (matrix[row, col + 1] == 'P')
                                {
                                    hasToDie = true;
                                }
                                resultMatrix[row, col + 1] = 'B';
                            }
                        }
                    }
                }

                matrix = (char[,])resultMatrix.Clone();

                if (hasToDie || hasToWin)
                {
                    break;
                }                
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

            if (hasToDie)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
            else if (hasToWin)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
        }
    }
}
