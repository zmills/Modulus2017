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

namespace EaglesNestMobileApp.Android.Views.Campus_Life
{
    public class facilitiesFragment : Fragment
    {
        View view;

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

            Button _dining = view.FindViewById<Button>(Resource.Id.Dining);
            Button _academics = view.FindViewById<Button>(Resource.Id.Academic);
            Button _church = view.FindViewById<Button>(Resource.Id.Church);
            Button _service = view.FindViewById<Button>(Resource.Id.Service);
            Button _recreation = view.FindViewById<Button>(Resource.Id.Recreation);
            Button _dorm = view.FindViewById<Button>(Resource.Id.Dorm);

            _dining.Click += LoadLayeredFragment;
            _academics.Click += LoadLayeredFragment;
            _church.Click += LoadLayeredFragment;
            _service.Click += LoadLayeredFragment;
            _recreation.Click += LoadLayeredFragment;
            _dorm.Click += LoadLayeredFragment;
            return view;
        }

        private void LoadLayeredFragment(object sender, System.EventArgs e)
        {
            CreateAndShowDialog((sender as Button).Text);
        }

        private void CreateAndShowDialog(string facilityCategory)
        {
            switch (facilityCategory)
            {
                case AndroidApp.FacilityCategory.Academics:
                    {

                    }
                    break;
                case AndroidApp.FacilityCategory.Church:
                    {

                    }
                    break;
                case AndroidApp.FacilityCategory.Dining:
                    {

                    }
                    break;
                case AndroidApp.FacilityCategory.Dorm:
                    {

                    }
                    break;
                case AndroidApp.FacilityCategory.Recreation:

                    break;
                case AndroidApp.FacilityCategory.Service:

                    break;
            }
        }
    }
}