﻿namespace P02.Facade
{
    public class CarAddressBuilder : CarBuilderFacade
    {
        public CarAddressBuilder(Car car)
        {
            this.Car = car;
        }

        public CarAddressBuilder InCity(string city)
        {
            Car.City = city;
            return this;
        }

        public CarAddressBuilder AtAddress(string address)
        {
            Car.Address = address;
            return this;
        }
    }
}
