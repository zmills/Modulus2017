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

        public string GetFullCourseName()
        {
            return $"{CourseCode}-{SectionNumber} {CourseName}";
        }
    }
}