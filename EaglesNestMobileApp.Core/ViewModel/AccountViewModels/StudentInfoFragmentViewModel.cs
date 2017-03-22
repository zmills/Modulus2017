using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel.AccountViewModels
{
    public class StudentInfoFragmentViewModel : ViewModelBase
    {
        /* The list of the student assignments */
        private Student _currentUser;
        public Student CurrentUser
        {
            get { return _currentUser; }
            private set { Set(() => CurrentUser, ref _currentUser, value); }
        }

        /* Command to be binded to the refresh event in the view */
        private RelayCommand _refreshCommand;
        public RelayCommand RefreshCommand => _refreshCommand ??
            (_refreshCommand = new RelayCommand(async () => await RefreshAccountAsync()));

        /* Singleton instance of the database                    */
        private readonly IAzureService Database;

        public StudentInfoFragmentViewModel(IAzureService database)
        {
            Database = database;
        }

        public async Task RefreshAccountAsync()
        {
            /* Initialize the localDb if not already present and sync  */
            await Database.InitLocalStore();
            await Database.SyncAsync(pullData: true);


            /* Get the student info. SEE GETSTUDENT METHOD                                 */
            CurrentUser = await Database.GetStudentAsync();

        }
    }
}
