namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Teacher : Person
    {
        public ICollection<Discipline> Disciplines { get; set; }

        // constructor
        public Teacher(string name, ICollection<Discipline> disciplines)
            : base(name)
        {
            this.Disciplines = disciplines;
        }

        // methods
        public void AddDiscipline(Discipline discipline)
        {
            this.Disciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            this.Disciplines.Remove(discipline);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat(" Teacher name: {0} \n", this.Name);
            result.AppendLine(" Disciplines:");
            foreach (var discipline in this.Disciplines)
            {
                result.AppendFormat("\t{0}\n", discipline);
            }            
            result.Length--; // remove last new line symbol "\n"
            return result.ToString();
        }
    }
}
