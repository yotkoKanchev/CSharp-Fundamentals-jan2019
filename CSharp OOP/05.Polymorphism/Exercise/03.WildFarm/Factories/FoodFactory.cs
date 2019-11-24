namespace P03.WildFarm.Factories
{
    using P03.WildFarm.Foods;
    using System;

    public class FoodFactory
    {
        public Food Create(string input)
        {
            var foodArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var type = foodArgs[0];
            var quantity = int.Parse(foodArgs[1]);

            Food food;
            switch (type)
            {
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;
                case "Fruit":
                    food = new Fruit(quantity);
                    break;
                default:
                case "Meat":
                    food = new Meat(quantity);
                    break;
                case "Seeds":
                    food = new Seeds(quantity);
                    break;
            }

            return food;
        }
    }
}
