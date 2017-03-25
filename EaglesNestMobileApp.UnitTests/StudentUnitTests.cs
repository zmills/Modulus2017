using EaglesNestMobileApp.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EaglesNestMobileApp.UnitTests
{
    /// <summary>
    /// Summary description for StudentTests
    /// </summary>
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            /* Arrange */
            Student student = new Student();
            student.FirstName = "Zachary";
            student.LastName = "Mills";
            student.MiddleName = "Nathanial";

            String expected = "Mills, Zachary Nathanial";

            /* Act     */
            string actual = student.FullName;

            /* Assert  */
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            /* Arrange */
            Student student = new Student();
            student.MiddleName = "Nathanial";
            student.LastName = "Mills";
            string expected = "Mills, Nathanial";

            /* Act     */
            string actual = student.FullName;

            /* Assert  */
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            /* Arrange */
            Student student = new Student();
            student.FirstName = "Zachary";
            student.MiddleName = "Nathanial";
            string expected = "Zachary Nathanial";

            /* Act     */
            string actual = student.FullName;

            /* Assert  */
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameMiddleNameEmpty()
        {
            /* Arrange */
            Student student = new Student();
            student.FirstName = "Zachary";
            student.LastName = "Mills";
            string expected = "Mills, Zachary";

            /* Act     */
            string actual = student.FullName;

            /* Assert  */
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameFirstNameOnly()
        {
            /* Arrange */
            Student student = new Student();
            student.FirstName = "Zachary";
            string expected = "Zachary";

            /* Act     */
            string actual = student.FullName;

            /* Assert  */
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameMiddleNameOnly()
        {
            /* Arrange */
            Student student = new Student();
            student.MiddleName = "Nathanial";
            string expected = "Nathanial";

            /* Act     */
            string actual = student.FullName;

            /* Assert  */
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameLastNameOnly()
        {
            /* Arrange */
            Student student = new Student();
            student.LastName = "Mills";
            string expected = "Mills";

            /* Act     */
            string actual = student.FullName;

            /* Assert  */
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void ValidateValid()
        //{
        //    /* Arrange */
        //    var Student = new Student();
        //    Student.LastName = "Baggins";
        //    Student.EmailAddress = "fbaggins@hobbiton.me";

        //    /* Act     */
        //    var expected = true;

        //    /* Assert  */
        //    var actual = Student.Validate();

        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void ValidateMissingLastName()
        //{
        //    /* Arrange */
        //    var Student = new Student();
        //    Student.EmailAddress = "fbaggins@hobbiton.me";

        //    /* Act     */
        //    var expected = false;

        //    /* Assert  */
        //    var actual = Student.Validate();

        //    Assert.AreEqual(expected, actual);
        //}
    }
}
