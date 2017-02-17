using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V7.Widget;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace classGradesNameSpace
{


   
    public class classGrades
    {
        private string assignmentName;
        private DateTime assignmentDate;
        private float assignmentGrade;

        public classGrades(string assignmentName, DateTime assignmentDate, float assignmentGrade)
        {
            this.assignmentName = assignmentName;
            this.assignmentDate = assignmentDate;
            this.assignmentGrade = assignmentGrade;
        }

        public string getAssignmentName { get; set; }
        public DateTime assignmentDare { get; set; }
        public float assignmentGrade { get; set; }
    }

    public class AssignmentList
    {
        static classGrades[] Scores =
        {
            new classGrades(HW1, 2/15/17, 680),
            new classGrades(HW2, 2,16,17, 67),
        };

        private classGrades[] mGrades;

        public AssignmentList()
        {
            mGrades = AssignmentList;
        }

        public int NumGrades
        {
            get { return mGrades.Length; }
        }

        public classGrades this[int i]
        {
            get { return mGrades[i]; }
        }
    }
}
