namespace P07.FoodShortage
{
    public abstract class Person : IBuyer
    {
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.age = age;
            this.Food = 0;
        }

        public string Name { get; private set;}
        public int Food { get; internal set; }

        public abstract void BuyFood();
    }
}
