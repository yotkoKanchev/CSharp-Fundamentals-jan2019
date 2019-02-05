namespace _03._Count_Uppercase_Words
{
    using System;
    using System.Linq;

    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            Func<string, bool> checker = x => char.IsUpper(x[0]);

            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)
                .ToArray();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
