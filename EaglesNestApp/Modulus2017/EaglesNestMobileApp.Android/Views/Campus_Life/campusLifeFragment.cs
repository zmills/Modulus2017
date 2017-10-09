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
using Uri = Android.Net.Uri;
using Android.Content;
using Android.Support.V7.Widget;
using System.IO;
using Android.Util;
using EaglesNestMobileApp.Core.Contracts;
using Dialog = Android.App.Dialog;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using System.Threading.Tasks;
using Switch = Android.Widget.Switch;
using CompoundButton = Android.Widget.CompoundButton;

namespace EaglesNestMobileApp.Android.Views.Campus_Life
{
    public class campusLifeFragment : Fragment
    {
        public TabLayout TabLayout { get; set; }
        public View CurrentView { get; set; }
        public ViewPager CurrentPager { get; set; }

        private ICheckLogin ThemeSwitcher = App.Locator.CheckLogin;
        private Dialog _dialogBox;
        private SupportToolbar dialogToolbar;
        private string _theme;

        /* Fragments for the viewpager use as tabs                           */
        Fragment[] CampusLifeFragments =
        {
            new facilitiesFragment(),
            //new requestsFragment(),
            new studentCourtFragment(),
        };

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
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

            Toolbar toolbar = CurrentView.FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.InflateMenu(Resource.Menu.toolbar_menu);


            toolbar.MenuItemClick += Toolbar_MenuItemClick;
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
                        OpenSettingsPage();
                    }
                    break;
            }
        }

        private async void OpenSettingsPage()
        {
            /* Find the current theme                                        */
            TypedValue attrValue = new TypedValue();
            Activity.Theme.ResolveAttribute(
                Resource.Attribute.modThemeName, attrValue, true);

            _theme = attrValue.String.ToString();

            /* Create the dialog box based on the current theme              */
            if (_theme == "ModAppCompatLightTheme")
                _dialogBox = new Dialog(Activity, Resource.Style.ModAppCompatLightTheme);
            else
                _dialogBox = new Dialog(Activity, Resource.Style.ModAppCompatDarkTheme);

            _dialogBox.Window.SetContentView(Resource.Layout.SettingsLayout);

            _dialogBox.Window.SetWindowAnimations(Resource.Style.Base_Animation_AppCompat_DropDownUp);
            dialogToolbar = _dialogBox.Window.FindViewById<SupportToolbar>(Resource.Id.toolbar);

            Switch _themeSwitch = _dialogBox.Window.FindViewById<Switch>(Resource.Id.ThemeSwitch);

            if (_theme == "ModAppCompatLightTheme")
                _themeSwitch.Checked = false;
            else
                _themeSwitch.Checked = true;

            _themeSwitch.CheckedChange += ChangeTheme;

            dialogToolbar.SetNavigationIcon(Resource.Drawable.abc_ic_ab_back_material);
            dialogToolbar.Title = "Settings";

            dialogToolbar.NavigationClick += async (navSender, navEvent) =>
            {
                await Task.Delay(150);
                _dialogBox.Dismiss();
            };


            _dialogBox.DismissEvent += DismisDialogBox;

            await Task.Delay(150);
            _dialogBox.Show();
            await Task.Delay(400);
        }

        private void DismisDialogBox(object sender, System.EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("\n\n\n\n\nDialog being dismissed");

            TypedValue attrValue = new TypedValue();
            Activity.Theme.ResolveAttribute(
                Resource.Attribute.modThemeName, attrValue, true);

            string _currentTheme = attrValue.String.ToString();
            string _themeToChange = ThemeSwitcher.GetTheme("THEME");

            System.Diagnostics.Debug.WriteLine($"\n\n\n\n\nCurrent Theme: {_currentTheme}");
            System.Diagnostics.Debug.WriteLine($"\nTheme to change to: {_themeToChange}");

            if (_currentTheme != _themeToChange)
                SetTheme(_themeToChange);
        }

        private void SetTheme(string newTheme)
        {
            Intent intent = new Intent(Activity, Activity.Class);
            Activity.Finish();
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.mod_fadein, Resource.Animation.mod_fadeout);
        }

        private void ChangeTheme(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            ThemeSwitcher.DeleteTheme("THEME");

            if (e.IsChecked == true)
                ThemeSwitcher.SaveTheme("THEME", "ModAppCompatDarkTheme");
            else
                ThemeSwitcher.SaveTheme("THEME", "ModAppCompatLightTheme");
        }
    }
}