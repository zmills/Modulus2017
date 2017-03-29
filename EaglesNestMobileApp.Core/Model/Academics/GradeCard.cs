using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EaglesNestMobileApp.Core.Model.Academics
{
    public class GradeCard : ObservableObject
    {
        private ObservableCollection<Assignment> _classAssignments;
        public ObservableCollection<Assignment> ClassAssignments
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
            ClassAssignments = new ObservableCollection<Assignment>();
            CourseGrade = section.EnrollmentGrade;
            CourseTitle = section.GetFullCourseName();
            CourseId = section.Id;
        }

        public GradeCard(string courseTitle)
        {
            ClassAssignments = new ObservableCollection<Assignment>();
            this.CourseTitle = courseTitle;
        }

        public void AddAssignment(Assignment assignment)
        {
            ClassAssignments.Add(assignment);
        }

        public void AddAssignments(ObservableCollection<Assignment> assignments)
        {
            ClassAssignments = assignments;
        }

        public void ClearAssignments()
        {
            ClassAssignments.Clear();
        }
    }
}
