using System.Collections.Generic;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string,Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.cars = new Dictionary<string, Car>();
            this.capacity = capacity;
        }

        public int Count { get { return this.cars.Count; } set { } }

        public string AddCar(Car car)
        {
            if (this.cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (this.capacity == cars.Count)
            {
                return "Parking is full!";
            }

            this.cars[car.RegistrationNumber] = car;
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!this.cars.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(registrationNumber);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return cars[registrationNumber];
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNumber in registrationNumbers)
            {
                if (this.cars.ContainsKey(regNumber))
                {
                    cars.Remove(regNumber);
                }
            }
        }
    }
}
