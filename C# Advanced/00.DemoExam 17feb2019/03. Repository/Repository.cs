using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class Repository
    {
        private Dictionary<int,Person> people;

        private int id;
        private int count;

        public Dictionary<int,Person> People { get {return this.people; } set { this.people = value; } }

        public int Count { get { return this.count; } set { this.count = value; } }

        public Repository()
        {
            this.id = 0;
            this.people = new Dictionary<int, Person>();
        }


        public void Add(Person person)
        {
            this.people.Add(this.id, person);
            this.id += 1;
            this.count += 1;
        }

        public Person Get(int id)
        {
            return people.First(x => x.Key == id).Value;
        }

        public bool Update(int id, Person newPerson)
        {
            if (this.people.ContainsKey(id))
            {
                this.people[id] = newPerson;
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (this.people.ContainsKey(id))
            {
                this.people.Remove(id);
                this.count -= 1;
                return true;
            }

            return false;
        }

    }
}
