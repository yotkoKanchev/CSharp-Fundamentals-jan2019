namespace _04._Add_VAT
{
    using System;
    using System.Linq;

    class addVAT
    {
        static void Main(string[] args)
        {
            Func<string, double> addVAT = x => double.Parse(x) * 1.2;

            double[] numbers = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(addVAT)
                .ToArray();

            foreach (var num in numbers)
            {
                Console.WriteLine($"{num:f2}");
            }
        }
    }
}
