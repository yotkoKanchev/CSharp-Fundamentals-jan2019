namespace P01ListyIterator
{
    using System.Collections.Generic;
    using System.Linq;
    using System;
    public class ListyIterator<T>
    {
        private List<T> elements;
        private int currnetIndex;
        public ListyIterator(params T[] elements)
        {
            this.elements = elements.ToList();
            this.currnetIndex = 0;
        }

        public bool Move()
        {
            if (this.currnetIndex < this.elements.Count - 1)
            {
                this.currnetIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return this.currnetIndex < this.elements.Count - 1;
        }

        public void Print()
        {
            if (!this.elements.Any())
            {
                throw new NullReferenceException("Invalid Operation!");
            }
            Console.WriteLine(this.elements[this.currnetIndex]);
        }
    }
}
