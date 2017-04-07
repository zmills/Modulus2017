
using Android.Views;
using Android.Widget;
using Android.Support.Design.Widget;

namespace EaglesNestMobileApp.Android.Adapters
{
    class varsityTabListener : Java.Lang.Object, TabLayout.IOnTabSelectedListener
    {

        public View varsityLayout;
        public TextView line1,
                        line2,
                        line3,
                        line4,
                        line5; 

        public varsityTabListener(View view)
        {
            varsityLayout = view;
            line1 = varsityLayout.FindViewById<TextView>(Resource.Id.varsityOption1);
            line2 = varsityLayout.FindViewById<TextView>(Resource.Id.varsityOption2);
            line3 = varsityLayout.FindViewById<TextView>(Resource.Id.varsityOption3);
            line4 = varsityLayout.FindViewById<TextView>(Resource.Id.varsityOption4);
            line5 = varsityLayout.FindViewById<TextView>(Resource.Id.varsityOption5);

        }

        public void OnTabReselected(TabLayout.Tab tab)
        {
           
        }

        public void OnTabSelected(TabLayout.Tab tab)
        {
            switch (tab.Text)
            {
                case "Breakfast":                 
                    line1.Text = "1 - Breakfast Pizza";
                    line2.Text = "2 - Continetal Breakfast";
                    line3.Text = "3 - Closed";
                    line4.Text = "4 - Closed";
                    line5.Text = "5 - Mega Cerear Bar";

                    break;
                case "Lunch":
                    line1.Text = "1 - Pizza Bar";
                    line2.Text = "2 - Hot Deli";
                    line3.Text = "3 - Chicken Tenders";
                    line4.Text = "4 - Soup and Salad";
                    line5.Text = "5 - Mega Cereal Bar";
                    break;
                case "Dinner":
                    line1.Text = "1 - Pizza Bar";
                    line2.Text = "2 - Hot Deli";
                    line3.Text = "3 - Chicken Tenders";
                    line4.Text = "4 - Soup and Salad";
                    line5.Text = "5 - Mega Cereal Bar";
                    break;
            }
        }

        public void OnTabUnselected(TabLayout.Tab tab)
        {
           
        }
    }
}