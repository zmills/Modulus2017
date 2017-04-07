/*****************************************************************************/
/*                              diningFragment                               */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using EaglesNestMobileApp.Android.Adapters;
using EaglesNestMobileApp.Core;

namespace EaglesNestMobileApp.Android.Views.Dining
{
    public class diningFragment : Fragment
    {
        TabLayout TabLayout { get; set; }
        View CurrentView { get; set; }
        ViewPager CurrentPager { get; set; }

        Fragment[] DiningFragments =
        {
            new fourWindsFragment(),
            new varsityFragment(),
            new grabNGoFragment()
        };


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
            //Activity.RunOnUiThread(() => App.Locator.FourWinds.InitializeVm());
            //Activity.RunOnUiThread(() => App.Locator.GrabAndGo.InitializeVm());
            //Activity.RunOnUiThread(() => App.Locator.Varsity.InitializeVm());
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Use this to return your custom view for this Fragment         */
            Activity.RunOnUiThread(() => CurrentView = inflater.Inflate(Resource.Layout.TabLayout, 
                container, false));

            CurrentPager = 
                CurrentView.FindViewById<ViewPager>(Resource.Id.MainViewPager);

            Activity.RunOnUiThread(()=>CurrentPager.Adapter = 
                new navigationAdapter(ChildFragmentManager, DiningFragments, 
                                         App.Tabs.DiningPage));

            Activity.RunOnUiThread(() => TabLayout = 
                CurrentView.FindViewById<TabLayout>(Resource.Id.MainTabLayout));

            /* Set the tablayout to fixed so that the titles aren't smashed  */
            /* together. REMINDER: BACKLIST: get width of tabLayout and set  */
            /* Fixed or Scrollable depending on the width                    */
            TabLayout.TabMode = TabLayout.ModeFixed;
            Activity.RunOnUiThread(() => TabLayout.SetupWithViewPager(CurrentPager));
            
            return CurrentView;
        }
    }
}