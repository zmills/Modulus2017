
using Android.App;
using Android.OS;

namespace EaglesNestMobileApp.Android.Views
{
    [Activity(Label = "SplashScreenActivity", Theme = "@style/SplashScreenTheme", MainLauncher = true, NoHistory = true)]
    public class SplashScreenActivity : Activity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);

        }
    }
}