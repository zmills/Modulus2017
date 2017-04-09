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
            RetainInstance = true;
            //UserVisibleHint = true;
        }


        public override View OnCreateView(LayoutInflater inflater,
            ViewGroup container, Bundle savedInstanceState)
        {
            StudentInfoView = inflater.Inflate(Resource.Layout.StudentInfoFragmentLayout,
                container, false);

            StudentInfoView.FindViewById<Button>(Resource.Id.BoxCombinationInstructions).Click += ShowCombination;

            ImageView _accountPhotoView = StudentInfoView.FindViewById<ImageView>(Resource.Id.AccountPhoto);
            RoundedBitmapDrawable _drawable = RoundedBitmapDrawableFactory.Create(Resources,
                    BitmapFactory.DecodeResource(Resources, Resource.Drawable.account_photo));
            _drawable.CornerRadius = System.Math.Min(_drawable.MinimumWidth, _drawable.MinimumHeight);

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
            /*UI THREAD*/

            //Activity.RunOnUiThread(()=>SetStudentInfo());


            /* Use this to return your custom view for this Fragment         */
            return StudentInfoView;
        }

        private void ShowCombination(object sender, EventArgs e)
        {
            Dialog dialogBox = new Dialog(Activity, Resource.Style.Base_V7_Theme_AppCompat);
            dialogBox.SetContentView(Resource.Layout.BoxCombinationDialogLayout);
            dialogBox.FindViewById<TextView>(Resource.Id.BoxCombinationText).Text =
                ViewModel.BoxCombinationInstructions;
            dialogBox.Show();

        }

        private void SetStudentInfo()
        {
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentFullName).Text = ViewModel.CurrentUser.FormattedName;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentId).Text = ViewModel.CurrentUser.Id;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentMajor).Text = ViewModel.CurrentUser.MajorName;

            /* A MINOR NEEDS TO BE ADDED TO THE STUDENT CLASS*/
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentMinor).Text = ViewModel.CurrentUser.MajorName;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentRoom).Text = ViewModel.CurrentUser.RoomNumber;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentMailbox).Text = ViewModel.CurrentUser.BoxNumber;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentBoxCombination).Text = ViewModel.CurrentUser.BoxCombination;

            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentCollegianName).Text = $"{ViewModel.CurrentUser.CollegianName} {ViewModel.CurrentUser.CollegianMascot}";
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentCollegianLocation).Text = ViewModel.CurrentUser.CollegianLocation;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentChapelSeatSection).Text = ViewModel.CurrentUser.FormattedChapelSeat;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentChapelSeatRowNumber).Text = ViewModel.CurrentUser.FormattedChapelSeat;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentEmail).Text = ViewModel.CurrentUser.StudentEmail;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentRoomPhone).Text = ViewModel.CurrentUser.RoomNumber;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentSchoolAddress).Text = ViewModel.CurrentUser.FormattedAddress;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentPersonalEmail).Text = ViewModel.CurrentUser.PersonalEmail;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentCellphone).Text = ViewModel.CurrentUser.CellPhone;
            StudentInfoView.FindViewById<TextView>(Resource.Id.StudentHomeAddress).Text = ViewModel.CurrentUser.FormattedAddress;
        }
    }
}