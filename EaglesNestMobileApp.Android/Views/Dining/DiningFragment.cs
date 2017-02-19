using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.Design.Widget;
using Java.Lang;
using Android.Support.V4.View;
using EaglesNestMobileApp.Android.Adapters;
using Android.Runtime;
using EaglesNestMobileApp.Core;

namespace EaglesNestMobileApp.Android.Views.Dining
{
    public class diningFragment : Fragment
    {
        TabLayout _tabLayout;

        Fragment[] _diningFragments =
        {
            new fourWindsFragment(),
            new varsityFragment(),
            new grabNGoFragment()
        };

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View _currentView = inflater.Inflate(Resource.Layout.TabLayout, container, false);

            ViewPager currentPager = _currentView.FindViewById<ViewPager>(Resource.Id.MainViewPager);

            currentPager.Adapter = new navigationAdapter(ChildFragmentManager, _diningFragments, App.Tabs.DiningPage);
           
            _tabLayout = _currentView.FindViewById<TabLayout>(Resource.Id.MainTabLayout);

            // Set the tablayout to fixed so that the titles aren't smashed together
            _tabLayout.TabMode = TabLayout.ModeFixed;
            _tabLayout.SetupWithViewPager(currentPager);
            
            return _currentView;
        }
    }
}