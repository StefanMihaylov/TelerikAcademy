namespace School
{
    public abstract class Person : ICommentable
    {
        private string name;
        public string Comment { get; set; }

        // constructors
        public Person(string name)
        {
            this.Name = name;
        }

        // property
        public string Name
        {
            get { return this.name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new System.ArgumentException("Name should not be null or empty");
                }
                this.name = value;
            }
        }

        // methods
        public void AddComment(string comment)
        {
            this.Comment = comment;
        }
    }
}
