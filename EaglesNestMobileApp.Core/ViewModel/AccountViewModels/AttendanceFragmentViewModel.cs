using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Model;
using EaglesNestMobileApp.Core.Model.Personal;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel.AccountViewModels
{
    public class AttendanceFragmentViewModel
    {
        /* Absences, then tardies           */
        public List<Course> Classes = new List<Course>();

        public ObservableCollection<AttendanceCard> AttendanceCards =
            new ObservableCollection<AttendanceCard>();

        private List<ClassAttendance> Violations =
            new List<ClassAttendance>();

        readonly IAzureService Database;

        public AttendanceFragmentViewModel(IAzureService database)
        {
            Database = database;
        }

        public async Task InitializeAsync()
        {
            Classes = await Database.GetCoursesAsync();

            foreach (var course in Classes)
            {
                AttendanceCards.Add(new AttendanceCard
                {
                    CourseName = course.CourseName,
                    CourseId = course.Id
                });
            }


            Violations = await Database.GetAttendanceViolationsAsync();
            GetViolations();
        }

        private void GetViolations()
        {
            foreach (var violation in Violations)
            {
                switch (violation.ViolationType)
                {
                    /* List of absences           */
                    case App.ViolationTypes.Absence:
                        {
                            foreach (var course in AttendanceCards)
                            {
                                if (course.CourseId == violation.CourseId)
                                {
                                    course.AttendanceViolations[0].Add(violation);
                                    break;
                                }
                            }
                        }
                        break;

                    /* List of pending absences           */
                    case App.ViolationTypes.PendingAbsence:
                        {
                            foreach (var course in AttendanceCards)
                            {
                                if (course.CourseId == violation.CourseId)
                                {
                                    course.AttendanceViolations[1].Add(violation);
                                    break;
                                }
                            }
                        }
                        break;

                    /* List of tardies          */
                    case App.ViolationTypes.Tardy:
                        {
                            foreach (var course in AttendanceCards)
                            {
                                if (course.CourseId == violation.CourseId)
                                {
                                    course.AttendanceViolations[2].Add(violation);
                                    break;
                                }
                            }
                        }
                        break;

                    /* List of pending tardies           */
                    case App.ViolationTypes.PendingTardy:
                        {
                            foreach (var course in AttendanceCards)
                            {
                                if (course.CourseId == violation.CourseId)
                                {
                                    course.AttendanceViolations[3].Add(violation);
                                    break;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void InitializeStatic()
        {
            for (int count = 0; count < 5; count++)
            {
                Course current = new Course { Id = "1", CourseName = $"Class {count}" };
                Classes.Add(current);
            }

            for (int inner = 0; inner < 4; inner++)
            {
                ClassAttendance violation = new ClassAttendance { CourseId = "1", Date = "May 10", ViolationType = App.ViolationTypes.Absence };
                Violations.Add(violation);
            }

            for (int inner = 0; inner < 4; inner++)
            {
                ClassAttendance violation = new ClassAttendance { CourseId = "1", Date = "May 10", ViolationType = App.ViolationTypes.PendingAbsence };
                Violations.Add(violation);
            }

            for (int inner = 0; inner < 4; inner++)
            {
                ClassAttendance violation = new ClassAttendance { CourseId = "1", Date = "May 10", ViolationType = App.ViolationTypes.Tardy };
                Violations.Add(violation);
            }

            for (int inner = 0; inner < 4; inner++)
            {
                ClassAttendance violation = new ClassAttendance { CourseId = "1", Date = "May 10", ViolationType = App.ViolationTypes.PendingTardy };
                Violations.Add(violation);
            }
            GetViolations();
        }
    }
}
