namespace _01.ClubParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int hallsMaxCapacity = int.Parse(Console.ReadLine());

            Stack<string> inputs = new Stack<string>(Console.ReadLine().Split());
            Dictionary<string, List<int>> hallsAndReservations = new Dictionary<string, List<int>>();
            Queue<string> halls = new Queue<string>();

            while (inputs.Any())
            {
                string currentValue = inputs.Peek();

                if (char.IsLetter(currentValue[0]))
                {
                    hallsAndReservations[currentValue] = new List<int>();
                    halls.Enqueue(currentValue);
                    inputs.Pop();
                }
                else
                {
                    if (halls.Any())
                    {
                        string currentHall = halls.Peek();

                        int currentNumber = int.Parse(currentValue);
                        int currentHallSum = hallsAndReservations[currentHall].Sum();

                        if (currentNumber + currentHallSum > hallsMaxCapacity)
                        {
                            Console.Write($"{currentHall} -> ");
                            Console.WriteLine(string.Join(", ", hallsAndReservations[currentHall]));
                            hallsAndReservations.Remove(currentHall);
                            halls.Dequeue();
                        }
                        else
                        {
                            hallsAndReservations[currentHall].Add(currentNumber);
                            inputs.Pop();
                        }
                    }
                    else
                    {
                        inputs.Pop();
                    }
                }
            }
        }
    }
}
