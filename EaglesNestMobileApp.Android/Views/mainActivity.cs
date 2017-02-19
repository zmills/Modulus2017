/***************************************************************************************/
/* This activity is started after the user has successfully logged in. It handles all  */
/* the navigation and the selected item events of the bottom navigation view           */
/***************************************************************************************/

using Android.OS;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using EaglesNestMobileApp.Android.Views.Account;
using EaglesNestMobileApp.Android.Views.Campus_Life;
using EaglesNestMobileApp.Android.Views.Dining;
using EaglesNestMobileApp.Android.Views.Academics;
using EaglesNestMobileApp.Android.Views.Home;
using static Android.Support.Design.Widget.BottomNavigationView;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;
using Android.App;

namespace EaglesNestMobileApp.Android.Views
{
    [Activity(Label = "EaglesNestMobileApp.Android", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppCompatLightTheme")] //"Theme" sets the theme
   public class mainActivity : AppCompatActivity
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

            // Set up the first page to show up once the application loads
            FragmentTransaction _transaction = SupportFragmentManager.BeginTransaction();
            _transaction.Replace(Resource.Id.MainFrameLayout, HomePage, Constants.HomePageKey);
            _transaction.AddToBackStack(null);
            _transaction.Commit();
        }

        // Event handler for menu item selection
        private void BottomNavigationMenu_NavigationItemSelected(object sender, NavigationItemSelectedEventArgs menuItem)
        {

            FragmentTransaction _transaction = SupportFragmentManager.BeginTransaction();

            // Load the appropriate page based off of the id of the menu item selected
            switch (menuItem.Item.ItemId)
            {
                case Resource.Id.BottomNavIconHome:
                    _transaction.Replace(Resource.Id.MainFrameLayout, HomePage, Constants.HomePageKey);
                    break;
                case Resource.Id.BottomNavIconGrades:
                    _transaction.Replace(Resource.Id.MainFrameLayout, AcademicsPage, Constants.AcademicsPageKey);
                    break;
                case Resource.Id.BottomNavIconCampus:
                    _transaction.Replace(Resource.Id.MainFrameLayout, CampusLifePage, Constants.CampusLifePageKey);
                    break;
                case Resource.Id.BottomNavIconDining:
                    _transaction.Replace(Resource.Id.MainFrameLayout, DiningPage, Constants.DiningPageKey);
                    break;
                case Resource.Id.BottomNavIconAccount:
                    _transaction.Replace(Resource.Id.MainFrameLayout, AccountPage, Constants.AccountPageKey);
                    break;
            }

            // Add the fragment to the backstack so that it can be retrieve using the back button
            _transaction.AddToBackStack(null);
            _transaction.Commit();
        }
    }
}