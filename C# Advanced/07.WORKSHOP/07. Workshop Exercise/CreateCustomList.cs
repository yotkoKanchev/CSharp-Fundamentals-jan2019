namespace WorkshopCreateCustomList
{
    using System;

    public class CreateCustomList
    {
        public static void Main()
        {
            CustomList list = new CustomList();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);

            list.RemoveAt(7);

            list.Insert(1, 99);

            list.Swap(1, 10);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

        }
    }
}
