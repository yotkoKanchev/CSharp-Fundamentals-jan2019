namespace _06._Auto_Repair_and_Service
{
    using System;
    using System.Collections.Generic;

    class AutoRepairService
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                );

            Stack<string> servedVechicles = new Stack<string>();

            string inputLine = Console.ReadLine();

            while (inputLine?.ToLower() != "end")
            {
                string[] tokens = inputLine.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                switch (command)
                {
                    case "Service":
                        if (cars.Count > 0)
                        {
                            string currentCar = cars.Dequeue();
                            Console.WriteLine($"Vehicle {currentCar} got served.");
                            servedVechicles.Push(currentCar);
                        }
                        break;
                    case "CarInfo":
                        string carToLookFor = tokens[1];
                        if (cars.Contains(carToLookFor))
                        {
                            Console.WriteLine("Still waiting for service.");
                        }
                        else
                        {
                            Console.WriteLine("Served.");
                        }

                        break;
                    case "History":

                        Console.WriteLine($"{string.Join(", ", servedVechicles)}");                        
                        break;
                    default:
                        break;
                }

                inputLine = Console.ReadLine();
            }

            if (cars.Count > 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", cars)}");                
            }

            if (servedVechicles.Count > 0)
            {
                Console.WriteLine($"Served vehicles: {string.Join(", ", servedVechicles)}");             
            }
        }
    }
}
