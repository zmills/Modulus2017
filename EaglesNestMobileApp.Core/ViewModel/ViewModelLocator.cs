/*****************************************************************************/
/*                             ViewModelLocator                              */
/* This class handles the registration of all the services along with each   */
/* viewmodel. Accessors to singleton instances are also provided.            */
/*                                                                           */
/*****************************************************************************/

using EaglesNestMobileApp.Core.Model;
using EaglesNestMobileApp.Core.Services;
using EaglesNestMobileApp.Core.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using EaglesNestMobileApp.Core.ViewModel.AccountViewModels;
using EaglesNestMobileApp.Core.ViewModel.AcademicsViewModels;
using EaglesNestMobileApp.Core.ViewModel.DiningViewModels;
using EaglesNestMobileApp.Core.ViewModel.CampusLifeViewModels;
using System;

namespace EaglesNestMobileApp.Core.ViewModel
{
    public class ViewModelLocator : ObservableObject
    {
        private string _user = "";
        public string User
        {
            get { return _user; }
            set { Set(() => User, ref _user, value); }
        }
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            /* Register viewmodels here with any other services                 */
            /* REMEMBER THAT THE DIALOG SERVICE IS REGISTERED ALREADY           */
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginActivityViewModel>();
            SimpleIoc.Default.Register<IAzureService, AzureService>();
            SimpleIoc.Default.Register<StudentInfoFragmentViewModel>();
            SimpleIoc.Default.Register<EventsFragmentViewModel>();
            SimpleIoc.Default.Register<GradesFragmentViewModel>();
            SimpleIoc.Default.Register<VarsityFragmentViewModel>();
            SimpleIoc.Default.Register<FourWindsFragmentViewModel>();
            SimpleIoc.Default.Register<GrabAndGoFragmentViewModel>();
            SimpleIoc.Default.Register<ExamScheduleFragmentViewModel>();
            SimpleIoc.Default.Register<AttendanceFragmentViewModel>();
            SimpleIoc.Default.Register<ScheduleFragmentViewModel>();
            SimpleIoc.Default.Register<StudentCourtFragmentViewModel>();
        }

        /* This method is used by the AndroidApp class to register the Android */
        /*  navigation service                                                 */
        public static void
           RegisterNavigationService(INavigationService navigationService)
        {
            SimpleIoc.Default.Register(() => navigationService);
        }

        /* This method is used by the AndroidApp class to register the Android */
        /*  dialog service                                                     */
        public static void RegisterDialogService(IDialogService dialogService)
        {
            SimpleIoc.Default.Register(() => dialogService);
        }

        public static void RegisterGetPreferences(ICheckLogin loginService)
        {
            SimpleIoc.Default.Register(() => loginService);
        }

        public static void RegisterCustomDialogService(ICustomProgressDialog customDialogService)
        {
            SimpleIoc.Default.Register(() => customDialogService);
        }

        public static void UnregisterDialogService()
        {
            SimpleIoc.Default.Unregister<ICustomProgressDialog>();
        }
                                                        
        /* The following returns the sigleton instance of the service/         */
        /* viewmodel                                                           */
        public LoginActivityViewModel Login =>
           ServiceLocator.Current.GetInstance<LoginActivityViewModel>();

        public AnnouncementsFragmentViewModel Announcements =>
           ServiceLocator.Current.GetInstance<AnnouncementsFragmentViewModel>();

        public GradesFragmentViewModel Grades =>
        ServiceLocator.Current.GetInstance<GradesFragmentViewModel>();

        public EventsFragmentViewModel Events =>
        ServiceLocator.Current.GetInstance<EventsFragmentViewModel>();

        public StudentInfoFragmentViewModel StudentInfo =>
        ServiceLocator.Current.GetInstance<StudentInfoFragmentViewModel>();

        public StudentCourtFragmentViewModel StudentCourt =>
        ServiceLocator.Current.GetInstance<StudentCourtFragmentViewModel>();

        public GrabAndGoFragmentViewModel GrabAndGo =>
        ServiceLocator.Current.GetInstance<GrabAndGoFragmentViewModel>();

        public VarsityFragmentViewModel Varsity =>
        ServiceLocator.Current.GetInstance<VarsityFragmentViewModel>();

        public FourWindsFragmentViewModel FourWinds =>
        ServiceLocator.Current.GetInstance<FourWindsFragmentViewModel>();

        public ExamScheduleFragmentViewModel Exams =>
        ServiceLocator.Current.GetInstance<ExamScheduleFragmentViewModel>();

        public INavigationService Navigator =>
        ServiceLocator.Current.GetInstance<INavigationService>();

        public ICheckLogin CheckLogin =>
       ServiceLocator.Current.GetInstance<ICheckLogin>();

        public ICustomProgressDialog Dialog =>
       ServiceLocator.Current.GetInstance<ICustomProgressDialog>();

        public MainViewModel Main =>
        ServiceLocator.Current.GetInstance<MainViewModel>();

        public AttendanceFragmentViewModel Attendance =>
        ServiceLocator.Current.GetInstance<AttendanceFragmentViewModel>();

        public ScheduleFragmentViewModel StudentSchedule =>
        ServiceLocator.Current.GetInstance<ScheduleFragmentViewModel>();

        public static void Cleanup()
        {
            ViewModelLocator _locator = App.Locator;
            _locator.Attendance.Cleanup();
            _locator.Events.Cleanup();
            _locator.Exams.Cleanup();
            _locator.FourWinds.Cleanup();
            _locator.GrabAndGo.Cleanup();
            _locator.Grades.Cleanup();
            _locator.StudentInfo.Cleanup();
            _locator.StudentSchedule.Cleanup();
            _locator.Varsity.Cleanup();
            _locator.Login.Cleanup();
            UnregisterDialogService();
            SimpleIoc.Default.Unregister<AzureService>();
        }
    }
}