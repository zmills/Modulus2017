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
using Android.Graphics;
using static Android.Support.V4.App.ActionBarDrawerToggle;
using Android.Support.V7.View;

// Referenced from:
// http://stackoverflow.com/questions/6799066/how-to-use-multiple-touchdelegate/20051314#20051314
// 

namespace EaglesNestMobileApp.Android.Helpers
{
    class TouchDelegateComposite : TouchDelegate
    {
        private List<TouchDelegate> touchDelegatesArray = new List<TouchDelegate>();
        private static Rect unusedRect = new Rect();
        
        // Constructor
        public TouchDelegateComposite(View view) : base(unusedRect, view) { }

        // Add a TouchDelegate to the TouchDelegate Array
        public void addTouchDelegate(TouchDelegate touchDelegate)
        {
            // Create new array of TouchDelegates if array is null
            /*if (touchDelegatesArray == null)
                touchDelegatesArray = new List<TouchDelegate>();*/

            // Add a TouchDelegate to the array
            if (touchDelegate != null)
                touchDelegatesArray.Add(touchDelegate);
        }

        public int getChildCount()
        {
            return touchDelegatesArray.Count;
        }

        /*public void removeTouchDelegate(TouchDelegate touchDelegate)
        {
            if (touchDelegatesArray != null)
            {
                touchDelegatesArray.Remove(touchDelegate);
                if (touchDelegatesArray.Count() == 0)
                    touchDelegatesArray = null;
            }
        }*/

        public override bool OnTouchEvent(MotionEvent e)
        {
            bool _result = false;
            float x = e.GetX();
            float y = e.GetY();
          
            foreach(TouchDelegate touchDelegate in touchDelegatesArray)
            { 
                e.SetLocation(x, y);
                // See if touch location is within the touchDelegate bounds
                _result = touchDelegate.OnTouchEvent(e) || _result;
            }
            return _result;
        }
    }
}