namespace StudentExercise
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Student : ICloneable, IComparable<Student>
    {
        // fields
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string permanentAddress;
        private string phoneNumber;
        private string email;
        private string course;

        // constructor
        public Student(string firstName, string middleName, string lastName, string ssn, string address, string phone,
            string email, string course, UniversityType university, FacultyType faculty, SpecialtyType specialty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.PermanentAddresss = address;
            this.PhoneNumber = phone;
            this.Email = email;
            this.Course = course;
            this.University = university;
            this.Faculty = faculty;
            this.Specialty = specialty;
        }

        // properties
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name cannot be empty");
                }
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Middle name cannot be empty");
                }
                this.middleName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last name cannot be empty");
                }
                this.lastName = value;
            }
        }

        public string SSN
        {
            get { return this.ssn; }
            set
            {
                string pattern = @"^\d{3}-?\d{2}-?\d{4}$"; // stackoverflow
                if (!Regex.IsMatch(value, pattern))
                {
                    throw new ArgumentNullException("SSN number does not match the pattern XXX-XX-XXXX");
                }
                this.ssn = value;
            }
        }

        public string PermanentAddresss
        {
            get { return this.permanentAddress; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The permanent address cannot be empty");
                }
                this.permanentAddress = value;
            }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set
            {
                string pattern = @"^[0-9\-\+]{8,15}$"; // stackoverflow
                if (!Regex.IsMatch(value, pattern))
                {
                    throw new ArgumentNullException("Phone number does not match the pattern 0771234567 or +0771234567");
                }
                this.phoneNumber = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"; // stackoverflow
                if (!Regex.IsMatch(value, pattern))
                {
                    throw new ArgumentNullException("Email address does not match the pattern 0771234567 or +0771234567");
                }
                this.email = value;
            }
        }

        public string Course
        {
            get { return this.course; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Course cannot be empty");
                }
                this.course = value;
            }
        }

        public SpecialtyType Specialty { get; private set; }

        public UniversityType University { get; private set; }

        public FacultyType Faculty { get; private set; }

        // methods
        public override bool Equals(object other)
        {
            if (other is Student)
            {
                Student otherStudent = other as Student;
                return (this.SSN == otherStudent.SSN) && (this.LastName == otherStudent.LastName) &&
                    (this.FirstName == otherStudent.FirstName);
            }
            return false;
        }

        public static bool operator ==(Student first, Student second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !first.Equals(second);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ ((int)(this.LastName[0]) * (int)(this.FirstName[0])); // I hope this works
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("Name: {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName));
            result.AppendLine(string.Format("SSN: {0}", this.SSN));
            result.AppendLine(string.Format("Address: {0}", this.PermanentAddresss));
            result.AppendLine(string.Format("Phone number: {0}", this.PhoneNumber));
            result.AppendLine(string.Format("Email: {0}", this.Email));
            result.AppendLine(string.Format("University: {0}, Faculty: {1}, Specialty: {2}",
                this.University, this.Faculty, this.Specialty));
            result.Append(string.Format("Course: {0}", this.Course));

            return result.ToString();
        }

        public object Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.PermanentAddresss, this.PhoneNumber, this.Email, this.Course, this.University, this.Faculty, this.Specialty);
        }

        public int CompareTo(Student other)
        {
            string nameFirst = this.FirstName + this.MiddleName + this.LastName;
            string nameSecond = other.FirstName + other.MiddleName + other.LastName;

            int nameCompare = nameFirst.CompareTo(nameSecond);
            if (nameCompare != 0)
            {
                return nameCompare;
            }
            else
            {
                uint number1 = SocialNumberConverter(this.SSN);
                uint number2 = SocialNumberConverter(other.SSN);
                return number1.CompareTo(number2);
            }
        }

        private uint SocialNumberConverter(string ssn)
        {
            string[] splittedNumber = ssn.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            string joinedNumber = string.Join("", splittedNumber);
            return uint.Parse(joinedNumber);
        }
    }
}
