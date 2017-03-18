//*************************************************************************/
//*                              AndroidApp                               */
//* This static class contains a reference to MVVMLight's viewmodel       */
//* locator IoC container. Android specific services can be registered in */
//* in here (DialogService or Toast). The Locator accessor in this class  */
//* must be called as soon as the application starts up since it is in    */
//* charge of configuring the navigation between ACTIVITIES.              */
//*                                                                       */
//*************************************************************************/

using EaglesNestMobileApp.Android.Views;
using EaglesNestMobileApp.Core.ViewModel;
using EaglesNestMobileApp.Core;
using JimBobBennett.MvvmLight.AppCompat;

namespace EaglesNestMobileApp.Android
{
   public static class AndroidApp
   {
      private static ViewModelLocator _locator;
      public static ViewModelLocator Locator
      {
         get
         {
            if (_locator == null)
            {
               /* The first initialization will also take care of the navigation       */
               /* service along with the dialog service. See the ViewModelLocator      */
               /* class in the PCL                                                     */
               AppCompatNavigationService _navigator = new AppCompatNavigationService();
               
               _navigator.Configure(App.PageKeys.MainPageKey, typeof(mainActivity));

               ViewModelLocator.RegisterNavigationService(_navigator);

               _locator = new ViewModelLocator();
            }

            return _locator;
         }
      }

   }
}
 