namespace _01.GenericBoxOfString
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {

            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                string data = Console.ReadLine();
                Box<string> box = new Box<string>(data);

                Console.WriteLine(box);
            }
        }
    }
}
