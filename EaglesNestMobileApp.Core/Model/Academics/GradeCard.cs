using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace EaglesNestMobileApp.Core.Model.Academics
{
    public class GradeCard : ObservableObject
    {
        public List<Assignment> ClassAssignments { get; set; }
        public string CourseTitle { get; set; }
        public string CourseGrade { get; set; }
        public string CourseId { get; set; }
        public int AssignmentCount => ClassAssignments.Count;

        public GradeCard(Course section)
        {
            ClassAssignments = new List<Assignment>();
            CourseGrade = section.EnrollmentGrade;
            CourseTitle = section.GetFullCourseName();
            CourseId = section.Id;
        }

        public void AddAssignment(Assignment assignment)
        {
            ClassAssignments.Add(assignment);
        }

        public void AddAssignments(List<Assignment> assignments)
        {
            ClassAssignments = assignments;
        }

        public void ClearAssignments()
        {
            ClassAssignments.Clear();
        }
    }
}
