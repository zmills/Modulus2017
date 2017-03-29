namespace EaglesNestMobileApp.Core.Model
{
    public class Course
    {
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

        public string GetFullCourseName()
        {
            return $"{CourseCode}-{SectionNumber} {CourseName}";
        }
    }
}