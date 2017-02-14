using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Java.Lang;
using Android.Support.V4.View;
using EaglesNestMobileApp.Android.Adapters;
using Android.Support.Design.Widget;
using Android.Runtime;

namespace EaglesNestMobileApp.Android.Views.Home
{
    public class homeFragment : Fragment
    {
        TabLayout tabLayout;

        Fragment[] homeFragments = 
        {
            new announcementsFragment(),
            new eventsFragment(),
            new calendarFragment()
        };

        ICharSequence[] titles = CharSequence.ArrayFromStringArray( new[] 
        {
            "Announcements",
            "Events Signup",
            "Calendar"
        });


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View currentView = inflater.Inflate(Resource.Layout.Home, container, false);

           ViewPager currentPager = currentView.FindViewById<ViewPager>(Resource.Id.homeViewPager);

            currentPager.Adapter = new navigationAdapter(ChildFragmentManager, homeFragments, titles);

            tabLayout = currentView.FindViewById<TabLayout>(Resource.Id.home_tabs);

            tabLayout.SetupWithViewPager(currentPager);

            return currentView;
        }
    }
}