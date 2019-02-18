namespace _02.GenericBoxOfInteger
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int inputLinesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLinesCount; i++)
            {
                int number = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(number);
                Console.WriteLine(box);
            }
        }
    }
}
