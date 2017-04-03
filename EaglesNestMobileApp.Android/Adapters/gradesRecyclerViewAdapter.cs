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
using Android.Animation;
using Android.Transitions;
using Android.Views.Animations;

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
        /*TESTING - ANIMATION */
        /*TESTING - ANIMATION */
        public View myView { get; set; }
        /*TESTING - ANIMATION */
        public AnimatorSet _rotate180 { get; set; }
        public AnimatorSet _fadeIn { get; set; }
        RotateAnimation rotateTry2;

        /*TESTING - ANIMATION */
        public View GradesCard { get; set; }
        public Button animButton { get; set; }

        public gradesRecyclerViewAdapter(List<Card> grades, Context context)
        {
            // Set the local list to the list passed in
            GradesCardList = grades;
            _context = context;
            //_rotate180 = (AnimatorSet)AnimatorInflater.LoadAnimator(context, Resource.Animation.rotate_180_overshoot);
            rotateTry2 = new RotateAnimation(0, 180, Dimension.RelativeToSelf, 0.5f, Dimension.RelativeToSelf, 0.5f);
            rotateTry2.Duration = 500;
            rotateTry2.Interpolator = new AnticipateOvershootInterpolator();
            rotateTry2.FillAfter = true;
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
            {
                GradesViewHolder.ShowGradesArrow.StartAnimation(rotateTry2);
                GradesViewHolder.ExpandCard.Visibility = ViewStates.Visible;
                /* Fade out up arrow */
                //_rotate180.Start();
                
            }
            else
            {
                GradesViewHolder.ExpandCard.Visibility = ViewStates.Gone;
                //_rotate180.Start();
                //GradesViewHolder.ShowGradesArrow.StartAnimation(rotateTry2);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view =
                LayoutInflater.From(parent.Context).Inflate(Resource.Layout.GradesCardLayout, parent, false);

            /*View dialogBoxLayout =
                LayoutInflater.From(parent.Context).Inflate(Resource.Layout.GradesCardLayout, parent, false);*/

            GradesViewHolder = new gradesViewHolder(view);

            /* Switch arrow icon click event */
            //_rotate180.SetTarget(GradesViewHolder.ShowGradesArrow);

            /* Show Grades Button Click Event */
            GradesViewHolder.ShowGradesButton.Click += View_Click;
            GradesViewHolder.ShowGradesButton.Tag = GradesViewHolder;

            /*Teacher Info Button Click Event */
            GradesViewHolder.TeacherInfoButton.Click += PopUpBox;


            /* TESTING - ANIMATION */
            /*animButton = view.FindViewById<Button>(Resource.Id.ShowGradesButton);
            animButton.Click += startAnimation;
            myView = view.FindViewById<TextView>(Resource.Id.CourseGrade);
            _animatorSet = (AnimatorSet)AnimatorInflater.LoadAnimator(parent.Context, Resource.Animation.move_fab);
            _animatorSet.SetTarget(myView);*/
            //Activity.RunOnUiThread(() => _animatorSet.Start());
            //FAB.Click += startAnimation;
            


            return GradesViewHolder;
        }

        private void startAnimation(object sender, System.EventArgs e)
        {
            //Activity.RunOnUiThread(() => _animatorSet.Start());
            //_animatorSet.Start();
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
            (sender as Button).Enabled = false;
            Dialog dialogBox = new Dialog(_context, Resource.Style.ModAppCompatLightTheme);
            dialogBox.SetTitle("Messaging & Telephone Instructions");
            //dialogBox.SetMessage("");
            dialogBox.Window.SetContentView(Resource.Layout.StudentInfoFragmentLayout);
            dialogBox.Window.SetWindowAnimations(Resource.Style.Base_Animation_AppCompat_DropDownUp);
            #region OTHER ANIMATIONS
            /* 1. Animation_AppCompat_Dialog, Base_Animation_AppCompat_Dialog
                  - Simple Fade In                                           */
            /* 2. Animation_Design_BottomSheetDialog
                  - slide in from bottom                                     */
            /* 3. Animation_AppCompat_DropDownUp, Base_Animation_AppCompat_DropDownUp
                  - Slight Grow and Fade in;
                    start position is slightly below end positon             */
            #endregion
            await Task.Delay(150);
            dialogBox.Show();
            await Task.Delay(400);
            (sender as Button).Enabled = true;
            await Task.Delay(5000);
            dialogBox.Dismiss();
            
        }
    }
}