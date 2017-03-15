using Android.Support.V7.Widget;
using Android.Views;
using System.Collections.Generic;
using EaglesNestMobileApp.Core.Model;
using Android.Widget;
using Android.OS;
using System.Threading;
using AppCompatButton = Android.Support.V7.Widget.AppCompatButton;
using Android.Graphics;
using EaglesNestMobileApp.Android.Helpers;
using System.Collections.ObjectModel;
using System;

using EaglesNestMobileApp.Core.Model.Food;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class MenuItemAdapter : RecyclerView.Adapter
    {
        public MenuItem[] mMenuItems;
        public MenuItemViewHolder CurrentHolder { get; set; }




        public MenuItemAdapter(MenuItem[] menuItems)
        {
            mMenuItems = menuItems;
        }

        public override int ItemCount
        {
            get
            {
                return mMenuItems.Length;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //inflate the menuitem textview 
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.MenuItemLayout, parent, false);
            RecyclerView.ViewHolder _viewHolder = new MenuItemViewHolder(view);

            return _viewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            // bind the item with the list array
            MenuItem menuItem = MenuItems.builtInItems[position];
            CurrentHolder = holder as MenuItemViewHolder;
            CurrentHolder.BindCard(menuItem);
           
        }

       
    }


}