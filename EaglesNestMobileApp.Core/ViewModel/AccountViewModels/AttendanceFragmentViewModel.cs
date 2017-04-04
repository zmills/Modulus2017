using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Model;
using EaglesNestMobileApp.Core.Model.Personal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel.AccountViewModels
{
    public class AttendanceFragmentViewModel
    {
        /* Abscences, then tardies           */
        public ObservableCollection<Course> Classes = new ObservableCollection<Course>();

        private ObservableCollection<AttendanceViolation> Violations =
            new ObservableCollection<AttendanceViolation>();

        readonly IAzureService Database;

        public AttendanceFragmentViewModel(IAzureService database)
        {
            Database = database;
        }

        public async Task Initialize()
        {
            Classes = await Database.GetCoursesAsync();
            //Violations = await Database.GetAttendanceViolationsAsync();

            GetViolations(Violations);
        }

        private void GetViolations(ObservableCollection<AttendanceViolation> attendanceViolations)
        {
            foreach (var violation in attendanceViolations)
            {
                switch (violation.ViolationType)
                {
                    /* List of absences           */
                    case App.ViolationTypes.Absence:
                        {
                            foreach (var course in Classes)
                            {
                                if (course.Id == violation.CourseId)
                                    course.AttendanceViolations[0].Add(violation);
                            }
                        }
                        break;

                    /* List of pending absences           */
                    case App.ViolationTypes.PendingAbsence:
                        {
                            foreach (var course in Classes)
                            {
                                if (course.Id == violation.CourseId)
                                    course.AttendanceViolations[1].Add(violation);
                            }
                        }
                        break;

                    /* List of tardies          */
                    case App.ViolationTypes.Tardy:
                        {
                            foreach (var course in Classes)
                            {
                                if (course.Id == violation.CourseId)
                                    course.AttendanceViolations[2].Add(violation);
                            }
                        }
                        break;

                    /* List of pending tardies           */
                    case App.ViolationTypes.PendingTardy:
                        {
                            foreach (var course in Classes)
                            {
                                if (course.Id == violation.CourseId)
                                    course.AttendanceViolations[3].Add(violation);
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
                AttendanceViolation violation = new AttendanceViolation { CourseId = "1", Date = "May 10", ViolationType = App.ViolationTypes.Absence };
                Violations.Add(violation);
            }

            for (int inner = 0; inner < 4; inner++)
            {
                AttendanceViolation violation = new AttendanceViolation { CourseId = "1", Date = "May 10", ViolationType = App.ViolationTypes.PendingAbsence };
                Violations.Add(violation);
            }

            for (int inner = 0; inner < 4; inner++)
            {
                AttendanceViolation violation = new AttendanceViolation { CourseId = "1", Date = "May 10", ViolationType = App.ViolationTypes.Tardy };
                Violations.Add(violation);
            }

            for (int inner = 0; inner < 4; inner++)
            {
                AttendanceViolation violation = new AttendanceViolation { CourseId = "1", Date = "May 10", ViolationType = App.ViolationTypes.PendingTardy };
                Violations.Add(violation);
            }
            GetViolations(Violations);
        }
    }
}
