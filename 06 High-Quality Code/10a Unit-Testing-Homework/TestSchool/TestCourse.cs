namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Unit_Testing;

    [TestClass]
    public class TestCourse
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseNameCannotBeNull()
        {
            var course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseNameCannotBeEmpty()
        {
            var course = new Course(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseNameCannotBeWhiteSpace()
        {
            var course = new Course(" ");
        }

        [TestMethod]
        public void CourseNameCanBeValid()
        {
            var name = "HQC";
            var course = new Course(name);
            Assert.AreEqual(name, course.Name);
        }

        [TestMethod]
        public void CourseListIsInitialized()
        {
            var course = new Course("HQC");
            var students = course.Students;
            Assert.AreEqual(0, students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JoiningCourseStudentCannotBeNull()
        {
            var course = new Course("HQC");
            course.Join(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void JoiningCourseStudentAlreadyExist()
        {
            var course = new Course("HQC");
            var student = new Student("John", Student.MinStudentID);
            course.Join(student);
            course.Join(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CourseIsFull()
        {
            var course = new Course("HQC");
            Student student;
            for (int i = 0; i < Course.MaxStudentsInCourse; i++)
            {
                student = new Student("John", Student.MinStudentID + i);
                course.Join(student);
            }

            student = new Student("John", Student.MaxStudentID);
            course.Join(student);
        }

        [TestMethod]
        public void JoiningCourseStudentIsEnteredCorrectly()
        {
            var course = new Course("HQC");
            var student = new Student("John", Student.MaxStudentID);
            course.Join(student);
            Assert.AreEqual(1, course.Students.Count);
        }

        [TestMethod]
        public void JoiningCourseStudentsIsEnteredCorrectly()
        {
            var course = new Course("HQC");
            var numberOfStudents = Course.MaxStudentsInCourse / 2;
            Student student;

            for (int i = 0; i < numberOfStudents; i++)
            {
                student = new Student("John", Student.MinStudentID + i);
                course.Join(student);
            }

            student = new Student("John", Student.MaxStudentID);
            course.Join(student);
            Assert.AreEqual(numberOfStudents + 1, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LeavingCourseStudentCannotBeNull()
        {
            var course = new Course("HQC");
            course.Leave(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LeavingCourseStudentDoesNotExist()
        {
            var course = new Course("HQC");
            var student = new Student("John", Student.MinStudentID);
            course.Join(student);
            var newStudent = new Student("John", Student.MinStudentID + 1);
            course.Leave(newStudent);
        }

        [TestMethod]
        public void LeavingCourseStudentIsRemovedCorrectly()
        {
            var course = new Course("HQC");
            var student = new Student("John", Student.MinStudentID);
            var newStudent = new Student("John", Student.MinStudentID + 1);

            course.Join(student);
            course.Join(newStudent);
            course.Leave(student);

            Assert.AreEqual(1, course.Students.Count);
        }
    }
}
