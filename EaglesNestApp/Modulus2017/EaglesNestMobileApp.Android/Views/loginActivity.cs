﻿/*****************************************************************************/
/*                              loginActivity                                */
/* This activity determines whether a user needs to login and refers him to  */
/* the viewmodel associated with the login if he does need to login. All     */
/* logic and errors associated with logging in are handled in the viewmodel  */
/* (loginActivityViewModel.cs) in the PCL.                                   */
/*                                                                           */
/*****************************************************************************/
using Android.Content.PM;
using Android.App;
using Android.OS;
using Android.Widget;
using EaglesNestMobileApp.Android.Helpers;
using EaglesNestMobileApp.Core;
using EaglesNestMobileApp.Core.ViewModel;
using GalaSoft.MvvmLight.Helpers;
using Java.IO;
using JimBobBennett.MvvmLight.AppCompat;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Android
{
    [Activity(Label = "The Nest", MainLauncher = false, ScreenOrientation = 
        ScreenOrientation.Portrait, Icon = "@drawable/nest_app_icon",
            Theme = "@style/ModAppCompatLightTheme")]
    /* This base class is a mashup of AppCompativity and Laurent's           */
    /* ActivityBase. It was taken from Jim Bob Bennett's Nuget package.      */
    public class loginActivity : AppCompatActivityBase
    {
        /* This locator MUST be called first so that navigation and dialog can */
        /* be initialized, ie, this using the LoginViewModel accessor          */
        /* registers the activities that can be navigated.                     */
        public LoginActivityViewModel LoginViewModel => AndroidApp.Locator.Login;
        public EditText Username { get; set; }
        public EditText Password { get; set; }
        public Button LoginButton { get; set; }

        /* Once this thing is created make sure we check for whether the user  */
        /* is already logged in before we actually show him this layout. We    */
        /* can either use a different activity or wrap the contents of this    */
        /* activity in a huge IF STATEMENT                                     */
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            /* Set our view from the "main" layout resource                     */
            SetContentView(Resource.Layout.LoginLayout);
            ViewModelLocator
                .RegisterCustomDialogService(new CustomProgressDialog(this));

            CurrentPlatform.Init();

            /* Bind views to the viewmodel                                      */
            Username = FindViewById<EditText>(Resource.Id.UserId);
            Password = FindViewById<EditText>(Resource.Id.Password);
            LoginButton = FindViewById<Button>(Resource.Id.LogInButton);

            /* This binds the input from the user to the current user token in  */
            /* the login viewmodel                                              */

            LoginViewModel.CurrentUser.SetBinding(
                () => LoginViewModel.CurrentUser.Id, Username,
                () => Username.Text, BindingMode.TwoWay);

            LoginViewModel.CurrentUser.SetBinding(
                () => LoginViewModel.CurrentUser.Password, Password,
                () => Password.Text, BindingMode.TwoWay);

            /* This command in the login viewmodel handles all the login logic  */
            LoginButton.SetCommand("Click", LoginViewModel.LoginCommand);
        }


        public override void OnBackPressed()
        {
            FinishAffinity();
            Finish();
        }
    }
}