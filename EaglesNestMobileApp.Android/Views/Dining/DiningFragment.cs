using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.Design.Widget;
using Java.Lang;
using Android.Support.V4.View;
using EaglesNestMobileApp.Android.Adapters;
using Android.Runtime;

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

        ICharSequence[] _titles = CharSequence.ArrayFromStringArray(new[]
        {
            "Four Winds",
            "Varsity",
            "Grab N Go"
        });


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View currentView = inflater.Inflate(Resource.Layout.TabLayout, container, false);

            ViewPager currentPager = currentView.FindViewById<ViewPager>(Resource.Id.MainViewPager);

            currentPager.Adapter = new navigationAdapter(ChildFragmentManager, _diningFragments, _titles);
           
            _tabLayout = currentView.FindViewById<TabLayout>(Resource.Id.MainTabLayout);

            // Set the tablayout to fixed so that the titles aren't smashed together
            _tabLayout.TabMode = TabLayout.ModeFixed;

            _tabLayout.SetupWithViewPager(currentPager);

            return currentView;
        }
    }
}