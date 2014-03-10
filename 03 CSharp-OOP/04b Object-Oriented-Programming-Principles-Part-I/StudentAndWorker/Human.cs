namespace StudentAndWorker
{
    public abstract class Human
    {
        // fields
        private string firstName;
        private string lastName;

        // constructor
        public Human(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }

        // properties
        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new System.ArgumentException("First name should not be null or empty");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new System.ArgumentException("Last name should not be null or empty");
                }
                this.lastName = value;
            }
        }

        // methods
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
