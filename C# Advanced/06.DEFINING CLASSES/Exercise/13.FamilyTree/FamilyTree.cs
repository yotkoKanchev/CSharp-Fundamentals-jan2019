namespace _13.FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FamilyTree
    {
        static void Main(string[] args)
        {
            List<Person> familyTreePeople = new List<Person>();

            string personDetail = Console.ReadLine();

            string familyTreeDetails = Console.ReadLine();

            while (familyTreeDetails?.ToLower() != "end")
            {
                if (familyTreeDetails.Contains("-"))
                {
                    string[] details = familyTreeDetails.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                    Person parent = new Person();
                    Person child = new Person();

                    if (char.IsDigit(details[0][0]))
                    {
                        string parentBirthday = details[0];
                        if (char.IsDigit(details[1][0]))
                        {
                            string childBirthDay = details[1];
                            if (!familyTreePeople.Any(x => x.BirthDay == childBirthDay))
                            {
                                child.BirthDay = childBirthDay;
                                familyTreePeople.Add(child);
                            }

                            if (!familyTreePeople.Any(x => x.BirthDay == parentBirthday))
                            {
                                parent.BirthDay = parentBirthday;
                                familyTreePeople.Add(parent);
                            }

                            familyTreePeople.Find(x => x.BirthDay == parentBirthday).Children.Add(familyTreePeople.Find(x => x.BirthDay == childBirthDay));
                            familyTreePeople.Find(x => x.BirthDay == childBirthDay).Parents.Add(familyTreePeople.Find(x => x.BirthDay == parentBirthday));

                        }
                        else
                        {
                            string childName = details[1];

                            if (!familyTreePeople.Any(x => x.Name == childName))
                            {
                                child.Name = childName;
                                familyTreePeople.Add(child);
                            }

                            if (!familyTreePeople.Any(x => x.BirthDay == parentBirthday))
                            {
                                parent.BirthDay = parentBirthday;
                                familyTreePeople.Add(parent);
                            }

                            familyTreePeople.Find(x => x.BirthDay == parentBirthday).Children.Add(familyTreePeople.Find(x => x.Name == childName));
                            familyTreePeople.Find(x => x.Name == childName).Parents.Add(familyTreePeople.Find(x => x.BirthDay == parentBirthday));
                        }
                    }
                    else
                    {
                        string parentName = details[0];

                        if (char.IsDigit(details[1][0]))
                        {
                            String childBirthday = details[1];

                            if (!familyTreePeople.Any(x => x.BirthDay == childBirthday))
                            {
                                child.BirthDay = childBirthday;
                                familyTreePeople.Add(child);
                            }

                            if (!familyTreePeople.Any(x => x.Name == parentName))
                            {
                                parent.Name = parentName;
                                familyTreePeople.Add(parent);
                            }

                            familyTreePeople.Find(x => x.BirthDay == childBirthday).Parents.Add(familyTreePeople.Find(x => x.Name == parentName));
                            familyTreePeople.Find(x => x.Name == parentName).Children.Add(familyTreePeople.Find(x => x.BirthDay == childBirthday));
                        }
                        else
                        {
                            string childName = details[1];

                            if (!familyTreePeople.Any(x => x.Name == childName))
                            {
                                child.Name = childName;
                                familyTreePeople.Add(child);
                            }

                            if (!familyTreePeople.Any(x => x.Name == parentName))
                            {
                                parent.Name = parentName;
                                familyTreePeople.Add(parent);
                            }

                            familyTreePeople.Find(x => x.Name == childName).Parents.Add(familyTreePeople.Find(x => x.Name == parentName));
                            familyTreePeople.Find(x => x.Name == parentName).Children.Add(familyTreePeople.Find(x => x.Name == childName));
                        }
                    }
                }
                else
                {
                    string[] personDetails = familyTreeDetails.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string personName = personDetails[0] + " " + personDetails[1];
                    string personBirthDay = personDetails[2];
                                                           
                    if (familyTreePeople.Any(x => x.Name == personName))
                    {
                        familyTreePeople.Find(x => x.Name == personName).BirthDay = personBirthDay;
                    }

                    if (familyTreePeople.Any(x => x.BirthDay == personBirthDay) )
                    {
                        familyTreePeople.Find(x => x.BirthDay == personBirthDay).Name = personName;
                    }

                    if (!familyTreePeople.Any(x => x.Name == personName) && !familyTreePeople.Any(x => x.BirthDay == personBirthDay))
                    {
                        Person person = new Person();
                        person.Name = personName;
                        person.BirthDay = personBirthDay;
                        familyTreePeople.Add(person);
                    }
                }
                familyTreeDetails = Console.ReadLine();
            }

            Person mainPerson = null;

            if (char.IsDigit(personDetail[0]))
            {
                mainPerson = familyTreePeople.Find(x => x.BirthDay == personDetail);
            }
            else
            {
                mainPerson = familyTreePeople.Find(x => x.Name == personDetail);
            }

            familyTreePeople.Remove(mainPerson);

            if (familyTreePeople.Any(x => x.Name == mainPerson.Name && x.BirthDay == mainPerson.BirthDay))
            {
                Person samePerson = familyTreePeople.Find(x => x.Name == mainPerson.Name && x.BirthDay == mainPerson.BirthDay);
                if (mainPerson.Parents.Count == 0)
                {
                    foreach (var parent in samePerson.Parents)
                    {
                        mainPerson.Parents.Add(parent);
                    }
                }

                if (mainPerson.Children.Count == 0)
                {
                    foreach (var child in samePerson.Children)
                    {
                        mainPerson.Children.Add(child);
                    }
                }
            }
         
            Console.WriteLine($"{mainPerson.Name} {mainPerson.BirthDay}");
            Console.WriteLine("Parents:");
            foreach (var parent in mainPerson.Parents)
            {
                Console.WriteLine($"{parent.Name} {parent.BirthDay}");
            }
            Console.WriteLine("Children:");
            foreach (var child in mainPerson.Children)
            {
                Console.WriteLine($"{child.Name} {child.BirthDay}");
            }
        }
    }
}
