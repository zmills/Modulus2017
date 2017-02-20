/***************************************************************************************/
/* This class is the "homepage" of the fragments inside the campus life tab. It holds a*/
/* viewpager and is loaded everytime the campus life menu item is selected.            */
/***************************************************************************************/

using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Runtime;
using Android.Support.Design.Widget;
using Java.Lang;
using Android.Support.V4.View;
using EaglesNestMobileApp.Android.Adapters;
using EaglesNestMobileApp.Core;

namespace EaglesNestMobileApp.Android.Views.Campus_Life
{
    public class campusLifeFragment : Fragment
    {
        TabLayout _tabLayout;

        // Fragments for the viewpager use as tabs
        Fragment[] _campusLifeFragments =
        {
            new facilitiesFragment(),
            new requestsFragment(),
            new studentCourtFragment(),
        };

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        // Sets up the viewpager, tabs, and the titles of the tabs when the campus life item is selected
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View _currentView = inflater.Inflate(Resource.Layout.TabLayout, container, false);

            ViewPager _currentPager = _currentView.FindViewById<ViewPager>(Resource.Id.MainViewPager);

            _currentPager.Adapter = 
                new navigationAdapter(ChildFragmentManager, _campusLifeFragments, App.Tabs.CampusLifePage);

            _tabLayout = _currentView.FindViewById<TabLayout>(Resource.Id.MainTabLayout);

            _tabLayout.SetupWithViewPager(_currentPager);

            return _currentView;
        }
    }
}