using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsNum = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>(); 
            for(int i = 0; i < studentsNum; i++)
            {
                string[] currStudent = Console.ReadLine().
                    Split(" ", StringSplitOptions.RemoveEmptyEntries).
                    ToArray();
                Student student = new Student(currStudent[0], currStudent[1], double.Parse(currStudent[2]));
                students.Add(student);
            }
            foreach(Student student in students.OrderByDescending(x => x.Grade))
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
    public class Student
    {
        public Student() { }
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
        public override string ToString()
        {
            
            return $"{this.FirstName} {this.LastName}: {this.Grade:f2}";
        }
    }
}
