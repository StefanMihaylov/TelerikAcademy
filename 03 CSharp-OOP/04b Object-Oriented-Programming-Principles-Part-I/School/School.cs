namespace School
{
    using System;
    using System.Collections.Generic;
using System.Text;

    public class School
    {
        private ICollection<Class> classes;

        // constructor
        public School(ICollection<Class> classes)
        {
            this.Classes = classes;
        }

        // properties
        public ICollection<Class> Classes
        {
            get { return this.classes; }
            private set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("Set of classes should not be null or empty");
                }
                this.classes = value;
            }
        }

        // methods
        public void AddNewClass(Class newClass)
        {
            if (newClass == null)
            {
                throw new ArgumentException("Class should not be null ");
            }
            this.Classes.Add(newClass);
        }

        public void RemoveClass(Class oldClass)
        {
            if (!this.Classes.Contains(oldClass))
            {
                throw new ArgumentException("Set of classes doesn't contain class " + oldClass.Identifier);
            }
            this.Classes.Remove(oldClass);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(" School classes:");
            foreach (var schoolClass in this.Classes)
            {
                result.AppendLine(schoolClass.ToString());
                result.AppendLine();
            }
            return result.ToString();
        }
    }
}
