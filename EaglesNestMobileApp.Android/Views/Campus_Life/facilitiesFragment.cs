using Android.OS;
using Android.Views;
using Android.Support.V4.App;

namespace EaglesNestMobileApp.Android.Views.Campus_Life
{
    public class facilitiesFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.FacilitiesFragmentLayout, container, false);
        }
    }
}