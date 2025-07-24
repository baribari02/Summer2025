using System;

namespace PracticeProblem
{
    internal class Person
    {
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public int? Age { get; }

        public Person(int id, string name, string email, int? age = null)
        {
            Id = id;
            Name = name;
            Email = email;
            Age = age;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Person person = (Person)obj;
            return Id == person.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override string ToString()
        {
            return $"{Name} ({Id}, {Email}{(Age.HasValue ? $", {Age}" : "")})";
        }
    }
}
