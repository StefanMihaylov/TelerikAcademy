namespace StudentSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using StudentSystem.Model;

    public class StudentSystemDbCounext : DbContext
    {
        public StudentSystemDbCounext()
            : base("StudentSystemDB")
        {
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homework { get; set; }
    }
}
