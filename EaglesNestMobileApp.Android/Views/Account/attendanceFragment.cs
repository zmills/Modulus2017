/*****************************************************************************/
/*                             attendanceFragment                            */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using System;
using EaglesNestMobileApp.Core.ViewModel.AccountViewModels;
using GalaSoft.MvvmLight.Helpers;
using EaglesNestMobileApp.Core.Model;
using EaglesNestMobileApp.Core.Model.Personal;
using EaglesNestMobileApp.Core;

namespace EaglesNestMobileApp.Android.Views.Account
{
    public class attendanceFragment : Fragment
    {
        View _attendanceView;
        List<RecyclerView> RecyclerviewList = new List<RecyclerView>();
        RecyclerView _recyclerview;
        ObservableRecyclerAdapter<Course, CachingViewHolder> _adapter;

        public AttendanceFragmentViewModel ViewModel
        {
            get { return App.Locator.Attendance; }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Use this to return your custom view for this Fragment  */
            _attendanceView = inflater.Inflate(Resource.Layout.AttendanceFragmentLayout,
                container, false);

            _recyclerview =
                    _attendanceView.FindViewById<RecyclerView>(Resource.Id.AttendanceRecyclerView);

            _adapter = ViewModel.Classes.GetRecyclerAdapter
            (
                BindViewHolder, Resource.Layout.AttendanceRecyclerViewLayout
            );

            Activity.RunOnUiThread( ()=>
                {
                    _recyclerview.SetLayoutManager(new LinearLayoutManager(Activity));
                    _recyclerview.SetAdapter(_adapter);
                });

            return _attendanceView;
        }

        private void BindViewHolder(CachingViewHolder holder, Course course, int position)
        {
            TextView _classNameTextView    = holder.FindCachedViewById<TextView>(Resource.Id.attendanceClassName);
            TextView _absenceNumber        = holder.FindCachedViewById<TextView>(Resource.Id.attendanceClassUnexcusedNumber);
            TextView _pendingAbsenceNumber = holder.FindCachedViewById<TextView>(Resource.Id.AttendancePendingUnexcusedNumber);
            TextView _tardyNumber          = holder.FindCachedViewById<TextView>(Resource.Id.AttendanceTardiesNumber);
            TextView _pendingTardyNumber   = holder.FindCachedViewById<TextView>(Resource.Id.AttendancePendingTardiesNumber);

            /* Set up the children recyclerviews                          */
            SetUpRecyclerViews(holder, course);
            
            /* Delete the binding                            */
            holder.DeleteBinding(_classNameTextView);
            holder.DeleteBinding(_absenceNumber);
            holder.DeleteBinding(_pendingAbsenceNumber);
            holder.DeleteBinding(_tardyNumber);
            holder.DeleteBinding(_pendingTardyNumber);

            /* Create a new binding and save it              */
            var _classNameBinding = new Binding<string, string>
                (
                    course,
                    () => course.CourseName,
                    _classNameTextView,
                    ()=> _classNameTextView.Text
                );

            var _absenceNumberBinding = new Binding<string, string>
                (
                    course,
                    ()=> course.Absences,
                    _absenceNumber,
                    ()=> _absenceNumber.Text
                );

            var _pendingAbsenceNumberBinding = new Binding<string, string>
                (
                    course,
                    ()=> course.PendingAbsences,
                    _pendingAbsenceNumber,
                    ()=> _pendingAbsenceNumber.Text
                );


            var _tardyNumberBinding = new Binding<string, string>
                (
                    course,
                    () => course.Tardies,
                    _tardyNumber,
                    () => _tardyNumber.Text
                );

            var _pendingTardyNumberBinding = new Binding<string, string>
                (
                    course,
                    ()=> course.PendingTardies,
                    _pendingTardyNumber,
                    ()=> _pendingTardyNumber.Text
                );
            
            holder.SaveBinding(_classNameTextView, _classNameBinding);
            holder.SaveBinding(_absenceNumber,_absenceNumberBinding);
            holder.SaveBinding(_pendingAbsenceNumber, _pendingAbsenceNumberBinding);
            holder.SaveBinding(_tardyNumber, _tardyNumberBinding);
            holder.SaveBinding(_pendingTardyNumber, _pendingTardyNumberBinding);
        }

        private void SetUpRecyclerViews(CachingViewHolder holder, Course course)
        {
           
            RecyclerviewList = new List<RecyclerView>
            {
                holder.FindCachedViewById<RecyclerView>(Resource.Id.AttendancePenaltyListRecyclerView1),
                holder.FindCachedViewById<RecyclerView>(Resource.Id.AttendancePenaltyListRecyclerView2),
                holder.FindCachedViewById<RecyclerView>(Resource.Id.AttendancePenaltyListRecyclerView4),
                holder.FindCachedViewById<RecyclerView>(Resource.Id.AttendancePenaltyListRecyclerView3)
            };

            /* Set adapters and linearlayoutmanagers to the recyclerviews */
            Activity.RunOnUiThread(() =>
            {
                for (int count = 0; count < 4; count++)
                {
                    /* Set Adapters */
                    RecyclerviewList[count].SetAdapter
                        (
                            course.AttendanceViolations[count].GetRecyclerAdapter
                                (BindChildViewHolder, Resource.Layout.AttendancePenaltyLayout)
                        );

                    /* Set Layout Managers */
                    RecyclerviewList[count].SetLayoutManager(new LinearLayoutManager(Activity));
                }
            });
        }

        private void BindChildViewHolder(CachingViewHolder holder, AttendanceViolation violation, int position)
        {
            TextView _violation = holder.FindCachedViewById<TextView>(Resource.Id.AttendancePenaltyListItem);

            holder.DeleteBinding(_violation);
            var _violationBinding = new Binding<string, string>
                (
                    violation,
                    () => violation.Date,
                    _violation,
                    () => _violation.Text
                );

            holder.SaveBinding(_violation, _violationBinding);
        }
    }
}