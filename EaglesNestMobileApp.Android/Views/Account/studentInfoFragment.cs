/*****************************************************************************/
/*                            studentInfoFragment                            */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Widget;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Graphics.Drawable;
using Android.Content.Res;
using EaglesNestMobileApp.Core.ViewModel.AccountViewModels;
using EaglesNestMobileApp.Core;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Helpers;
using System;

namespace EaglesNestMobileApp.Android.Views.Account
{
    public class studentInfoFragment : Fragment
    {
        public View StudentInfoView { get; set; }

        List<Binding> _bindings = new List<Binding>();

        public StudentInfoFragmentViewModel ViewModel
        {
            get { return App.Locator.StudentInfo; }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {
            StudentInfoView = inflater.Inflate(Resource.Layout.StudentInfoFragmentLayout,
                container, false);

            /* Display the student photo                                       */
            Activity.RunOnUiThread(()=>RenderBitmap());

            //sActivity.RunOnUiThread(()=>SetStudentInfo());
            
            /* Use this to return your custom view for this Fragment         */
            return StudentInfoView;
        }

        private void RenderBitmap()
        {
            /* Tried to refactor. MARCELINO NEEDS TO LOOK AT THIS !!!!!!!!!!!*/
            /* See note and commented out code for detailed approach         */
            //Resources _resources = Resources;
            RoundedBitmapDrawable _drawable =
                RoundedBitmapDrawableFactory.Create(Resources,
                    BitmapFactory.DecodeResource(Resources,
                        Resource.Drawable.account_photo));

            _drawable.CornerRadius = Math.Min(_drawable.MinimumWidth, _drawable.MinimumHeight);
            StudentInfoView.FindViewById<ImageView>(Resource.Id.AccountPhoto).SetImageDrawable(_drawable);
            
            ///* Create and set Account Photo circular image */
            //Resources _resources = Resources;
            //Bitmap _accountPhotoBitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.account_photo);
            //ImageView _accountPhotoView = StudentInfoView.FindViewById<ImageView>(Resource.Id.AccountPhoto);
            //RoundedBitmapDrawable _drawable = RoundedBitmapDrawableFactory.Create(_resources, _accountPhotoBitmap);
            //_drawable.CornerRadius = System.Math.Min(_drawable.MinimumWidth, _drawable.MinimumHeight);
            //#region NOTE
            //// Use the following only if image has same width and height:
            ////     Replace _drawable.CorderRadius = ... with
            ////     _drawable.Circular = true;
            //#endregion
            //_accountPhotoView.SetImageDrawable(_drawable);
        }

        private void SetStudentInfo()
        {
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.AddressLineOne;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.AddressLineTwo;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.BoxCombination;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.BoxNumber;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.CellPhone;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.City;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.Classification;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.CollegianLocation;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.CollegianMascot;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.CollegianName;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.Country;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.DegreeName;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.DoorNumber;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.Dorm;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.FirstName;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.Id;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.LastName;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.MajorName;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.MiddleName;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.PersonalEmail;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.PreferredName;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.RoomNumber;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.Row;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.SeatNumber;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.Section;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.State;
            //StudentInfoView.FindViewById<TextView>(Resource.Id).Text = ViewModel.CurrentUser.StudentEmail;
        }
    }
}