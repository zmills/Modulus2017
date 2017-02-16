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
        TabLayout _tabLayout;

        // Fragments to be used as tabs for the viewpager
        Fragment[] _accountFragments =
        {
            new studentInfoFragment(),
            new attendanceFragment(),
            new scheduleFragment()
        };

        // Titles of the tabs
        ICharSequence[] _titles = CharSequence.ArrayFromStringArray(new[]
        {
            "Student Info",
            "Attendance",
            "Student Schedule"
        });


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        // Sets up the viewpager and the tabs along with their titles
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        { 

            View _currentView = inflater.Inflate(Resource.Layout.TabLayout, container, false);

            ViewPager _currentPager = _currentView.FindViewById<ViewPager>(Resource.Id.MainViewPager);

            _currentPager.Adapter = new navigationAdapter(ChildFragmentManager, _accountFragments, _titles);

            _tabLayout = _currentView.FindViewById<TabLayout>(Resource.Id.MainTabLayout);

            // Set the tablayout to fixed so that the titles aren't smashed together
            if (_tabLayout.Width < _currentView.Width)
                _tabLayout.TabMode = TabLayout.ModeFixed;

            _tabLayout.SetupWithViewPager(_currentPager);

            return _currentView;
        }
    }
}