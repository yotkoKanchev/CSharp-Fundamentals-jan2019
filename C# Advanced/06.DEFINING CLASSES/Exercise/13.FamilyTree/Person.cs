using System.Collections.Generic;

namespace _13.FamilyTree
{
    public class Person
    {
        public string Name { get; set; }
        public string BirthDay { get; set; }
        public List<Person> Parents { get; set; } = new List<Person>();
        public List<Person> Children { get; set; } = new List<Person>();
    }
}
