using GalaSoft.MvvmLight;
using System;

namespace EaglesNestMobileApp.Core.Model
{
    public class Assignment : ObservableObject
    {
        public string Version { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string AssignmentName { get; set; }
        public string AssignmentDate { get; set; }
        //public DateTimeOffset AssignmentDate { get; set; }
        public string GradeScore { get; set; }
        public float PointsEarned { get; set; }
        public float PointsPossible { get; set; }
        public string StudentId { get; set; }
        public string FormattedAssignmentDate => AssignmentDate.ToString();
    }
}
