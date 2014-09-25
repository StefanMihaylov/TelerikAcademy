namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using StudentSystem.Data;
    using StudentSystem.Model;
    using System.Data.Entity;
    using StudentSystem.Data.Migrations;

    public class Program
    {
        public static void Main()
        {
            // Database.SetInitializer<StudentSystemDbCounext>(new DbInitializer()); // this don't work

            // you should change the model to seed some random data, or my configuration is wrong
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbCounext, Configuration>());

            using (var db = new StudentSystemDbCounext())
            {
                var newStudent = new Student()
                {
                    FirstName = "Peter",
                    LastName = "Petrov",
                    DateOfBirth = new DateTime(1990, 06, 23)
                };

                db.Students.Add(newStudent);
                db.SaveChanges();

                // print all students
                var savedStudents = db.Students;
                foreach (var student in savedStudents)
                {
                    Console.WriteLine("{0}: {1} {2} - {4} - {3} years old", 
                        student.StudentId, student.FirstName, student.LastName, 
                        DateTime.Now.Subtract(student.DateOfBirth).Days / 365,
                        student.Email != null? student.Email : "N/A");
                }
            }
        }
    }
}
