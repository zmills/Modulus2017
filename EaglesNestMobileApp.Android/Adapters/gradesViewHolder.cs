using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using EaglesNestMobileApp.Android.Cards;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class gradesViewHolder : RecyclerView.ViewHolder
    {
        // Public accessors
        // Instantiate a viewholder TextView to be set with a class name
        public TextView GradesClassName { get; set; }
        public LinearLayout llExpandArea;

        public gradesViewHolder(View view) : base(view)
        {
            // Set the GradesClassName TextView to the GradesCardClassName textview in the layout
            GradesClassName = view.FindViewById<TextView>(Resource.Id.GradesCardClassName);

            llExpandArea = view.FindViewById<LinearLayout>(Resource.Id.llExpandArea);
        }

        // Take in a gradesCard and assign its data to the viewholder's views
        public void GetGradesCard(Card gradesCard)
        {
            GradesClassName.Text = gradesCard.Title;
        }
    }
}