using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using EaglesNestMobileApp.Core.Model;
using EaglesNestMobileApp.Core.Model.Home;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class eventSignUpHolder : RecyclerView.ViewHolder
    {
        // Public accessors
        public TextView Title        { get; set; }
        public TextView Description  { get; set; }
        public Button SignUp         { get; set; }

        public eventSignUpHolder(View view) : base(view)
        {
            // Set the textview and the imageview to those in the cardviewlayout
            Title = view.FindViewById<TextView>(Resource.Id.eventSignUpTitle);
            Description = view.FindViewById<TextView>(Resource.Id.eventSignUpDescription);
            SignUp = view.FindViewById<Button>(Resource.Id.eventSignUpButton);
        }

        // This takes in a card and does the assignment to the textview and imageview
        public void GetCard(EventsSignUp eventSignUp)
        {
            Title.Text =  eventSignUp.Title;
            Description.Text = eventSignUp.Description; //eventSignUp.Description;
            SignUp.Text = eventSignUp.ButtonText;
        }
    }
}