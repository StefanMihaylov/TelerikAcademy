namespace StudentsName
{
    public class Student
    {
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public uint Age { get; set; }

        public Student(string name, string family, uint age)
        {
            this.FirstName = name;
            this.FamilyName = family;
            this.Age = age;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} {1}, Age: {2}", this.FirstName, this.FamilyName, this.Age);
        }
    }
}
