using Android.App;
using Android.OS;
using Android.Widget;
using EaglesNestMobileApp.Android.Resources;
using System;

namespace EaglesNestMobileApp.Android
{
    [Activity(Label = "Eaglesnest", MainLauncher = true, Icon = "@drawable/logo")]
    public class loginActivity : Activity
    {
        private EditText username;
                         //password;
        private Button button;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            username = (EditText)FindViewById(Resource.Id.inputUserId);

            //Hide action bar
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            //Toolbar will now take on default actionbar characteristics
            SetActionBar(toolbar);

            ActionBar.Title = "Hello from Toolbar";
            ActionBar.Hide();

            button = (Button)FindViewById(Resource.Id.LogInButton);

            button.Click += attempt_logIn;
        }

        /* Temporary method to show another layout                          */
        void attempt_logIn(object sender, EventArgs e)
        {
            Toast.MakeText(this, "No internet Baldy", ToastLength.Long).Show();
            StartActivity(typeof(announcements));
        }
    }
}
