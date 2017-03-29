using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Model;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel.AcademicsViewModels
{
    public class ExamScheduleFragmentViewModel : ViewModelBase
    {
        private ObservableCollection<Course> _classes =
            new ObservableCollection<Course>();
        public ObservableCollection<Course> Classes
        {
            get { return _classes; }
            set { Set(() => Classes, ref _classes, value); }
        }

        private readonly IAzureService Database;

        public ExamScheduleFragmentViewModel(IAzureService database)
        {
            this.Database = database;
        }

        private async void Initialize()
        {
            await Task.Run(() => RefreshExamScheduleAsync());
        }

        public void InitializeVm()
        {
            for(int counter = 0; counter <= 6; counter++)
            {
                Course current = new Course
                {
                    CourseName = "Software Engineering",
                    CourseCode = "CS 451",
                    ExamDate = "May 10",
                    ExamBeginTime = "8:00am",
                    ExamEndTime = "9:00am",
                    Location = "AC 215",
                    SectionNumber = "1"
                };
                Classes.Add(current);
            }

        }

        private async void RefreshExamScheduleAsync()
        {
            Classes = await Database.GetCoursesAsync();
        }
    }
}
