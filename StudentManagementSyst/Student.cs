using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSyst
{
    public class Student : Person
    {

        public int ID { get; set; }
        public double GPA { get; set; }
        public string Gender { get; set; }

        // Student კლასის კონსტრუქტორი რომელიც მშობელ კლას Person-საც იძახებს
        public Student(int id, string firstName, string lastName, double gpa, string gender)
            : base(firstName, lastName) // უკავშირდება მშობელ კლასს
        {
            ID = id;
            GPA = gpa;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {base.ToString()}, GPA: {GPA}, Gender: {Gender}";
        }

        


    }

}
