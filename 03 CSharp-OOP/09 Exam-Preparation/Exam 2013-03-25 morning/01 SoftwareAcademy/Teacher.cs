using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        private string name;
        private IList<ICourse> courses;

        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Teacher name cannot be null");
                }
                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {

            if (course == null)
            {
               throw new ArgumentNullException("Teacher course cannot be null"); 
            }
            this.courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Teacher: Name={0}", this.Name);
            if (this.courses.Count > 0)
            {
                var courseNames = this.courses.Select(c => c.Name);
                result.Append("; Courses=[");
                result.Append(string.Join(", ", courseNames));
                result.Append("]");
            }
            return result.ToString();
        }
    }
}
