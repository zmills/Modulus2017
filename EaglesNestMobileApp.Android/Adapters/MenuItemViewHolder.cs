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
    public class MenuItemViewHolder : RecyclerView.ViewHolder
    {
        public TextView menuItemTitle { get; set; }

        public MenuItemViewHolder(View view) : base(view)
        {
            menuItemTitle = view.FindViewById<TextView>(Resource.Id.MenuFoodItem);
        }



        public void BindCard(MenuItem item)
        {
            menuItemTitle.Text = item.Name;
        }
    }


}