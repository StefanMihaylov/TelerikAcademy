using System;

namespace StudentExercise
{
    class Test
    {
        static void Main()
        {
            Student student = new Student("Ivan", "Petrov", "Ivanov", "123-45-6789",
                "Sofia, ul.Nikolayko Pernik No12", "+359899445566", "ebacha@home.bg", "OOP",
                UniversityType.TechnicalUniversity, FacultyType.ComputerSystemsAndControl, SpecialtyType.ComputerSystems);

            Student student2 = new Student("Vassil", "Draganov", "Mihaylov", "987-45-6543",
                "Sofia, ul.Hanko Brat No54", "+35987456321", "vasildm@abv.bg", "HTML",
                UniversityType.SofiaUniversity, FacultyType.History, SpecialtyType.History);

            // student3 - same as "student" but with smaller SSN
            Student student3 = new Student("Ivan", "Petrov", "Ivanov", "123-45-6700",
                "Sofia, ul.Nikolayko Pernik No12", "+359899445566", "ebacha@home.bg", "OOP",
                UniversityType.TechnicalUniversity, FacultyType.ComputerSystemsAndControl, SpecialtyType.ComputerSystems);

            Student clonedStudent = (Student)student.Clone();

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(student2);
            Console.WriteLine();

            Console.WriteLine("student == clonedStudent: {0}",student == clonedStudent);
            Console.WriteLine("student > student2: {0}",student.CompareTo(student2) > 0 ? "Yes": "No");
            Console.WriteLine("student > student3: {0}", student.CompareTo(student3) > 0 ? "Yes" : "No");
            Console.WriteLine();
        }
    }
}
