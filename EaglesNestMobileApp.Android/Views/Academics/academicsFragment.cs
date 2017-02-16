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
        TabLayout _tabLayout;

        // Fragments to be used in the view pager as tabs
        Fragment[] _academicsFragments =
        {
            new gradesFragment(),
            new gradeReportFragment(),
            new examScheduleFragment()
        };

        // Titles for the tabs
        ICharSequence[] _titles = CharSequence.ArrayFromStringArray(new[]
        {
            "Class Grades",
            "Grade Report",
            "Exam Schedule"
        });


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // The layout is set first so when finding the view by id we look specifically in the elements in this layout
            View _currentView = inflater.Inflate(Resource.Layout.TabLayout, container, false);

            ViewPager _currentPager = _currentView.FindViewById<ViewPager>(Resource.Id.MainViewPager);

            _currentPager.Adapter = new navigationAdapter(ChildFragmentManager, _academicsFragments, _titles);

            _tabLayout = _currentView.FindViewById<TabLayout>(Resource.Id.MainTabLayout);

            // Set the tablayout to fixed so that the titles aren't smashed together
            if (_tabLayout.Width < _currentView.Resources.DisplayMetrics.WidthPixels)
                _tabLayout.TabMode = TabLayout.ModeFixed;

            _tabLayout.SetupWithViewPager(_currentPager);

            return _currentView;
        }
    }
}