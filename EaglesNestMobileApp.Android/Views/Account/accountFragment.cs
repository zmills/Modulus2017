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
using Uri = Android.Net.Uri;
using Android.Content;
using Android.Support.V7.Widget;
using EaglesNestMobileApp.Core.ViewModel.AccountViewModels;
using System.IO;

namespace EaglesNestMobileApp.Android.Views.Account
{
    public class accountFragment : Fragment
    {
        public TabLayout TabLayout { get; set; }
        public View CurrentView { get; set; }
        public ViewPager CurrentPager { get; set; }

        public StudentInfoFragmentViewModel ViewModel
        {
            get { return App.Locator.StudentInfo; }
        }

        // Fragments to be used as tabs for the viewpager
        Fragment[] AccountFragments =
        {
            new studentInfoFragment(),
            new attendanceFragment(),
            new scheduleFragment()
        };


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
        }

        /* Sets up the viewpager and the tabs along with their titles        */
        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        { 

            CurrentView = 
                inflater.Inflate(Resource.Layout.AccountFragmentLayout, container, false);

            CurrentPager = 
                CurrentView.FindViewById<ViewPager>(Resource.Id.MainViewPager);

            CurrentPager.Adapter = 
                new navigationAdapter(ChildFragmentManager, AccountFragments, 
                    App.Tabs.AccountPage);

            TabLayout = 
                CurrentView.FindViewById<TabLayout>(Resource.Id.MainTabLayout);

            TabLayout.SetupWithViewPager(CurrentPager);

            Toolbar toolbar = CurrentView.FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.InflateMenu(Resource.Menu.toolbar_menu);


            toolbar.MenuItemClick += Toolbar_MenuItemClick;

            return CurrentView;
        }

        private  void Toolbar_MenuItemClick(object sender, Toolbar.MenuItemClickEventArgs e)
        {
            switch (e.Item.ItemId)
            {
                case Resource.Id.email_button:
                    StartActivity(new Intent(Intent.ActionView, Uri.Parse("https://students.pcci.edu/owa/")));
                    break;
                case Resource.Id.logout_menu:
                    {
                        App.Locator.Main.Purge();

                        File.Delete(System.Environment.GetFolderPath(
                            System.Environment.SpecialFolder.Personal) + "/" + App.DatabaseName);

                        App.Locator.Main.Logout();
                    }
                    break;
            }
        }
    }
}