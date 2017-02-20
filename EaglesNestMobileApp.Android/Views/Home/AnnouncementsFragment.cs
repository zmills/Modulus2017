using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V7.Widget;

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

            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.AnnouncementsFragmentLayout, container, false);
        }
    }
}