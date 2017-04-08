using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EaglesNestMobileApp.Core.Model.Academics
{
    public class GradeCard : ObservableObject
    {
        private ObservableCollection<Assignment> _classAssignments = 
            new ObservableCollection<Assignment>();
        public ObservableCollection<Assignment> ClassAssignments
        {
            get { return _classAssignments; }
            private set { Set(() => ClassAssignments, ref _classAssignments, value); }
        }

        public string CourseTitle { get; set; }
        public string CourseGrade { get; set; }
        public string CourseId    { get; set; }
        public int AssignmentCount => ClassAssignments.Count;

        public GradeCard(Course section)
        {
            ClassAssignments = new ObservableCollection<Assignment>();
            CourseGrade = section.EnrollmentGrade;
            CourseTitle = section.GetFullCourseName;
            CourseId = section.Id;
        }

        public GradeCard() { }

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
