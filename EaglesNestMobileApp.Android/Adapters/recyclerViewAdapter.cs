using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Java.Lang;
using Android.Support.V4.App;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EaglesNestMobileApp.Android.Adapters
{
    [Activity(Label = "recyclerViewAdapter")]
    public class recyclerViewAdapter : RecyclerView.Adapter<recyclerViewAdapter.MyViewHolder>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}