using System.Collections.ObjectModel;

namespace EaglesNestMobileApp.Core.Model.Personal
{
    public class AttendanceCard
    {
        public ObservableCollection<ObservableCollection<ClassAttendance>> AttendanceViolations =
            new ObservableCollection<ObservableCollection<ClassAttendance>>
        {
            new ObservableCollection<ClassAttendance>(),
            new ObservableCollection<ClassAttendance>(),
            new ObservableCollection<ClassAttendance>(),
            new ObservableCollection<ClassAttendance>()
        };

        public string Absences { get { return AttendanceViolations[0].Count.ToString(); } }
        public string PendingAbsences { get { return AttendanceViolations[1].Count.ToString(); } }
        public string Tardies { get { return AttendanceViolations[2].Count.ToString(); } }
        public string PendingTardies { get { return AttendanceViolations[3].Count.ToString(); } }

        public string CourseName { get; set; }
        public string CourseId { get; set; }
    }
}
