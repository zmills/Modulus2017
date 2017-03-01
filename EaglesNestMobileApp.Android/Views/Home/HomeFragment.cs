/*****************************************************************************/
/*                               homeFragment                                */
/* This activity determines whether a user needs to login and refers him to  */
/* the viewmodel associated with the login if he does need to login. All     */
/* logic and errors associated with logging in are handled in the viewmodel  */
/* (loginActivityViewModel.cs) in the PCL.                                   */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V4.View;
using EaglesNestMobileApp.Android.Adapters;
using Android.Support.Design.Widget;
using EaglesNestMobileApp.Core;

namespace EaglesNestMobileApp.Android.Views.Home
{
    /* This fragment loads the three tabs for the Home menu item and its     */
    /* viewpager                                                             */
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

        public override View OnCreateView(LayoutInflater inflater, 
                               ViewGroup container, Bundle savedInstanceState)
        {
            CurrentView = inflater.Inflate(Resource.Layout.TabLayout,
                                              container, false);

            ViewPager currentPager = 
                CurrentView.FindViewById<ViewPager>(Resource.Id.MainViewPager);

            currentPager.Adapter = 
                new navigationAdapter(ChildFragmentManager, HomeFragments,
                                         App.Tabs.HomePage);

            TabLayout = 
                CurrentView.FindViewById<TabLayout>(Resource.Id.MainTabLayout);

            TabLayout.SetupWithViewPager(currentPager);

            return CurrentView;
        }
    }
}