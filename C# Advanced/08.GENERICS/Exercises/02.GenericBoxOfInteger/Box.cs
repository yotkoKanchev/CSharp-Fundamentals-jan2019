namespace _02.GenericBoxOfInteger
{
    public class Box<T>
    {
        private T number;

        public Box(T number)
        {
            this.number = number;
        }

        public override string ToString()
        {
            return $"{this.number.GetType()}: {this.number}";
        }
    }
}
