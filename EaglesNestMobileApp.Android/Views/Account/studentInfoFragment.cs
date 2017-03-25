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

namespace EaglesNestMobileApp.Android.Views.Account
{
    public class studentInfoFragment : Fragment
    {
        public View StudentInfoView { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {
            StudentInfoView = inflater.Inflate(Resource.Layout.StudentInfoFragmentLayout,
                container, false);

            /* Create and set Account Photo circular image */
            Resources _resources = Resources;
            Bitmap _accountPhotoBitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.account_photo);
            ImageView _accountPhotoView = StudentInfoView.FindViewById<ImageView>(Resource.Id.AccountPhoto);
            RoundedBitmapDrawable _drawable = RoundedBitmapDrawableFactory.Create(_resources, _accountPhotoBitmap);
            _drawable.CornerRadius = System.Math.Min(_drawable.MinimumWidth, _drawable.MinimumHeight);
            #region NOTE
            // Use the following only if image has same width and height:
            //     Replace _drawable.CorderRadius = ... with
            //     _drawable.Circular = true;
            #endregion
            _accountPhotoView.SetImageDrawable(_drawable);

            


            /* Use this to return your custom view for this Fragment         */
            return StudentInfoView;
        }
    }
}