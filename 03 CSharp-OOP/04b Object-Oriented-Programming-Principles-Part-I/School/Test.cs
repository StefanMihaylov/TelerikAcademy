namespace School
{
    using System;

    public class Test
    {
        public static void Main()
        {
            // this test is get from the forum post and it is modified to fit to class names
            Student[] students1 = new Student[]
            {
                new Student("Kiril Nikolov", 1),
                new Student("Stamo Petkov", 2),
                new Student("Yordan Yordanov", 3),
                new Student("Boris Gutsev", 4),
                new Student("Martin Yankov", 5),
                new Student("Vladimir Georgiev", 6),
                new Student("Lina Ivanova", 7)
            };

            Student[] students2 = new Student[]
            {
                new Student("Mihail Petrov", 1),
                new Student("Lyubomir Yanchev", 2),
                new Student("Nikolay Alexiev", 3),
                new Student("Konstantin Dikov", 4),
                new Student("Dimitar Todorov", 5),
                new Student("Tsvetan Ivanov", 6),
                new Student("Victor Ivanov", 7)
            };

            Discipline[] donchoMinkovCourses = new Discipline[]
            {
                new Discipline("C# Fundamentals Part I", 8, 8),
                new Discipline("C# Fundamentals Part II", 8, 8),
                new Discipline("Object-Oriented Programming", 8, 8),
                new Discipline("JavaScript Part I", 8, 8)
            };

            Discipline[] nikolayKostovCourses = new Discipline[]
            {
                new Discipline("C# Fundamentals Part I", 10, 2),
                new Discipline("C# Fundamentals Part II", 5, 5),
                new Discipline("Object-Oriented Programming", 9, 9),
                new Discipline("ASP.NET MVC", 8, 8)
            };

            Discipline[] georgeGeorgievCourses = new Discipline[]
            {
                new Discipline("C# Fundamentals Part I", 10, 1),
                new Discipline("C# Fundamentals Part II", 5, 5),
                new Discipline("HTML5", 9, 9),
                new Discipline("CSS3", 8, 8)
            };

            Discipline[] svetlinNakovCourses = new Discipline[]
            {
                new Discipline("C# Fundamentals Part I", 10, 10),
                new Discipline("C# Fundamentals Part II", 18, 3),
                new Discipline("Object-Oriented Programming", 8, 1),
                new Discipline("Knowledge Sharing and Teamwork", 10, 0)
            };

            Teacher[] teachers1 = new Teacher[]
            {
                new Teacher("Doncho Minkov", donchoMinkovCourses),
                new Teacher("Nikolay Kostov", nikolayKostovCourses)
            };

            Teacher[] teachers2 = new Teacher[]
            {
                new Teacher("George Georgiev", georgeGeorgievCourses),
                new Teacher("Svetlin Nakov", svetlinNakovCourses)
            };

            Class[] schoolClasses = new Class[]
            {
                new Class("Ia", students1, teachers1),
                new Class("Ib", students2, teachers2)
            };

            School telerikAcademy = new School(schoolClasses);
            Console.Write(telerikAcademy);
        }
    }
}
