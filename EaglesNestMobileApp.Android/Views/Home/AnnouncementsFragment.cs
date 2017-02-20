using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Support.V7.Content;

namespace EaglesNestMobileApp.Android.Views.Home
{
    public class announcementsFragment : Fragment
    {
        private RecyclerView announceRecyclerView;
        private RecyclerView.Adapter announceAdapter;
        private RecyclerView.LayoutManager announceLayoutManager;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View announcementsView = inflater.Inflate(Resource.Layout.AnnouncementsFragmentLayout, container, false);

            announceRecyclerView = announcementsView.FindViewById<RecyclerView>(Resource.Id.AnnouncementsRecyclerView);

            announceLayoutManager = new LinearLayoutManager(Activity);

            announceRecyclerView.SetLayoutManager(announceLayoutManager);

            // Use this to return your custom view for this Fragment
            return announcementsView;
        }
    }
}