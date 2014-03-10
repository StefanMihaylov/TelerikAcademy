namespace PersonExercise
{
    using System;

    class Person
    {
        // fields
        private string name;
        private int? age;

        // constructor
        public Person(string inputName)
        {
            this.Name = inputName;
        }

        // properties
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public int? Age
        {
            get 
            {
                return this.age;
            }

            set
            {
                if (value != null && value < 0)
                {
                    throw new ArgumentNullException("Age cannot be smaller than zero");
                }
                this.age = value;
            }
        }

        // methods
        public override string ToString()
        {
            return string.Format("Name: {0}, Age: {1}", this.Name, this.Age==null?"Not specified":this.Age.ToString());
        }
    }
}
