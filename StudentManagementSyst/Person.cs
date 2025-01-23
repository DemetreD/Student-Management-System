using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSyst
{
    public class Person
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        //აბრუნებს სტუდენტის სრულ სახელს
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
