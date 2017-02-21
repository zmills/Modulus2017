using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using EaglesNestMobileApp.Android.Cards;
using EaglesNestMobileApp.Android.Adapters;

namespace EaglesNestMobileApp.Android.Views.Home
{
    public class announcementsFragment : Fragment
    {
        private RecyclerView announceRecyclerView;
        private RecyclerView.Adapter announceAdapter;
        private RecyclerView.LayoutManager announceLayoutManager;
        private List<Card> announcements;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // announcements would be set to the cards in the viewmodel here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View announcementsView = inflater.Inflate(Resource.Layout.AnnouncementsFragmentLayout, container, false);

            announceRecyclerView = announcementsView.FindViewById<RecyclerView>(Resource.Id.AnnouncementsRecyclerView);

            announceLayoutManager = new LinearLayoutManager(Activity);

            announceAdapter = new announcementsRecyclerViewAdapter();

            announceRecyclerView.SetAdapter(announceAdapter);
            
            return announcementsView;
        }
    }
}