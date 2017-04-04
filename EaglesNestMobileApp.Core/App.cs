/*****************************************************************************/
/*                                     App                                   */
/*  This static class contains a reference to MVVMLight's viewmodel          */
/*  locator IoC container. All the services are registered in the PCL's      */
/*  ViewModelLocator class. Also, constants, such as page keys and titles    */
/*  are also stored here for convenience.                                    */
/*                                                                           */
/*****************************************************************************/
using Android.Runtime;
using EaglesNestMobileApp.Core.ViewModel;
using Java.Lang;
using Microsoft.WindowsAzure.MobileServices;

namespace EaglesNestMobileApp.Core
{
    public static class App
    {
        /* This locator can be used in the PCL                               */
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator =>
           _locator ?? (_locator = new ViewModelLocator());

        private static MobileServiceClient client;
        public static MobileServiceClient Client =>
            client ?? (client = new MobileServiceClient("https://modulus.azurewebsites.net"));

        /* Local DataBase name.                                              */
        public const string DatabaseName = "EagleDatabase.db";

        /* Attendance violation types                                        */
        public static class ViolationTypes
        {
            public const string Absence = "A";
            public const string Tardy = "T";
            public const string PendingAbsence = "PA";
            public const string PendingTardy = "PT";
        }

        public enum Days
        {
            Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
        }

        /* Mealtimes                                                         */
        public static class MealTimes
        {
            public const string Breakfast = "Breakfast";
            public const string Lunch = "Lunch";
            public const string Dinner = "Dinner";
        }

        /* Keys for the various food lines.                                  */
        public static class LineKeys
        {
            public const string LineOne = "1";
            public const string LineTwo = "2";
            public const string LineThree = "3";
            public const string LineFour = "4";
            public const string LineFive = "5";
            public const string LineSix = "6";
            public const string LineSeven = "7";
        }

        /* Keys for the various activities and fragments                     */
        public static class PageKeys
        {
            public const string MainPageKey = "MainPage";
            public const string LoginPageKey = "LoginPage";
            public const string HomePageKey = "Home";
            public const string AcademicsPageKey = "Academics";
            public const string CampusLifePageKey = "Campus Life";
            public const string DiningPageKey = "Dining";
            public const string AccountPageKey = "Account";
        }

        /* The titles for each tab in the pages                              */
        public static class Tabs
        {
            public static ICharSequence[] HomePage =
               CharSequence.ArrayFromStringArray(new[]
            {
                "Announcements",
                "Events Signup",
                "Calendar of Events"
            });
            public static ICharSequence[] DiningPage =
               CharSequence.ArrayFromStringArray(new[]
            {
                "Four Winds",
                "Varsity",
                "Grab N Go"
            });
            public static ICharSequence[] AccountPage =
               CharSequence.ArrayFromStringArray(new[]
            {
                "Student Info",
                "Attendance",
                "Student Schedule"
            });
            public static ICharSequence[] CampusLifePage =
               CharSequence.ArrayFromStringArray(new[]
            {
                "Facility Times",
                //"Pass Requests",
                "Student Court"
            });
            public static ICharSequence[] AcademicsPage =
               CharSequence.ArrayFromStringArray(new[]
            {
                "Class Grades",
                "Grade Report",
                "Exam Schedule"
            });
        }
    }
}