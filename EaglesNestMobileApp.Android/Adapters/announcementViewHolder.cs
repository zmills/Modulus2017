using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using EaglesNestMobileApp.Android.Cards;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class announcementViewHolder : RecyclerView.ViewHolder
    {
        public TextView _title;
        public ImageView _image;

        public announcementViewHolder(View view) : base(view)
        {
            _title = view.FindViewById<TextView>(Resource.Id.CardText);
            _image = view.FindViewById<ImageView>(Resource.Id.CardImage);
        }

        public void GetCard(Card announcement)
        {
            _title.Text = announcement.Title;
            _image.SetImageResource(announcement.Image);
        }
    }
}