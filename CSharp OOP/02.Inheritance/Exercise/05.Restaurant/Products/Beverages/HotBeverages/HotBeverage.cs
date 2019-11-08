﻿namespace Restaurant.Products.Beverages.HotBeverages
{
    public abstract class HotBeverage : Beverage
    {
        public HotBeverage(string name, decimal price, double milliliters) 
            : base(name, price, milliliters)
        {
        }
    }
}
