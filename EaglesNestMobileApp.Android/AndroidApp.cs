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
using EaglesNestMobileApp.Core.ViewModel;
using EaglesNestMobileApp.Android.Views;
using GalaSoft.MvvmLight.Ioc;
using EaglesNestMobileApp.Core;
using JimBobBennett.MvvmLight.AppCompat;
using GalaSoft.MvvmLight.Views;

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
                    // The first initialization will also take care of the navigation service
                    // along with the dialog service
                    AppCompatNavigationService navigator = new AppCompatNavigationService();
                    navigator.Configure(App.PageKeys.LoginPageKey, typeof(loginActivity));
                    navigator.Configure(App.PageKeys.MainPageKey,  typeof(mainActivity));

                    ViewModelLocator.RegisterNavigationService(navigator);

                    _locator = new ViewModelLocator();
                }

                return _locator;
            }
        }

    }
}