//***************************************************************************************/
//*                                   mainActivity                                      */
//* This activity is started after the user has successfully logged in. It handles all  */
//* the navigation and the selected item events of the bottom navigation view           */
//*                                                                                     */
//***************************************************************************************/
using Android.OS;
using Android.Support.Design.Widget;
using EaglesNestMobileApp.Android.Views.Account;
using EaglesNestMobileApp.Android.Views.Campus_Life;
using EaglesNestMobileApp.Android.Views.Dining;
using EaglesNestMobileApp.Android.Views.Academics;
using EaglesNestMobileApp.Android.Views.Home;
using static Android.Support.Design.Widget.BottomNavigationView;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;
using Android.App;
using JimBobBennett.MvvmLight.AppCompat;
using EaglesNestMobileApp.Core;
using Android.Widget;

namespace EaglesNestMobileApp.Android.Views
{
   [Activity(Label = "EaglesNestMobileApp.Android", Icon = "@drawable/icon", Theme = "@style/AppCompatLightTheme")]
   public class mainActivity : AppCompatActivityBase // See loginActivity for base class explanation
   {
      // Fragments corresponding to each navigation menu item
      private homeFragment             _homePage = new homeFragment();
        private academicsFragment   _academicsPage = new academicsFragment();
        private campusLifeFragment _campusLifePage = new campusLifeFragment();
        private diningFragment         _diningPage = new diningFragment();
        private accountFragment       _accountPage = new accountFragment();

        // References the bottom navigation menu in this activity's layout
        private BottomNavigationView _bottomNavigationMenu;
        

        // Public accessors for member variables
        public homeFragment             HomePage => _homePage;
        public academicsFragment   AcademicsPage => _academicsPage;
        public campusLifeFragment CampusLifePage => _campusLifePage;
        public diningFragment         DiningPage => _diningPage;
        public accountFragment       AccountPage => _accountPage;
        public BottomNavigationView BottomNavigationMenu => _bottomNavigationMenu;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.BottomNavLayout);

            InitializeNavigation();
         }

        private void InitializeNavigation()
        {
            // Set up the event handler for the bottom navigation menu
            _bottomNavigationMenu = FindViewById<BottomNavigationView>(Resource.Id.BottomNavBar);
            BottomNavigationMenu.NavigationItemSelected += BottomNavigationMenu_NavigationItemSelected;

            LoadFragment(Constants.HomePageKey);
        }

        public override void OnBackPressed()
        {
            // If the entry on top of the backstack is the home page, close the application
            // else load the homepage and show the user a warning toast 
            if (SupportFragmentManager.GetBackStackEntryAt
                (SupportFragmentManager.BackStackEntryCount - 1).Name == Constants.HomePageKey)
                System.Environment.Exit(0);
            else
            {
                LoadFragment(Constants.HomePageKey);
                Toast.MakeText(this, "Press back again to close application.", ToastLength.Short).Show();
                _bottomNavigationMenu.Menu.GetItem(0).SetChecked(true);
            }
        }

        // Event handler for menu item selection
        private void BottomNavigationMenu_NavigationItemSelected(object sender, NavigationItemSelectedEventArgs menuItem)
        {
            // Load the appropriate page based off of the id of the menu item selected
            switch (menuItem.Item.ItemId)
            {
                case Resource.Id.BottomNavIconHome:
                    LoadFragment(Constants.HomePageKey);
                    break;
                case Resource.Id.BottomNavIconGrades:
                    LoadFragment(Constants.AcademicsPageKey);
                    break;
                case Resource.Id.BottomNavIconCampus:
                    LoadFragment(Constants.CampusLifePageKey);
                    break;
                case Resource.Id.BottomNavIconDining:
                    LoadFragment(Constants.DiningPageKey);
                    break;
                case Resource.Id.BottomNavIconAccount:
                    LoadFragment(Constants.AccountPageKey);
                    break;
            }
        }

        // Loads the appropriate fragment and adds it to the backstack
        private void LoadFragment(string Tag)
        {
            FragmentTransaction _transaction = SupportFragmentManager.BeginTransaction();

            switch (Tag)
            {
                case Constants.HomePageKey:
                    _transaction.Replace(Resource.Id.MainFrameLayout, HomePage, Tag);
                    break;
                case Constants.AcademicsPageKey:
                    _transaction.Replace(Resource.Id.MainFrameLayout, AcademicsPage, Tag);
                    break;
                case Constants.CampusLifePageKey:
                    _transaction.Replace(Resource.Id.MainFrameLayout, CampusLifePage, Tag);
                    break;
                case Constants.DiningPageKey:
                    _transaction.Replace(Resource.Id.MainFrameLayout, DiningPage, Tag);
                    break;
                case Constants.AccountPageKey:
                    _transaction.Replace(Resource.Id.MainFrameLayout, AccountPage, Tag);
                    break;
            }
            _transaction.AddToBackStack(Tag);
            _transaction.Commit();
        }
    }
}