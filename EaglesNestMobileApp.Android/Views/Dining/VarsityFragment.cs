/*****************************************************************************/
/*                              varsityFragment                              */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;

using Android.Support.Design.Widget;
using System;
using Android.Widget;
using static Android.Support.Design.Widget.TabLayout;
using System.Collections.Generic;
using EaglesNestMobileApp.Android.Adapters;

namespace EaglesNestMobileApp.Android.Views.Dining
{
    public class varsityFragment : Fragment
    {

        public View varsityLayout;
        public TabLayout breakfastTab;
        public IOnTabSelectedListener listener;
        


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater,
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Use this to return your custom view for this Fragment         */
            varsityLayout = inflater.Inflate(Resource.Layout.VarsityFragmentLayout,
                             container, false);
            listener = new varsityTabListener(varsityLayout);

            breakfastTab = varsityLayout.FindViewById<TabLayout>(Resource.Id.varsityTabs);
            breakfastTab.AddOnTabSelectedListener(listener);

            return varsityLayout;
        }

        
    }
}