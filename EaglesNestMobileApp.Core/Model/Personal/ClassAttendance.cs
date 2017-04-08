using System;

namespace EaglesNestMobileApp.Core.Model.Personal
{
    public class ClassAttendance
    {
        public string Version { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string Id { get; set; }
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public string ViolationType { get; set; } // PT, T, PA, A
        public string Date { get; set; }
    }
}