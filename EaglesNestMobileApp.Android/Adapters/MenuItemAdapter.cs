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
using static Android.Views.View;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class MenuItemAdapter : RecyclerView.Adapter
    {
        public MenuItem[] menuItemsArray;
        public MenuItemViewHolder CurrentHolder { get; set; }
        public View helloView;
        public View hideView;

        /*********************************************************************/
        /* Constructor                                                       */
        /*********************************************************************/
        public MenuItemAdapter(MenuItem[] menuItems)
        {
            menuItemsArray = menuItems;
        }

        /*********************************************************************/
        /* Return the number of menu items in the list for adapter use       */
        /*********************************************************************/
        public override int ItemCount => menuItemsArray.Length;

        /*********************************************************************/
        /* Create the viewholder                                             */
        /*********************************************************************/
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //inflate the menuitem textview 
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.MenuItemLayout, parent, false);
            RecyclerView.ViewHolder _viewHolder = new MenuItemViewHolder(view);

            return _viewHolder;
        }

        /*********************************************************************/
        /* Bind the layout views to the viewholder                           */
        /*********************************************************************/
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            // bind the item with the list array
            MenuItem menuItem = menuItemsArray[position];
            CurrentHolder = holder as MenuItemViewHolder;
            CurrentHolder.BindCard(menuItem, CurrentHolder);

            //hideView = CurrentHolder.line1List;
            //CurrentHolder.mView.Post(() => CurrentHolder.mView.FindViewById<View>(Resource.Id.line1).Click += myClickEvent);

        }

        private void myClickEvent(object sender, EventArgs e)
        {
            
            if (hideView.Visibility == ViewStates.Visible)
                hideView.Visibility = ViewStates.Gone;
            else
                hideView.Visibility = ViewStates.Visible;
        }
    }


}