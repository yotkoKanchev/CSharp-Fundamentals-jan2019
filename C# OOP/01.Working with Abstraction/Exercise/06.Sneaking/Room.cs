namespace P06_Sneaking
{
    using System;
    using System.Linq;
    using System.Text;

    public class Room
    {
        private char[][] matrix;
        public Room(int rows)
        {
            this.Rows = rows;
            matrix = new char[this.Rows][];
            this.InitializeRoom();
            this.HasToFinishGame = false;
        }

        public int Rows { get; set; }

        public bool HasToFinishGame { get; set; }

        private void InitializeRoom()
        {
            for (int row = 0; row < this.Rows; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                matrix[row] = new char[currentRow.Length];
                matrix[row] = currentRow;
            }
        }

        internal void MoveSam(Player sam, Player nikoladze, char move)
        {
            int currentSamRow = sam.Row;
            int currentSamCol = sam.Col;

            this.matrix[sam.Row][sam.Col] = '.';

            switch (move)
            {
                case 'U':
                    sam.Row--;
                    break;
                case 'D':
                    sam.Row++;
                    break;
                case 'L':
                    sam.Col--;
                    break;
                case 'R':
                    sam.Col++;
                    break;
            }

            this.matrix[sam.Row][sam.Col] = 'S';

            if (this.matrix[sam.Row].Contains('N'))
            {
                this.matrix[sam.Row][Array.IndexOf(this.matrix[sam.Row], 'N')] = 'X';
                Console.WriteLine("Nikoladze killed!");
                this.HasToFinishGame = true;
            }
            else if (this.matrix[sam.Row].Contains('b') && sam.Col > Array.IndexOf(this.matrix[sam.Row], 'b'))
            {
                ReverseSamPoition(currentSamRow, currentSamCol, sam);
                
                Console.WriteLine($"Sam died at {sam.Row}, {sam.Col}");
                this.HasToFinishGame = true;
            }
            else if (this.matrix[sam.Row].Contains('d') && sam.Col < Array.IndexOf(this.matrix[sam.Row], 'd'))
            {
                ReverseSamPoition(currentSamRow, currentSamCol, sam);
                Console.WriteLine($"Sam died at {sam.Row}, {sam.Col}");
                this.HasToFinishGame = true;
            }
        }

        private void ReverseSamPoition(int currentSamRow, int currentSamCol, Player sam)
        {
            this.matrix[sam.Row][sam.Col] = '.';
            this.matrix[currentSamRow][currentSamCol] = 'X';
            sam.Row = currentSamRow;
            sam.Col = currentSamCol;
        }

        internal void MoveEnemies()
        {
            for (int row = 0; row < this.Rows; row++)
            {
                if (this.matrix[row].Contains('b'))
                {
                    int index = Array.IndexOf(this.matrix[row], 'b');
                    if (index < this.matrix[row].Length - 1)
                    {
                        this.matrix[row][index] = '.';
                        this.matrix[row][index + 1] = 'b';
                    }
                    else
                    {
                        this.matrix[row][index] = 'd';
                    }
                }
                else if (this.matrix[row].Contains('d'))
                {
                    int index = Array.IndexOf(this.matrix[row], 'd');
                    if (index > 0)
                    {
                        this.matrix[row][index] = '.';
                        this.matrix[row][index - 1] = 'd';
                    }
                    else
                    {
                        this.matrix[row][index] = 'b';
                    }
                }
            }
        }

        public int[] GetPosition(char letter)
        {
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.matrix[row].Length; col++)
                {
                    if (this.matrix[row][col] == letter)
                    {
                        return new int[2] { row, col };
                    }
                }
            }

            return null;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.matrix[row].Length; col++)
                {
                    sb.Append(this.matrix[row][col]);
                }
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }
    }
}
