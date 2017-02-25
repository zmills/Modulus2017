using System;
using Android.Support.V7.Widget;
using Android.Views;
using EaglesNestMobileApp.Android.Cards;
using System.Collections.Generic;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class gradesRecyclerViewAdapter : RecyclerView.Adapter
    {
        // List of grades to be displayed as cards
        public List<Card> GradesCardList { get; set; }
        public gradesViewHolder GradesViewHolder { get; set; }

        public gradesRecyclerViewAdapter(List<Card> grades)
        {
            // Set the local list to the list passed in
            GradesCardList = grades;
        }

        // Returns the number of cards in the list
        public override int ItemCount => GradesCardList.Count;

        public int ViewPosition => GradesViewHolder.AdapterPosition;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Card _currentGradesCard = GradesCardList[position];
            GradesViewHolder = (gradesViewHolder)holder;
            GradesViewHolder.GetGradesCard(_currentGradesCard);
        }

        

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.GradesCardLayout, parent, false);
            return new gradesViewHolder(view);
        }
    }
}