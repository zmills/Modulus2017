using System.Collections.Generic;

namespace EaglesNestMobileApp.Core.Model.Academics
{
    public class ProfessorCard
    {
        public string ProfessorName { get; set; }
        public string CourseCode { get; set; }
        public string Office { get; set; }
        public string ProfessorEmail { get; set; }
        public List<ProfessorTimes> Times { get; set; }
    }
}
