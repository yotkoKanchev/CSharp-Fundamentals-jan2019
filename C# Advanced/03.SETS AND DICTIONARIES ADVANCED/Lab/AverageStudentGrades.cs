namespace _02._Average_Student_Grades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AverageStudentGrades
    {
        static void Main(string[] args)
        {
            var studentGrades = new Dictionary<string, List<double>>();
            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                string[] personArguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personArguments[0];
                double mark = double.Parse(personArguments[1]);

                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades[name] = new List<double>();
                }

                studentGrades[name].Add(mark);
            }

            foreach (var kvp in studentGrades)
            {
                Console.Write($"{kvp.Key} -> ");
                foreach (var mark in kvp.Value)
                {
                    Console.Write($"{mark:f2} ");
                }
                Console.Write($"(avg: {kvp.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
