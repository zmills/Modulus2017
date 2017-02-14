/***************************************************************************************/
/* This class is the "homepage" of the fragments inside the account tab. It holds a    */
/* viewpager and is loaded everytime the academics menu item is selected.              */
/***************************************************************************************/

using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Runtime;
using Android.Support.Design.Widget;
using Java.Lang;
using Android.Support.V4.View;
using EaglesNestMobileApp.Android.Adapters;

namespace EaglesNestMobileApp.Android.Views.Account
{
    public class accountFragment : Fragment
    {
        TabLayout tabLayout;

        // Fragments to be used as tabs for the viewpager
        Fragment[] accountFragments =
        {
            new personalInfoFragment(),
            new attendanceFragment(),
            new scheduleFragment()
        };

        // Titles of the tabs
        ICharSequence[] titles = CharSequence.ArrayFromStringArray(new[]
        {
            "Personal Info",
            "Class Attendance",
            "Student Schedule"
        });


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        // Sets up the viewpager and the tabs along with their titles
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        { 

            View currentView = inflater.Inflate(Resource.Layout.Home, container, false);

            ViewPager currentPager = currentView.FindViewById<ViewPager>(Resource.Id.homeViewPager);

            currentPager.Adapter = new navigationAdapter(ChildFragmentManager, accountFragments, titles);

            tabLayout = currentView.FindViewById<TabLayout>(Resource.Id.home_tabs);

            tabLayout.SetupWithViewPager(currentPager);

            return currentView;
        }
    }
}