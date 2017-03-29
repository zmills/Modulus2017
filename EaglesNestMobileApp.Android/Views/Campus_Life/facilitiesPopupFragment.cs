using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Widget;

namespace EaglesNestMobileApp.Android.Views.Campus_Life
{
    class facilitiesPopupFragment : Fragment
    {
        View facilitiesPopupView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater,
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Use this to return your custom view for this Fragment         */
            facilitiesPopupView = inflater.Inflate(Resource.Layout.AttendanceFragmentLayout,
                container, false);

            return facilitiesPopupView;
        }
    }
}