using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Model;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel.AcademicsViewModels
{
    public class ExamSeceduleFragmentViewModel : ViewModelBase
    {
        private ObservableCollection<Course> _classes;
        public ObservableCollection<Course> Classes
        {
            get { return _classes; }
            set { Set(() => Classes, ref _classes, value); }
        }

        private readonly IAzureService Database;

        public ExamSeceduleFragmentViewModel(IAzureService database)
        {
            this.Database = database;
        }

        public async void Initialize()
        {
            await Task.Run(() => RefreshExamScheduleAsync());
        }

        private async void RefreshExamScheduleAsync()
        {
            Classes = await Database.GetCoursesAsync();
        }
    }
}
