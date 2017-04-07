using EaglesNestMobileApp.Core.Model.Personal;
using System;
using System.Collections.ObjectModel;

namespace EaglesNestMobileApp.Core.Model
{
    public class Course
    {
        public string Version { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string Id { get; set; }
        public string CourseCode { get; set; }
        public string StudentId { get; set; }
        public string CourseName { get; set; }
        public string SectionNumber { get; set; }
        public string EnrollmentGrade { get; set; }
        public string ProfessorTitle { get; set; }
        public string ProfessorFirstName { get; set; }
        public string ProfessorLastName { get; set; }
        public string ProfessorEmail { get; set; }
        public string Location { get; set; }
        public string ExamEndTime { get; set; }
        public string ExamBeginTime { get; set; }
        public string ExamType { get; set; }
        public string ExamDate { get; set; }
        public string FormattedCourseCode { get { return $"{CourseCode}-{SectionNumber}"; } }
        public string ExamTime { get { return $"{ExamBeginTime}-{ExamEndTime}"; } }
       
        public string Absences { get { return AttendanceViolations[0].Count.ToString(); } }
        public string PendingAbsences { get { return AttendanceViolations[1].Count.ToString(); } }
        public string Tardies { get { return AttendanceViolations[2].Count.ToString(); } }
        public string PendingTardies { get { return AttendanceViolations[3].Count.ToString(); } }

        public string GetFullCourseName
        {
            get { return $"{CourseCode}-{SectionNumber} {CourseName}"; }
        }


        public ObservableCollection<ObservableCollection<AttendanceViolation>> AttendanceViolations = 
            new ObservableCollection<ObservableCollection<AttendanceViolation>>
        {
            new ObservableCollection<AttendanceViolation>(),
            new ObservableCollection<AttendanceViolation>(),
            new ObservableCollection<AttendanceViolation>(),
            new ObservableCollection<AttendanceViolation>()
        };
    }
}