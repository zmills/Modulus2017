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
using Uri = Android.Net.Uri;
using Android.Content;
using Android.Support.V7.Widget;
using System.IO;

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
            RetainInstance = true;
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

            Toolbar toolbar = CurrentView.FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.InflateMenu(Resource.Menu.toolbar_menu);


            toolbar.MenuItemClick += Toolbar_MenuItemClick;

            TabLayout.SetupWithViewPager(CurrentPager);
            return CurrentView;
        }

        private void Toolbar_MenuItemClick(object sender, Toolbar.MenuItemClickEventArgs e)
        {
            switch (e.Item.ItemId)
            {
                case Resource.Id.email_button:
                    StartActivity(new Intent(Intent.ActionView, Uri.Parse("https://students.pcci.edu/owa/")));
                    break;
                case Resource.Id.logout_menu:
                    {

                        App.Locator.Main.LogoutAsync();

                        File.Delete(System.Environment.GetFolderPath(
                            System.Environment.SpecialFolder.Personal) + "/" + App.DatabaseName);
                    }
                    break;
            }
        }
    }
}