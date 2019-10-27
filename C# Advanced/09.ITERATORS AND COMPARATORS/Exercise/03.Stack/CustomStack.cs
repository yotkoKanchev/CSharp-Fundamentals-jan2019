namespace P03Stack
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System;

    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> elements;

        public CustomStack()
        {
            this.elements = new List<T>();
        }
        public void Push(params T[] elements)
        {
            this.elements.AddRange(elements);
        }

        public void Pop()
        {
            if (this.elements.Any())
            {
                this.elements.RemoveAt(this.elements.Count - 1);
            }
            else
            {
                Console.WriteLine("No elements");
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 2; i++)
            {
                foreach (var element in this.elements)
                {
                    sb.AppendLine(element.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.elements.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
