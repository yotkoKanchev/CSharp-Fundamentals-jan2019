using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodString
{
    public class Box <T>
    {
        public T FirstElement { get; set; }
        public T SecondElement { get; set; }
        public List<T> Elements { get; set; } = new List<T>();

        public void SwapElements(int firstIndex, int secondIndex)
        {
            T temp = this.Elements[firstIndex];
            this.Elements[firstIndex] = this.Elements[secondIndex];
            this.Elements[secondIndex] = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var element in this.Elements)
            {
               sb.AppendLine($"{element.GetType()}: {element}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
