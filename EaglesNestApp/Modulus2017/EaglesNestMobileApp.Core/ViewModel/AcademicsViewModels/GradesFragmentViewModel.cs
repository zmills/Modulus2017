﻿using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Model;
using EaglesNestMobileApp.Core.Model.Academics;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

namespace EaglesNestMobileApp.Core.ViewModel
{
    public class GradesFragmentViewModel : ViewModelBase
    {
        /* The list of the student assignments */
        private List<Assignment> _assignments = new List<Assignment>();
        protected List<Assignment> Assignments
        {
            get { return _assignments; }
            private set { Set(() => Assignments, ref _assignments, value); }
        }

        /* The list of classes the student is taking */
        private List<Course> _classes = new List<Course>();
        protected List<Course> Classes
        {
            get { return _classes; }
            set { Set(() => Classes, ref _classes, value); }
        }

        private List<ProfessorTimes> _professorsHours = new List<ProfessorTimes>();
        protected List<ProfessorTimes> ProfessorsHours
        {
            get { return _professorsHours; }
            set { Set(() => ProfessorsHours, ref _professorsHours, value); }
        }

        /* Grade cards to be passed to the views */
        private ObservableCollection<GradeCard> _grades =
            new ObservableCollection<GradeCard>();

        public ObservableCollection<GradeCard> Grades
        {
            get { return _grades; }
            set { Set(() => Grades, ref _grades, value); }
        }
        /* Command to be binded to the refresh event in the view */
        private RelayCommand _refreshCommand;

        public RelayCommand RefreshCommand => _refreshCommand ??
            (_refreshCommand =
                new RelayCommand(async () => await RefreshGradesAsync()));

        /* Singleton instance of the database                    */
        private readonly IAzureService Database;

        public GradesFragmentViewModel(IAzureService database)
        {
            Database = database;
        }

        public async Task InitializeAsync()
        {
            Classes = await Database.GetCoursesAsync();

            ProfessorsHours = await Database.GetProfessorTimesAsync();

            Assignments = await Database.GetAssignmentsAsync();

            /* Sort the list of based off of the most recently updated one */
            Assignments.Sort
                (
                        (x, y) => x.AssignmentDate.CompareTo(y.AssignmentDate)
                );

            Assignments.Reverse();

            
            /* Format the student gradeCards for the separate views    */
            GetGradeCards();
        }

        /* Refresh the grades pulling off of the remote db.                */
        /* There needs to be something that indicates to the user          */
        /* that the page is being refreshed like in a swipe refresh layout */
        public async Task RefreshGradesAsync()
        {
            try
            {
                await Database.SyncAsync(pullData: true);

                Classes = await Database.GetCoursesAsync();

                Assignments = await Database.GetAssignmentsAsync();

                /* Sort the list of based off of the most recently updated one */
                Assignments.Sort
                    (
                        (x, y) => x.AssignmentDate.CompareTo(y.AssignmentDate)
                    );

                /* Format the student gradeCards for the separate views    */
                Grades.Clear();
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

            foreach (var course in Classes)
            {
                GradeCard current = new GradeCard(course);
                foreach (var assignment in Assignments)
                {
                    if (assignment.CourseId == current.CourseId)
                        current.AddAssignment(assignment);
                }

                foreach (var hour in ProfessorsHours)
                {
                    if (current.ProfessorId == hour.ProfessorId)
                        current.ProfessorsHours.Add(hour);

                    if (current.ProfessorsHours.Count == 2)
                        break;
                }
                Grades.Add(current);
            }

            var _tempGrades = 
                new ObservableCollection<GradeCard>(Grades.OrderByDescending(x => x.ClassAssignments[0].AssignmentDate));
            
            
            Grades.Clear();
            foreach (var item in _tempGrades)
                Grades.Add(item);
            /* Sort the classes based off of the most recently updated assignment           */
            //Grades.Sort((x, y) => DateTimeOffset.Compare(x.ClassAssignments[0].UpdatedAt, y.ClassAssignments[0].UpdatedAt));
        }


        public override void Cleanup()
        {
            Classes.Clear();
            Assignments.Clear();
            Grades.Clear();
            ProfessorsHours.Clear();
            base.Cleanup();
        }

        public void InitializeStatic()
        {
            Grades = new ObservableCollection<GradeCard>();
            for (int counter = 0; counter < 15; counter++)
            {
                GradeCard current = new GradeCard()
                {
                    CourseTitle = "CS 452 Software Engineering Project II",
                };

                for (int index = 0; index < 4; index++)
                {
                    Assignment currentAssignment = new Assignment()
                    {
                        AssignmentName = "Quiz " + index,
                        AssignmentDate = "4/12/2017",
                        GradeScore = "100"
                    };
                    current.AddAssignment(currentAssignment);
                }

                Grades.Add(current);
            }
        }
    }
}
