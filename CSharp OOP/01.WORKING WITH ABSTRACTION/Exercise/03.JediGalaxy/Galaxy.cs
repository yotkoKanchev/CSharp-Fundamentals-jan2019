namespace P03_JediGalaxy
{
    public class Galaxy
    {
        public Galaxy(int rows, int cols)
        {
            this.Matrix = new int[rows, cols];
            this.InitializeMаtrix();
        }

        public int[,] Matrix { get; set; }

        private void InitializeMаtrix()
        {
            int value = 0;

            for (int row = 0; row < this.Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.Matrix.GetLength(1); col++)
                {
                    Matrix[row, col] = value++;
                }
            }
        }

        public bool IsInside(int row, int col)
        {
            return row >= 0 && 
                   row < this.Matrix.GetLength(0) && 
                   col >= 0 && 
                   col < this.Matrix.GetLength(1);
        }
    }
}
