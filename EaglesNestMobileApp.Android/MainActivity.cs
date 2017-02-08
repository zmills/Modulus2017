using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using EaglesNestMobileApp.Android.Resources;

namespace EaglesNestMobileApp.Android
{
    [Activity(Label = "Eaglenest", MainLauncher = true, Icon = "@drawable/logo")]
    public class MainActivity : Activity
    {
        //private EditText username,
        //                 password;
        private Button button;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            //username = (EditText)FindViewById(Resource.Id.inputUserId);

            //Hide action bar
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            //Toolbar will now take on default actionbar characteristics
            SetActionBar(toolbar);

            ActionBar.Title = "Hello from Toolbar";
            ActionBar.Hide();

            button = (Button)FindViewById(Resource.Id.LogInButton);

            button.Click += attempt_logIn;
           

        }

       
        
        void attempt_logIn(object sender, EventArgs e)
        {

            //// Toast.MakeText(this, "No internet Baldy", ToastLength.Long).Show();
     
            StartActivity(typeof(announcements));
     
        }

     
    }
}
