namespace P04.PizzaCalories
{
    public abstract class Ingredient
    {
        private const double DefaultCaloriesPerGram = 2;

        internal abstract int Weight { get; set; }

        internal abstract double CaloriesModifier();

        internal double GetTotalCalories()
        {
            return DefaultCaloriesPerGram * this.Weight * this.CaloriesModifier();
        }
    }
}
