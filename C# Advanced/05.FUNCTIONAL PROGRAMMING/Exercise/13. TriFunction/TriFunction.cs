namespace _13._TriFunction
{
    using System;
    using System.Linq;

    class TriFunction
    {
        static void Main(string[] args)
        {
            int sumToCompare = int.Parse(Console.ReadLine());

             string name = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.ToCharArray()
                .Select(y=>(int)y)
                .Sum() >= sumToCompare)
                .FirstOrDefault();

            Console.WriteLine(name);
        }
    }
}
