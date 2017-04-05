using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.Model.Personal
{
    public class AttendanceViolation
    {
        public string Version { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string Id {get; set;}
        public string CourseId { get; set; }
        public string ViolationType { get; set; } // PT, T, PA, A
        public string Date { get; set; }
    }
}
