/*****************************************************************************/
/*                           studentCourtFragment                            */
/*                                                                           */
/*****************************************************************************/
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content.Res;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using EaglesNestMobileApp.Core;
using EaglesNestMobileApp.Core.Model.Campus;
using EaglesNestMobileApp.Core.ViewModel.CampusLifeViewModels;
using GalaSoft.MvvmLight.Helpers;
using System;
using System.Threading.Tasks;
using AndroidAnimation = Android.Animation;

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

        /* Constants                                                         */
        public const string GREEN_SCREEN = "Green";
        public const string GRAY_SCREEN = "Gray";
        public const string RED_SCREEN = "Red";

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
            DemeritsProgBar = new ProgressBar(Activity);
            DormInfractionsProgBar = new ProgressBar(Activity);
            AbsencesProgBar = new ProgressBar(Activity);
            LateDormProgBar = new ProgressBar(Activity);

            DemeritsProgBar =
                StudentCourtView.FindViewById<ProgressBar>(Resource.Id.DemeritsProgressBar);
            DormInfractionsProgBar =
                StudentCourtView.FindViewById<ProgressBar>(Resource.Id.DormInfractionsProgressBar);
            AbsencesProgBar =
                StudentCourtView.FindViewById<ProgressBar>(Resource.Id.AbsencesProgressBar);
            LateDormProgBar =
                StudentCourtView.FindViewById<ProgressBar>(Resource.Id.LateDormProgressBar);

            /* Set max value for progress bars                               */
            DemeritsProgBar.Max = App.StudentCourt.MaxDemerits;
            DormInfractionsProgBar.Max = App.StudentCourt.MaxDormInfractions;
            AbsencesProgBar.Max = App.StudentCourt.MaxAbsences;
            LateDormProgBar.Max = App.StudentCourt.MaxLateDormInfraction;

            StudentCourtView.Post(() => SetUpProgressBars());

            /*****************************************************************/
            /* Create Student Court Gradient                                 */
            /*****************************************************************/

            int startColor = Color.Transparent;
            int endColor;
            Color startColorAndroidGraphics;
            TextView statusText =
                StudentCourtView.FindViewById<TextView>(Resource.Id.StudentCourtStatusText);
            ImageView studentCourtImage =
                StudentCourtView.FindViewById<ImageView>(Resource.Id.StudentCourtCircle);
            Drawable imageBackground = studentCourtImage.Background;

            /* Convert dp stroke width to pixels for student court circle    */
            int strokeWidthDp = 4;
            DisplayMetrics displayMetrics = Resources.DisplayMetrics;
            float strokeWidth = TypedValue.ApplyDimension(
                ComplexUnitType.Dip, strokeWidthDp, displayMetrics);

            /* Set the start color for gradient                              */
            string screenColor = "Red";

            switch (ViewModel.StudentOffenseCard.StudentCourtStatus)
            {
                case App.StudentCourtStatus.Green:
                    {
                        startColor = ResourcesCompat.GetColor(
                            Resources, Resource.Color.green_500, null);
                        statusText.Text =
                            "You are not required to attend Student Court.";
                    }
                    break;
                case App.StudentCourtStatus.Gray:
                    {
                        startColor = ResourcesCompat.GetColor(
                            Resources, Resource.Color.body_text_soft_light_theme, null);
                        statusText.Text =
                            "You are not required to attend Student Court.";
                    }
                    break;
                case App.StudentCourtStatus.Red:
                    {
                        startColor = ResourcesCompat.GetColor(
                            Resources, Resource.Color.red_a700, null);
                        statusText.Text =
                            "You are required to attend Student Court.";
                    }
                    break;
            }

            /* Set color for circle image                                    */
            startColorAndroidGraphics = new Color(startColor);
            GradientDrawable shapeDrawable = (GradientDrawable)imageBackground;
            shapeDrawable.SetStroke((int)strokeWidth, startColorAndroidGraphics);

            /* Set text color for student court status                       */
            StudentCourtView.FindViewById<TextView>(Resource.Id.StudentCourtStatusText)
                .SetTextColor(startColorAndroidGraphics);

            /* Get the name of the current theme                             */
            TypedValue attrValue = new TypedValue();
            Activity.Theme.ResolveAttribute(
                Resource.Attribute.modThemeName, attrValue, true);

            /* Set the end color for gradient based on the current theme     */
            if (attrValue.String.ToString() == "ModAppCompatLightTheme")
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



            /*****************************************************************/
            /* Click events for info icons                                   */
            /*****************************************************************/
            StudentCourtView.FindViewById<ImageView>(Resource.Id.DormInfractionsInfoIcon).Click += ShowInfoIconDialog;
            StudentCourtView.FindViewById<ImageView>(Resource.Id.AbsencesInfoIcon).Click += ShowInfoIconDialog;
            StudentCourtView.FindViewById<ImageView>(Resource.Id.LateDormInfoIcon).Click += ShowInfoIconDialog;

            /* Use this to return your custom view for this Fragment         */
            return StudentCourtView;
        }

        private async void ShowInfoIconDialog(object sender, EventArgs e)
        {
            string tag = (sender as ImageView).Tag.ToString();

            /* Disable the button                                            */
            (sender as ImageView).Enabled = false;

            /* Build and create the dialog                                   */
            AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(Activity);
            //dialogBuilder.SetView(Resource.Layout.GradesTeacherInfoLayout);
            AlertDialog dialogBox = dialogBuilder.Create();

            /* Set the dialog title and message                              */
            switch (tag)
            {
                case "DormInfractionsInfoIcon":
                    {
                        dialogBox.SetTitle("Residence Hall Infractions");
                        dialogBox.SetMessage("These records do not include pending report slips. For each residence hall violation after 10 cumulative incidents, a $5.00 fine will be assessed.");
                    }
                    break;
                case "AbsencesInfoIcon":
                    {
                        dialogBox.SetTitle("Unexcused Class Absences");
                        dialogBox.SetMessage("These records do not include pending report slips. For each unexcused absence after 12 cumulative unexcused absences in all classes, 10 demerits will be given.");
                    }
                    break;
                case "LateDormInfoIcon":
                    {
                        dialogBox.SetTitle("Late Out/Into Residence Hall Infractions");
                        dialogBox.SetMessage("These records do not include pending report slips. For each late out/into residence hall violation after 10 cumulative incidents, a $5.00 fine will be assessed.");
                    }
                    break;
            }

            /* Set dialog animation                                          */
            dialogBox.Window.SetWindowAnimations(Resource.Style.Base_Animation_AppCompat_DropDownUp);

            /* Show the dialog                                               */
            await Task.Delay(100);
            dialogBox.Show();
            await Task.Delay(400);
            (sender as ImageView).Enabled = true;
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

            holder.DeleteBinding(_titleView);
            holder.DeleteBinding(_dateView);
            holder.DeleteBinding(_timeView);

            var _titleBinding = new Binding<string, string>
                (
                    offenseCard,
                    () => offenseCard.OffenseTitle,
                    _titleView,
                    () => _titleView.Text,
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

            var _timeBinding = new Binding<string, string>
                (
                    offenseCard,
                    () => offenseCard.OffenseTime,
                    _timeView,
                    () => _timeView.Text,
                    BindingMode.OneWay
                );

            holder.SaveBinding(_titleView, _titleBinding);
            holder.SaveBinding(_dateView, _dateBinding);
            holder.SaveBinding(_timeView, _timeBinding);
        }

        private void SetUpProgressBars()
        {

            /* Progress bar animations                                       */
            AndroidAnimation.ObjectAnimator _demeritsProgBarAnim,
                                            _dormInfractionsProgBarAnim,
                                            _absencesProgBarAnim,
                                            _lateDormProgBarAnim;

            /* Set student total demerits and infractions                    */
            TotalDemerits = 50 * App.StudentCourt.ProgBarMultiplier;
            TotalDormInfractions = 7 * App.StudentCourt.ProgBarMultiplier;
            TotalAbsences = 5 * App.StudentCourt.ProgBarMultiplier;
            TotalLateDorm = 6 * App.StudentCourt.ProgBarMultiplier;
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