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

namespace EaglesNestMobileApp.Core.ViewModel
{
    public class ViewModelLocator : ObservableObject
    {
        private LocalToken _user;
        public LocalToken User
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
            //SimpleIoc.Default.Register<AcademicsViewModel>(true);
            SimpleIoc.Default.Register<DiningFragmentsViewModel>();
            //SimpleIoc.Default.Register<AccountViewModel>(true);

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


        /* The following returns the sigleton instance of the service/         */
        /* viewmodel                                                           */
        public LoginActivityViewModel Login =>
           ServiceLocator.Current.GetInstance<LoginActivityViewModel>();
        public StudentInfoFragmentViewModel StudentInfo =>
           ServiceLocator.Current.GetInstance<StudentInfoFragmentViewModel>();
        public INavigationService Navigator =>
           ServiceLocator.Current.GetInstance<INavigationService>();
        public MainViewModel Main =>
            ServiceLocator.Current.GetInstance<MainViewModel>();
       
        public GradesFragmentViewModel Grades =>
            ServiceLocator.Current.GetInstance<GradesFragmentViewModel>();
        public DiningFragmentsViewModel Dining =>
            ServiceLocator.Current.GetInstance<DiningFragmentsViewModel>();
        public ExamSeceduleFragmentViewModel Exams =>
            ServiceLocator.Current.GetInstance<ExamSeceduleFragmentViewModel>();

        public static void Cleanup()
        {
            /* TODO Clear the ViewModels                                        */
        }
    }
}