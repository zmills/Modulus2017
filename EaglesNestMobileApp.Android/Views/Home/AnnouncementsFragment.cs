/*****************************************************************************/
/*                           announcementsFragment                           */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using EaglesNestMobileApp.Android.Adapters;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using System;
using EaglesNestMobileApp.Core.Model;
using Java.Lang;
using System.Threading;
using Android.Graphics;
using Android.Widget;

namespace EaglesNestMobileApp.Android.Views.Home
{
    public class announcementsFragment : Fragment
    {
        /* Public properties                                                 */
        /* This will bind to the list in the viewmodel                       */
        public List<Card> Announcements { get; set; }
        public RecyclerView AnnouncementRecyclerView { get; set; }
        public announcementsRecyclerViewAdapter AnnouncementAdapter { get; set; }
        public RecyclerView.LayoutManager AnnouncementLayoutManager { get; set; }
        public View AnnouncementsView { get; set; }
        public SwipeRefreshLayout RefreshLayout { get; set; }
        public TabLayout TabLayout { get; set; }
        


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            /* Get the announcements. Announcements would be set to the      */
            /* cards inside the viewmodel here                               */
            InitializeAnnouncements();
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup parent, Bundle savedInstanceState)
        {
            /* Inflate the layout for the fragment                           */
            AnnouncementsView = inflater.Inflate(
                Resource.Layout.AnnouncementsFragmentLayout, parent, false);

            /* Get the recyclerview layout                                   */
            AnnouncementRecyclerView = 
                AnnouncementsView.FindViewById<RecyclerView>(
                    Resource.Id.AnnouncementsRecyclerView);

            /* Create a new layout manager using the activity containing     */
            /* this fragment as the context                                  */
            AnnouncementLayoutManager = new LinearLayoutManager(Activity);

            /* Create a custom adapter and pass it the data that it will be  */
            /* recycling through                                             */
            AnnouncementAdapter = 
                new announcementsRecyclerViewAdapter(Activity as mainActivity, Announcements);
            /* Helps with performance: HasStableIds = true 
               ALTHOUGH FOR NOW, DO NOT INCLUDE THIS: DATA DOES NOT DISPLAY 
               CORRECTLY                                                     */
            //AnnouncementAdapter.HasStableIds = true;

            /* Selecting the tab will automatically scroll back to the top   */
            /* of the list                                                   */
            TabLayout = ParentFragment.View.FindViewById<TabLayout>(
                Resource.Id.MainTabLayout);
            TabLayout.TabReselected += TabReselected;

            /* "Pulling" down on the page will refresh the view              */
            RefreshLayout =
                AnnouncementsView.FindViewById<SwipeRefreshLayout>(
                    Resource.Id.SwipeRefreshAnnouncements);

            RefreshLayout.SetColorSchemeResources(Resource.Color.primary,
                Resource.Color.accent, Resource.Color.primary_text,
                    Resource.Color.secondary_text);
            RefreshLayout.Refresh += RefreshLayoutRefresh;

            /* Setup the recyclerview with the created adapter and layout    */
            /* manager                                                       */
            AnnouncementRecyclerView.SetLayoutManager(AnnouncementLayoutManager);
            AnnouncementRecyclerView.SetAdapter(AnnouncementAdapter);

            /* Notifies Adapter that the data set has changed (Important)    */
            //AnnouncementAdapter.NotifyDataSetChanged();
            //AnnouncementRecyclerView.GetAdapter().NotifyDataSetChanged();
            /* (Important)                                                   */
            //AnnouncementRecyclerView.Post(() => AnnouncementAdapter.NotifyDataSetChanged());
            //AnnouncementRecyclerView.Post(() => AnnouncementRecyclerView.GetAdapter().NotifyDataSetChanged());
            
           
            return AnnouncementsView;
        }

        private void RefreshLayoutRefresh(object sender, EventArgs e)
        {
            /* THIS NEEDS TO BE REMOVED                                      */
            InitializeAnnouncementsTEST();
            RefreshLayout.Refreshing = false;
        }

        private void InitializeAnnouncementsTEST()
        {
            Announcements.Clear();
            

            /* Create an array of images                                     */
            int[] _card_images = new int[5];
            _card_images[0] = Resource.Drawable.BroomHockeyAllStarCons1;
            _card_images[1] = Resource.Drawable.FreshmanMidnightMadnessSignup1;
            _card_images[2] = Resource.Drawable.BroomHockeyAllStarCons1;
            _card_images[3] = Resource.Drawable.FreshmanMidnightMadnessSignup1;
            _card_images[4] = Resource.Drawable.BroomHockeyAllStarCons1;

            /* Loop through inserting cards in the announcements list after  */
            /* titling them and providing an image                           */
            for (int counter = 0; counter < 40; counter++)
            {
                int index = counter % 5;

                Card current = new Card("Item " + counter, _card_images[index]);
                Announcements.Add(current);
            }
            AnnouncementAdapter.NotifyDataSetChanged();
        }

        /* Scroll up to the top of the page if the "Announcements" layout is */
        /* selected                                                          */
        private void TabReselected(object sender, 
            TabLayout.TabReselectedEventArgs e)
        {
            if (e.Tab.Text == "Announcements")
            {
                if (AnnouncementAdapter.ViewPosition >= 10)
                    AnnouncementRecyclerView.ScrollToPosition(10);
                AnnouncementRecyclerView.SmoothScrollToPosition(0);
            }
        }

        /* THIS NEEDS TO BE MOVED TO THE VIEWMODEL                           */
        private void InitializeAnnouncements()
        {
            Announcements = new List<Card>();

            /* Create an array of images                                     */
            int[] _card_images = new int[5];
            _card_images[0] = Resource.Drawable.BroomHockeyAllStarCons1;
            _card_images[1] = Resource.Drawable.CLEvent1;
            _card_images[2] = Resource.Drawable.FreshmanMidnightMadnessSignup1;
            _card_images[3] = Resource.Drawable.Nov28MissionPrayerBand1;
            _card_images[4] = Resource.Drawable.SubmitStudentPhotosFall2;

            /* Loop through inserting cards in the announcements list after  */
            /* titling them and providing an image                           */
            for (int counter = 0; counter < 40; counter++)
            {
                int index = counter % 5;

                Card current = new Card("Item " + counter, _card_images[index]);
                Announcements.Add(current);
            }
        }
    }
}