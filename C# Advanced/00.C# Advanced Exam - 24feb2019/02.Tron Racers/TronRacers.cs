namespace TronRacers
{
    using System;

    public class TronRacers
    {
        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[][] field = new char[matrixSize][];

            int firstPlayerRow = -1;
            int firstPlayerCol = -1;
            int secondPlayerRow = -1;
            int secondPlayerCol = -1;

            for (int row = 0; row < matrixSize; row++)
            {
                string currentRow = Console.ReadLine();
                field[row] = new char[matrixSize];

                for (int col = 0; col < matrixSize; col++)
                {
                    field[row][col] = currentRow[col];

                    if (field[row][col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    else if (field[row][col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                string firstPlayerCommand = commands[0];
                string secondPlayerCommand = commands[1];

                switch (firstPlayerCommand)
                {
                    case "up": firstPlayerRow = MoveUp(matrixSize, firstPlayerRow); break;
                    case "down": firstPlayerRow = MoveDown(matrixSize, firstPlayerRow); break;
                    case "right": firstPlayerCol = MoveRight(matrixSize, firstPlayerCol); break;
                    case "left": firstPlayerCol = MoveLeft(matrixSize, firstPlayerCol); break;                    
                }

                if (ChekIfDies(field, firstPlayerRow, firstPlayerCol, 'f' , 's'))
                {
                    break;
                }                

                switch (secondPlayerCommand)
                {
                    case "up": secondPlayerRow = MoveUp(matrixSize, secondPlayerRow); break;
                    case "down": secondPlayerRow = MoveDown(matrixSize, secondPlayerRow); break;
                    case "right": secondPlayerCol = MoveRight(matrixSize, secondPlayerCol); break;
                    case "left": secondPlayerCol = MoveLeft(matrixSize, secondPlayerCol); break;
                }

                if (ChekIfDies(field, secondPlayerRow, secondPlayerCol, 's', 'f'))
                {
                    break;
                }
            }

            foreach (var row in field)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static bool ChekIfDies(char[][] field, int row, int col, char player, char enemy)
        {
            if (field[row][col] == '*')
            {
                field[row][col] = player;
            }
            else if (field[row][col] == enemy)
            {
                field[row][col] = 'x';
                return true;
            }

            return false;
        }

        public static int MoveUp(int matrixSize, int row)
        {
            return row == 0 ? matrixSize - 1 : row - 1;
        }

        public static int MoveDown(int matrixSize, int row)
        {
            return row == matrixSize - 1 ? 0 : row + 1;           
        }

        public static int MoveLeft(int matrixSize, int col)
        {
            return col == 0 ? matrixSize - 1 : col - 1;            
        }

        public static int MoveRight(int matrixSize, int col)
        {
            return col == matrixSize - 1 ? 0 : col + 1;
        }
    }
}
