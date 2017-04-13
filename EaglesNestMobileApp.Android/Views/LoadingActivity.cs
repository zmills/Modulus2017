using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using JimBobBennett.MvvmLight.AppCompat;

namespace EaglesNestMobileApp.Android.Views
{
    [Activity(Label = "The Nest", Icon = "@drawable/TheNestLogo1",
       ScreenOrientation = ScreenOrientation.Portrait,
           MainLauncher = false, Theme = "@style/ModAppCompatLightTheme")]
    public class LoadingActivity : AppCompatActivityBase
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SplashScreenLayout);
        }
    }
}