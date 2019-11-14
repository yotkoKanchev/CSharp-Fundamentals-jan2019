namespace P06.BirthdayCelebrations
{
    public class Citizen : IIdentyfiable, IMammal
    {
        private int age;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }
    }
}
