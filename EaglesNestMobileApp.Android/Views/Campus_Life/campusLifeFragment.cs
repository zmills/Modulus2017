using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Runtime;
using Android.Support.Design.Widget;
using Java.Lang;
using Android.Support.V4.View;
using EaglesNestMobileApp.Android.Adapters;

namespace EaglesNestMobileApp.Android.Views.Campus_Life
{
    public class campusLifeFragment : Fragment
    {
        TabLayout tabLayout;

        Fragment[] campusLifeFragments =
        {
            new studentCourtFragment(),
            new facilitiesFragment(),
            new requestsFragment()
        };

        ICharSequence[] titles = CharSequence.ArrayFromStringArray(new[]
        {
            "Student Court",
            "Facilities",
            "Requests"
        });


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View currentView = inflater.Inflate(Resource.Layout.Home, container, false);

            ViewPager currentPager = currentView.FindViewById<ViewPager>(Resource.Id.homeViewPager);

            currentPager.Adapter = new navigationAdapter(ChildFragmentManager, campusLifeFragments, titles);
            
            tabLayout = currentView.FindViewById<TabLayout>(Resource.Id.home_tabs);

            tabLayout.SetupWithViewPager(currentPager);

            return currentView;
        }
    }
}