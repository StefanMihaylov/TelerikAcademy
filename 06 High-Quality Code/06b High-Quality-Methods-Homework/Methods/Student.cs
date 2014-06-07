namespace Methods
{
    using System;

    public class Student
    {
        public Student(string firstName, string lastName, DateTime birthDate, SexEnum sex)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Sex = sex;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime BirthDate { get; private set; }

        public SexEnum Sex { get; private set; }

        public string City { get; set; }

        public string Hobby { get; set; }

        public bool IsOlderThan(Student otherStudent)
        {
            DateTime firstDate = this.BirthDate;
            DateTime secondDate = otherStudent.BirthDate;
            return firstDate > secondDate;
        }
    }
}
