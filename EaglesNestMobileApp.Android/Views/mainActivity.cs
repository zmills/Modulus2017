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

namespace EaglesNestMobileApp.Android.Views
{
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

            // Load the home page by default
            InitializeNavigation();
        }

        private void InitializeNavigation()
        {
            // Load the first page to be displayed
            FragmentTransaction Transaction = SupportFragmentManager.BeginTransaction();
            Transaction.Replace(Resource.Id.mainfraime, homePage, "Home");

            // Set up the event handler for the bottom navigation menu
            bottomNavigationMenu = FindViewById<BottomNavigationView>(Resource.Layout.design_navigation_menu);
            bottomNavigationMenu.NavigationItemSelected += BottomNavigationMenu_NavigationItemSelected;
        }

        // Event handler for menu item selection
        private void BottomNavigationMenu_NavigationItemSelected(object sender, NavigationItemSelectedEventArgs menuItem)
        {
            FragmentTransaction Transaction = SupportFragmentManager.BeginTransaction();

            // Load the appropriate page based off of the id of the menu item selected
            switch (menuItem.Item.ItemId)
            {
                case Resource.Id.tab_home:
                    Transaction.Replace(Resource.Id.mainframe, homePage, "Home");
                    break;
                case Resource.Id.tab_academics:
                    Transaction.Replace(Resource.Id.mainframe, academicsPage, "Academics");
                    break;
                case Resource.Id.tab_campus_life:
                    Transaction.Replace(Resource.Id.mainframe, campusLifePage, "Campus Life");
                    break;
                case Resource.Id.tab_dining:
                    Transaction.Replace(Resource.Id.mainframe, diningPage, "Dining");
                    break;
                case Resource.Id.tab_account:
                    Transaction.Replace(Resource.Id.mainframe, accountPage, "Account");
                    break;
            }

            // Add the fragment to the backstack so that it can be retrieve using the back button
            Transaction.AddToBackStack(null);
            Transaction.Commit();
        }
    }
}