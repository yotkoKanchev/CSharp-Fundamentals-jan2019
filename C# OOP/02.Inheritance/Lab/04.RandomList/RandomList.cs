namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;

    public class RandomList : List<string>
    {
        private Random random;

        public RandomList()
        {
            this.random = new Random();
        }

        public string RandomString()
        {
            var randomIndex = this.random.Next(0, this.Count);
            this.RemoveElement(randomIndex);

            return this[randomIndex];
        }

        private void RemoveElement(int randomIndex)
        {
            this.RemoveAt(randomIndex);
        }
    }
}
