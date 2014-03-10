namespace StudentSort
{
    using System;
    using System.Linq;
    using StudentsName;

    class SortStudents
    {
        //5. Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last	name in descending order. Rewrite the same with LINQ.

        static void Main()
        {
            // same as exercise 3 & 4
            Student[] students = new Student[10];

            students[0] = new Student("Ivan", "Vassilev", 20);
            students[1] = new Student("Peter", "Ivanov", 25);
            students[2] = new Student("Ivan", "Petrov", 29);
            students[3] = new Student("Angel", "Ivanov", 18);
            students[4] = new Student("Boris", "Jordanov", 17);
            students[5] = new Student("Hassan", "Mummun", 24);
            students[6] = new Student("Ani", "Salich", 19);
            students[7] = new Student("Emil", "Cholakov", 30);
            students[8] = new Student("Vassil", "Dellov", 22);
            students[9] = new Student("Dimitrii", "Mendeleev", 27);
            
            // using lambda
            var sortedStudents = students.OrderByDescending(st => st.FirstName).ThenByDescending(st => st.FamilyName);
            Console.WriteLine(" Sorted students using Lambda expressions:");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();


            // using LINQ
            sortedStudents = from student in students
                                 orderby student.FirstName descending, student.FamilyName descending
                                 select student;

            Console.WriteLine(" Sorted students using LINQ:");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
        }
    }
}
