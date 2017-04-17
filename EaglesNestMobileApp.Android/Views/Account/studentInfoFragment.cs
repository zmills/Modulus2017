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
using Dialog = Android.App.Dialog;
using System.Threading;
using EaglesNestMobileApp.Core.ViewModel;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;

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

        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        //MARCELINO USE THIS TO DECIDE WHICH PICTURE TO LOAD
        private string userIdNumber;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
            userIdNumber = ViewModel.CurrentUser.Id;
        }


        public override View OnCreateView(LayoutInflater inflater,
            ViewGroup container, Bundle savedInstanceState)
        {
            StudentInfoView = inflater.Inflate(Resource.Layout.StudentInfoFragmentLayout,
                container, false);

            StudentInfoView.FindViewById<Button>(Resource.Id.BoxCombinationInstructions)
                .SetCommand("Click", ViewModel.ShowBoxCombinationCommand);

            StudentInfoView.FindViewById<Button>(Resource.Id.StudentChecksheet)
                .SetCommand("Click", ViewModel.ShowChecksheetCommand);

            StudentInfoView.FindViewById<Button>(Resource.Id.MessagingAndTelephoneInstructions)
                .SetCommand("Click", ViewModel.ShowTelephoneInstructionsCommand);

            ImageView _accountPhotoView =
                StudentInfoView.FindViewById<ImageView>(Resource.Id.AccountPhoto);

            RoundedBitmapDrawable _drawable = null;

            switch (userIdNumber)
            {
                case "130000":
                    {
                        _drawable = RoundedBitmapDrawableFactory.Create(
                            Resources, BitmapFactory.DecodeResource(
                                Resources, Resource.Drawable.abby));
                    }
                    break;
                case "124801":
                    {
                        _drawable = RoundedBitmapDrawableFactory.Create(
                            Resources, BitmapFactory.DecodeResource(
                                Resources, Resource.Drawable.becki));
                    }
                    break;
                case "118965":
                    {
                        _drawable = RoundedBitmapDrawableFactory.Create(
                            Resources, BitmapFactory.DecodeResource(
                                Resources, Resource.Drawable.account_photo));
                    }
                    break;
                case "123456":
                    {
                        _drawable = RoundedBitmapDrawableFactory.Create(
                            Resources, BitmapFactory.DecodeResource(
                                Resources, Resource.Drawable.nick));
                    }
                    break;

            }

            _drawable.CornerRadius = Math.Min(_drawable.MinimumWidth, _drawable.MinimumHeight);

            Activity.RunOnUiThread(() =>
            {
                _accountPhotoView.SetImageDrawable(_drawable);
            });

            //Resources _resources = Resources;
            //Bitmap _accountPhotoBitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.account_photo);
            ///*SEPARATE THREAD*/ ImageView _accountPhotoView = StudentInfoView.FindViewById<ImageView>(Resource.Id.AccountPhoto);
            //RoundedBitmapDrawable _drawable = RoundedBitmapDrawableFactory.Create(Resources,
            //    BitmapFactory.DecodeResource(Resources, Resource.Drawable.account_photo));
            //_drawable.CornerRadius = System.Math.Min(_drawable.MinimumWidth, _drawable.MinimumHeight);
            #region NOTE
            // Use the following only if image has same width and height:
            //     Replace _drawable.CorderRadius = ... with
            //     _drawable.Circular = true;
            #endregion

            ParentFragment.View.FindViewById<TabLayout>(
                Resource.Id.MainTabLayout).TabReselected += TabReselected;

            SetStudentInfo();

            /* Use this to return your custom view for this Fragment         */
            return StudentInfoView;
        }

        private void TabReselected(object sender,
           TabLayout.TabReselectedEventArgs e)
        {
            if (e.Tab.Text == "Student Info")
            {
                StudentInfoView.FindViewById<NestedScrollView>(Resource.Id.StudentScrollview).SmoothScrollTo(0, 0);
            }
        }

        private void SetStudentInfo()
        {
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentFullName)
                .Text = ViewModel.CurrentUser.FormattedName;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentId)
                .Text = ViewModel.CurrentUser.Id;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentMajor)
                .Text = ViewModel.CurrentUser.MajorName;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentMinor)
                .Text = ViewModel.CurrentUser.MinorName;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentRoom)
                .Text = ViewModel.CurrentUser.FormattedRoom;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentMailbox)
                .Text = ViewModel.CurrentUser.BoxNumber;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentBoxCombination)
                .Text = ViewModel.CurrentUser.BoxCombination;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentCollegianName)
                .Text = ViewModel.CurrentUser.FormattedCollegian;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentCollegianLocation)
                .Text = ViewModel.CurrentUser.CollegianLocation;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentChapelSeatSection)
                .Text = ViewModel.CurrentUser.FormattedChapelSection;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentChapelSeatRowNumber)
                .Text = ViewModel.CurrentUser.FormattedChapelRow;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentEmail)
                .Text = ViewModel.CurrentUser.StudentEmail;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentRoomPhone)
                .Text = ViewModel.CurrentUser.FormattedRoomPhone;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentSchoolAddress)
                .Text = ViewModel.CurrentUser.FormattedStudentAddress;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentPersonalEmail)
                .Text = ViewModel.CurrentUser.PersonalEmail;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentCellphone)
                .Text = ViewModel.CurrentUser.FormattedCellPhone;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentHomeAddress)
                .Text = ViewModel.CurrentUser.FormattedAddress;
        }
    }
}