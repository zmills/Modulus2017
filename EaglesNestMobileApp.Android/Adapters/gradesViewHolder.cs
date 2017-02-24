using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using EaglesNestMobileApp.Android.Cards;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class gradesViewHolder : RecyclerView.ViewHolder
    {
        // Public accessors
        public TextView Title { get; set; }

        public gradesViewHolder(View view) : base(view)
        {
            // Set the textview and the imageview to those in the cardviewlayout
            Title = view.FindViewById<TextView>(Resource.Id.CardText);
        }

        // This takes in a card and does the assignment to the textview and imageview
        public void GetCard(Card grades)
        {
            Title.Text = grades.Title;
        }
    }
}