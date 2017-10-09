/*****************************************************************************/
/*                             calendarFragment                              */
/*                                                                           */
/*****************************************************************************/

using Android.OS;
using Android.Views;
using Android.Support.V4.App;

namespace EaglesNestMobileApp.Android.Views.Home
{
    public class calendarFragment : Fragment
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
            return inflater.Inflate(Resource.Layout.CalendarFragmentLayout, 
                                       container, false);
        }
    }
}