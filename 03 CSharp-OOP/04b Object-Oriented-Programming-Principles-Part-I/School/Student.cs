namespace School
{
    public class Student : Person
    {
        private int classNumber;

        // consructors
        public Student(string name, int number)
            : base(name)
        {
            this.ClassNumber = number;
        }

        // property
        public int ClassNumber
        {
            get { return this.classNumber; }
            private set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("Sturent class number should not be smaller than zero");
                }
                this.classNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Class number: {1}",this.Name,this.ClassNumber);
        }
    }
}
