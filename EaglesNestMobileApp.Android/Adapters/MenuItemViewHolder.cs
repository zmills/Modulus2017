using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EaglesNestMobileApp.Core.Model.Food;
using Android.Support.V7.Widget;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class MenuItemViewHolder : RecyclerView.ViewHolder, View.IOnClickListener
    {
        public TextView menuItemTitle { get; set; }
        public View line1text;
        public View mView;
        public View line1List;
        public View hideView { get; set; }



        public MenuItemViewHolder(View view) : base(view)
        {
            menuItemTitle = view.FindViewById<TextView>(Resource.Id.MenuFoodItem);


            line1text = view.FindViewById<TextView>(Resource.Id.line1);
            mView = view;
            line1List = mView.FindViewById<View>(Resource.Id.Line1RecyclerView);
        }

        private void Line1_Click(object sender, EventArgs e)
        {

            if (line1List.Visibility == ViewStates.Visible)
                line1List.Visibility = ViewStates.Gone;
            else
                line1List.Visibility = ViewStates.Visible;
        }

        public void BindCard(MenuItem item, MenuItemViewHolder holder)
        {
            menuItemTitle.Text = item.Name;
            //hideView = holder.line1List;
            //holder.mView.Post(() => holder.mView.FindViewById<View>(Resource.Id.line1).Click += myClickEvent);
        }

        private void myClickEvent(object sender, EventArgs e)
        {
            if (hideView.Visibility == ViewStates.Visible)
                hideView.Visibility = ViewStates.Gone;
            else
                hideView.Visibility = ViewStates.Visible;
        }

        public void OnClick(View v)
        {
            View list = v.FindViewById<RecyclerView>(Resource.Id.Line1RecyclerView);

            if (list.Visibility == ViewStates.Visible)
                list.Visibility = ViewStates.Gone;
            else
                list.Visibility = ViewStates.Visible;

        }
    }


}