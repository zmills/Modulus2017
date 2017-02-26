using Android.Views;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using EaglesNestMobileApp.Core.Model;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class eventSignUpRecyclerViewAdapter : RecyclerView.Adapter
    {
        // List of annoucements to be displayed as cards
        public List<Card> Events { get; set; }
        eventSignUpHolder currentHolder { get; set; }

        public eventSignUpRecyclerViewAdapter(List<Card> events)
        {
            // Set the local list to whatever was passed in
            Events = events;
        }

        // Returns the number of cards in the list
        public override int ItemCount => Events.Count;

        // Returns the current card
        public int ViewPosition => currentHolder.AdapterPosition;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            // Find the correct card based off of its position in the recycler view and set its title and image
            Card card = Events[position];
            currentHolder = holder as eventSignUpHolder;
            currentHolder.GetCard(card);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Return the layout of the card to the view holder so it can access the textview and the imageview
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.EventCardLayout, parent, false);
            return new eventSignUpHolder(view);
        }
    }
}