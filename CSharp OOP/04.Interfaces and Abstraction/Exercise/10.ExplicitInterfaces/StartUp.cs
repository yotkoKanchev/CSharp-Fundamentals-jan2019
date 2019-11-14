namespace P10.ExplicitInterfaces
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            while (true)
            {
                var personArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var name = personArgs[0];

                if (name?.ToLower() == "end")
                {
                    break;
                }

                var country = personArgs[1];
                var age = int.Parse(personArgs[2]);

                var person = new Citizen(name, country, age);

                Console.WriteLine(person.GetName());
                Console.WriteLine(((IPerson)person).GetName());
            }
        }
    }
}
