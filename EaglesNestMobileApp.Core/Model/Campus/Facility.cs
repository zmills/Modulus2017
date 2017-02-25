using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.Model
{
    public class Facility
    {
        public string Id { get; set; }
        public string BuildingId { get; set; }
        public string BuildingType { get; set; }
        public string DayOfWeek { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
    }
}
