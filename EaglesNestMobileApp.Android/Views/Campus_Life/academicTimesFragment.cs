/*****************************************************************************/
/*                             attendanceFragment                            */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Widget;

namespace EaglesNestMobileApp.Android.Views.Account
{
    public class academicTimesFragment : Fragment
    {
        View academicTimesView;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater,
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Use this to return your custom view for this Fragment         */
            academicTimesView = inflater.Inflate(Resource.Layout.AcademicTimesFragmentLayout,
                container, false);


            return academicTimesView;
        }
    }
}