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
using Android.Views.Animations;
//using Android.Support.Transitions;
using Android.Transitions;

namespace EaglesNestMobileApp.Android.Adapters
{
    public class gradesRecyclerViewAdapter : RecyclerView.Adapter
    {
        public const int INITIAL_EXPANDED_POSITION = -1; //Used later to check against
        // List of grades to be displayed as cards
        public List<Card> GradesCardList { get; set; }
        public gradesViewHolder GradesViewHolder { get; set; }
        private int expandedPosition = INITIAL_EXPANDED_POSITION;
        private Context _context;
        public View dialogBoxLayout { get; set; }
        RotateAnimation rotateArrow;
        public TransitionSet transitionSet;

        /*TESTING - ANIMATION */
        public View GradesCard { get; set; }
        public Button animButton { get; set; }

        public gradesRecyclerViewAdapter(List<Card> grades, Context context)
        {
            // Set the local list to the list passed in
            GradesCardList = grades;
            _context = context;

            /* Create rotate animation */
            rotateArrow = new RotateAnimation(0, 180, Dimension.RelativeToSelf, 0.5f, Dimension.RelativeToSelf, 0.5f)
            {
                Duration = 500,
                Interpolator = new AnticipateOvershootInterpolator(),
                FillAfter = true
            };

            #region THE FOLLOWING TRANSITION IS NOT USED
            /*transitionSet = new TransitionSet();
            transitionSet.SetOrdering(TransitionOrdering.Together);
            transitionSet.SetDuration(400);
            ChangeBounds changeBounds = new ChangeBounds();
            ChangeImageTransform changeImageTransform = new ChangeImageTransform();
            Fade fadeIn = new Fade(FadingMode.In);
            transitionSet.AddTransition(changeBounds)
                         .AddTransition(changeImageTransform)
                         .AddTransition(fadeIn);*/
            /* If this was used, these would be called later */
            /* transitionSet.AddTarget(GradesViewHolder.ExpandCard);
               TransitionManager.BeginDelayedTransition(GradesViewHolder.ExpandCard, transitionSet); */
            #endregion
        }

        // Returns the number of cards in the list
        public override int ItemCount => GradesCardList.Count;

        public int ViewPosition => GradesViewHolder.AdapterPosition;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            System.Diagnostics.Debug.Write("ONBINDVIEWHOLDER(POSITION): " + position);
            System.Diagnostics.Debug.Write("ITEMCOUNT: " + ItemCount);

            Card _currentGradesCard = GradesCardList[position];
            GradesViewHolder = (gradesViewHolder)holder;
            GradesViewHolder.GetGradesCard(_currentGradesCard);

            System.Diagnostics.Debug.Write("POSITION: " + position + " == EXPANDED_POSTION: " + expandedPosition + "?");

            if (position == expandedPosition)
            {
                System.Diagnostics.Debug.Write("OPEN-POSITION(" + position + ")");
                System.Diagnostics.Debug.Write("OPEN-VH.POSITION(" + GradesViewHolder.AdapterPosition + ")");
                GradesViewHolder.ShowGradesArrow.StartAnimation(rotateArrow);
                GradesViewHolder.ExpandCard.Visibility = ViewStates.Visible;
            }
                else
                {
                    System.Diagnostics.Debug.Write("CLOSE-POSITION(" + position + ")");
                    System.Diagnostics.Debug.Write("CLOSE-VH.POSITION(" + GradesViewHolder.AdapterPosition + ")");
                    GradesViewHolder.ExpandCard.Visibility = ViewStates.Gone;
                }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view =
                LayoutInflater.From(parent.Context).Inflate(Resource.Layout.GradesCardLayout, parent, false);

            GradesViewHolder = new gradesViewHolder(view);

            /* Show Grades Button Click Event */
            GradesViewHolder.ShowGradesButton.Click += View_Click;
            GradesViewHolder.ShowGradesButton.Tag = GradesViewHolder;

            /*Teacher Info Button Click Event */
            GradesViewHolder.TeacherInfoButton.Click += PopUpBox;

            return GradesViewHolder;
        }

        private void View_Click(object sender, EventArgs e)
        {
            gradesViewHolder GradesViewHolderCurrent = (gradesViewHolder)(sender as View).Tag;

            if (expandedPosition >= 0)
            {
                int prev = expandedPosition;
                System.Diagnostics.Debug.Write("ITEM COUNT: " + ItemCount);
                System.Diagnostics.Debug.Write("PREV: " + prev + "VH.POSITION: " + GradesViewHolderCurrent.AdapterPosition);
                NotifyItemChanged(prev);    
            }
            expandedPosition = GradesViewHolderCurrent.AdapterPosition;
            System.Diagnostics.Debug.Write("NOTIFY(EXPANDED_POSTION): " + expandedPosition);
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