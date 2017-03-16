/*****************************************************************************/
/*                             requestsFragment                              */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using System;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Support.V4.Widget;

namespace EaglesNestMobileApp.Android.Views.Campus_Life
{
    public class requestsFragment : Fragment
    {
        public SwipeRefreshLayout RefreshLayout { get; set; }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {

            RefreshLayout.SetColorSchemeResources(Resource.Color.primary,
                Resource.Color.accent, Resource.Color.primary_text,
                    Resource.Color.secondary_text);
            RefreshLayout.Refresh += RefreshLayoutRefresh;


            /* Use this to return your custom view for this Fragment         */
            return inflater.Inflate(Resource.Layout.RequestsFragmentLayout,
                container, false);       
        }

    private void RefreshLayoutRefresh(object sender, EventArgs e)
    {
        /* THIS NEEDS TO BE REMOVED                                      */
        RefreshLayout.Refreshing = false;
    }
}
}