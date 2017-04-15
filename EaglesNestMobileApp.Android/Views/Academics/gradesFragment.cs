/*****************************************************************************/
/*                                gradesFragment                             */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using EaglesNestMobileApp.Core.Model;
using GalaSoft.MvvmLight.Helpers;
using EaglesNestMobileApp.Core.Model.Academics;
using EaglesNestMobileApp.Core.ViewModel;
using EaglesNestMobileApp.Core;
using Android.Support.Design.Widget;
using Android.Widget;
using System;
using Dialog = Android.App.Dialog;
using Android.Views.Animations;
using Android.Support.Transitions;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Android.Views.Academics
{
    public class gradesFragment : Fragment
    {
        /* Parent and child recycler views                                         */
        private RecyclerView _gradesRecyclerView;
        private RecyclerView _assignmentsRecyclerView;

        /* Observable adapters for the recyclerviews                               */
        private ObservableRecyclerAdapter<GradeCard, CachingViewHolder> _gradesAdapter;
        private ObservableRecyclerAdapter<Assignment, CachingViewHolder> _assignmentAdapter;

        /* Main view for the fragment                                              */
        private View _gradesView;

        private CachingViewHolder _holder;
        private TabLayout _currentTabLayout;

        /* Hold this for when we're scrolling back up                              */
        private int _position { get; set; }

        /* Position for closing and reopening grades layout       */
        private int _expandedPosition = -1;

        /* Arrow to be rotated along with its transition          */
        private RotateAnimation _rotateArrow;
        private TransitionSet _transitionSet;

        /* Get the instance of the Grades viewmodel                                */
        public GradesFragmentViewModel ViewModel
        {
            get { return App.Locator.Grades; }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            /* Create rotate animation */
            _rotateArrow = new RotateAnimation(0, 180, Dimension.RelativeToSelf, 0.5f, Dimension.RelativeToSelf, 0.5f)
            {
                Duration = 500,
                Interpolator = new AnticipateOvershootInterpolator(),
                FillAfter = true
            };
        }

        public override View OnCreateView(LayoutInflater inflater,
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Inflate the layout for the fragment                                 */
            _gradesView = inflater.Inflate(Resource.Layout.GradesFragmentLayout,
                container, false);

            /* Get the parent recyclerview                                         */
            _gradesRecyclerView =
                _gradesView.FindViewById<RecyclerView>(
                    Resource.Id.GradesRecyclerView);

            Activity.RunOnUiThread(() => _gradesAdapter =
                ViewModel.Grades.GetRecyclerAdapter(BindViewHolder,
                    Resource.Layout.GradesCardLayout));

            /* Setup the recyclerview with the created adapter and layout manager  */
            _gradesRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
            _gradesRecyclerView.SetAdapter(_gradesAdapter);

            /* Get the tablayout so we can scroll back up                          */
            _currentTabLayout =
                ParentFragment.View.FindViewById<TabLayout>(Resource.Id.MainTabLayout);

            _currentTabLayout.TabReselected += TabLayoutTabReselected;

            return _gradesView;
        }

        private void TabLayoutTabReselected(object sender,
            TabLayout.TabReselectedEventArgs newEvent)
        {
            /* Scroll to the top when the tab is reselected                        */
            if (newEvent.Tab.Text == App.Tabs.AcademicsPage[0].ToString())
            {
                if (_position > 10)
                {
                    Activity.RunOnUiThread(() => _gradesRecyclerView.ScrollToPosition(10));
                }
                Activity.RunOnUiThread(() => _gradesRecyclerView.SmoothScrollToPosition(0));
            }
        }

        private void BindViewHolder(CachingViewHolder holder, GradeCard gradeCard, int position)
        {
            _position = position;

            LinearLayout _expandArea =
                holder.FindCachedViewById<LinearLayout>(Resource.Id.llExpandArea);

       

            /* Handle the closing of the previous recyclerview */
            if (position == _expandedPosition)
            {
                System.Diagnostics.Debug.Write("OPEN-POSITION(" + position + ")");
                System.Diagnostics.Debug.Write("OPEN-VH.POSITION(" + holder.AdapterPosition + ")");
                holder.FindCachedViewById<ImageView>(Resource.Id.ShowGradesArrowIcon).StartAnimation(_rotateArrow);
                _expandArea.Visibility = ViewStates.Visible;
            }
            else
            {
                System.Diagnostics.Debug.Write("CLOSE-POSITION(" + position + ")");
                System.Diagnostics.Debug.Write("CLOSE-VH.POSITION(" + holder.AdapterPosition + ")");
                Activity.RunOnUiThread(() => _expandArea.Visibility = ViewStates.Gone);
            }

            TextView _className =
                holder.FindCachedViewById<TextView>(Resource.Id.GradesCardClassName);

            TextView _courseGrade =
                holder.FindCachedViewById<TextView>(Resource.Id.CourseGrade);

            holder.FindCachedViewById<Button>(Resource.Id.TeacherInfoButton).Click += ShowTeacherInfo;
            holder.FindCachedViewById<Button>(Resource.Id.ShowGradesButton).Tag = holder;
            holder.FindCachedViewById<Button>(Resource.Id.ShowGradesButton).Click += ShowGrades;

            /* Set up the child recyclerview for the assignments                       */
            _assignmentsRecyclerView =
               holder.FindCachedViewById<RecyclerView>(
                   Resource.Id.AssignmentsRecyclerView);

            /* Bind to the data                                                    */
            Activity.RunOnUiThread(() => 
                _assignmentAdapter =
                    gradeCard.ClassAssignments.GetRecyclerAdapter(ChildBindViewHolder,
                        Resource.Layout.GradesAssignment));

            /* Set the nested recyclerview layout manager and adapter              */
            _assignmentsRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));

            _assignmentsRecyclerView.SetAdapter(_assignmentAdapter);

            /* Delete the binding for memory purposes                              */
            holder.DeleteBinding(_className);
            holder.DeleteBinding(_courseGrade);

            /* Create new binding and bind the properties to the view              */
            var _titleBinding = new Binding<string, string>(
                gradeCard,
                () => gradeCard.CourseTitle,
                _className,
                () => _className.Text,
                BindingMode.OneWay);

            var _gradeBinding = new Binding<string, string>(
                gradeCard,
                () => gradeCard.CourseGrade,
                _courseGrade,
                () => _courseGrade.Text,
                BindingMode.OneWay);

            /* Save the binding; remember to delete it later                       */
            holder.SaveBinding(_className, _titleBinding);
            holder.SaveBinding(_courseGrade, _gradeBinding);
        }

        private void ShowGrades(object sender, EventArgs e)
        {
            _holder = (CachingViewHolder)(sender as View).Tag;

            if (_expandedPosition >= 0)
            {
                int prev = _expandedPosition;

                System.Diagnostics.Debug.Write("ITEM COUNT: " + _gradesAdapter.ItemCount);
                System.Diagnostics.Debug.Write("PREV: " + prev + "VH.POSITION: " + _holder.AdapterPosition);

                _gradesAdapter.NotifyItemChanged(prev);
            }
            _expandedPosition = _holder.AdapterPosition;
            System.Diagnostics.Debug.Write("NOTIFY(EXPANDED_POSTION): " + _expandedPosition);
            _gradesAdapter.NotifyItemChanged(_expandedPosition);
        }

        private async void ShowTeacherInfo(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            Dialog _dialogBox = new Dialog(Activity/*, Resource.Style.ModAppCompatLightTheme*/);
            _dialogBox.SetTitle("Teacher Info");
            _dialogBox.Window.SetContentView(Resource.Layout.BoxCombinationDialogLayout);
            //_dialogBox.Window.SetWindowAnimations(Resource.Style.Base_Animation_AppCompat_DropDownUp);
            _dialogBox.Show();

            await Task.Delay(400);
            (sender as Button).Enabled = true;
        }

        private void ChildBindViewHolder(CachingViewHolder holder, 
            Assignment assignment, int position)
        {
            TextView _assignmentName =
                holder.FindCachedViewById<TextView>(Resource.Id.AssignmentName);

            TextView _assignmentDate =
                holder.FindCachedViewById<TextView>(Resource.Id.AssignmentDate);

            TextView _assignmentGrade =
                holder.FindCachedViewById<TextView>(Resource.Id.AssignmentGrade);

            /* Delete the previous binding                                         */
            holder.DeleteBinding(_assignmentName);
            holder.DeleteBinding(_assignmentDate);
            holder.DeleteBinding(_assignmentGrade);

            /* Create new bindings and and save them                         */
            var _nameBinding = new Binding<string, string>
                (
                    assignment,
                    () => assignment.AssignmentName,
                    _assignmentName,
                    () => _assignmentName.Text
                );

            var _dateBinding = new Binding<string, string>
                (
                    assignment,
                    () => assignment.AssignmentDate,
                    _assignmentDate,
                    () => _assignmentDate.Text
                );

            var _gradeBinding = new Binding<string, string>
                (
                    assignment,
                    () => assignment.GradeScore,
                    _assignmentGrade,
                    () => _assignmentGrade.Text
                );

            /* Save the binding                                                */
            holder.SaveBinding(_assignmentName, _nameBinding);
            holder.SaveBinding(_assignmentDate, _dateBinding);
            holder.SaveBinding(_assignmentGrade, _gradeBinding);
        }
    }
}



/////*****************************************************************************/
/////*                      OLDGRADES      gradesFragment                        */
/////*                                                                           */
/////*****************************************************************************/
//using Android.OS;
//using Android.Views;
//using Android.Support.V4.App;
//using Android.Support.V7.Widget;
//using System.Collections.Generic;
//using EaglesNestMobileApp.Android.Adapters;
//using EaglesNestMobileApp.Core.Model;
////using Android.Widget;
//using Android.Content;
//using Android.Support.Design.Widget;
//using Android.Animation;
//using Android.Widget;
//using static Android.Support.V7.Widget.RecyclerView;

//namespace EaglesNestMobileApp.Android.Views.Academics
//{
//    public class gradesFragment : Fragment
//    {
//        /* Public properties                                                 */
//        /* This will bind to the list in the viewmodel                       */
//        public List<Card> GradesCardList { get; set; }
//        public RecyclerView GradesRecyclerView { get; set; }
//        public gradesRecyclerViewAdapter GradesAdapter { get; set; }
//        public RecyclerView.LayoutManager GradesLayoutManager { get; set; }
//        public View GradesView { get; set; }

//        public override void OnCreate(Bundle savedInstanceState)
//        {
//            base.OnCreate(savedInstanceState);
//            RetainInstance = true;

//            InitializeGrades();
//        }

//        public override View OnCreateView(LayoutInflater inflater,
//            ViewGroup container, Bundle savedInstanceState)
//        {
//            /* Inflate the layout for the fragment                           */
//            GradesView = inflater.Inflate(Resource.Layout.GradesFragmentLayout,
//                container, false);

//            /* Get the view pager                                            */
//            GradesRecyclerView =
//                GradesView.FindViewById<RecyclerView>(
//                    Resource.Id.GradesRecyclerView);

//            /* Create a new layout manager using the activity containing     */
//            /* this fragment as the context                                  */

//            GradesLayoutManager = new LinearLayoutManager(Activity);

//            /* Create a custom adapter and pass it the data that it will be  */
//            /* recycling through                                             */
//            GradesAdapter = new gradesRecyclerViewAdapter(GradesCardList, Activity);

//            /* Setup the recyclerview with the created adapter and layout    */
//            /* manager                                                       */
//            GradesRecyclerView.SetLayoutManager(GradesLayoutManager);
//            GradesRecyclerView.SetAdapter(GradesAdapter);

//            return GradesView;
//        }

//        private void InitializeGrades()
//        {
//            GradesCardList = new List<Card>();
//            List<string> CourseNames = new List<string>();
//            CourseNames.Add("BA 403-4 Business Communications");
//            CourseNames.Add("BI 216-2 Teachings of Jesus");
//            CourseNames.Add("CC 131 College Choir");
//            CourseNames.Add("CS 432 Computer Architecture");
//            CourseNames.Add("CS 452 Software Engineering Project II");


//            for (int counter = 0; counter < 5; counter++)
//            {
//                Card current = new Card(CourseNames[counter]);
//                GradesCardList.Add(current);
//            }

//        }
//    }
//}