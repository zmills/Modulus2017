using Android.App;
using Android.OS;
using Android.Widget;
using EaglesNestMobileApp.Core;
using EaglesNestMobileApp.Core.ViewModel;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using JimBobBennett.MvvmLight.AppCompat;
using Microsoft.Practices.ServiceLocation;
using Microsoft.WindowsAzure.MobileServices;

namespace EaglesNestMobileApp.Android
{
    // This base class is a mashup of AppCompativity and Laurent's ActivityBase
    [Activity(Label = "Eaglesnest", MainLauncher = true, Icon = "@drawable/logo")]
    public class loginActivity : AppCompatActivityBase
    {
        // This locator MUST be called first so that navigation and dialog can be initialized
        public LoginActivityViewModel LoginviewModel => AndroidApp.Locator.Login;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            CurrentPlatform.Init();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.LoginLayout);

            // Bind views to the viewmodel
            EditText  _username = FindViewById<EditText>(Resource.Id.UserId);
            EditText  _password = FindViewById<EditText>(Resource.Id.Password);
            Button _loginButton = FindViewById<Button>(Resource.Id.LogInButton);

            LoginviewModel.CurrentUser.SetBinding(() => LoginviewModel.CurrentUser.Id, _username,
                                 () => _username.Text, BindingMode.TwoWay);

            LoginviewModel.CurrentUser.SetBinding(() => LoginviewModel.CurrentUser.Password, _password,
                                 () => _password.Text, BindingMode.TwoWay);

            // This command in the login viewmodel handles all the login logic
            _loginButton.SetCommand("Click", LoginviewModel.LoginCommand);
        }
    }
}