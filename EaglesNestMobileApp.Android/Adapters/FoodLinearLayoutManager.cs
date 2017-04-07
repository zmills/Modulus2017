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
using Android.Support.V7.Widget;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class FoodLinearLayoutManager : LinearLayoutManager
    {
        public FoodLinearLayoutManager(Context context) : base(context)
        {

        }

        public override bool CanScrollVertically()
        {
            return false;
        }
    }
}