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
            //App.Locator.Announcements.Initialize();
            App.Locator.Events.Initialize();
            App.Locator.Grades.Initialize();
            await App.Locator.Exams.Initialize();
            await App.Locator.GrabAndGo.InitializeAsync();
            await App.Locator.StudentInfo.InitializeAsync();
            await App.Locator.Varsity.InitializeAsync();
            await App.Locator.FourWinds.InitializeAsync();
        }
    }
}