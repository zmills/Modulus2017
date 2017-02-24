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
        public List<Card> Grades { get; set; }
        public gradesViewHolder CurrentHolder { get; set; }

        public gradesRecyclerViewAdapter(List<Card> grades)
        {
            // Set the local list to whatever was passed in
            Grades = grades;
        }

        // Returns the number of cards in the list
        public override int ItemCount => Grades.Count;

        public int ViewPosition = CurrentHolder.


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            throw new NotImplementedException();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            throw new NotImplementedException();
        }
    }
}