//*************************************************************************/
//*                             loginActivity                             */
//* This activity determines whether a user needs to login and refers him */
//* to the viewmodel associated with the login if he does need to login.  */
//* All logic and errors associated with logging in are handled in the    */
//* viewmodel (loginActivityViewModel.cs) in the PCL.                     */
//*                                                                       */
//*************************************************************************/
using Android.App;
using Android.OS;
using Android.Widget;
using EaglesNestMobileApp.Core.ViewModel;
using GalaSoft.MvvmLight.Helpers;
using JimBobBennett.MvvmLight.AppCompat;
using Microsoft.WindowsAzure.MobileServices;
namespace EaglesNestMobileApp.Android
{
   [Activity(Label = "Eaglesnest", MainLauncher = true, Icon = "@drawable/logo")]
   // This base class is a mashup of AppCompativity and Laurent's ActivityBase. It was taken from
   // Jim Bob Bennett's Nuget package.
   public class loginActivity : AppCompatActivityBase
   {
      // This locator MUST be called first so that navigation and dialog can be initialized, ie,
      // this using the LoginViewModel accessor registers the activities that can be navigated.
      public LoginActivityViewModel LoginViewModel => AndroidApp.Locator.Login;
      // Once this thing is created make sure we check for whether the user is already logged in
      // before we actually show him this layout. We can either use a different activity or 
      // wrap the contents of this activity in a huge IF STATEMENT
      protected override void OnCreate(Bundle bundle)
      {
         base.OnCreate(bundle);
         CurrentPlatform.Init();
         // Set our view from the "main" layout resource
         SetContentView(Resource.Layout.LoginLayout);
         // Bind views to the viewmodel
         EditText _username  = FindViewById<EditText>(Resource.Id.UserId);
         EditText _password  = FindViewById<EditText>(Resource.Id.Password);
         Button _loginButton = FindViewById<Button>(Resource.Id.LogInButton);
         // This binds the input from the user to the token in the login viewmodel
         LoginViewModel.CurrentUser.SetBinding(() => LoginViewModel.CurrentUser.Id, _username,
                              () => _username.Text, BindingMode.TwoWay);
         LoginViewModel.CurrentUser.SetBinding(() => LoginViewModel.CurrentUser.Password, _password,
                              () => _password.Text, BindingMode.TwoWay);
         // This command in the login viewmodel handles all the login logic
         _loginButton.SetCommand("Click", LoginViewModel.LoginCommand);
      }
   }
}