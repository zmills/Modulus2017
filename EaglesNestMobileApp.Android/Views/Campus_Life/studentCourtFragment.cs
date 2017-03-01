/*****************************************************************************/
/*                           studentCourtFragment                            */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using System;
using Android.Widget;
using Android.Support.V7.Widget;

namespace EaglesNestMobileApp.Android.Views.Campus_Life
{
    public class studentCourtFragment : Fragment
    {
        public SwipeRefreshLayout RefreshLayout { get; set; }
        public View StudentCourtView { get; set; }
        public TextView PendingHeader { get; set; }
        public CardView StatusCard { get; set; }
        public TextView Infraction { get; set; }
        public CardView InfractionCard { get; set; }



        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {

            StudentCourtView = inflater.Inflate(Resource.Layout.StudentCourtFragmentLayout,
                container, false);
            /* "Pulling" down on the page will refresh the view              */
            RefreshLayout =
                StudentCourtView.FindViewById<SwipeRefreshLayout>(
                    Resource.Id.SwipeRefreshStudentCourt);

            PendingHeader = StudentCourtView.FindViewById<TextView>(Resource.Id.studentCourtInfractionBanner);
           PendingHeader.Visibility = ViewStates.Invisible;

            StatusCard = StudentCourtView.FindViewById<CardView>(Resource.Id.StudentCourtCard);
            Infraction = StudentCourtView.FindViewById<TextView>(Resource.Id.infraction1);
            InfractionCard = StudentCourtView.FindViewById<CardView>(Resource.Id.infraction1Card);
            InfractionCard.Visibility = ViewStates.Invisible;



            RefreshLayout.SetColorSchemeResources(Resource.Color.primary,
                Resource.Color.accent, Resource.Color.primary_text,
                    Resource.Color.secondary_text);
            RefreshLayout.Refresh += RefreshLayoutRefresh;


            /* Use this to return your custom view for this Fragment         */
            return StudentCourtView;
        }

        private void RefreshLayoutRefresh(object sender, EventArgs e)
        {
            /* THIS NEEDS TO BE REMOVED                                      */

            
            StatusCard.SetCardBackgroundColor(Resource.Color.red_screenaaa);
            Infraction.Text = "You are required to go to student court";
            PendingHeader.Visibility = ViewStates.Visible;
            InfractionCard.Visibility = ViewStates.Visible;
            

            RefreshLayout.Refreshing = false;
        }
    }
}