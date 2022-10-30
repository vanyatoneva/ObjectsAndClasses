using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            string input = Console.ReadLine();
            while(input != "End")
            {
                string[] personInfo = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                int index = personList.FindIndex(x=> x.Id == personInfo[1]);
                if(index == -1)
                {
                    Person person = new Person(personInfo[0], personInfo[1], int.Parse(personInfo[2]));
                    personList.Add(person);
                }
                else
                {
                    personList[index].ChangeInfo(personInfo[0], int.Parse(personInfo[2]));
                }
                input = Console.ReadLine();
            }
            foreach(Person person in personList.OrderBy(x=> x.Age))
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
    public class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public string Name { get; private set; }
        public string Id { get; private set; }
        public int Age { get; private set; }

        public void ChangeInfo(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public override string ToString()
        {
            return $"{this.Name} with ID: {this.Id} is {this.Age} years old.";
        }
    }
}
