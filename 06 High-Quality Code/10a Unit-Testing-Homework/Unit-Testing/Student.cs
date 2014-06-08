namespace Unit_Testing
{
    using System;

    public class Student
    {
        public const int MinStudentID = 10000;
        public const int MaxStudentID = 99999;

        private string name;
        private int id;

        public Student(string name, int id)
        {
            this.Name = name;
            this.ID = id;
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
                    throw new ArgumentNullException("Student name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value < MinStudentID || value > MaxStudentID)
                {
                    throw new ArgumentException(string.Format("Student ID should be in range [{0}...{1}]", MinStudentID, MaxStudentID));
                }

                this.id = value;
            }
        }
    }
}
