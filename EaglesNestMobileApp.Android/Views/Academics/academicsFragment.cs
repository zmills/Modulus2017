/***************************************************************************************/
/* This class is the "homepage" of the fragments inside the academics tab. It holds a  */
/* view pager and is loaded everytime the academics menu item is selected.             */
/***************************************************************************************/

using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.Design.Widget;
using Java.Lang;
using Android.Support.V4.App;
using Android.Support.V4.View;
using EaglesNestMobileApp.Android.Adapters;

namespace EaglesNestMobileApp.Android.Views.Academics
{
    public class academicsFragment : Fragment
    {
        TabLayout tabLayout;

        // Fragments to be used in the view pager as tabs
        Fragment[] academicsFragments =
        {
            new gradesFragment(),
            new gradeReportFragment(),
            new examScheduleFragment()
        };

        // Titles for the tabs
        ICharSequence[] titles = CharSequence.ArrayFromStringArray(new[]
        {
            "Class Grades",
            "Grade Reports",
            "Exam Schedules"
        });


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // The layout is set first so when finding the view by id we look specifically in the elements in this layout
            View currentView = inflater.Inflate(Resource.Layout.Home, container, false);

            ViewPager currentPager = currentView.FindViewById<ViewPager>(Resource.Id.homeViewPager);

            // Create an instance of the viewpager adapter using tabs
            currentPager.Adapter = new navigationAdapter(ChildFragmentManager, academicsFragments, titles);

            tabLayout = currentView.FindViewById<TabLayout>(Resource.Id.home_tabs);

            tabLayout.SetupWithViewPager(currentPager);

            return currentView;
        }
    }
}