/*****************************************************************************/
/*                                gradesFragment                             */
/*                                                                           */
/*****************************************************************************/
//using Android.OS;
//using Android.Views;
//using Android.Support.V4.App;
//using Android.Support.V7.Widget;
//using EaglesNestMobileApp.Core.Model;
//using GalaSoft.MvvmLight.Helpers;
//using EaglesNestMobileApp.Core.Model.Academics;
//using EaglesNestMobileApp.Core.ViewModel;
//using EaglesNestMobileApp.Core;
//using Android.Support.Design.Widget;
//using Android.Widget;

//namespace EaglesNestMobileApp.Android.Views.Academics
//{
//    public class gradesFragment : Fragment
//    {
//        /* Parent and child recycler views                                         */
//        private RecyclerView _gradesRecyclerView;
//        private RecyclerView _assignmentsRecyclerView;

//        /* Observable adapters for the recyclerviews                               */
//        private ObservableRecyclerAdapter<GradeCard, CachingViewHolder> _gradesAdapter;
//        private ObservableRecyclerAdapter<Assignment, CachingViewHolder> _assignmentAdapter;

//        /* Main view for the fragment                                              */
//        private View _gradesView;
//        private TabLayout _currentTabLayout;

//        /* Hold this for when we're scrolling back up                              */
//        private int _position { get; set; }

//        /* Get the instance of the Grades viewmodel                                */
//        public GradesFragmentViewModel ViewModel
//        {
//            get { return App.Locator.Grades; }
//        }

//        public override void OnCreate(Bundle savedInstanceState)
//        {
//            base.OnCreate(savedInstanceState);
//        }

//        public override View OnCreateView(LayoutInflater inflater,
//            ViewGroup container, Bundle savedInstanceState)
//        {
//            /* Inflate the layout for the fragment                                 */
//            _gradesView = inflater.Inflate(Resource.Layout.GradesFragmentLayout,
//                container, false);

//            /* Get the parent recyclerview                                         */
//            _gradesRecyclerView =
//                _gradesView.FindViewById<RecyclerView>(
//                    Resource.Id.GradesRecyclerView);

//            Activity.RunOnUiThread(() => _gradesAdapter =
//                ViewModel.Grades.GetRecyclerAdapter(BindViewHolder,
//                    Resource.Layout.GradesCardLayout, OnItemClick));

//            /* Setup the recyclerview with the created adapter and layout manager  */
//            _gradesRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
//            _gradesRecyclerView.SetAdapter(_gradesAdapter);

//            /* Get the tablayout so we can scroll back up                          */
//            _currentTabLayout =
//                ParentFragment.View.FindViewById<TabLayout>(Resource.Id.MainTabLayout);

//            _currentTabLayout.TabReselected += TabLayoutTabReselected;

//            return _gradesView;
//        }

//        private void TabLayoutTabReselected(object sender,
//            TabLayout.TabReselectedEventArgs newEvent)
//        {
//            /* Scroll to the top when the tab is reselected                        */
//            if (newEvent.Tab.Text == "Class Grades")
//            {
//                if (_position > 10)
//                {
//                    Activity.RunOnUiThread(() => _gradesRecyclerView.ScrollToPosition(10));
//                }
//                Activity.RunOnUiThread(() => _gradesRecyclerView.SmoothScrollToPosition(0));
//            }
//        }

//        /* No event handler yet                                                     */
//        private void OnItemClick(int oldViewPosition, View oldView, int newViewPosition, View newView)
//        {

//        }

//        private void BindViewHolder(CachingViewHolder holder, GradeCard gradeCard, int position)
//        {
//            /* Save the position for scrolling back up                             */
//            _position = position;

//            TextView _textview =
//                holder.FindCachedViewById<TextView>(Resource.Id.GradesCardClassName);

//            /* Get the recyclerview                                                */
//            _assignmentsRecyclerView =
//               holder.FindCachedViewById<RecyclerView>(
//                   Resource.Id.AssignmentsRecyclerView);

//            /* Bind to the data                                                    */
//            Activity.RunOnUiThread(() => _assignmentAdapter =
//            gradeCard.ClassAssignments.GetRecyclerAdapter(ChildBindViewHolder,
//                Resource.Layout.ClassAssignment,
//                OnChildClick
//                ));

//            /* Set the nested recyclerview layout manager and adapter              */
//            _assignmentsRecyclerView.SetLayoutManager(new LinearLayoutManager(
//                Activity, LinearLayoutManager.Vertical, false));

//            _assignmentsRecyclerView.SetAdapter(_assignmentAdapter);

//            /* Delete the binding for memory purposes                              */
//            holder.DeleteBinding(_textview);

//            /* Create new binding and bind the properties to the view              */
//            var titleBinding = new Binding<string, string>(
//                gradeCard,
//                () => gradeCard.CourseTitle,
//                _textview,
//                () => _textview.Text,
//                BindingMode.OneWay);

//            /* Save the binding; remember to delete it later                       */
//            holder.SaveBinding(_textview, titleBinding);
//        }

//        /* There is no event handler for this one yet; I don't think we'll have one*/
//        private void OnChildClick(int oldViewPosition, View oldView, int newViewPosition, View newView)
//        {

//        }

//        private void ChildBindViewHolder(CachingViewHolder holder, Assignment assignment, int position)
//        {
//            TextView _assignmentview =
//                holder.FindCachedViewById<TextView>(Resource.Id.AssignmentTextView);

//            /* Delete the previous binding                                         */
//            holder.DeleteBinding(_assignmentview);

//            /* Create a new binding and and save it                                */
//            var assignmentBinding = new Binding<string, string>(
//                assignment,
//                () => assignment.AssingmentName,
//                _assignmentview,
//                () => _assignmentview.Text);

//            holder.SaveBinding(_assignmentview, assignmentBinding);
//        }
//    }
//}



///*****************************************************************************/
///*                      OLDGRADES      gradesFragment                        */
///*                                                                           */
///*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using EaglesNestMobileApp.Android.Adapters;
using EaglesNestMobileApp.Core.Model;
//using Android.Widget;
using Android.Content;
using Android.Support.Design.Widget;
using Android.Animation;
using Android.Widget;

namespace EaglesNestMobileApp.Android.Views.Academics
{
    public class gradesFragment : Fragment
    {
        /* Public properties                                                 */
        /* This will bind to the list in the viewmodel                       */
        public List<Card> GradesCardList { get; set; }
        public RecyclerView GradesRecyclerView { get; set; }
        public gradesRecyclerViewAdapter GradesAdapter { get; set; }
        public RecyclerView.LayoutManager GradesLayoutManager { get; set; }
        public View GradesView { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;

            InitializeGrades();
        }

        public override View OnCreateView(LayoutInflater inflater,
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Inflate the layout for the fragment                           */
            GradesView = inflater.Inflate(Resource.Layout.GradesFragmentLayout,
                container, false);

            /* Get the view pager                                            */
            GradesRecyclerView =
                GradesView.FindViewById<RecyclerView>(
                    Resource.Id.GradesRecyclerView);

            /* Create a new layout manager using the activity containing     */
            /* this fragment as the context                                  */

            GradesLayoutManager = new LinearLayoutManager(Activity);

            /* Create a custom adapter and pass it the data that it will be  */
            /* recycling through                                             */
            GradesAdapter = new gradesRecyclerViewAdapter(GradesCardList, Activity);

            /* Setup the recyclerview with the created adapter and layout    */
            /* manager                                                       */
            GradesRecyclerView.SetLayoutManager(GradesLayoutManager);
            GradesRecyclerView.SetAdapter(GradesAdapter);
            return GradesView;
        }

        private void InitializeGrades()
        {
            GradesCardList = new List<Card>();
            List<string> CourseNames = new List<string>();
            CourseNames.Add("BA 403-4 Business Communications");
            CourseNames.Add("BI 216-2 Teachings of Jesus");
            CourseNames.Add("CC 131 College Choir");
            CourseNames.Add("CS 432 Computer Architecture");
            CourseNames.Add("CS 452 Software Engineering Project II");


            for (int counter = 0; counter < 5; counter++)
            {
                Card current = new Card(CourseNames[counter]);
                GradesCardList.Add(current);
            }

        }
    }
}