namespace P09.CollectionHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var word in words)
            {
                Console.Write(addCollection.Add(word) + " ");
            }
            Console.WriteLine();
            foreach (var word in words)
            {
                Console.Write(addRemoveCollection.Add(word) + " ");
            }
            Console.WriteLine();
            foreach (var word in words)
            {
                Console.Write(myList.Add(word) + " ");
            }
            Console.WriteLine();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                Console.Write(addRemoveCollection.Remove() + ' ');
            }

            Console.WriteLine();

            for (int i = 0; i < number; i++)
            {
                Console.Write(myList.Remove() + ' ');
            }
        }
    }
}
