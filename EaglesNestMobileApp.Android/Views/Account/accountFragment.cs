/*****************************************************************************/
/*                               accountFragment                             */
/*                                                                           */                                                            
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using EaglesNestMobileApp.Android.Adapters;
using EaglesNestMobileApp.Core;

namespace EaglesNestMobileApp.Android.Views.Account
{
    public class accountFragment : Fragment
    {
        public TabLayout TabLayout { get; set; }
        public View CurrentView { get; set; }
        public ViewPager CurrentPager { get; set; }

        // Fragments to be used as tabs for the viewpager
        Fragment[] AccountFragments =
        {
            new studentInfoFragment(),
            //new attendanceFragment(),
            new scheduleFragment()
        };


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        /* Sets up the viewpager and the tabs along with their titles        */
        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        { 

            CurrentView = 
                inflater.Inflate(Resource.Layout.TabLayout, container, false);

            CurrentPager = 
                CurrentView.FindViewById<ViewPager>(Resource.Id.MainViewPager);

            CurrentPager.Adapter = 
                new navigationAdapter(ChildFragmentManager, AccountFragments, 
                    App.Tabs.AccountPage);

            TabLayout = 
                CurrentView.FindViewById<TabLayout>(Resource.Id.MainTabLayout);

            TabLayout.SetupWithViewPager(CurrentPager);

            return CurrentView;
        }
    }
}