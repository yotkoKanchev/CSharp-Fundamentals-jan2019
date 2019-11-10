namespace P04.PizzaCalories
{
    public static class Modifier
    {
        internal class Toping
        {
            internal const double Meat = 1.2;
            internal const double Veggies = 0.8;
            internal const double Cheese = 1.1;
            internal const double Sauce = 0.9;
        }
        internal class Flour
        {
            internal const double White = 1.5;
            internal const double Wholegrain = 1.0;
        }

        internal class BakingType
        {
            internal const double Crispy = 0.9;
            internal const double Chewy = 1.1;
            internal const double Homemade = 1.0;
        }
    }
}
