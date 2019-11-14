namespace P07.FoodShortage
{
    public class PersonFactory
    {
        public Person Create(string[] personArgs)
        {
            var name = personArgs[0];
            var age = int.Parse(personArgs[1]);
            Person person;

            if (personArgs.Length == 4)
            {
                var id = personArgs[2];
                var birthdate = personArgs[3];
                person = new Citizen(name, age, id, birthdate);
            }
            else
            {
                var group = personArgs[2];
                person = new Rebel(name, age, group);
            }

            return person;
        }
    }
}
