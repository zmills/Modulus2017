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
using Uri = Android.Net.Uri;
using Android.Content;
using Android.Support.V7.Widget;
using System.IO;
using Android.Util;
using EaglesNestMobileApp.Core.Contracts;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Android.Views.Dining
{
    public class diningFragment : Fragment
    {
        TabLayout TabLayout { get; set; }
        View CurrentView { get; set; }
        ViewPager CurrentPager { get; set; }
        ICheckLogin ThemeSwitcher = App.Locator.CheckLogin;

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

            Toolbar toolbar = CurrentView.FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.InflateMenu(Resource.Menu.toolbar_menu);

            toolbar.MenuItemClick += Toolbar_MenuItemClick;

            /* Set the tablayout to fixed so that the titles aren't smashed  */
            /* together. REMINDER: BACKLIST: get width of tabLayout and set  */
            /* Fixed or Scrollable depending on the width                    */
            TabLayout.TabMode = TabLayout.ModeFixed;
            Activity.RunOnUiThread(() => TabLayout.SetupWithViewPager(CurrentPager));
            
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
                        App.Locator.Main.Purge();
                        
                        File.Delete(System.Environment.GetFolderPath(
                            System.Environment.SpecialFolder.Personal) + "/" + App.DatabaseName);

                        App.Locator.Main.Logout();
                    }
                    break;
                case Resource.Id.settings_button:
                    {
                        if (ThemeSwitcher.GetTheme("THEME") == "ModAppCompatLightTheme")
                        {
                            ThemeSwitcher.DeleteTheme("THEME");
                            ThemeSwitcher.SaveTheme("THEME", "ModAppCompatDarkTheme");
                            Activity.SetTheme(Resource.Style.ModAppCompatDarkTheme);
                            Activity.Recreate();
                        }
                        else
                        {
                            ThemeSwitcher.DeleteTheme("THEME");
                            ThemeSwitcher.SaveTheme("THEME", "ModAppCompatLightTheme");
                            Activity.SetTheme(Resource.Style.ModAppCompatLightTheme);
                            Activity.Recreate();
                        }
                    }
                    break;
            }
        }
    }
}