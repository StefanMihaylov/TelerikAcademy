namespace StudentsSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Student
    {
        private string firstName;
        private string lastName;
        private int facNumber; //FN
        private string phone;
        private string email;
        private List<int> marks;
        private int groupNumber;

        public Student(string firstName, string lastName, int facNumber, 
            string phone,string email , List<int> marks, int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacNumber = facNumber;
            this.PhoneNumber = phone;
            this.Email = email;
            this.marks = marks;
            this.GroupNumber = groupNumber;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Firts name shouldn't be empty");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name shouldn't be empty");
                }
                this.lastName = value;
            }
        }

        public int FacNumber
        {
            get { return this.facNumber; }
            set
            {
                if (value <= 99999)
                {
                    throw new ArgumentException("Faculty number should be more than 5 digits");
                }
                this.facNumber = value;
            }
        }

        public string PhoneNumber
        {
            get { return this.phone; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Phone number shouldn't be empty");
                }
                this.phone = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email shouldn't be empty");
                }
                this.email = value;
            }
        }

        public List<int> Marks
        {
            get { return this.marks; }
        }

        public int GroupNumber
        {
            get { return this.groupNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Group number should be greather than zero");
                }
                this.groupNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat(" Name: {0} {1}, Facilty number: {2}, Group: {3} \n", 
                this.FirstName, this.LastName,this.FacNumber, this.groupNumber);
            result.AppendFormat(" Phone: {0}, E-mail: {1} \n", this.PhoneNumber, this.Email);
            result.Append(" Marks: ");
            foreach (var mark in this.Marks)
            {
                result.AppendFormat("{0} ",mark);
            }
            return result.ToString();
        }
    }
}
