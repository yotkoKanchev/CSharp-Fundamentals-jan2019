namespace P02Collection
{
    using System;
    using System.Linq;

    public class Collection
    {
        public static void Main()
        {
            var elements = Console.ReadLine().Split(' ').Skip(1).ToArray();

            var listyOperator = new ListyIterator<string>(elements);

            while (true)
            {
                var command = Console.ReadLine();

                if (command?.ToLower() == "end")
                {
                    break;
                }

                try
                {
                    if (command == "Move")
                    {
                        Console.WriteLine(listyOperator.Move());
                    }
                    else if (command == "Print")
                    {
                        listyOperator.Print();
                    }
                    else if (command == "HasNext")
                    {
                        Console.WriteLine(listyOperator.HasNext());
                    }
                    else if (command == "PrintAll")
                    {
                        listyOperator.PrintAll();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
