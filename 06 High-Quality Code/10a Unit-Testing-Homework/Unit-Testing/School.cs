namespace Unit_Testing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        private string name;
        private ICollection<Course> courses;

        public School(string name)
        {
            this.Name = name;
            this.courses = new List<Course>();
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

        public ICollection<Course> Courses
        {
            get
            {
                return new List<Course>(this.courses);
            }
        }

        public void AddCourse(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Course name cannot be null or empty");
            }           

            if (this.courses.Any(c => c.Name == name))
            {
                throw new ArgumentException("Course already exist");
            }

            var course = new Course(name);
            this.courses.Add(course);
        }

        public void RemoveCourse(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Course name cannot be null or empty");
            }

            if (!this.courses.Any(c => c.Name == name))
            {
                throw new ArgumentException("Course do not exist");
            }

            var course = this.courses.First<Course>(c => c.Name == name);
            this.courses.Remove(course);
        }
    }
}
