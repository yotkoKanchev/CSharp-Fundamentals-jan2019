namespace _03._Miner
{
    using System;
    using System.Linq;

    class Miner
    {
        static void Main(string[] args)
        {
            int qubicMatrixSize = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            char[][] matrix = new char[qubicMatrixSize][];

            for (int i = 0; i < qubicMatrixSize; i++)
            {
                char[] currentLine = Console.ReadLine().Split().Select(char.Parse).ToArray();
                matrix[i] = currentLine;
            }

            int totalCoal = 0;
            int rowIndex = -1;
            int colIndex = -1;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'c')
                    {
                        totalCoal++;
                    }
                    else if (matrix[row][col] == 's')
                    {
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            bool isOver = false;
            bool collectedAllCoal = false;

            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];
                switch (currentCommand)
                {
                    case "left":
                        if (colIndex == 0)
                        {
                            continue;
                        }

                        if (matrix[rowIndex][colIndex - 1] == 'e')
                        {
                            colIndex--;
                            isOver = true;
                        }
                        else if (matrix[rowIndex][colIndex - 1] == 'c')
                        {
                            matrix[rowIndex][colIndex - 1] = '*';
                            colIndex--;
                            totalCoal--;
                        }
                        else
                        {
                            colIndex--;
                        }
                        break;
                    case "right":

                        if (colIndex == matrix[rowIndex].Length - 1)
                        {
                            continue;
                        }

                        if (matrix[rowIndex][colIndex + 1] == 'e')
                        {
                            colIndex++;
                            isOver = true;
                        }
                        else if (matrix[rowIndex][colIndex + 1] == 'c')
                        {
                            matrix[rowIndex][colIndex + 1] = '*';
                            colIndex++;
                            totalCoal--;
                        }
                        else
                        {
                            colIndex++;
                        }
                        break;
                    case "up":
                        if (rowIndex == 0)
                        {
                            continue;
                        }

                        if (matrix[rowIndex - 1][colIndex] == 'e')
                        {
                            rowIndex--;
                            isOver = true;
                        }
                        else if (matrix[rowIndex - 1][colIndex] == 'c')
                        {
                            matrix[rowIndex - 1][colIndex] = '*';
                            rowIndex--;
                            totalCoal--;
                        }
                        else
                        {
                            rowIndex--;
                        }
                        break;
                    case "down":
                        if (rowIndex == matrix.Length - 1)
                        {
                            continue;
                        }

                        if (matrix[rowIndex + 1][colIndex] == 'e')
                        {
                            rowIndex++;
                            isOver = true;
                        }
                        else if (matrix[rowIndex + 1][colIndex] == 'c')
                        {
                            matrix[rowIndex + 1][colIndex] = '*';
                            rowIndex++;
                            totalCoal--;
                        }
                        else
                        {
                            rowIndex++;
                        }
                        break;
                    default:
                        break;
                }

                if (isOver == true)
                {
                    break;
                }

                if (totalCoal == 0)
                {
                    collectedAllCoal = true;
                    break;
                }
            }

            if (isOver)
            {
                Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
            }
            else if (collectedAllCoal)
            {
                Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
            }
            else
            {
                Console.WriteLine($"{totalCoal} coals left. ({rowIndex}, {colIndex})");
            }
        }
    }
}
