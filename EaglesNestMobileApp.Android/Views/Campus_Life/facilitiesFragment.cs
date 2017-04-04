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

namespace EaglesNestMobileApp.Android.Views.Campus_Life
{
    public class facilitiesFragment : Fragment
    {
        View view;
        Dialog _dialogBox;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
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
            /* ViewModel Text must be passed to all these layouts                */
            switch ((sender as Button).Text)
            {
                case AndroidApp.FacilityCategory.Academics:
                    {
                        _dialogBox = new Dialog(Activity, Resource.Style.ModAppCompatLightTheme);
                        _dialogBox.Show();
                        await Task.Delay(5000);
                        _dialogBox.Dismiss();
                    }
                    break;
                case AndroidApp.FacilityCategory.Church:
                    {
                        _dialogBox = new Dialog(Activity, Resource.Style.ModAppCompatLightTheme);
                        _dialogBox.SetContentView(Resource.Layout.FacilitiesTimeChurch);
                        _dialogBox.Show();
                        await Task.Delay(5000);
                        _dialogBox.Dismiss();
                    }
                    break;
                case AndroidApp.FacilityCategory.Dining:
                    {
                        _dialogBox = new Dialog(Activity, Resource.Style.ModAppCompatLightTheme);
                        _dialogBox.Show();
                        await Task.Delay(5000);
                        _dialogBox.Dismiss();
                    }
                    break;
                case AndroidApp.FacilityCategory.Dorm:
                    {
                        _dialogBox = new Dialog(Activity, Resource.Style.ModAppCompatLightTheme);
                        _dialogBox.Show();
                        await Task.Delay(5000);
                        _dialogBox.Dismiss();
                    }
                    break;
                case AndroidApp.FacilityCategory.Recreation:
                    {
                        _dialogBox = new Dialog(Activity, Resource.Style.ModAppCompatLightTheme);
                        _dialogBox.Show();
                        await Task.Delay(5000);
                        _dialogBox.Dismiss();
                    }
                    break;
                case AndroidApp.FacilityCategory.Service:
                    {
                        _dialogBox = new Dialog(Activity, Resource.Style.ModAppCompatLightTheme);
                        _dialogBox.Show();
                        await Task.Delay(5000);
                        _dialogBox.Dismiss();
                    }
                    break;
            }
        }
    }
}