namespace StudentsName
{
    using System;
    using System.Linq;

    class StudentsName
    {
        // 3. Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Use LINQ query operators.
        // 4. Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

        static void Main()
        {
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

            // Exercise 3
            var someStidents = from student in students
                               where student.FirstName.CompareTo(student.FamilyName) < 0
                               select student;

            Console.WriteLine(" Students whose first name is before its last name alphabetically:");
            foreach (var student in someStidents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();


            // Exercise 4 
            someStidents = from student in students
                           where student.Age >= 18 && student.Age <= 24
                           select student;

            Console.WriteLine(" First name and last name of all students with age between 18 and 24:");
            foreach (var student in someStidents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
        }
    }
}
