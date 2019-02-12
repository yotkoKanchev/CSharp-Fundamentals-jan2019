using System;

namespace WorkshopCreateCustomList
{
    public class CustomList
    {
        private const int listCapacity = 2;

        private int[] items;

        public CustomList()
        {
            this.items = new int[listCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("Index can not be bigger or equal than the list count!");
                }
                return items[index];
            }

            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("Index can not be bigger or equal than the list count!");
                }
                items[index] = value;
            }
        }

        private void Resize()
        {
            int[] newArray = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                newArray[i] = this.items[i];
            }

            this.items = newArray;
        }

        public void Add(int item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public int RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid Index!");
            }

            var number = this.items[index];

            this.items[index] = 0;

            this.Shift(index);

            this.Count--;

            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return number;
        }

        private void Shrink()
        {
            int[] newArray = new int[this.items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.items[i];
            }

            this.items = newArray;
        }

        private void Shift(int index)
        {
            for(int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void ShiftToRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        public void Insert(int index, int element)
        {
            if (index > this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid Index!");
            }

            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.ShiftToRight(index);

            this.items[index] = element;
            this.Count++;
        }

        public bool Contains(int element)
        {
            foreach (var num in this.items)
            {
                if (num == element)
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= this.items.Length || secondIndex < 0 || secondIndex >= items.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid Index!");
            }
            else
            {
                var temp = this.items[firstIndex];
                this.items[firstIndex] = this.items[secondIndex];
                this.items[secondIndex] = temp;
            }
            
        }
    }
}
