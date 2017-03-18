/*****************************************************************************/
/*                              eventsFragment                               */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using EaglesNestMobileApp.Android.Adapters;
using Android.Support.Design.Widget;
using EaglesNestMobileApp.Core.Model;
using EaglesNestMobileApp.Core.Model.Home;

namespace EaglesNestMobileApp.Android.Views.Home
{
    public class eventsFragment : Fragment
    {
        /* This will bind to the list in the viewmodel                       */
        public List<EventsSignUpCard> Events { get; set; }
        public RecyclerView EventSignUpRecyclerView { get; set; }
        public eventSignUpRecyclerViewAdapter EventSignUpAdapter { get; set; }
        public RecyclerView.LayoutManager EventSignUpLayoutManager { get; set; }
        public TabLayout TabLayout { get; set; }
        public View EventSignUpView { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            /* Create your fragment here                                     */
            InitializeEvents();
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {
            // Inflate the layout for the fragment
            EventSignUpView = 
                inflater.Inflate(Resource.Layout.EventsFragmentLayout, 
                                    container, false);

            /* Get the view pager                                            */
            EventSignUpRecyclerView = 
                EventSignUpView.FindViewById<RecyclerView>(
                    Resource.Id.EventSignUpRecyclerView);

            /* Create a new layout manager using the activity containing     */
            /* this fragment as the context                                  */
            EventSignUpLayoutManager = new LinearLayoutManager(Activity);

            /* Create a custom adapter and pass it the data that it will be  */
            /* recycling through                                             */
            EventSignUpAdapter = new eventSignUpRecyclerViewAdapter(Events);

            /* Selecting the tab will automatically scroll back to the top   */
            /* of the list                                                   */
            TabLayout = 
                ParentFragment.View.FindViewById<TabLayout>(
                    Resource.Id.MainTabLayout);
            TabLayout.TabReselected += TabReselected;

            /* Setup the recyclerview with the created adapter and layout    */
            /* manager                                                       */
            EventSignUpRecyclerView.SetLayoutManager(EventSignUpLayoutManager);
            EventSignUpRecyclerView.SetAdapter(EventSignUpAdapter);
            return EventSignUpView;
        }

        private void TabReselected(object sender, 
                                      TabLayout.TabReselectedEventArgs Event)
        {
            if (Event.Tab.Text == "Events Signup")
            {
                if (EventSignUpAdapter.ViewPosition >= 10)
                    EventSignUpRecyclerView.ScrollToPosition(10);

                EventSignUpRecyclerView.SmoothScrollToPosition(0);
            }
        }

        private void InitializeEvents()
        {
            Events = new List<EventsSignUpCard>();

            /* Loop through inserting cards in the announcements list after  */
            /* titling them and providing an image                           */
            for (int counter = 0; counter < 20; counter++)
            {
                EventsSignUpCard current = 
                    new EventsSignUpCard("Event " + counter,
                                            "Event Description", "SIGNUP");
               Events.Add(current);
            }
        }
    }
}