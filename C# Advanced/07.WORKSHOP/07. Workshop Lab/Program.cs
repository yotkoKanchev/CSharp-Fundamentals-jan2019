namespace CreateLinkedList
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();
                        
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);
            list.AddFirst(5);
            list.AddFirst(6);
            list.AddFirst(7);
            list.AddFirst(8);
            list.RemoveLast();
            list.RemoveFirst();
            list.ForEach(x => Console.WriteLine(2));

            var array = list.ToArray();

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(list.Count);
        }
    }
}
