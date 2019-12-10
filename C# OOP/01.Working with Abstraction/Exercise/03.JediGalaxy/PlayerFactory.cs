namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public class PlayerFactory
    {
        public Player Create(string arguments)
        {
            int[] coordinates = arguments
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int row = coordinates[0];
            int col = coordinates[1];

            return new Player(row, col);
        }
    }
}
