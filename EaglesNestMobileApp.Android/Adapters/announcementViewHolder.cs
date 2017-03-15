using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using EaglesNestMobileApp.Core.Model;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class announcementViewHolder : RecyclerView.ViewHolder
    {
        // Public accessors
        public TextView Title { get; set; }
        public ImageView Image { get; set; }
        public ViewGroup ParentLayout;

        public announcementViewHolder(View view) : base(view)
        {
            System.Diagnostics.Debug.Write("CALLED THE VIEWHOLDER!!!!!!!!!!!!!!!!!!!!!!!!");

           // Set the textview and the imageview to those in the cardviewlayout
            Title = view.FindViewById<TextView>(Resource.Id.AnnouncementsCardText);
            Image = view.FindViewById<ImageView>(Resource.Id.AnnouncementsCardImage);

            ParentLayout = view.FindViewById<RelativeLayout>(Resource.Id.AnnouncementsCardRelativeLayout);
        }

        // This takes in a card and binds its views to the viewholder's views
        public void BindCard(Card announcementsCard)
        {
            Title.Text = announcementsCard.Title;
            Image.SetImageResource(announcementsCard.Image);
        }
    }
}