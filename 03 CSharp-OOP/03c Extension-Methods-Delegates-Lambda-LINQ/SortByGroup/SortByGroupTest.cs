namespace SortByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SortByGroupTest
    {
        // 18. Create a program that extracts all students grouped by GroupName and then prints them to the console. Use LINQ.
        // 19. Rewrite the previous using extension methods.

        static void Main()
        {
            List<Student> students = new List<Student>() 
            {
                new Student("Ivan Petrov", "Robin"),
                new Student("Peter Ivanov", "Dazzler"),
                new Student("Jordan Dimitrov", "Dazzler"),
                new Student("Ralica Vitkova", "Thor"),
                new Student("Penka Mihaylova", "Robin"),
                new Student("Hassan Mummun", "Dazzler"),
                new Student("Ali Raza", "Thor"),
                new Student("Sylvia Malinova", "Robin"),
                new Student("Nikolay Natzkov", "Thor"),
                new Student("Boyan Bonev", "Dazzler"),
            };

            // using LINQ
            var sortedByGroupLINQ = from student in students
                                    orderby student.FullName
                                    group student by student.GroupName into CurrentGroup
                                    orderby CurrentGroup.Key
                                    select CurrentGroup;
            foreach (var group in sortedByGroupLINQ)
            {
                Console.WriteLine("Group \"{0}\"", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine("   {0}", student.FullName);
                }
            }

            Console.WriteLine(new string('-', 40));

            // using extention methods
            var sortedByGroup = students.OrderBy(st=> st.FullName).GroupBy(st => st.GroupName).OrderBy(gr => gr.Key);
            foreach (var group in sortedByGroup)
            {
                Console.WriteLine("Group \"{0}\"", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine("   {0}", student.FullName);
                }
            }
        }
    }
}
