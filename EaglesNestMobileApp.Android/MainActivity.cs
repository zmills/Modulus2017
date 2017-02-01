using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace EaglesNestMobileApp.Android
{
    [Activity(Label = "", MainLauncher = true, Icon = "@drawable/logo")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
          
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Hide action bar
            ActionBar.Hide();
        }

      
    }
}

