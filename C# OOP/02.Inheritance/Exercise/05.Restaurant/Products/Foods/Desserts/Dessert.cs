﻿namespace Restaurant.Products.Foods.Desserts
{
    public abstract class Dessert : Food
    {
        public Dessert(string name, decimal price, double grams, double calories) 
            : base(name, price, grams)
        {
            this.Calories = calories;
        }

        public double Calories { get; internal set; }
    }
}
