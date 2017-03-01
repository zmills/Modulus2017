/*****************************************************************************/
/*                              grabNGoFragment                              */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
namespace EaglesNestMobileApp.Android.Views.Dining
{
    public class grabNGoFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Use this to return your custom view for this Fragment         */
            return inflater.Inflate(Resource.Layout.GrabNGoFragmentLayout, 
                container, false);
        }
    }
}