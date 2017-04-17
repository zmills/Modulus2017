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
        public string ProfessorId { get; set; }
        public string Office { get; set; }
        public string Location { get; set; }
        public string ExamEndTime { get; set; }
        public string ExamBeginTime { get; set; }
        public string ExamType { get; set; }
        public string ExamDate { get; set; }
        public string ExamDay { get; set; } // This is soley for sorting purposes
        public string FormattedCourseCode { get { return $"{CourseCode}-{SectionNumber}"; } }
        public string ExamTime { get { return $"{ExamBeginTime}-{ExamEndTime}"; } }
        
        public string GetFullCourseName
        {
            get { return $"{CourseCode}-{SectionNumber} {CourseName}"; }
        }

    }
}