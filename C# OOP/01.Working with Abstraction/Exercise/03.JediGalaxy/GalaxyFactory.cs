using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class GalaxyFactory
    {
        public Galaxy Create(string arguments)
        {
            int[] galaxyDimenssions = arguments.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = galaxyDimenssions[0];
            int cols = galaxyDimenssions[1];
            return new Galaxy(rows, cols);
        }
    }
}
