/*****************************************************************************/
/*                              scheduleFragment                             */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using EaglesNestMobileApp.Core.ViewModel.AccountViewModels;
using EaglesNestMobileApp.Core;

namespace EaglesNestMobileApp.Android.Views.Account
{
    public class scheduleFragment : Fragment
    {
        public ScheduleFragmentViewModel ViewModel
        {
            get { return App.Locator.StudentSchedule; }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Use this to return your custom view for this Fragment         */
            return inflater.Inflate(Resource.Layout.ScheduleFragmentLayout, 
                container, false);
        }
    }
}