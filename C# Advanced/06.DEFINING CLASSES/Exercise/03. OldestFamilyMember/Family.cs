namespace DefiningClasses
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private List<Person> people;

        public List<Person> People
        {
            get { return this.people; }
            set { this.people = value; }
        } 

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.people.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
}
