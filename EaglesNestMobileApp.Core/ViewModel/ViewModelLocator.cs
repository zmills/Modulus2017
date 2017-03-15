/*****************************************************************************/
/*                             ViewModelLocator                              */
/* This class handles the registration of all the services along with each   */
/* viewmodel. Accessors to singleton instances are also provided.            */
/*                                                                           */
/*****************************************************************************/

using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace EaglesNestMobileApp.Core.ViewModel
{
   public class ViewModelLocator
   {
      public ViewModelLocator()
      {
         ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

         /* Register viewmodels here with any other services                 */
         /* REMEMBER THAT THE DIALOG SERVICE IS REGISTERED ALREADY           */
         SimpleIoc.Default.Register<MainViewModel>();
         SimpleIoc.Default.Register<LoginActivityViewModel>(true);
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
      public INavigationService Navigator =>
         ServiceLocator.Current.GetInstance<INavigationService>();
      public MainViewModel Main =>
         ServiceLocator.Current.GetInstance<MainViewModel>();

      public static void Cleanup()
      {
         /* TODO Clear the ViewModels                                        */
      }
   }
}