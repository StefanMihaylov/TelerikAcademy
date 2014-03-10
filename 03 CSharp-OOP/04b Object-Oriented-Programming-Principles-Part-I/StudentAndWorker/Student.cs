namespace StudentAndWorker
{
    public class Student : Human
    {
        private int grade;  // whole number between 2 nad 6; 
        // grade can be double number between 2.0 and 6.0; or - integer between 0 nad 100


        // contructor
        public Student(string firts, string last, int grade)
            : base(firts, last)
        {
            this.Grade = grade;
        }

        // property
        public int Grade
        {
            get { return this.grade; }
            private set
            {
                if (value > 6 && value < 2)
                {
                    throw new System.ArgumentException("Grade should be number between 2 and 6");
                }
                this.grade = value;
            }
        }

        // methods
        public override string ToString()
        {
            return base.ToString() + " - Grade: "  + this.Grade;
        }
    }
}
