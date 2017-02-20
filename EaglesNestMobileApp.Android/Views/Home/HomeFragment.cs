using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Java.Lang;
using Android.Support.V4.View;
using EaglesNestMobileApp.Android.Adapters;
using Android.Support.Design.Widget;
using Android.Runtime;
using EaglesNestMobileApp.Core;

namespace EaglesNestMobileApp.Android.Views.Home
{
    public class homeFragment : Fragment
    {
        TabLayout _tabLayout;

        Fragment[] _homeFragments = 
        {
            new announcementsFragment(),
            new eventsFragment(),
            new calendarFragment()
        };

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View _currentView = inflater.Inflate(Resource.Layout.TabLayout, container, false);

            ViewPager currentPager = _currentView.FindViewById<ViewPager>(Resource.Id.MainViewPager);

            currentPager.Adapter = new navigationAdapter(ChildFragmentManager, _homeFragments, App.Tabs.HomePage);

            _tabLayout = _currentView.FindViewById<TabLayout>(Resource.Id.MainTabLayout);

            _tabLayout.SetupWithViewPager(currentPager);

            return _currentView;
        }
    }
}