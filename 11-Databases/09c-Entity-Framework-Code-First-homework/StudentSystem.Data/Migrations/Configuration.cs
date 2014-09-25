namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using StudentSystem.Model;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbCounext>
    {
        private static Random random;
        private static readonly string[] names = new string[]
        { 
            // only males :)
            "Peter",
            "Ivan",
            "George",
            "Stefan",
            "Jordan",
            "Matrin",
            "Spas",
            "Boyan"
        };       

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentSystem.Data.StudentSystemDbCounext";

            random = new Random();
        }

        protected override void Seed(StudentSystemDbCounext context)
        {
            if (context.Students.Count() > 0)
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                context.Students.Add(this.GetRandomStudent());

                //TODO: Add some random courses. No time fror this Now !!!!!
            }

            context.SaveChanges();
        }

        private Student GetRandomStudent()
        {
            string firstName = this.GetRandomName(names);
            string lastName = this.GetRandomName(names) + "ov";

            return new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = GetRandomDate(1985, 1999),
                Email = char.ToLower(firstName[0]) + "." + lastName.ToLower() + "@gmail.com"
            };
        }

        private int GetRandomNumber(int from, int to)
        {
            return random.Next(from, to + 1);
        }

        private DateTime GetRandomDate(int yearFrom, int yearTo)
        {
            int year = this.GetRandomNumber(yearFrom, yearTo);
            int month = this.GetRandomNumber(1, 12);
            int day = this.GetRandomNumber(1, 31);

            return new DateTime(year, month, day);
        }

        private string GetRandomName(string[] names)
        {
            int namesCount = names.Length;
            int index = this.GetRandomNumber(0, namesCount - 1);
            return names[index];
        }
    }
}
