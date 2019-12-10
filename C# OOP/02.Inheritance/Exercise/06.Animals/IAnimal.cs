namespace Animals
{
    public interface IAnimal
    {
        public string Name { get;  }

        public int Age { get; }

        public string Gender { get; }

        public string ProduceSound();
    }
}
