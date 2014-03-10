namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Class : ICommentable
    {
        private string identifier;
        private ICollection<Student> students;
        private ICollection<Teacher> teachers;
        public string Comment { get; set; }

        // constructors
        public Class(string identifier, ICollection<Student> students, ICollection<Teacher> teachers, string comment)
        {
            this.Identifier = identifier;
            this.Students = students;
            this.Teachers = teachers;
            this.Comment = comment;
        }

        public Class(string identifier, ICollection<Student> students, ICollection<Teacher> teachers)
            : this(identifier, students, teachers, null)
        {

        }

        // properties
        public string Identifier
        {
            get { return this.identifier; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Class identifier should not be null or empty");
                }
                this.identifier = value;
            }
        }

        public ICollection<Student> Students
        {
            get { return this.students; }
            private set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("Set of students should not be null or empty");
                }
                this.students = value;
            }
        }

        public ICollection<Teacher> Teachers
        {
            get { return this.teachers; }
            private set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("Set of teachers should not be null or empty");
                }
                this.teachers = value;
            }
        }

        // methods
        public void AddComment(string comment)
        {
            this.Comment = comment;
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentException("Student should not be null ");
            }
            this.Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (!this.Students.Contains(student))
            {
                throw new ArgumentException("Set of students doesn't contain student " + student.Name);
            }
            this.Students.Remove(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentException("Teacher should not be null ");
            }
            this.Teachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            if (!this.Teachers.Contains(teacher))
            {
                throw new ArgumentException("Set of teachers doesn't contain teacher " + teacher.Name);
            }
            this.Teachers.Remove(teacher);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat(" Class {0} \n", this.Identifier);
            result.AppendFormat(" Students:\n");
            foreach (var student in this.Students)
            {
                 result.AppendFormat(" \t{0}\n",student);
            }
            result.AppendFormat(" Teachers:\n");
            foreach (var teacher in this.Teachers)
            {
                result.AppendFormat("{0}\n", teacher);
            }
            result.Length--; // remove last new line symbol "\n"
            return result.ToString();
        }  
    }
}
