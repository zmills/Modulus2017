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
    public class attendanceFragment : Fragment
    {
        View announcementView;
        //TextView attendanceList;
        //TextView unexcusedAttendanceReport;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Use this to return your custom view for this Fragment         */
            announcementView = inflater.Inflate(Resource.Layout.AttendanceFragmentLayout,
                container, false);

            //attendanceList = announcementView.FindViewById<TextView>(Resource.Id.class1AttendanceUnexcused);
            //unexcusedAttendanceReport = announcementView.FindViewById<TextView>(Resource.Id.attendanceCardClassDetailsTst);

            //attendanceList.Click += AttendanceList_Click;
            return announcementView;
        }

        private void AttendanceList_Click(object sender, System.EventArgs e)
        {
            //if (unexcusedAttendanceReport.Visibility == ViewStates.Gone)
            //    unexcusedAttendanceReport.Visibility = ViewStates.Visible;
            //else
            //    unexcusedAttendanceReport.Visibility = ViewStates.Gone;
        }
    }
}