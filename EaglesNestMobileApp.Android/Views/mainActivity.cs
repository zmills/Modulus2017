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
using Android.App;
using JimBobBennett.MvvmLight.AppCompat;
using EaglesNestMobileApp.Core;
using Android.Widget;
using Android.Content.PM;
using Java.IO;

namespace EaglesNestMobileApp.Android.Views
{
    [Activity(Label = "The Nest", Icon = "@drawable/TheNestLogo1",
       ScreenOrientation = ScreenOrientation.Portrait,
           MainLauncher = false, Theme = "@style/ModAppCompatDarkTheme")]

    /* See loginActivity for base class explanation                          */
    public class mainActivity : AppCompatActivityBase
    {
        /* Variables for managing the backstack                              */
        private bool _isHome;
        private int _backStackCount;
        private string _fragmentTag;

        /* Public accessors for member variables                             */
        public homeFragment HomePage
            { get; private set; } = new homeFragment();

        public academicsFragment AcademicsPage
            { get; private set; } = new academicsFragment();

        public campusLifeFragment CampusLifePage
            { get; private set; } = new campusLifeFragment();

        public diningFragment DiningPage
            { get; private set; } = new diningFragment();

        public accountFragment AccountPage
            { get; private set; } = new accountFragment();

        public BottomNavigationView BottomNavigationMenu
            { get; private set; }

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
            RunOnUiThread(() => (BottomNavigationMenu =
                FindViewById<BottomNavigationView>(Resource.Id.BottomNavBar))
                    .NavigationItemSelected += NavItemSelected);
            

            /* Loads up the main page                                        */
            RunOnUiThread(() => LoadHomeFragment());
        }

        public override void OnBackPressed()
        {
            _isHome =
                SupportFragmentManager
                    .FindFragmentByTag(App.PageKeys.HomePageKey).IsVisible;

            if (!_isHome)
            {
                RunOnUiThread(() => LoadHomeFragment());
                Toast.MakeText(this, "Press back again to exit application.",
                    ToastLength.Short).Show();
                BottomNavigationMenu.Menu.GetItem(0).SetChecked(true);
            }
            else
            {
                Finish();
                FinishAffinity();
            }
        }

        private void LoadHomeFragment()
        {
            FragmentTransaction _transaction =
                   SupportFragmentManager.BeginTransaction();

            _fragmentTag = App.PageKeys.HomePageKey;
            _transaction.Replace(Resource.Id.MainFrameLayout,
                HomePage, _fragmentTag);

            _backStackCount = SupportFragmentManager.BackStackEntryCount;

            /* Add the homefragment to the backstack for back button purposes */
            if (_backStackCount < 1)
            {
                _transaction.AddToBackStack(_fragmentTag);
            }
            _transaction.Commit();
        }

        /* Event handler for menu item selection                             */
        private void NavItemSelected(object sender,
                                     NavigationItemSelectedEventArgs menuItem)
        {
            FragmentTransaction _transaction =
                SupportFragmentManager.BeginTransaction();

            /* Load the page based off of the id of the menu item selected   */
            switch (menuItem.Item.ItemId)
            {
                case Resource.Id.BottomNavIconHome:
                    {
                        RunOnUiThread(() => LoadHomeFragment());
                        return;
                    }
                case Resource.Id.BottomNavIconGrades:
                    {
                        _fragmentTag = App.PageKeys.AcademicsPageKey;
                        _transaction.Replace(Resource.Id.MainFrameLayout,
                            AcademicsPage, _fragmentTag);
                    }break;
                case Resource.Id.BottomNavIconCampus:
                    {
                        _fragmentTag = App.PageKeys.CampusLifePageKey;
                        _transaction.Replace(Resource.Id.MainFrameLayout,
                            CampusLifePage, _fragmentTag);

                    }break;
                case Resource.Id.BottomNavIconDining:
                    {
                        _fragmentTag = App.PageKeys.DiningPageKey;
                        _transaction.Replace(Resource.Id.MainFrameLayout,
                            DiningPage, _fragmentTag);
                    }break;
                case Resource.Id.BottomNavIconAccount:
                    {
                        _fragmentTag = App.PageKeys.AccountPageKey;
                        _transaction.Replace(Resource.Id.MainFrameLayout,
                            AccountPage, _fragmentTag);
                    }break;
            }
            _transaction.Commit();
        }
    }
}