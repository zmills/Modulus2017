/*****************************************************************************/
/*                               StudentUnitTests                            */
/*          This class test each unit of work in the Student class.          */
/*                                                                           */
/*****************************************************************************/
using EaglesNestMobileApp.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EaglesNestMobileApp.UnitTests
{
    [TestClass]
    public class StudentTests
    {
        /*********************************************************************/
        /*          Test what happens when the full name is valid            */
        /*********************************************************************/
        [TestMethod]
        public void FullNameTestValid()
        {
            /* Arrange                                                       */
            Student student = new Student();
            student.FirstName = "Zachary";
            student.LastName = "Mills";
            student.MiddleName = "Nathanial";

            String expected = "Mills, Zachary Nathanial";

            /* Act                                                           */
            string actual = student.FullName;

            /* Assert                                                        */
            Assert.AreEqual(expected, actual);
        }

        /*********************************************************************/
        /*          Test what happens when the first name is empty           */
        /*********************************************************************/
        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            /* Arrange                                                       */
            Student student = new Student();
            student.MiddleName = "Nathanial";
            student.LastName = "Mills";
            string expected = "Mills, Nathanial";

            /* Act                                                           */
            string actual = student.FullName;

            /* Assert                                                        */
            Assert.AreEqual(expected, actual);
        }

        /*********************************************************************/
        /*          Test what happens when the last name is empty            */
        /*********************************************************************/
        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            /* Arrange                                                       */
            Student student = new Student();
            student.FirstName = "Zachary";
            student.MiddleName = "Nathanial";
            string expected = "Zachary Nathanial";

            /* Act                                                           */
            string actual = student.FullName;

            /* Assert                                                        */
            Assert.AreEqual(expected, actual);
        }

        /*********************************************************************/
        /*          Test what happens when the middle name is empty          */
        /*********************************************************************/
        [TestMethod]
        public void FullNameMiddleNameEmpty()
        {
            /* Arrange                                                       */
            Student student = new Student();
            student.FirstName = "Zachary";
            student.LastName = "Mills";
            string expected = "Mills, Zachary";

            /* Act                                                           */
            string actual = student.FullName;

            /* Assert                                                        */
            Assert.AreEqual(expected, actual);
        }

        /*********************************************************************/
        /*          Test what happens when full name is first name only      */
        /*********************************************************************/
        [TestMethod]
        public void FullNameFirstNameOnly()
        {
            /* Arrange                                                       */
            Student student = new Student();
            student.FirstName = "Zachary";
            string expected = "Zachary";

            /* Act                                                           */
            string actual = student.FullName;

            /* Assert                                                        */
            Assert.AreEqual(expected, actual);
        }

        /*********************************************************************/
        /*          Test what happens when full name is middle name only     */
        /*********************************************************************/
        [TestMethod]
        public void FullNameMiddleNameOnly()
        {
            /* Arrange                                                       */
            Student student = new Student();
            student.MiddleName = "Nathanial";
            string expected = "Nathanial";

            /* Act                                                           */
            string actual = student.FullName;

            /* Assert                                                        */
            Assert.AreEqual(expected, actual);
        }

        /*********************************************************************/
        /*          Test what happens when full name is last name only       */
        /*********************************************************************/
        [TestMethod]
        public void FullNameLastNameOnly()
        {
            /* Arrange                                                       */
            Student student = new Student();
            student.LastName = "Mills";
            string expected = "Mills";

            /* Act                                                           */
            string actual = student.FullName;

            /* Assert                                                        */
            Assert.AreEqual(expected, actual);
        }
    }
}
