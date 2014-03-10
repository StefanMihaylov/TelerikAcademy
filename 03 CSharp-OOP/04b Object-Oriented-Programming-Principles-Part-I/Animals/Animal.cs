namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Animal : ISound
    {
        // fields
        private int age;
        private string name;
        private string sex;

        // constructor
        public Animal(string name, int age, string sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        // properties
        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Animal age should be bigger than zero");
                }
                this.age = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Animal name should not be empty");
                }
                this.name = value;
            }
        }

        public string Sex
        {
            get { return this.sex; }
            private set
            {
                if (value != "male" && value != "female")
                {
                    throw new ArgumentException("Animal sex should be \"male\" or \"female\" only");
                }
                this.sex = value;
            }
        }

        // methods
        public abstract string ProduseSound();

        public override string ToString()
        {
            return string.Format("Animal: {0}, Name: {1}, Age: {2} years, Sex: {3}, Sound: {4}",
                GetType().Name, this.Name, this.Age, this.Sex, ProduseSound());
        }

        public static Dictionary<string,double> AverageAge(ICollection<Animal> animals)
        {
           return animals.GroupBy(an => an.GetType().Name).
                ToDictionary(an => an.Key, an => an.Average(anim => anim.Age));
        }
    }
}
