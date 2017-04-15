using EaglesNestMobileApp.Core.Contracts;
using GalaSoft.MvvmLight;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IAzureService Database;

        ViewModelLocator _locator = App.Locator;

        public MainViewModel(IAzureService database)
        {
            Database = database;
        }

        public async Task InitializeNewUserAsync()
        {
            // THIS SHOULD BE ANNOTHER SPLASH SCREEN"
            // _locator.Navigator.NavigateTo(App.PageKeys.LoadingPageKey);
            await Database.InitLocalStore();
            await Database.SyncAsync(pullData: true);
            //_locator.Events.Initialize();
            _locator.Navigator.NavigateTo(App.PageKeys.MainPageKey);
            await _locator.Events.InitializeAsync();
            //_locator.Grades.InitializeStatic();
            await _locator.Grades.InitializeAsync();
            await _locator.Exams.InitializeAsync();
            await _locator.StudentCourt.InitializeAsync();
            //_locator.Exams.InitializeStatic();
            await _locator.GrabAndGo.InitializeAsync();
            //_locator.GrabAndGo.InitializeVm();
            await _locator.StudentInfo.InitializeAsync();
            await _locator.Varsity.InitializeAsync();
            //_locator.Varsity.InitializeStatic();
            await _locator.FourWinds.InitializeAsync();
            //_locator.FourWinds.InitializeStatic();
            // _locator.Attendance.InitializeStatic();
            await _locator.Attendance.InitializeAsync();
            //_locator.StudentSchedule.InitializeStatic();
            await _locator.StudentSchedule.InitializeAsync();
        }

        public async Task InitializeLoggedInUserAsync()
        {
            // _locator.Navigator.NavigateTo(App.PageKeys.LoadingPageKey);
            await Database.InitExistingLocalStore();
            //_locator.Events.Initialize();
            _locator.Navigator.NavigateTo(App.PageKeys.MainPageKey);
            await _locator.Events.InitializeAsync();
            //_locator.Grades.InitializeStatic();
            await _locator.Grades.InitializeAsync();
            await _locator.Exams.InitializeAsync();
            await _locator.StudentCourt.InitializeAsync();

            //_locator.Exams.InitializeStatic();
            await _locator.GrabAndGo.InitializeAsync();
            //_locator.GrabAndGo.InitializeVm();
            await _locator.StudentInfo.InitializeAsync();
            await _locator.Varsity.InitializeAsync();
            //_locator.Varsity.InitializeStatic();
            await _locator.FourWinds.InitializeAsync();
            //_locator.FourWinds.InitializeStatic();
            // _locator.Attendance.InitializeStatic();
            await _locator.Attendance.InitializeAsync();
            //_locator.StudentSchedule.InitializeStatic();
            await _locator.StudentSchedule.InitializeAsync();
            await Database.SyncAsync(pullData: true);
        }

        /*********************************************************************/
        /*                      Starts the main activity                     */
        /*********************************************************************/
        public void LogoutAsync()
        {
            _locator.CheckLogin.Logout("USERNAME");
            ViewModelLocator.Cleanup();
            _locator.Navigator.NavigateTo(App.PageKeys.LoginPageKey);
        }

        public async Task Purge()
        {
            await Database.PurgeDatabaseAsync();
        }
    }
}