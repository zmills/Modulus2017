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
            string title = (sender as Button).Text;

            /* Disable the button                                            */
            (sender as Button).Enabled = false;

            /* Create the dialog box                                         */
            _dialogBox = new Dialog(Activity, Resource.Style.ModAppCompatLightTheme);
            #region NOT NEEDED
            /*_dialogBox.Window.RequestFeature(WindowFeatures.NoTitle);
            _dialogBox.RequestWindowFeature(1);*/
            #endregion

            /* ViewModel Text must be passed to all these layouts            */
            switch (title)
            {

                case AndroidApp.FacilityCategory.Academics:
                    {
                        _dialogBox.Window.SetContentView(Resource.Layout.AcademicTimesFragmentLayout2);
                    }
                    break;
                case AndroidApp.FacilityCategory.Church:
                    {
                        _dialogBox.Window.SetContentView(Resource.Layout.FacilityTimesChurch);
                    }
                    break;
                case AndroidApp.FacilityCategory.Dining:
                    {
                        _dialogBox.Window.SetContentView(Resource.Layout.FacilityTimesDining);
                    }
                    break;
                case AndroidApp.FacilityCategory.Dorm:
                    {
                        _dialogBox.Window.SetContentView(Resource.Layout.FacilityTimesDorm);
                    }
                    break;
                case AndroidApp.FacilityCategory.Recreation:
                    {
                        _dialogBox.Window.SetContentView(Resource.Layout.FacilityTimesRecreation);
                    }
                    break;
                case AndroidApp.FacilityCategory.Service:
                    {
                        _dialogBox.Window.SetContentView(Resource.Layout.FacilityTimesService);
                    }
                    break;
            }

            _dialogBox.Window.SetWindowAnimations(Resource.Style.Base_Animation_AppCompat_DropDownUp);
            //dialogToolbar = _dialogBox.Window.FindViewById<SupportToolbar>(Resource.Id.toolbar);
            //dialogToolbar.SetNavigationIcon(Resource.Drawable.abc_ic_ab_back_material);
            //dialogToolbar.Title = title;/* Or create a tag for each button and set its tag as the title */
            //dialogToolbar.NavigationClick += async (navSender, navEvent) =>
            //{
            //    await Task.Delay(150);
            //    _dialogBox.Dismiss();
            //};

            await Task.Delay(150);
            _dialogBox.Show();
            await Task.Delay(400);
            (sender as Button).Enabled = true;
        }
    }
}