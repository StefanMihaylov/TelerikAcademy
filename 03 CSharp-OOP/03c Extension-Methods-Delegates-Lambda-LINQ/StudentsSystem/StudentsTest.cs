namespace StudentsSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsTest
    {
        static void Main()
        {
            List<Student> students = new List<Student>() 
            {
                new Student("Ivan", "Petrov", 123405, "029251212", "ivan@abv.bg", new List<int>() { 5, 5, 6, 5 }, 1),
                new Student("Peter", "Ivanov", 324105, "0325214521", "peter@mail.bg", new List<int>() { 2, 4, 3, 6 }, 2),
                new Student("Jordan", "Dimitrov", 251406, "07221551", "dancho@gmail.com", new List<int>() { 6, 6, 6, 3 }, 3),
                new Student("Ralica", "Vitkova", 987406, "02251485", "qka_pichka@abv.bg", new List<int>() { 4, 6, 4, 6 }, 2),
                new Student("Penka", "Mihaylova", 529107, "0899124578", "kaka_pena@hotmail.com", 
                    new List<int>() { 6, 6, 3, 4 }, 1),
                new Student("Hassan", "Mummun", 121206, "054124154", "h.mummun@abv.bg", new List<int>() { 3, 3, 3, 3 }, 3),
                new Student("Ali", "Raza", 333303, "0025322141255112", "bat_sali@abv.bg", new List<int>() { 2, 2, 3, 4 }, 2),
                new Student("Sylvia", "Malinova", 514802, "0854712345", "sliveto@mail.bg", new List<int>() { 3, 3, 5, 5 }, 1),
                new Student("Nikolay", "Natzkov", 215408, "025874587", "Kulio@abv.bg", new List<int>() { 4, 4, 4, 4 }, 2),
                new Student("Boyan", "Bonev", 714506, "022154741", "bonev@hotmail.com", new List<int>() { 6, 6, 6, 6 }, 3),
            };

            // Select only the students that are from group number 2
            // using LINQ
            var selectedStudents = from student in students
                                   where student.GroupNumber == 2
                                   orderby student.FirstName
                                   select student;
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Students that are from group number 2:");
            Console.WriteLine(new string('-', 40));
            foreach (var st in selectedStudents)
            {
                Console.WriteLine(st);
            }

            // using Lambda expressions
            selectedStudents = students.Where(st => st.GroupNumber == 2).OrderBy(st => st.FirstName);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Students that are from group number 2:");
            Console.WriteLine(new string('-', 40));
            foreach (var st in selectedStudents)
            {
                Console.WriteLine(st);
            }

            // Extract all students that have email in abv.bg. Use string methods and LINQ.
            selectedStudents = from student in students
                               where student.Email.EndsWith("abv.bg") // This will work if e-mail are entered correctly
                               orderby student.FirstName
                               select student;

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Students that have email in abv.bg:");
            Console.WriteLine(new string('-', 40));
            foreach (var st in selectedStudents)
            {
                Console.WriteLine(st);
            }

            // Extract all students with phones in Sofia. Use LINQ.
            selectedStudents = from student in students
                               where student.PhoneNumber.StartsWith("02")
                               orderby student.FirstName
                               select student;

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Students with phones in Sofia:");
            Console.WriteLine(new string('-', 40));
            foreach (var st in selectedStudents)
            {
                Console.WriteLine(st);
            }

            //  Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks.

            var someStudents = from student in students
                               where student.Marks.Contains(6)
                               orderby student.FirstName
                               select new
                               {
                                   FullName = student.FirstName + " " + student.LastName,
                                   Marks = student.Marks,
                               };

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Students that have at least one mark Excellent (6):");
            Console.WriteLine(new string('-', 40));
            foreach (var st in someStudents)
            {
                Console.Write(" Name: {0},  Marks: ", st.FullName);
                foreach (var mark in st.Marks)
                {
                    Console.Write("{0} ", mark);
                }
                Console.WriteLine();
            }

            // 14. Write down a similar program that extracts the students with exactly two marks "2". Use extension methods.
            selectedStudents = students.Where(s => s.Marks.FindAll(m => m == 2).Count == 2).OrderBy(s => s.FirstName);

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("students with exactly two marks \"2\":");
            Console.WriteLine(new string('-', 40));
            foreach (var st in selectedStudents)
            {
                Console.WriteLine(st);
            }

            // 15. Extract all Marks of the students that enrolled in 2006. 
            // (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).

            var someStudents2 = students.Where(st => st.FacNumber.ToString().Substring(4, 2) == "06").
                OrderBy(st => st.FirstName).
                Select(st => new { FullName = st.FirstName + " " + st.LastName, Marks = st.Marks, FN = st.FacNumber, });

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(" Marks of the students that enrolled in 2006:");
            Console.WriteLine(new string('-', 40));
            foreach (var st in someStudents2)
            {
                Console.Write(" Name: {0}, FN: {1}, Marks: ", st.FullName, st.FN);
                foreach (var mark in st.Marks)
                {
                    Console.Write("{0} ", mark);
                }
                Console.WriteLine();
            }
        }
    }
}
