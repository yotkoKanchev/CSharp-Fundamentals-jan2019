namespace P02Collection
{
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using System.Collections;

    public class ListyIterator<T> : IEnumerable<T>
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

        public void PrintAll()
        {
            if (!this.elements.Any())
            {
                throw new NullReferenceException("Invalid Operation");
            }

            Console.WriteLine(string.Join(" ", this.elements));
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
