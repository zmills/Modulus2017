/*****************************************************************************/
/*                              academicsFragment                            */
/*                                                                           */
/* This class is the "homepage" of the fragments inside the academics tab.   */
/* It holds a view pager and is loaded everytime the academics menu item is  */
/* selected.                                                                 */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using EaglesNestMobileApp.Android.Adapters;
using EaglesNestMobileApp.Core;

namespace EaglesNestMobileApp.Android.Views.Academics
{
    public class academicsFragment : Fragment
    {
        public TabLayout TabLayout { get; set; }
        public ViewPager CurrentPager { get; set; }
        public View CurrentView { get; set; }

        /* Fragments to be used in the view pager as tabs                    */
        Fragment[] AcademicsFragments =
        {
            new gradesFragment(),
            //new gradeReportFragment(),
            new examScheduleFragment()
        };

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {
            /* The layout is set first so when finding the view by id we     */
            /* look specifically in the elements in this layout              */
            CurrentView = inflater.Inflate(Resource.Layout.TabLayout, 
                                              container, false);

            CurrentPager = 
                CurrentView.FindViewById<ViewPager>(Resource.Id.MainViewPager);

            CurrentPager.Adapter = new navigationAdapter(ChildFragmentManager, 
                AcademicsFragments, App.Tabs.AcademicsPage );

            TabLayout = 
                CurrentView.FindViewById<TabLayout>(Resource.Id.MainTabLayout);

            TabLayout.SetupWithViewPager(CurrentPager);
            return CurrentView;
        }
    }
}