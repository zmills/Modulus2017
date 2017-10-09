
using Android.App;
using Android.Content.PM;
using Android.OS;
using EaglesNestMobileApp.Android.Helpers;
using EaglesNestMobileApp.Core;
using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.ViewModel;
using JimBobBennett.MvvmLight.AppCompat;

namespace EaglesNestMobileApp.Android.Views
{
    [Activity(Label = "The Nest", Theme = "@style/SplashScreenTheme",
        MainLauncher = true, ScreenOrientation =
        ScreenOrientation.Portrait, NoHistory = true)]
    public class SplashScreenActivity : AppCompatActivityBase
    {
        public LoginActivityViewModel LoginViewModel => AndroidApp.Locator.Login;
        //ICheckLogin ThemeSwitcher = App.Locator.CheckLogin;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }

        protected override void OnResume()
        { 
            base.OnResume();

            //if (ThemeSwitcher.GetTheme("THEME") == null)
            //    ThemeSwitcher.SaveTheme("THEME", "ModAppCompatLightTheme");

            LoginViewModel.CheckUser();
        }
    }
}