using System;

namespace EaglesNestMobileApp.Core.Model.Academics
{
    public class ProfessorTimes
    {
        public string Id { get; set; }
        public string ProfessorId { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Version { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
