namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;    
    using Unit_Testing;

    [TestClass]
    public class TestStudent
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentNameCannotBeNull()
        {
            var student = new Student(null, Student.MinStudentID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentNameCannotBeEmpty()
        {
            var student = new Student(string.Empty, Student.MinStudentID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentNameCannotBeWhiteSpace()
        {
            var student = new Student(" ", Student.MinStudentID);
        }

        [TestMethod]
        public void StudentNameCanBeValid()
        {
            var student = new Student("Pesho", Student.MinStudentID);
            Assert.AreEqual("Pesho", student.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentIDCannotBeLessThanZero()
        {
            var student = new Student("Pesho", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentIDCannotBeLessThanMinimal()
        {
            var student = new Student("Pesho", Student.MinStudentID - 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentIDCannotBeMoreThanMaximal()
        {
            var student = new Student("Pesho", Student.MaxStudentID + 1);
        }

        [TestMethod]
        public void StudentIDCannBeMinimal()
        {
            var student = new Student("Pesho", Student.MinStudentID);
            Assert.AreEqual(Student.MinStudentID, student.ID);
        }

        [TestMethod]
        public void StudentIDCannBeValid()
        {
            var testValue = ((Student.MaxStudentID - Student.MinStudentID) / 2) + Student.MinStudentID;
            var student = new Student("Pesho", testValue);
            Assert.AreEqual(testValue, student.ID);
        }

        [TestMethod]
        public void StudentIDCannBeMaximal()
        {
            var student = new Student("Pesho", Student.MaxStudentID);
            Assert.AreEqual(Student.MaxStudentID, student.ID);
        }
    }
}
