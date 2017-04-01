using System;
using Android.Support.V7.Widget;
using Android.Views;
using System.Collections.Generic;
using EaglesNestMobileApp.Core.Model;
using ProgressDialog = Android.App.ProgressDialog;
using Android.Widget;
using Android.Content;
using Android.App;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class gradesRecyclerViewAdapter : RecyclerView.Adapter
    {
        // List of grades to be displayed as cards
        public List<Card> GradesCardList { get; set; }
        public gradesViewHolder GradesViewHolder { get; set; }
        private int expandedPosition = -1;
        private Context _context;
        public View dialogBoxLayout { get; set; }

        public gradesRecyclerViewAdapter(List<Card> grades, Context context)
        {
            // Set the local list to the list passed in
            GradesCardList = grades;
            _context = context;
        }

        // Returns the number of cards in the list
        public override int ItemCount => GradesCardList.Count;

        public int ViewPosition => GradesViewHolder.AdapterPosition;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Card _currentGradesCard = GradesCardList[position];
            GradesViewHolder = (gradesViewHolder)holder;
            GradesViewHolder.GetGradesCard(_currentGradesCard);

            if (position == expandedPosition)
                GradesViewHolder.ExpandCard.Visibility = ViewStates.Visible;
            else
                GradesViewHolder.ExpandCard.Visibility = ViewStates.Gone;       
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view =
                LayoutInflater.From(parent.Context).Inflate(Resource.Layout.GradesCardLayout, parent, false);

            /*View dialogBoxLayout =
                LayoutInflater.From(parent.Context).Inflate(Resource.Layout.GradesCardLayout, parent, false);*/

            GradesViewHolder = new gradesViewHolder(view);

            GradesViewHolder.ShowGradesButton.Click += View_Click;
            GradesViewHolder.ShowGradesButton.Tag = GradesViewHolder;
            GradesViewHolder.TeacherInfoButton.Click += PopUpBox;

            return GradesViewHolder;
        }

        private void View_Click(object sender, EventArgs e)
        {
            gradesViewHolder GradesViewHolderCurrent = (gradesViewHolder)(sender as View).Tag;

            if (expandedPosition >= 0)
            {
                int prev = expandedPosition;
                NotifyItemChanged(prev);
            }

            expandedPosition = GradesViewHolderCurrent.AdapterPosition;
            NotifyItemChanged(expandedPosition);
        }

        private async void PopUpBox(object sender, EventArgs e)
        {
            Dialog dialogBox = new Dialog(_context, Resource.Style.ModAppCompatLightTheme);
            dialogBox.SetTitle("Messaging & Telephone Instructions");
            //dialogBox.SetMessage("");
            dialogBox.SetContentView(Resource.Layout.StudentInfoFragmentLayout);
            //dialogBox.SetView(LayoutInflater.From(_context).Inflate(Resource.Layout.GradesCardLayout, null));
            /*dialogBox.Window.Attributes.Width = ViewGroup.LayoutParams.MatchParent;
            dialogBox.Window.Attributes.Height = ViewGroup.LayoutParams.MatchParent;
            dialogBox.Window.Attributes.HorizontalMargin = 0;
            dialogBox.Window.Attributes.VerticalMargin = 0;
            dialogBox.Window.Attributes.VerticalWeight = 0;
            dialogBox.Window.Attributes.HorizontalWeight = 0;*/
            //dialogBox.Window.AddFlags(WindowManagerFlags.Fullscreen);
            //dialogBox.Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.TranslucentStatus);
            dialogBox.Show();
            await Task.Delay(5000);
            dialogBox.Dismiss();
        }
    }
}