

namespace StudentAndWorker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Test
    {
        static void Main()
        {
            // students test
            var students = new List<Student>
            {
                new Student("Ivan", "Petrov", 6),
                new Student("Peter", "Ivanov", 4),
                new Student("Jordan", "Dimitrov", 5),
                new Student("Ralica", "Vitkova", 6),
                new Student("Penka", "Mihaylova", 5),
                new Student("Hassan", "Mummun", 2),
                new Student("Ali", "Raza", 3),
                new Student("Sylvia", "Malinova",4),
                new Student("Nikolay", "Natzkov", 3),
                new Student("Boyan", "Bonev", 6),
            };

            var sortedStudents = students.OrderBy(st => st.Grade).ThenBy(st => st.FirstName);
            Console.WriteLine("Students sorted by grade:");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine("  {0}",student);
            }
            Console.WriteLine(new string('-', 40));


            // workers test
            var workers = new List<Worker>
            {
                new Worker("Ivan", "Vasilev", 200,8),
                new Worker("Vasil", "Ivanov", 250,8),
                new Worker("Dimitar", "Jordanov", 100,8),
                new Worker("Ralica", "Dimitrova", 200,8),
                new Worker("Penka", "Mihaylova", 300,8),
                new Worker("Hassan", "Mehmed", 150,8),
                new Worker("Sherbet", "Tekin", 300,8),
                new Worker("Sylvia", "Velitchkova",280,8),
                new Worker("Nikolay", "Lekov", 340,8),
                new Worker("Georgi", "Genov", 400,8),
            };

            var sortedWorkers = workers.OrderByDescending(w => w.MoneyPerHour()).ThenBy(w => w.FirstName);
            Console.WriteLine("Workers sorted by hour salary:");
            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine("  {0}",worker);
            }
            Console.WriteLine(new string('-', 40));

            // merged list
            List<Human> studentsAndWorkers = new List<Human>();
            studentsAndWorkers.AddRange(students);
            studentsAndWorkers.AddRange(workers);

            Console.WriteLine("Humans sorted by name:");
            var sortedHumans = studentsAndWorkers.OrderBy(h => h.FirstName).ThenBy(h => h.LastName);
            foreach (var human in sortedHumans)
            {
                Console.WriteLine("  {0}",human);
            }
        }
    }
}
