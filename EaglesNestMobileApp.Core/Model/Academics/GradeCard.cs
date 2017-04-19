using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace EaglesNestMobileApp.Core.Model.Academics
{
    public class GradeCard : ObservableObject
    {
        private ObservableCollection<Assignment> _classAssignments =
            new ObservableCollection<Assignment>();
        public ObservableCollection<Assignment> ClassAssignments
        {
            get { return _classAssignments; }
            private set { Set(() => ClassAssignments, ref _classAssignments, value); }
        }

        private ObservableCollection<ProfessorTimes> _professorsHours = 
            new ObservableCollection<ProfessorTimes>();
        public ObservableCollection<ProfessorTimes> ProfessorsHours
        {
            get { return _professorsHours; }
            set { Set(() => ProfessorsHours, ref _professorsHours, value); }
        }

        public string CourseTitle { get; set; }
        public string CourseGrade { get { return GetCurrentGrade(); } }
        public string CourseId { get; set; }
        public string ProfessorName { get; set; }
        public string ProfessorEmail { get; set; }
        public string ProfessorId { get; set; }
        public string ProfessorOffice { get; set; }
        public int AssignmentCount => ClassAssignments.Count;

        public GradeCard(Course section)
        {
            ClassAssignments = new ObservableCollection<Assignment>();
            CourseTitle = section.GetFullCourseName;
            CourseId = section.Id;
            ProfessorName = $"{section.ProfessorTitle} " +
                $"{section.ProfessorFirstName} {section.ProfessorLastName}";
            ProfessorEmail = section.ProfessorEmail;
            ProfessorOffice = section.Office;
            ProfessorId = section.ProfessorId;
        }

        public GradeCard() { }

        public GradeCard(string courseTitle)
        {
            ClassAssignments = new ObservableCollection<Assignment>();
            this.CourseTitle = courseTitle;
        }

        public void AddAssignment(Assignment assignment)
        {
            ClassAssignments.Add(assignment);
        }

        public void AddAssignments(ObservableCollection<Assignment> assignments)
        {
            ClassAssignments = assignments;
        }

        public string GetCurrentGrade()
        {
            string currentGrade;
            float totalEarned = 0.00f,
                  totalPossible = 0.00f;

            /* Loop until assignment grades are totaled               */
            foreach (var assignment in ClassAssignments)
            {
                totalEarned += assignment.PointsEarned;
                totalPossible += assignment.PointsPossible;
            }

            /* Get the assignment grade average                       */
            float currentGradePercentage = (float)(totalEarned / totalPossible) * 100.0f;

            /* Assign the current letter grade                        */
            if (currentGradePercentage >= 97.5f)
                currentGrade = "A+";
            else if (currentGradePercentage >= 93.5f)
                currentGrade = "A";
            else if (currentGradePercentage >= 90.0f)
                currentGrade = "A-";
            else if (currentGradePercentage >= 87.5f)
                currentGrade = "B+";
            else if (currentGradePercentage >= 83.5f)
                currentGrade = "B";
            else if (currentGradePercentage >= 80.0f)
                currentGrade = "B-";
            else if (currentGradePercentage >= 77.5f)
                currentGrade = "C+";
            else if (currentGradePercentage >= 73.5f)
                currentGrade = "C";
            else if (currentGradePercentage >= 70.0f)
                currentGrade = "C-";
            else if (currentGradePercentage >= 67.5f)
                currentGrade = "D+";
            else if (currentGradePercentage >= 63.5f)
                currentGrade = "D";
            else if (currentGradePercentage >= 60.0f)
                currentGrade = "D-";
            else
                currentGrade = "F";

            return currentGrade;
        }

        public void ClearAssignments()
        {
            ClassAssignments.Clear();
        }
    }
}
