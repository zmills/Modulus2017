/*****************************************************************************/
/*                             examScheduleFragment                          */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using EaglesNestMobileApp.Core.ViewModel.AcademicsViewModels;
using EaglesNestMobileApp.Core;
using GalaSoft.MvvmLight.Helpers;
using EaglesNestMobileApp.Core.Model;
using Android.Support.V7.Widget;
using System;
using Android.Widget;
using Android.Support.Design.Widget;

namespace EaglesNestMobileApp.Android.Views.Academics
{
    public class examScheduleFragment : Fragment
    {
        private View _examScheduleFragmentView;
        private ObservableRecyclerAdapter<Course, CachingViewHolder> _adapter;
        private RecyclerView _recyclerView;
        private int _position;
        public ExamScheduleFragmentViewModel ViewModel
        {
            get { return App.Locator.Exams; }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Use this to return your custom view for this Fragment         */
            _examScheduleFragmentView = inflater
                .Inflate(Resource.Layout.ExamScheduleFragmentLayout, container, false);

            _recyclerView =
                _examScheduleFragmentView.FindViewById<RecyclerView>(
                    Resource.Id.ExamScheduleRecyclerView);

            ParentFragment.View.FindViewById<TabLayout>(Resource.Id.MainTabLayout)
                .TabReselected += TabLayoutTabReselected;

            Activity.RunOnUiThread(() => _adapter =
                ViewModel.Classes.GetRecyclerAdapter(BindViewHolder,
                    Resource.Layout.ExamScheduleCardLayout));

            Activity.RunOnUiThread(() => _recyclerView.SetLayoutManager(
                new LinearLayoutManager(Activity)));

            Activity.RunOnUiThread(() => _recyclerView.SetAdapter(_adapter));

            return _examScheduleFragmentView;
        }

        private void TabLayoutTabReselected(object sender,
            TabLayout.TabReselectedEventArgs newEvent)
        {
            /* Scroll to the top when the tab is reselected                        */
            if (newEvent.Tab.Text == App.Tabs.AcademicsPage[1].ToString())
            {
                if (_position > 10)
                {
                    Activity.RunOnUiThread(() => _recyclerView.ScrollToPosition(10));
                }
                Activity.RunOnUiThread(() => _recyclerView.SmoothScrollToPosition(0));
            }
        }

        private void BindViewHolder(CachingViewHolder holder, Course section, int position)
        {
            _position = holder.AdapterPosition;

            TextView _courseNumber = holder.FindCachedViewById<TextView>(Resource.Id.examClassNumber);
            TextView _courseName = holder.FindCachedViewById<TextView>(Resource.Id.examClassName);
            TextView _examDate = holder.FindCachedViewById<TextView>(Resource.Id.examDate);
            TextView _examTime = holder.FindCachedViewById<TextView>(Resource.Id.examTime);
            TextView _examLocation = holder.FindCachedViewById<TextView>(Resource.Id.examRoomLocation);
            
            /* Set the binding for the course code */
            holder.DeleteBinding(_courseNumber);
            var numberBinding = new Binding<string, string>(
                section,
                () => section.FormattedCourseCode,
                _courseNumber,
                () => _courseNumber.Text,
                BindingMode.OneWay);
            holder.SaveBinding(_courseNumber, numberBinding);

            /* Set binding for the coursename            */
            holder.DeleteBinding(_courseName);
            var nameBinding = new Binding<string, string>(
                section,
                () => section.CourseName,
                _courseName,
                () => _courseName.Text,
                BindingMode.OneWay);
            holder.SaveBinding(_courseName, nameBinding);

            /* Set binding for the exam date  */
            holder.DeleteBinding(_examDate);
            var dateBinding = new Binding<string, string>(
                section,
                () => section.ExamDay,
                _examDate,
                () => _examDate.Text,
                BindingMode.OneWay);
            holder.SaveBinding(_examDate, dateBinding);

            /* Set binding for exam time  */
            holder.DeleteBinding(_examTime);
            var timeBinding = new Binding<string, string>(
                section,
                () => section.ExamTime,
                _examTime,
                () => _examTime.Text,
                BindingMode.OneWay);
            holder.SaveBinding(_examTime, timeBinding);
            

            /*Set the binding for the exam location*/
            holder.DeleteBinding(_examLocation);
            var locationBinding = new Binding<string, string>(
                section,
                () => section.Location,
                _examLocation,
                () => _examLocation.Text,
                BindingMode.OneWay);

            holder.SaveBinding(_examLocation, locationBinding);
        }
    }
}