using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareAcademy
{
    public class Course : ICourse
    {
        private string name;
        private ITeacher teacher;
        private IList<string> topics;

        public Course(string name, ITeacher teacher = null)
        {
            this.Name = name;
            this.teacher = teacher;
            this.topics = new List<string>();
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
                    throw new ArgumentNullException("Course name cannot be null");
                }
                this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;
            }
            set
            {
                this.teacher = value;
            }
        }

        public void AddTopic(string topic)
        {
            if (string.IsNullOrEmpty(topic))
            {
                throw new ArgumentNullException("Course topic cannot be null");
            }
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{1}: Name={0}", this.Name,this.GetType().Name);

            if (this.teacher != null)
            {
                result.AppendFormat("; Teacher={0}",this.teacher.Name);
            }

            if (this.topics.Count > 0)
            {
                result.Append("; Topics=[");
                result.Append(string.Join(", ", this.topics));
                result.Append("]");
            }
            return result.ToString();
        }
    }
}
