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
        private Student _currentUser = new Student();
        public Student CurrentUser
        {
            get { return _currentUser; }
            private set { Set(() => CurrentUser, ref _currentUser, value); }
        }

        /* Command to be binded to the refresh event in the view */
        private RelayCommand _logOutCommand;
        public RelayCommand LogOutCommand => _logOutCommand ??
            (_logOutCommand = new RelayCommand(async () => await LogoutAsync()));

        /* Singleton instance of the database                    */
        private readonly IAzureService Database;

        public StudentInfoFragmentViewModel(IAzureService database)
        {
            Database = database;
        }

        public async Task InitializeAsync()
        {
            CurrentUser = await Database.GetStudentAsync();
        }

        /*********************************************************************/
        /*                      Starts the main activity                     */
        /*********************************************************************/
        public async Task LogoutAsync()
        {
            await Database.PurgeDatabaseAsync();
            App.Locator.Navigator.NavigateTo(App.PageKeys.LoginPageKey);
        }
    }
}
