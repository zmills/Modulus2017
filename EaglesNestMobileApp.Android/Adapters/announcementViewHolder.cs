using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using EaglesNestMobileApp.Android.Cards;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class announcementViewHolder : RecyclerView.ViewHolder
    {
        // Public accessors
        public TextView Title { get; set; }
        public ImageView Image { get; set; }

        public announcementViewHolder(View view) : base(view)
        {   
            // Set the textview and the imageview to those in the cardviewlayout
            Title = view.FindViewById<TextView>(Resource.Id.CardText);
            Image = view.FindViewById<ImageView>(Resource.Id.CardImage);
        }

        // This takes in a card and does the assignment to the textview and imageview
        public void GetCard(Card announcement)
        {
            Title.Text = announcement.Title;
            Image.SetImageResource(announcement.Image);
        }
    }
}