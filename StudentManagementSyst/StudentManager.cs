using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace StudentManagementSyst
{
    public class StudentManager
    {
        // სტუდენტების კოლექცია 
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public bool DeleteStudent(int id)
        {
            // LINQ გამოიყენება სტუდენტის მოსაძებნად
            var student = students.FirstOrDefault(s => s.ID == id);
            if (student != null)
            {
                students.Remove(student);
                return true;
            }
            return false;
        }




        public bool EditStudent(int id, string firstName, string lastName, double gpa, string gender)
        {
            var student = students.FirstOrDefault(s => s.ID == id);
            if (student != null)
            {
                student.FirstName = firstName;
                student.LastName = lastName;
                student.GPA = gpa;
                student.Gender = gender;
                return true;
            }
            return false;
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }



        // მონაცემების შენახვა ფაილში
        public void SaveToFile(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var student in students)
                {
                    writer.WriteLine($"{student.ID},{student.FirstName},{student.LastName},{student.GPA},{student.Gender}");
                }
            }
        }
        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 5 && int.TryParse(parts[0], out int id) && double.TryParse(parts[3], out double gpa))
                    {
                        AddStudent(new Student(id, parts[1], parts[2], gpa, parts[4]));
                    }
                }
            }
        }
        public List<Student> SearchByGPA(double minGPA)
        {
            return students
                .Where(s => s.GPA >= minGPA) // Where ფილტრავს სტუდენტებს GPA-ს მიხედვით
                .ToList();
        }


    }
}
