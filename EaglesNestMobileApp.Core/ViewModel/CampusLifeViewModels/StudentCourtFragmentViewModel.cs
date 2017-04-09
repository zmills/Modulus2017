using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Model.Campus;
using GalaSoft.MvvmLight;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel.CampusLifeViewModels
{
    public class StudentCourtFragmentViewModel : ViewModelBase
    {
        public OffenseCard StudentOffenseCard;

        readonly IAzureService Database;

        public StudentCourtFragmentViewModel(IAzureService database)
        {
            Database = database;
        }

        public async Task InitializeAsync()
        {
            var offenses = await Database.GetStudentCourtOffensesAsync();
            var categories = await Database.GetStudentCourtCategoriesAsync();
            var classes = await Database.GetCoursesAsync();

            StudentOffenseCard = new OffenseCard(offenses, categories, classes.Count.ToString());
        }
    }
}
