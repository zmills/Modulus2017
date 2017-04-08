//using System;
//using System.Text;
//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using EaglesNestMobileApp.Core.Model;
//using System.Collections.ObjectModel;
//using EaglesNestMobileApp.Core.Model.Academics;

//namespace EaglesNestMobileApp.UnitTests
//{
//    /// <summary>
//    /// Summary description for GradeCardUnitTests
//    /// </summary>
//    [TestClass]
//    public class GradeCardUnitTests
//    {
//        [TestMethod]
//        public void GetCurrentGradeTest()
//        {
//            /* Arrange */
//            ObservableCollection<Assignment> classAssignments =
//            new ObservableCollection<Assignment>();
//            GradeCard gradeCard = new GradeCard();

//            var expected = "A";

//            var actual = gradeCard.CourseGrade;

//            Assert.AreEqual(expected, actual);

//        }
//    }
//}
