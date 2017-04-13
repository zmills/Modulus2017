using EaglesNestMobileApp.Core.Contracts;
using GalaSoft.MvvmLight;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IAzureService Database;

        public MainViewModel(IAzureService database)
        {
            Database = database;
        }

        public async Task InitializeViewModels()
        {
            App.Locator.Navigator.NavigateTo(App.PageKeys.LoadingPageKey);
            await Database.SyncAsync(pullData: true);
            //App.Locator.Events.Initialize();
            App.Locator.Navigator.NavigateTo(App.PageKeys.MainPageKey);
            await App.Locator.Events.InitializeAsync();
            //App.Locator.Grades.InitializeStatic();
            await App.Locator.Grades.InitializeAsync();
            await App.Locator.Exams.Initialize();
            //App.Locator.Exams.InitializeStatic();
            await App.Locator.GrabAndGo.InitializeAsync();
            //App.Locator.GrabAndGo.InitializeVm();
            await App.Locator.StudentInfo.InitializeAsync();
            await App.Locator.Varsity.InitializeAsync();
            //App.Locator.Varsity.InitializeStatic();
            await App.Locator.FourWinds.InitializeAsync();
            //App.Locator.FourWinds.InitializeStatic();
            // App.Locator.Attendance.InitializeStatic();
            await App.Locator.Attendance.InitializeAsync();
            //App.Locator.StudentSchedule.InitializeStatic();
            await App.Locator.StudentSchedule.InitializeAsync();
        }

        /*********************************************************************/
        /*                      Starts the main activity                     */
        /*********************************************************************/
        public void Logout()
        {
            App.Locator.Navigator.NavigateTo(App.PageKeys.LoginPageKey);
        }
    }
}