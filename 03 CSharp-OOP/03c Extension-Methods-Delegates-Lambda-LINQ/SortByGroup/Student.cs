namespace SortByGroup
{
    class Student
    {
        public string FullName {get; private set;}
        public string GroupName { get; private set; }

        public Student(string name, string group)
        {
            this.FullName = name;
            this.GroupName = group;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Group: {1}", this.FullName, this.GroupName);
        }
    }
}
