using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace EaglesNestMobileApp.Core.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////  REMEMBER THAT THE DIALOG SERVICE IS REGISTERED ALREADY
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginActivityViewModel>(true);
        }

        public static void RegisterNavigationService(INavigationService navigationService)
        {
            SimpleIoc.Default.Register(() => navigationService);
        }

        public static void RegisterDialogService(IDialogService dialogService)
        {
            SimpleIoc.Default.Register(() => dialogService);
        }


        // the following returns the current instance
        public LoginActivityViewModel Login => ServiceLocator.Current.GetInstance<LoginActivityViewModel>();
        public INavigationService Navigator => ServiceLocator.Current.GetInstance<INavigationService>();
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
      
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}