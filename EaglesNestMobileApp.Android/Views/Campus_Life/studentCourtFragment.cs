/*****************************************************************************/
/*                           studentCourtFragment                            */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using System;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Content;
using Android.Graphics;
using AndroidAnimation = Android.Animation;
using Android.Views.Animations;
using Android.Support.Transitions;
using Android.Support.V4.Content;
using Android.Graphics.Drawables;
using Android.Support.V4.Content.Res;
using Android.Util;
using Android.Content.Res;
using EaglesNestMobileApp.Core;
using GalaSoft.MvvmLight.Helpers;
using EaglesNestMobileApp.Core.Model.Campus;
using EaglesNestMobileApp.Core.ViewModel.CampusLifeViewModels;

namespace EaglesNestMobileApp.Android.Views.Campus_Life
{
    public class studentCourtFragment : Fragment
    {
        public SwipeRefreshLayout RefreshLayout { get; set; }
        public View StudentCourtView { get; set; }
        public TextView PendingHeader { get; set; }
        public CardView StatusCard { get; set; }
        public TextView Infraction { get; set; }
        public CardView InfractionCard { get; set; }
        public ObservableRecyclerAdapter<Offense, CachingViewHolder> _adapter;

        /* Progress bars to be displayed                                     */
        public ProgressBar DemeritsProgBar;
        public ProgressBar DormInfractionsProgBar;
        public ProgressBar AbsencesProgBar;
        public ProgressBar LateDormProgBar;

        /* Student total demerits and infractions                            */
        public int TotalDemerits;
        public int TotalDormInfractions;
        public int TotalAbsences;
        public int TotalLateDorm;

        public StudentCourtFragmentViewModel ViewModel
        {
            get { return App.Locator.StudentCourt; }
        }

        private Handler mHandler = new Handler();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {

            StudentCourtView = inflater.Inflate(Resource.Layout.StudentCourtFragmentLayout,
                container, false);

            #region NICK's REFRESH LAYOUT CODE
            /* "Pulling" down on the page will refresh the view              */
            /*RefreshLayout =
                StudentCourtView.FindViewById<SwipeRefreshLayout>(
                    Resource.Id.SwipeRefreshStudentCourt);*/

            /*RefreshLayout.SetColorSchemeResources(Resource.Color.primary,
                Resource.Color.accent, Resource.Color.primary_text,
                    Resource.Color.secondary_text);
            RefreshLayout.Refresh += RefreshLayoutRefresh;*/
            #endregion

            RecyclerView _recyclerview =
                StudentCourtView.FindViewById<RecyclerView>(Resource.Id.PendingReportSlips);

            _adapter = ViewModel.StudentOffenseCard.Offenses.GetRecyclerAdapter
                (
                    BindViewHolder, Resource.Layout.StudentCourtInfractionCardLayout
                );

            _recyclerview.SetLayoutManager(new LinearLayoutManager(Activity));
            _recyclerview.SetAdapter(_adapter);

            /* Student court progress bars                                   */
            DemeritsProgBar        = new ProgressBar(Activity);
            DormInfractionsProgBar = new ProgressBar(Activity);
            AbsencesProgBar        = new ProgressBar(Activity);
            LateDormProgBar        = new ProgressBar(Activity);

            DemeritsProgBar =
                StudentCourtView.FindViewById<ProgressBar>(Resource.Id.DemeritsProgressBar);
            DormInfractionsProgBar =
                StudentCourtView.FindViewById<ProgressBar>(Resource.Id.DormInfractionsProgressBar);
            AbsencesProgBar =
                StudentCourtView.FindViewById<ProgressBar>(Resource.Id.AbsencesProgressBar);
            LateDormProgBar =
                StudentCourtView.FindViewById<ProgressBar>(Resource.Id.LateDormProgressBar);

            /* Set max value for progress bars                               */
            DemeritsProgBar.Max        = App.StudentCourt.MaxDemerits;
            DormInfractionsProgBar.Max = App.StudentCourt.MaxDormInfractions;
            AbsencesProgBar.Max        = App.StudentCourt.MaxAbsences;
            LateDormProgBar.Max        = App.StudentCourt.MaxLateDormInfraction;

            StudentCourtView.Post(() => SetUpProgressBars());

            /*****************************************************************/
            /* Create Student Court Gradient                                 */
            /*****************************************************************/

            /* Set the start color for gradient                              */
            int startColor = ResourcesCompat.GetColor(
                Resources, Resource.Color.red, null); //NOTE: this could be red or green, or gray . . .
            Color startColorAndroidGraphics = new Color(startColor);
            int endColor;

            /* Set text color for student court status                       */
            StudentCourtView.FindViewById<TextView>(Resource.Id.StudentCourtStatusText)
                .SetTextColor(startColorAndroidGraphics);

            /* Get the name of the current theme                             */
            TypedValue attrValue = new TypedValue();
            Activity.Theme.ResolveAttribute(
                Resource.Attribute.modThemeName, attrValue, true);

            /* Set the end color for gradient based on the current theme     */
            if ( attrValue.String.ToString() == "ModAppCompatLightTheme" )
                endColor = ResourcesCompat.GetColor(
                    Resources, Resource.Color.window_background, null);
            else
                endColor = ResourcesCompat.GetColor(
                    Resources, Resource.Color.window_background_dark_theme, null);

            int[] gradientColors = { startColor, endColor };
            
            /* Set the gradient's start and end colors                       */
            GradientDrawable gradient = new GradientDrawable(
                GradientDrawable.Orientation.TopBottom, gradientColors);
            StudentCourtView.FindViewById<ImageView>(Resource.Id.GradientStudentCourt)
                .Background = gradient;
            

            /* Use this to return your custom view for this Fragment         */
            return StudentCourtView;
        }

        private void BindViewHolder(CachingViewHolder holder, Offense offenseCard,
            int position)
        {
            TextView _titleView = 
                holder.FindCachedViewById<TextView>(Resource.Id.infractionTitle);

            TextView _dateView =
                holder.FindCachedViewById<TextView>(Resource.Id.infractionDate);

            TextView _timeView =
                holder.FindCachedViewById<TextView>(Resource.Id.infractionTime);

            holder.DeleteBinding(_timeView);
            holder.DeleteBinding(_dateView);
            holder.DeleteBinding(_timeView);

            var _titleBinding = new Binding<string, string>
                (
                    offenseCard,
                    ()=> offenseCard.OffenseTitle,
                    _titleView,
                    ()=> _titleView.Text,
                    BindingMode.OneWay
                );

            var _dateBinding = new Binding<string, string>
                (
                    offenseCard,
                    () => offenseCard.OffenseDate,
                    _dateView,
                    () => _dateView.Text,
                    BindingMode.OneWay
                );

            holder.SaveBinding(_titleView, _titleBinding);
            holder.SaveBinding(_dateView, _dateBinding);
        }

        private void SetUpProgressBars()
        {

            /* Progress bar animations                                       */
            AndroidAnimation.ObjectAnimator _demeritsProgBarAnim,
                                            _dormInfractionsProgBarAnim,
                                            _absencesProgBarAnim,
                                            _lateDormProgBarAnim;

            /* Set student total demerits and infractions                    */
            TotalDemerits        = 50 * App.StudentCourt.ProgBarMultiplier;
            TotalDormInfractions =  7 * App.StudentCourt.ProgBarMultiplier;
            TotalAbsences        =  5 * App.StudentCourt.ProgBarMultiplier;
            TotalLateDorm        =  6 * App.StudentCourt.ProgBarMultiplier;
            //HAVE TO BE BINDED
            TextView _demerits = StudentCourtView.FindViewById<TextView>(Resource.Id.totalDemerits);
            _demerits.Text = ViewModel.StudentOffenseCard.TotalDemerits;

            TextView _resInfractions = StudentCourtView.FindViewById<TextView>(Resource.Id.totalResidenceHallInfractions);
            _resInfractions.Text = ViewModel.StudentOffenseCard.TotalResidenceHallInfractions;

            TextView _unexcusedAbsences = StudentCourtView.FindViewById<TextView>(Resource.Id.totalAbsences);
            _unexcusedAbsences.Text = ViewModel.StudentOffenseCard.TotalUnexcusedAbsences;

            TextView _resLateInfractions = StudentCourtView.FindViewById<TextView>(Resource.Id.totalLateResidenceHallInfractions);
            _resLateInfractions.Text = ViewModel.StudentOffenseCard.TotalLateOutIntoInfractions;

            TotalDemerits = 
                int.Parse(ViewModel.StudentOffenseCard.TotalDemerits) * 
                    App.StudentCourt.ProgBarMultiplier;

            TotalDormInfractions = 
                int.Parse(ViewModel.StudentOffenseCard.TotalResidenceHallInfractions) * 
                    App.StudentCourt.ProgBarMultiplier;

            TotalAbsences = 
                int.Parse(ViewModel.StudentOffenseCard.TotalUnexcusedAbsences) * 
                    App.StudentCourt.ProgBarMultiplier;

            TotalLateDorm = 
                int.Parse(ViewModel.StudentOffenseCard.TotalLateOutIntoInfractions) * 
                    App.StudentCourt.ProgBarMultiplier;

            /* Set progress bar animations                                   */
            _demeritsProgBarAnim =
                AndroidAnimation.ObjectAnimator.OfInt(DemeritsProgBar, "progress", 0, TotalDemerits);
            _dormInfractionsProgBarAnim =
                AndroidAnimation.ObjectAnimator.OfInt(DormInfractionsProgBar, "progress", 0, TotalDormInfractions);
            _absencesProgBarAnim =
                AndroidAnimation.ObjectAnimator.OfInt(AbsencesProgBar, "progress", 0, TotalAbsences);
            _lateDormProgBarAnim =
                AndroidAnimation.ObjectAnimator.OfInt(LateDormProgBar, "progress", 0, TotalLateDorm);

            /* Set animation interpolaters                                   */
            _demeritsProgBarAnim.SetInterpolator(new DecelerateInterpolator());
            _dormInfractionsProgBarAnim.SetInterpolator(new DecelerateInterpolator());
            _absencesProgBarAnim.SetInterpolator(new DecelerateInterpolator());
            _lateDormProgBarAnim.SetInterpolator(new DecelerateInterpolator());

            /* Set animation durations                                       */
            _demeritsProgBarAnim.SetDuration(600);
            _dormInfractionsProgBarAnim.SetDuration(600);
            _absencesProgBarAnim.SetDuration(600);
            _lateDormProgBarAnim.SetDuration(600);

            /* Start animation                                               */
            _demeritsProgBarAnim.Start();
            _dormInfractionsProgBarAnim.Start();
            _absencesProgBarAnim.Start();
            _lateDormProgBarAnim.Start();
        }

        private void RefreshLayoutRefresh(object sender, EventArgs e)
        {
            /* THIS NEEDS TO BE REMOVED                                      */

            
            StatusCard.SetCardBackgroundColor(Resource.Color.red_screenaaa);
            Infraction.Text = "You are required to go to student court";
            PendingHeader.Visibility = ViewStates.Visible;
            InfractionCard.Visibility = ViewStates.Visible;
            

            RefreshLayout.Refreshing = false;
        }
    }
}