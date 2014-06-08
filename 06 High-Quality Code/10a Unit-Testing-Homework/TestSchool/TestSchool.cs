namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;    
    using Unit_Testing;

    [TestClass]
    public class TestSchool
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolNameCannotBeNull()
        {
            var school = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolNameCannotBeEmpty()
        {
            var school = new School(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolNameCannotBeWhiteSpace()
        {
            var school = new School(" ");
        }

        [TestMethod]
        public void SchoolNameCanBeValid()
        {
            var name = "John Atanasoff";
            var school = new School(name);
            Assert.AreEqual(name, school.Name);
        }

        [TestMethod]
        public void CourseListIsInitialized()
        {
            var school = new School("John Atanasoff");
            var courses = school.Courses;
            Assert.AreEqual(0, courses.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCourseNameCannotBeNull()
        {
            var school = new School("John Atanasoff");
            school.AddCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingCourseAlreadyExist()
        {
            var school = new School("John Atanasoff");
            school.AddCourse("HQC");
            school.AddCourse("HQC");
        }

        [TestMethod]
        public void CourseAddedEnteredCorrectly()
        {
            var school = new School("John Atanasoff");
            school.AddCourse("HQC");
            Assert.AreEqual(1, school.Courses.Count);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemovingCourseNameCannotBeNull()
        {
            var school = new School("John Atanasoff");
            school.RemoveCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemovingCourseDoesNotExist()
        {
            var school = new School("John Atanasoff");
            school.AddCourse("HQC");
            school.RemoveCourse("KPK");
        }

        [TestMethod]
        public void CourseIsRemovedCorrectly()
        {
            var school = new School("John Atanasoff");
            school.AddCourse("HQC");
            school.AddCourse("JS");
            school.RemoveCourse("HQC");

            Assert.AreEqual(1, school.Courses.Count);
        }
    }
}
