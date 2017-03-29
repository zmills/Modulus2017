using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Model;
using EaglesNestMobileApp.Core.Model.Academics;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel
{
    public class GradesFragmentViewModel : ViewModelBase
    {
        /* The list of the student assignments */
        private ObservableCollection<Assignment> _assignments;
        public ObservableCollection<Assignment> Assignments
        {
            get { return _assignments; }
            private set { Set(() => Assignments, ref _assignments, value); }
        }
        /* The list of classes the student is taking */
        private ObservableCollection<Course> _classes;
        public ObservableCollection<Course> Classes
        {
            get { return _classes; }
            set { Set(() => Classes, ref _classes, value); }
        }
        /* Grade cards to be passed to the views */
        private ObservableCollection<GradeCard> _grades;
        public ObservableCollection<GradeCard> Grades
        {
            get { return _grades; }
            set { Set(() => Grades, ref _grades, value); }
        }
        /* Command to be binded to the refresh event in the view */
        private RelayCommand _refreshCommand;
        public RelayCommand RefreshCommand => _refreshCommand ??
            (_refreshCommand = new RelayCommand(async () => await RefreshGradesAsync()));
        /* Singleton instance of the database                    */
        private readonly IAzureService Database;
        public GradesFragmentViewModel(IAzureService database)
        {
            Database = database;
        }
        /* Refresh the grades pulling off of the remote db.                */
        /* There needs to be something that indicates to the user          */
        /* that the page is being refreshed like in a swipe refresh layout */
        public async Task RefreshGradesAsync()
        {
            try
            {
                /* Initialize the localDb if not already present and sync  */
                await Database.InitLocalStore();
                await Database.SyncAsync(pullData: true); //THIS MUST NOT BE CALLED SO FREQUENTLY
                                                          // MAYBE IT SHOULD BE CALLED ON CREATE ACTIVITY AND ON RESUME/RESTART KIND OF STUFF
                                                          // WE CAN PULL THE INDIVIDUAL PARTS ON THEIR OWN IF WE HAVE PERFORMANCE ISSUES
                                                          /* Get all the classes and assignments for the classes     */
                                                          /* Should we pass it the IDNUMBER or should that be added  */
                                                          /* into the Azure service?                                 */
                Classes = await Database.GetCoursesAsync();
                Assignments = await Database.GetAssignmentsAsync();
                /* Format the student gradeCards for the separate views    */
                GetGradeCards();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred in retrieving the grades:");
                Debug.WriteLine($"{ex.Message} in {ex.Source}");
            }
        }
        /* Add each assignment to the appropriate card                     */
        public void GetGradeCards()
        {
            Grades = new ObservableCollection<GradeCard>();
            foreach (var course in Classes)
            {
                GradeCard current = new GradeCard(course);
                foreach (var assignment in Assignments)
                {
                    if (assignment.CourseId == current.CourseId)
                        current.AddAssignment(assignment);
                }
                /* Sort the list of assignments based off of the most recently updated one */
                // current.ClassAssignments.Sort((x, y) => DateTimeOffset.Compare(x.UpdatedAt, y.UpdatedAt));
                Grades.Add(current);
            }
            /* Sort the classes based off of the most recently updated assignment           */
            // Grades.Sort((x, y) => DateTimeOffset.Compare(x.ClassAssignments[0].UpdatedAt, y.ClassAssignments[0].UpdatedAt));
        }

        public void InitializeVm()
        {
            Grades = new ObservableCollection<GradeCard>();
            for (int counter = 0; counter < 15; counter++)
            {
                GradeCard current = new GradeCard("CS 452 Software Engineering Project II");

                for (int index = 0; index < 4; index++)
                {
                    Assignment currentAssignment = new Assignment() { AssingmentName = "Quiz " + index };
                    current.AddAssignment(currentAssignment);
                }

                Grades.Add(current);
            }
        }
    }
}
