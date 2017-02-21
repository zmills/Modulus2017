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
        // Public accessors
        public List<Card> Announcements { get; set; } // This will bind to the list in the viewmodel
        public RecyclerView AnnouncementRecyclerView { get; set; }
        public RecyclerView.Adapter AnnouncementAdapter { get; set; }
        public RecyclerView.LayoutManager AnnouncementLayoutManager { get; set; }
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Get the announcements. Announcements would be set to the cards inside the viewmodel here
            InitializeAnnouncements();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Inflate the layout for the fragment
            View _announcementsView  = inflater.Inflate(Resource.Layout.AnnouncementsFragmentLayout, container, false);

            // Get the view pager
            AnnouncementRecyclerView = _announcementsView.FindViewById<RecyclerView>(Resource.Id.AnnouncementsRecyclerView);

            // Create a new layout manager using the activity containing this fragment as the context
            AnnouncementLayoutManager = new LinearLayoutManager(Activity);

            // Create a custom adapter and pass it the data that it will be recycling through
            AnnouncementAdapter = new announcementsRecyclerViewAdapter(Announcements);

            // Setup the recyclerview with the created adapter and layout manager
            AnnouncementRecyclerView.SetLayoutManager(AnnouncementLayoutManager);
            AnnouncementRecyclerView.SetAdapter(AnnouncementAdapter);
            return _announcementsView;
        }

        // THIS NEEDS TO BE MOVED TO THE VIEWMODEL
        private void InitializeAnnouncements()
        {
            Announcements = new List<Card>();

            // Create an array of images
            int[] _card_images = new int[5];
            _card_images[0] = Resource.Drawable.BroomHockeyAllStarCons1;
            _card_images[1] = Resource.Drawable.CLEvent1;
            _card_images[2] = Resource.Drawable.FreshmanMidnightMadnessSignup1;
            _card_images[3] = Resource.Drawable.Nov28MissionPrayerBand1;
            _card_images[4] = Resource.Drawable.SubmitStudentPhotosFall2;

            // Loop through inserting cards in the announcements list after titling them and providing an image
            for (int counter = 0; counter < 40; counter++)
            {
                int index = counter % 5;

                Card current = new Card("Item " + counter, _card_images[index]);
                Announcements.Add(current);
            }
        }
    }
}