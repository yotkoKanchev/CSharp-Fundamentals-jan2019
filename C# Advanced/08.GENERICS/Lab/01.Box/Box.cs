using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        public List<T> DataList { get; set; } = new List<T>();

        public int Count => this.DataList.Count;

        public void Add(T element)
        {
            this.DataList.Add(element);
        }

        public T Remove()
        {
            var element = DataList[this.Count - 1];
            this.DataList.RemoveAt(this.Count - 1);
            return element;
        }
    }
}
