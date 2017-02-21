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
        private List<Card> announcements = new List<Card>();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            InitializeAnnouncements();
            // announcements would be set to the cards in the viewmodel here
        }

        private void InitializeAnnouncements()
        {
            announcements = new List<Card>();

            int[] card_images = new int[5];
            card_images[0] = Resource.Drawable.BroomHockeyAllStarCons1;
            card_images[1] = Resource.Drawable.CLEvent1;
            card_images[2] = Resource.Drawable.FreshmanMidnightMadnessSignup1;
            card_images[3] = Resource.Drawable.Nov28MissionPrayerBand1;
            card_images[4] = Resource.Drawable.SubmitStudentPhotosFall2;

            for (int i = 0; i < 40; i++)
            {
                int y = i % 5;

                Card x = new Card("item" + i, card_images[y]);
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