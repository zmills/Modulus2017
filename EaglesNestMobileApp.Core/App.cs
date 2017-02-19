using Android.Runtime;
using EaglesNestMobileApp.Core.ViewModel;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core
{
    public static class App
    {
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator => _locator ?? (_locator = new ViewModelLocator());

        // Keys for the various activities and fragments
        public static class PageKeys
        {
            public const string MainPageKey       = "MainPage";     // mainActivity key
            public const string LoginPageKey      = "LoginPage";    // loginActivity key
            public const string HomePageKey       = "Home";
            public const string AcademicsPageKey  = "Academics";
            public const string CampusLifePageKey = "Campus Life";
            public const string DiningPageKey     = "Dining";
            public const string AccountPageKey    = "Account";
        }

        // The titles for each page
        public static class Tabs
        {
            public static ICharSequence[] HomePage = CharSequence.ArrayFromStringArray(new[]
            {
                "Announcements",
                "Events Signup",
                "Calendar of Events"
            });

            public static ICharSequence[] DiningPage = CharSequence.ArrayFromStringArray(new[]
            {
                "Four Winds",
                "Varsity",
                "Grab N Go"
            });

            public static ICharSequence[] AccountPage = CharSequence.ArrayFromStringArray(new[]
            {
                "Student Info",
                "Attendance",
                "Student Schedule"
            });

            public static ICharSequence[] CampusLifePage = CharSequence.ArrayFromStringArray(new[]
            {
                "Facility Times",
                "Pass Requests",
                "Student Court"
            });

            public static ICharSequence[] AcademicsPage = CharSequence.ArrayFromStringArray(new[]
            {
                "Class Grades",
                "Grade Report",
                "Exam Schedule"
            });
        }
    }
}
