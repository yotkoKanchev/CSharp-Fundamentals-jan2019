namespace _04.GenericSwapMethodInteger
{
    using _03.GenericSwapMethodString;
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            int boxesCount = int.Parse(Console.ReadLine());

            Box<int> boxes = new Box<int>();

            for (int i = 0; i < boxesCount; i++)
            {
                boxes.Elements.Add(int.Parse(Console.ReadLine()));
            }

            int[] indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            boxes.SwapElements(indexes[0], indexes[1]);
            Console.WriteLine(boxes);
        }
    }
}
