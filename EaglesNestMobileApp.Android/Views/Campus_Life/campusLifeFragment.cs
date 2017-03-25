/*****************************************************************************/
/*                            campusLifeFragment                             */
/*                                                                           */
/* This class is the "homepage" of the fragments inside the campus life tab. */
/* It holds a viewpager and is loaded everytime the campus life menu item is */
/* selected.                                                                 */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using EaglesNestMobileApp.Android.Adapters;
using EaglesNestMobileApp.Core;

namespace EaglesNestMobileApp.Android.Views.Campus_Life
{
    public class campusLifeFragment : Fragment
    {
        public TabLayout TabLayout { get; set; }
        public View CurrentView { get; set; }
        public ViewPager CurrentPager { get; set; }

        /* Fragments for the viewpager use as tabs                           */
        Fragment[] CampusLifeFragments =
        {
            new facilitiesFragment(),
            new requestsFragment(),
            new studentCourtFragment(),
        };

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        /* Sets up the viewpager, tabs, and the titles of the tabs when the  */
        /* campus life item is selected                                      */
        public override View OnCreateView(LayoutInflater inflater,
            ViewGroup container, Bundle savedInstanceState)
        {
            CurrentView = inflater.Inflate(Resource.Layout.TabLayout,
                                              container, false);

            CurrentPager =
                CurrentView.FindViewById<ViewPager>(Resource.Id.MainViewPager);
            CurrentPager.Adapter =
                new navigationAdapter(ChildFragmentManager,
                                         CampusLifeFragments,
                                             App.Tabs.CampusLifePage);

            TabLayout =
                CurrentView.FindViewById<TabLayout>(Resource.Id.MainTabLayout);

            TabLayout.SetupWithViewPager(CurrentPager);
            return CurrentView;

        }
    }
}