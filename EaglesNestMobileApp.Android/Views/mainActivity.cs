/***************************************************************************************/
/* This activity is started after the user has successfully logged in. It handles all  */
/* the navigation and the selected item events of the bottom navigation view           */
/***************************************************************************************/

using Android.OS;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using EaglesNestMobileApp.Android.Views.Account;
using EaglesNestMobileApp.Android.Views.Campus_Life;
using EaglesNestMobileApp.Android.Views.Dining;
using EaglesNestMobileApp.Android.Views.Academics;
using EaglesNestMobileApp.Android.Views.Home;
using System;
using static Android.Support.Design.Widget.BottomNavigationView;
//using Android.App;

namespace EaglesNestMobileApp.Android.Views
{
   [Activity(Label = "EaglesNestMobileApp", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
   public class mainActivity : AppCompatActivity
    {
        // Fragments corresponding to each navigation menu item
        private homeFragment       homePage = new homeFragment();
        private academicsFragment  academicsPage = new academicsFragment();
        private accountFragment    accountPage = new accountFragment();
        private diningFragment     diningPage = new diningFragment();
        private campusLifeFragment campusLifePage = new campusLifeFragment();

        // References the bottom navigation menu in this activity's layout
        private BottomNavigationView bottomNavigationMenu;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.BottomNavLayout);

            // Load the home page by default
            InitializeNavigation();
        }

        private void InitializeNavigation()
        {
         // Load the first page to be displayed
         FragmentTransaction Transaction = SupportFragmentManager.BeginTransaction();
            Transaction.Replace(Resource.Id.MainFrameLayout, homePage, "Home");

            // Set up the event handler for the bottom navigation menu
            bottomNavigationMenu = FindViewById<BottomNavigationView>(Resource.Id.BottomNavBar);
            bottomNavigationMenu.NavigationItemSelected += BottomNavigationMenu_NavigationItemSelected;
        }

        // Event handler for menu item selection
        private void BottomNavigationMenu_NavigationItemSelected(object sender, NavigationItemSelectedEventArgs menuItem)
        {
            FragmentTransaction Transaction = SupportFragmentManager.BeginTransaction();

            // Load the appropriate page based off of the id of the menu item selected
            switch (menuItem.Item.ItemId)
            {
                case Resource.Id.BottomNavIconHome:
                    Transaction.Replace(Resource.Id.MainFrameLayout, homePage, "Home");
                    break;
                case Resource.Id.BottomNavIconGrades:
                    Transaction.Replace(Resource.Id.MainFrameLayout, academicsPage, "Academics");
                    break;
                case Resource.Id.BottomNavIconCampus:
                    Transaction.Replace(Resource.Id.MainFrameLayout, campusLifePage, "Campus Life");
                    break;
                case Resource.Id.BottomNavIconDining:
                    Transaction.Replace(Resource.Id.MainFrameLayout, diningPage, "Dining");
                    break;
                case Resource.Id.BottomNavIconAccount:
                    Transaction.Replace(Resource.Id.MainFrameLayout, accountPage, "Account");
                    break;
            }

            // Add the fragment to the backstack so that it can be retrieve using the back button
            Transaction.AddToBackStack(null);
            Transaction.Commit();
        }
    }
}