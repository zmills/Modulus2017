using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using EaglesNestMobileApp.Android.Cards;
using EaglesNestMobileApp.Android.Adapters;
using Android.Support.Design.Widget;
using System;

namespace EaglesNestMobileApp.Android.Views.Academics
{
    public class gradesFragment : Fragment
    {
        // Public accessors
        public List<Card> GradesCardList { get; set; } // This will bind to the list in the viewmodel
        public RecyclerView GradesRecyclerView { get; set; }
        public gradesRecyclerViewAdapter GradesAdapter { get; set; }
        public RecyclerView.LayoutManager GradesLayoutManager { get; set; }
        public View GradesView { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            InitializeGrades();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Inflate the layout for the fragment
            GradesView = inflater.Inflate(Resource.Layout.GradesFragmentLayout, container, false);

            // Get the view pager
            GradesRecyclerView = GradesView.FindViewById<RecyclerView>(Resource.Id.GradesRecyclerView);

            // Create a new layout manager using the activity containing this fragment as the context
            GradesLayoutManager = new LinearLayoutManager(Activity);

            // Create a custom adapter and pass it the data that it will be recycling through
            GradesAdapter = new gradesRecyclerViewAdapter(GradesCardList);

            // Setup the recyclerview with the created adapter and layout manager
            GradesRecyclerView.SetLayoutManager(GradesLayoutManager);
            GradesRecyclerView.SetAdapter(GradesAdapter);
            return GradesView;
        }

        private void InitializeGrades()
        {
            GradesCardList = new List<Card>();

            for (int counter = 0; counter < 10; counter++)
            {

                Card current = new Card("CS 451 Software Engineering Project2");
                GradesCardList.Add(current);
            }

        }
    }
}