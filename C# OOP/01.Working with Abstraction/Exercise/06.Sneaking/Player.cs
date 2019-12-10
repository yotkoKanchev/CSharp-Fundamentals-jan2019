namespace P06_Sneaking
{
    public class Player
    {
        public Player(int[] indeces)
        {
            this.Row = indeces[0];
            this.Col = indeces[1];
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }
}
