using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace EaglesNestMobileApp.Core.Model.Academics
{
    public class GradeCard : ObservableObject
    {
        private List<Assignment> _classAssignments;
        public List<Assignment> ClassAssignments
        {
            get { return _classAssignments; }
            private set { Set(() => ClassAssignments, ref _classAssignments, value); }
        }

        public string CourseTitle { get; private set; }
        public string CourseGrade { get; private set; }
        public string CourseId { get; private set; }
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
