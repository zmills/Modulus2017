/*****************************************************************************/
/*                            facilitiesFragment                             */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Widget;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;
using Android.Support.Design.Widget;
using System.Collections.Generic;
using Android.Content;
using EaglesNestMobileApp.Android.Views.Account;
using System;
using Dialog = Android.App.Dialog;
using System.Threading.Tasks;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Graphics.Drawables;
using Android.Support.V7.App;

namespace EaglesNestMobileApp.Android.Views.Campus_Life
{
    public class facilitiesFragment : Fragment
    {
        View view;
        Dialog _dialogBox;
        View toolbarLayout;
        SupportToolbar dialogToolbar;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Use this to return your custom view for this Fragment         */
            view = inflater.Inflate(Resource.Layout.FacilitiesFragmentLayout,
                container, false);

            toolbarLayout = inflater.Inflate(Resource.Layout.ToolbarDialogLayout,
                container, false);

            dialogToolbar = toolbarLayout.FindViewById<SupportToolbar>(Resource.Id.DialogToolbar);

            
            //dialogToolbar.SetNavigationIcon(Resource.Drawable.arrow_up);
            //dialogToolbar.SetTitle(Resource.String.Academic);
            if (dialogToolbar != null)
                dialogToolbar.SetTitle(Resource.String.Academic);

            Activity.RunOnUiThread(() => SetUpFacilitiesLayout());
            return view;
        }

        private void SetUpFacilitiesLayout()
        {
            view.FindViewById<Button>(Resource.Id.Dining).Click += LoadPopUpAsync;
            view.FindViewById<Button>(Resource.Id.Academic).Click += LoadPopUpAsync;
            view.FindViewById<Button>(Resource.Id.Church).Click += LoadPopUpAsync;
            view.FindViewById<Button>(Resource.Id.Service).Click += LoadPopUpAsync;
            view.FindViewById<Button>(Resource.Id.Recreation).Click += LoadPopUpAsync;
            view.FindViewById<Button>(Resource.Id.Dorm).Click += LoadPopUpAsync;
        }

        private async void LoadPopUpAsync(object sender, EventArgs e)
        {
            /* ViewModel Text must be passed to all these layouts                */
            switch ((sender as Button).Text)
            {
                case AndroidApp.FacilityCategory.Academics:
                    {
                        (sender as Button).Enabled = false;
                        _dialogBox = new Dialog(Activity, Resource.Style.ModAppCompatLightTheme);
                        //_dialogBox.Window.RequestFeature(WindowFeatures.NoTitle);
                        _dialogBox.Window.SetContentView(Resource.Layout.AcademicTimesFragmentLayout2);
                        _dialogBox.Window.SetWindowAnimations(Resource.Style.Base_Animation_AppCompat_DropDownUp);
                        await Task.Delay(150);
                        _dialogBox.Show();
                        await Task.Delay(400);
                        (sender as Button).Enabled = true;
                    }
                    break;
                case AndroidApp.FacilityCategory.Church:
                    {
                        (sender as Button).Enabled = false;
                        _dialogBox = new Dialog(Activity, Resource.Style.ModAppCompatLightTheme);
                        _dialogBox.Window.SetContentView(Resource.Layout.FacilityTimesChurch);
                        _dialogBox.Window.SetWindowAnimations(Resource.Style.Base_Animation_AppCompat_DropDownUp);
                        await Task.Delay(150);
                        _dialogBox.Show();
                        await Task.Delay(400);
                        (sender as Button).Enabled = true;
                    }
                    break;
                case AndroidApp.FacilityCategory.Dining:
                    {
                        (sender as Button).Enabled = false;
                        _dialogBox = new Dialog(Activity, Resource.Style.ModAppCompatLightTheme);
                        _dialogBox.Window.SetContentView(Resource.Layout.FacilityTimesDining);
                        _dialogBox.Window.SetWindowAnimations(Resource.Style.Base_Animation_AppCompat_DropDownUp);
                        await Task.Delay(150);
                        _dialogBox.Show();
                        await Task.Delay(400);
                        (sender as Button).Enabled = true;
                    }
                    break;
                case AndroidApp.FacilityCategory.Dorm:
                    {
                        (sender as Button).Enabled = false;
                        _dialogBox = new Dialog(Activity, Resource.Style.ModAppCompatLightTheme);
                        _dialogBox.Window.SetContentView(Resource.Layout.FacilityTimesDorm);
                        _dialogBox.Window.SetWindowAnimations(Resource.Style.Base_Animation_AppCompat_DropDownUp);
                        await Task.Delay(150);
                        _dialogBox.Show();
                        await Task.Delay(400);
                        (sender as Button).Enabled = true;
                    }
                    break;
                case AndroidApp.FacilityCategory.Recreation:
                    {
                        (sender as Button).Enabled = false;
                        _dialogBox = new Dialog(Activity, Resource.Style.ModAppCompatLightTheme);
                        _dialogBox.Window.SetContentView(Resource.Layout.FacilityTimesRecreation);
                        _dialogBox.Window.SetWindowAnimations(Resource.Style.Base_Animation_AppCompat_DropDownUp);
                        await Task.Delay(150);
                        _dialogBox.Show();
                        await Task.Delay(400);
                        (sender as Button).Enabled = true;
                    }
                    break;
                case AndroidApp.FacilityCategory.Service:
                    {
                        (sender as Button).Enabled = false;
                        _dialogBox = new Dialog(Activity, Resource.Style.ModAppCompatLightTheme);
                        _dialogBox.Window.SetContentView(Resource.Layout.FacilityTimesService);
                        _dialogBox.Window.SetWindowAnimations(Resource.Style.Base_Animation_AppCompat_DropDownUp);
                        await Task.Delay(150);
                        _dialogBox.Show();
                        await Task.Delay(400);
                        (sender as Button).Enabled = true;
                    }
                    break;
            }
        }
    }
}