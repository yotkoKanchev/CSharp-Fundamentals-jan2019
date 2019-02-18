namespace _03.GenericSwapMethodString
{
    using _04.GenericSwapMethodString;
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int boxesCount = int.Parse(Console.ReadLine());

            Box<string> boxes = new Box<string>();

            for (int i = 0; i < boxesCount; i++)
            {
                boxes.Elements.Add(Console.ReadLine());
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
