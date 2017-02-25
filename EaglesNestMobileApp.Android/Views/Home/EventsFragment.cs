using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using EaglesNestMobileApp.Android.Cards;
using EaglesNestMobileApp.Android.Adapters;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using System;
using EaglesNestMobileApp.Core.Model;

namespace EaglesNestMobileApp.Android.Views.Home
{
    public class eventsFragment : Fragment
    {
        public List<Card> Events { get; set; } // This will bind to the list in the viewmodel
        public RecyclerView EventSignUpRecyclerView { get; set; }
        public RecyclerView.Adapter eventSignUpAdapter { get; set; }
        public RecyclerView.LayoutManager eventSignUpLayoutManager { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            InitializeEvents();

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Inflate the layout for the fragment
            View _eventSignUpView = inflater.Inflate(Resource.Layout.EventsFragmentLayout, container, false);

            // Get the view pager
            EventSignUpRecyclerView = _eventSignUpView.FindViewById<RecyclerView>(Resource.Id.EventSignUpRecyclerView);

            // Create a new layout manager using the activity containing this fragment as the context
            eventSignUpLayoutManager = new LinearLayoutManager(Activity);

            // Create a custom adapter and pass it the data that it will be recycling through
            eventSignUpAdapter = new announcementsRecyclerViewAdapter(Events);

            // Selecting the tab will automatically scroll back to the top of the list
            TabLayout _tabLayout = ParentFragment.View.FindViewById<TabLayout>(Resource.Id.MainTabLayout);
            _tabLayout.TabReselected += TabReselected;

            // Setup the recyclerview with the created adapter and layout manager
            EventSignUpRecyclerView.SetLayoutManager(eventSignUpLayoutManager);
            EventSignUpRecyclerView.SetAdapter(eventSignUpAdapter);
            return _eventSignUpView;
        }

        private void TabReselected(object sender, TabLayout.TabReselectedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void InitializeEvents()
        {
            Events = new List<Card>();

            // Create an array of Events
            int[] _card_events = new int[2];


            // Loop through inserting cards in the announcements list after titling them and providing an image
            for (int counter = 0; counter < 1; counter++)
            {
                Card current = new Card("Event " + counter + "event text");
               Events.Add(current);
            }
        }
    }
}