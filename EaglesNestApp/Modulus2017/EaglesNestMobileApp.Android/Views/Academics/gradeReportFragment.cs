/*****************************************************************************/
/*                             gradeReportFragment                           */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace EaglesNestMobileApp.Android.Views.Academics
{
    public class gradeReportFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Use this to return your custom view for this Fragment         */
            return inflater.Inflate(Resource.Layout.GradeReportFragmentLayout, 
                container, false);
        }
    }
}