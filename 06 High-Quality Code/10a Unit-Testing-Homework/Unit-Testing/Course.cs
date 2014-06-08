namespace Unit_Testing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Course
    {
        public const int MaxStudentsInCourse = 30;

        private string name;
        private ICollection<Student> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Course name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public ICollection<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public void Join(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Student joining the course cannot be null");
            }

            if (this.students.Any(st => st.ID == student.ID))
            {
                throw new ArgumentException("Student already attend that course");
            }

            if (this.students.Count >= MaxStudentsInCourse)
            {
                throw new ArgumentOutOfRangeException("Course is full");
            }

            this.students.Add(student);
        }

        public void Leave(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Student leaving the course cannot be null");
            }

            if (!this.students.Any(st => st.ID == student.ID))
            {
                throw new ArgumentException("Student leaving the course do not exist");
            }

            this.students.Remove(student);
        }
    }
}
