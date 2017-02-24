using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using EaglesNestMobileApp.Android.Cards;
using EaglesNestMobileApp.Android.Adapters;
using Android.Support.Design.Widget;

namespace EaglesNestMobileApp.Android.Views.Academics
{
    public class gradesFragment : Fragment
    {
        // Public accessors
        public List<Card> Grades { get; set; } // This will bind to the list in the viewmodel
        public RecyclerView GradesRecyclerView { get; set; }
        public gradesRecyclerViewAdapter GradesAdapter { get; set; }
        public RecyclerView.LayoutManager GradesLayoutManager { get; set; }
        public View AnnouncementsView { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.GradesFragmentLayout, container, false);
        }
    }
}