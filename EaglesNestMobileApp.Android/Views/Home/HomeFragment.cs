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
        public TabLayout TabLayout { get; set; }
        public View CurrentView { get; set; }

        Fragment[] HomeFragments = 
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
            CurrentView = inflater.Inflate(Resource.Layout.TabLayout, container, false);

            ViewPager currentPager = CurrentView.FindViewById<ViewPager>(Resource.Id.MainViewPager);

            currentPager.Adapter = new navigationAdapter(ChildFragmentManager, HomeFragments, App.Tabs.HomePage);

            TabLayout = CurrentView.FindViewById<TabLayout>(Resource.Id.MainTabLayout);

            TabLayout.SetupWithViewPager(currentPager);

            return CurrentView;
        }
    }
}