using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using EaglesNestMobileApp.Android.Adapters;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using System;
using EaglesNestMobileApp.Core.Model;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class eventSignUpRecyclerViewAdapter : RecyclerView.Adapter
    {
        // List of annoucements to be displayed as cards
        public List<Card> Events { get; set; }

        public eventSignUpRecyclerViewAdapter(List<Card> events)
        {
            // Set the local list to whatever was passed in
            Events = events;
        }

        // Returns the number of cards in the list
        public override int ItemCount => Events.Count;


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            // Find the correct card based off of its position in the recycler view and set its title and image
            Card card = Events[position];
            eventSignUpHolder currentHolder = holder as eventSignUpHolder;
            currentHolder.GetCard(card);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Return the layout of the card to the view holder so it can access the textview and the imageview
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.EventsFragmentLayout, parent, false);
            return new eventSignUpHolder(view);
        }
    }
}