using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Model;
using GalaSoft.MvvmLight;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public async Task InitializeViewModels()
        {
            App.Locator.Events.Initialize();
            //App.Locator.Grades.InitializeStatic();
            await App.Locator.Grades.InitializeAsync();
            await App.Locator.Exams.Initialize();
            App.Locator.Exams.InitializeStatic();
            await App.Locator.GrabAndGo.InitializeAsync();
            //App.Locator.GrabAndGo.InitializeVm();
            await App.Locator.StudentInfo.InitializeAsync();
            await App.Locator.Varsity.InitializeAsync();
            App.Locator.Varsity.InitializeStatic();
            await App.Locator.FourWinds.InitializeAsync();
            //App.Locator.FourWinds.InitializeStatic();
            App.Locator.Attendance.InitializeStatic();
            App.Locator.StudentSchedule.InitializeStatic();
        }
    }
}