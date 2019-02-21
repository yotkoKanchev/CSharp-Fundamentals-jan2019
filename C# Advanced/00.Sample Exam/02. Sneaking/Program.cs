namespace _02._Sneaking
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());

            char[][] field = new char[rowsCount][];

            int rowSam = -1;
            int colSam = -1;
            bool SamIsDead = false;
            bool NikoladzeIsKilled = false;

            for (int row = 0; row < rowsCount; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                field[row] = currentRow;
            }


            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'S')
                    {
                        rowSam = row;
                        colSam = col;
                        break;
                    }
                }
            }

            string commands = Console.ReadLine();

            foreach (var command in commands)
            {
                for (int row = 0; row < field.Length; row++)
                {
                    for (int col = 0; col < field[row].Length; col++)
                    {
                        if (field[row][col] == 'b')
                        {
                            if (col == field[row].Length - 1)
                            {
                                field[row][col] = 'd';
                                break;
                            }
                            else
                            {
                                field[row][col] = '.';
                                field[row][col + 1] = 'b';
                                break;
                            }
                        }
                        else if (field[row][col] == 'd')
                        {
                            if (col == 0)
                            {
                                field[row][col] = 'b';
                                break;
                            }
                            else
                            {
                                field[row][col] = '.';
                                field[row][col - 1] = 'd';
                                break;
                            }
                        }
                    }
                }

                if (CheckSamDies(field, rowSam, colSam))
                {
                    SamIsDead = true;
                    break;
                }
                else
                {
                    switch (command)
                    {
                        case 'U':
                            field[rowSam][colSam] = '.';
                            rowSam --;
                            field[rowSam][colSam] = 'S';
                            break;

                        case 'D':
                            field[rowSam][colSam] = '.';
                            rowSam++;
                            field[rowSam][colSam] = 'S';
                            break;

                        case 'L':
                            field[rowSam][colSam] = '.';
                            colSam--;
                            field[rowSam][colSam] = 'S';
                            break;

                        case 'R':
                            field[rowSam][colSam] = '.';
                            colSam++;
                            field[rowSam][colSam] = 'S';
                            break;

                        case 'W':
                            break;
                    }
                }
                if (CheckNikoladzeDies(field[rowSam]))
                {
                    NikoladzeIsKilled = true;
                    break;
                }

                if (SamIsDead || NikoladzeIsKilled)
                {
                    break;
                }
            }            

            if (SamIsDead)
            {
                Console.WriteLine($"Sam died at {rowSam}, {colSam}");
            }

            if (NikoladzeIsKilled)
            {
                Console.WriteLine($"Nikoladze killed!");
            }

            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    Console.Write(field[row][col]);
                }

                Console.WriteLine();
            }
        }

        private static bool CheckNikoladzeDies(char[] currentRow)
        {
            if (currentRow.Contains('N'))
            {
                currentRow[Array.IndexOf(currentRow, 'N')] = 'X';
                return true;
            }

            return false;
        }

        private static bool CheckSamDies(char[][] field, int rowSam, int colSam)
        {
            if (field[rowSam].Contains('b'))
            {
                for (int i = 0; i < colSam; i++)
                {
                    if (field[rowSam][i] == 'b')
                    {
                        field[rowSam][colSam] = 'X';
                        return true;
                    }
                }
            }
            else if (field[rowSam].Contains('d'))
            {
                for (int i = colSam; i < field[rowSam].Length; i++)
                {
                    if (field[rowSam][i] == 'd')
                    {
                        field[rowSam][colSam] = 'X';
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
