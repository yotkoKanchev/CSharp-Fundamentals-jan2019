namespace P06EqualityLogic
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Person;

            if (other == null)
            {
                return false;
            }

            return this.Name.Equals(other.Name) && this.Age.Equals(other.Age);
        }

        public override int GetHashCode()
        {
            return string.Format("{0}_{1}", this.Name, this.Age).GetHashCode();
        }
    }
}
