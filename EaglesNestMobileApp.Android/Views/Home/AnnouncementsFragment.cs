using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using EaglesNestMobileApp.Android.Cards;
using EaglesNestMobileApp.Android.Adapters;
using System;

namespace EaglesNestMobileApp.Android.Views.Home
{
    public class announcementsFragment : Fragment
    {
        private RecyclerView announceRecyclerView;
        private RecyclerView.Adapter announceAdapter;
        private RecyclerView.LayoutManager announceLayoutManager;
        private List<AnnouncementCard> announcements = new List<AnnouncementCard>();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            InitializeAnnouncements();
            // announcements would be set to the cards in the viewmodel here
        }

        // These announcements are to be gotten from the viewmodel
        private void InitializeAnnouncements()
        {
            announcements = new List<AnnouncementCard>();

            for (int i = 0; i <= 40; i++)
            {
                AnnouncementCard x = new AnnouncementCard("item" + i, Resource.Drawable.logo);
                announcements.Add(x);
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View announcementsView = inflater.Inflate(Resource.Layout.AnnouncementsFragmentLayout, container, false);

            announceRecyclerView = announcementsView.FindViewById<RecyclerView>(Resource.Id.AnnouncementsRecyclerView);

            announceLayoutManager = new LinearLayoutManager(Activity);

            announceAdapter = new announcementsRecyclerViewAdapter(announcements);

            announceRecyclerView.SetLayoutManager(announceLayoutManager);

            announceRecyclerView.SetAdapter(announceAdapter);
            
            return announcementsView;
        }
    }
}