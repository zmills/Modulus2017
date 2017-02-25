using System;
using Android.Support.V7.Widget;
using Android.Views;
using EaglesNestMobileApp.Android.Cards;
using System.Collections.Generic;
using EaglesNestMobileApp.Core.Model;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class announcementsRecyclerViewAdapter : RecyclerView.Adapter
    {
        // List of annoucements to be displayed as cards
        public List<Card> Announcements { get; set; }
        public announcementViewHolder CurrentHolder { get; set; }

        public announcementsRecyclerViewAdapter(List<Card> announcements)
        {
            // Set the local list to whatever was passed in
            Announcements = announcements;
        }

        // Returns the number of cards in the list
        public override int ItemCount => Announcements.Count;

        // Returns the current card
        public int ViewPosition => CurrentHolder.AdapterPosition;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            // Find the correct card based off of its position in the recycler view and set its title and image
            Card card = Announcements[position];
            CurrentHolder = holder as announcementViewHolder;
            CurrentHolder.GetCard(card);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Return the layout of the card to the view holder so it can access the textview and the imageview
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.AnnouncementCardLayout, parent, false);
            return new announcementViewHolder(view);
        }
    }
}