/*****************************************************************************/
/*                                 mainActivity                              */
/* This activity is started after the user has successfully logged in. It    */       
/* handles all the navigation and the selected item events of the bottom     */
/* navigation view                                                           */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Support.Design.Widget;
using EaglesNestMobileApp.Android.Views.Account;
using EaglesNestMobileApp.Android.Views.Campus_Life;
using EaglesNestMobileApp.Android.Views.Dining;
using EaglesNestMobileApp.Android.Views.Academics;
using EaglesNestMobileApp.Android.Views.Home;
using static Android.Support.Design.Widget.BottomNavigationView;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;
using Fragment = Android.Support.V4.App.Fragment;
using Android.App;
using JimBobBennett.MvvmLight.AppCompat;
using EaglesNestMobileApp.Core;
using Android.Widget;
using Android.Views;

namespace EaglesNestMobileApp.Android.Views
{
   [Activity(Label = "EaglesNestMobileApp.Android", Icon = "@drawable/icon", MainLauncher = false, 
             Theme = "@style/AppCompatLightTheme")]
   
    /* See loginActivity for base class explanation                          */
    public class mainActivity : AppCompatActivityBase 
    {
      /* Fragments corresponding to each navigation menu item                */
        private homeFragment             _homePage = new homeFragment();
        private academicsFragment   _academicsPage = new academicsFragment();
        private campusLifeFragment _campusLifePage = new campusLifeFragment();
        private diningFragment         _diningPage = new diningFragment();
        private accountFragment       _accountPage = new accountFragment();

        /* References the bottom navigation menu in this activity's layout   */
        private BottomNavigationView _bottomNavigationMenu;
        

        /* Public accessors for member variables                             */
        public homeFragment             HomePage => _homePage;
        public academicsFragment   AcademicsPage => _academicsPage;
        public campusLifeFragment CampusLifePage => _campusLifePage;
        public diningFragment         DiningPage => _diningPage;
        public accountFragment       AccountPage => _accountPage;
        public BottomNavigationView BottomNavigationMenu => 
                                      _bottomNavigationMenu;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            /*( Set our view from the "main" layout resource                 */
            SetContentView(Resource.Layout.BottomNavLayout);
            InitializeNavigation();
         }

        private void InitializeNavigation()
        {
            /* Set up the event handler for the bottom navigation menu       */
            _bottomNavigationMenu = 
                FindViewById<BottomNavigationView>(Resource.Id.BottomNavBar);
            BottomNavigationMenu.NavigationItemSelected += NavItemSelected;

            /* Loads up the main page                                        */
            LoadFragment(App.PageKeys.HomePageKey);
        }

        public override void OnBackPressed()
        {
            /* If the entry on top of the backstack is the home page, close  */
            /* the application else load the homepage and show the user a    */
            /* warning toast                                                 */
            string _previousFragmentName = 
                SupportFragmentManager.GetBackStackEntryAt(
                    SupportFragmentManager.BackStackEntryCount - 1).Name;

            if(_previousFragmentName == "Layered")
            {
                base.OnBackPressed();
                _bottomNavigationMenu.Visibility = ViewStates.Visible;
            }
            else if (_previousFragmentName != App.PageKeys.HomePageKey)
            {
                LoadFragment(App.PageKeys.HomePageKey);
                Toast.MakeText(this, "Press back again to exit application.",
                    ToastLength.Short).Show();
                BottomNavigationMenu.Menu.GetItem(0).SetChecked(true);
            }
            else
            {
                FinishAffinity();
            }
        }

        /* Event handler for menu item selection                             */
        private void NavItemSelected(object sender, 
                                     NavigationItemSelectedEventArgs menuItem)
        {
            /* Load the page based off of the id of the menu item selected   */
            switch (menuItem.Item.ItemId)
            {
                case Resource.Id.BottomNavIconHome:
                    LoadFragment(App.PageKeys.HomePageKey);
                    break;
                case Resource.Id.BottomNavIconGrades:
                    LoadFragment(App.PageKeys.AcademicsPageKey);
                    break;
                case Resource.Id.BottomNavIconCampus:
                    LoadFragment(App.PageKeys.CampusLifePageKey);
                    break;
                case Resource.Id.BottomNavIconDining:
                    LoadFragment(App.PageKeys.DiningPageKey);
                    break;
                case Resource.Id.BottomNavIconAccount:
                    LoadFragment(App.PageKeys.AccountPageKey);
                    break;
            }
        }

        /* Loads the appropriate fragment and adds it to the backstack       */
        private void LoadFragment(string Tag)
        {
            FragmentTransaction _transaction =
                SupportFragmentManager.BeginTransaction();

            switch (Tag)
            {
                case App.PageKeys.HomePageKey:
                    _transaction.Replace(Resource.Id.MainFrameLayout, 
                                            HomePage, Tag);
                    break;
                case App.PageKeys.AcademicsPageKey:
                    _transaction.Replace(Resource.Id.MainFrameLayout, 
                                            AcademicsPage, Tag);
                    break;
                case App.PageKeys.CampusLifePageKey:
                    _transaction.Replace(Resource.Id.MainFrameLayout, 
                                            CampusLifePage, Tag);
                    break;
                case App.PageKeys.DiningPageKey:
                    _transaction.Replace(Resource.Id.MainFrameLayout, 
                                            DiningPage, Tag);
                    break;
                case App.PageKeys.AccountPageKey:
                    _transaction.Replace(Resource.Id.MainFrameLayout, 
                                            AccountPage, Tag);
                    break;
            }
            _transaction.AddToBackStack(Tag);
            _transaction.Commit();
        }
    }
}