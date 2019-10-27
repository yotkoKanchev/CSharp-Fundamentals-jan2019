namespace P01ListyIterator
{
    using System;
    using System.Linq;

    public class StartUp
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

                if (command == "Move")
                {
                    Console.WriteLine(listyOperator.Move());
                }
                else if (command == "Print")
                {
                    try
                    {
                        listyOperator.Print();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(listyOperator.HasNext());
                }
            }
        }
    }
}
