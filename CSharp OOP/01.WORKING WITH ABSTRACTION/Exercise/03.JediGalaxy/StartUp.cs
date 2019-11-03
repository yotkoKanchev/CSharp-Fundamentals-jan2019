namespace P03_JediGalaxy
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var playerFactory = new PlayerFactory();
            var galaxyFactory = new GalaxyFactory();
            long ivoPoints = 0;

            var galaxy = galaxyFactory.Create(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "Let the Force be with you")
            {
                var ivo = playerFactory.Create(command);
                var evil = playerFactory.Create(Console.ReadLine());

                DestroyStars(evil, galaxy);
                ivoPoints += AddPoints(ivo, galaxy);

                command = Console.ReadLine();
            }

            Console.WriteLine(ivoPoints);
        }

        private static long AddPoints(Player ivo, Galaxy galaxy)
        {
            int row = ivo.Row;
            int col = ivo.Col;
            int points = 0;

            while (row >= 0 && ivo.Col < galaxy.Matrix.GetLength(1))
            {
                if (galaxy.IsInside(row, col))
                {
                    points += galaxy.Matrix[row, col];
                }

                col++;
                row--;
            }

            return points;
        }

        private static void DestroyStars(Player evil, Galaxy galaxy)
        {
            int row = evil.Row;
            int col = evil.Col;

            while (row >= 0 && col >= 0)
            {
                if (galaxy.IsInside(row, col))
                {
                    galaxy.Matrix[row, col] = 0;
                }

                row--;
                col--;
            }
        }
    }
}
