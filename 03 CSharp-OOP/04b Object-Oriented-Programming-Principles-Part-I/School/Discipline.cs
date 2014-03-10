namespace School
{
    using System;

    public class Discipline : ICommentable
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;
        public string Comment{get; set;}

        // constructors

        public Discipline(string name, int lectures, int exercises, string comment)
        {
            this.Name = name;
            this.NumberOfLectures = lectures;
            this.NumberOfExercises = exercises;
            this.Comment = comment;
        }

        public Discipline(string name, int lectures, int exercises)
            : this(name, lectures, exercises, null)
        {

        }

        // properties
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Discipline name should not be null or empty");
                }
                this.name = value;
            }
        }

        public int NumberOfLectures
        {
            get { return this.numberOfLectures; }
            private set
            {
                if (value <=1)
                {
                    throw new ArgumentException("number of lectures should be bigger than one");
                }
                this.numberOfLectures = value;
            }
        }

        public int NumberOfExercises
        {
            get { return this.numberOfExercises; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("number of exercise should not be smaller than zero");
                }
                this.numberOfExercises = value;
            }
        }

        public void AddComment(string comment)
        {
            this.Comment = comment;
        }

        public override string ToString()
        {
            return String.Format(" {0}, {1} lectures, {2} exercises",
                this.Name,this.NumberOfLectures, this.NumberOfExercises);
        }
    }
}
