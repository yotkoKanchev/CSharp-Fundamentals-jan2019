namespace _05.GenericCountMethodString
{
    using System;
    using System.Collections.Generic;

    public class Box<T> where T : IComparable<T>
    {
        public Box(List<T> elements)
        {
            this.Elements = elements;
        }

        public List<T> Elements { get; set; } = new List<T>();

        public int GetCount(T elementToCompareWith)
        {
            int counter = 0;

            foreach (var element in this.Elements)
            {
                if (element.CompareTo(elementToCompareWith) > 0 )
                {
                    counter++;
                }
            }

            return counter;
        }
    }    
}
