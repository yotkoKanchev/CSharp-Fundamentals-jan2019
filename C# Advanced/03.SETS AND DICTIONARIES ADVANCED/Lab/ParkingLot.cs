namespace _06._Parking_Lot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ParkingLot
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();
            string inputLine = Console.ReadLine();

            while (inputLine?.ToLower() != "end")
            {
                string[] carArguments = inputLine.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string action = carArguments[0];
                string plateNumber = carArguments[1];

                if (action?.ToLower() == "in")
                {
                    parking.Add(plateNumber);
                }
                else if (action?.ToLower() == "out")
                {
                    if (parking.Contains(plateNumber))
                    {
                        parking.Remove(plateNumber);
                    }
                }

                inputLine = Console.ReadLine();
            }

            if (parking.Any())
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }            
        }
    }
}
