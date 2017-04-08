/*****************************************************************************/
/*                              scheduleFragment                             */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using EaglesNestMobileApp.Core.ViewModel.AccountViewModels;
using EaglesNestMobileApp.Core;
using Android.Support.V7.Widget;
using EaglesNestMobileApp.Core.Model.Personal;
using GalaSoft.MvvmLight.Helpers;
using System;
using Android.Widget;
using System.Collections.Generic;

namespace EaglesNestMobileApp.Android.Views.Account
{
    public class scheduleFragment : Fragment
    {
        private View _scheduleFragmentView;
        private RecyclerView _recyclerview;
        private TextView _title;
        private ObservableRecyclerAdapter<ScheduleEvent, CachingViewHolder> _adapter;

        public ScheduleFragmentViewModel ViewModel
        {
            get { return App.Locator.StudentSchedule; }
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
            _scheduleFragmentView = inflater.Inflate(Resource.Layout.ScheduleFragmentLayout, 
                container, false);

            _recyclerview = _scheduleFragmentView.FindViewById<RecyclerView>(Resource.Id.StudentScheduleRecyclerview);

            _adapter = ViewModel.Schedule[0].GetRecyclerAdapter
                (
                    BindViewHolder, Resource.Layout.StudentScheduleRecyclerViewLayout
                );

            _scheduleFragmentView.FindViewById<ImageButton>(Resource.Id.Sunday).Click += DayClicked;
            _scheduleFragmentView.FindViewById<ImageButton>(Resource.Id.Monday).Click += DayClicked;
            _scheduleFragmentView.FindViewById<ImageButton>(Resource.Id.Tuesday).Click += DayClicked;
            _scheduleFragmentView.FindViewById<ImageButton>(Resource.Id.Wednesday).Click += DayClicked;
            _scheduleFragmentView.FindViewById<ImageButton>(Resource.Id.Thursday).Click += DayClicked;
            _scheduleFragmentView.FindViewById<ImageButton>(Resource.Id.Friday).Click += DayClicked;
            _scheduleFragmentView.FindViewById<ImageButton>(Resource.Id.Saturday).Click += DayClicked;
            _title = _scheduleFragmentView.FindViewById<TextView>(Resource.Id.StudentScheduleDay);

            _recyclerview.SetAdapter(_adapter);

            _recyclerview.SetLayoutManager(new LinearLayoutManager(Activity));

            return _scheduleFragmentView;
        }

        private void DayClicked(object sender, EventArgs e)
        {
            
            System.Diagnostics.Debug.WriteLine((sender as View).Tag);
            switch ((sender as View).Tag.ToString())
            {
                case App.Days.Sunday:
                    {
                        _adapter.DataSource = ViewModel.Schedule[0];
                        _title.Text = App.Days.Sunday;
                        _adapter.NotifyDataSetChanged();
                    }
                    break;
                case App.Days.Monday:
                    {
                        _adapter.DataSource = ViewModel.Schedule[1];
                        _title.Text = App.Days.Monday;
                        _adapter.NotifyDataSetChanged();
                    }
                    break;
                case App.Days.Tuesday:
                    {
                        _adapter.DataSource = ViewModel.Schedule[2];
                        _title.Text = App.Days.Tuesday;
                    }
                    break;
                case App.Days.Wednesday:
                    {
                        _adapter.DataSource = ViewModel.Schedule[3];
                        _title.Text = App.Days.Wednesday;
                    }
                    break;
                case App.Days.Thursday:
                    {
                        _adapter.DataSource = ViewModel.Schedule[4];
                        _title.Text = App.Days.Thursday;
                    }
                    break;
                case App.Days.Friday:
                    {
                        _adapter.DataSource = ViewModel.Schedule[5];
                        _title.Text = App.Days.Friday;
                    }
                    break;
                case App.Days.Saturday:
                    {
                        _adapter.DataSource = ViewModel.Schedule[6];
                        _title.Text = App.Days.Saturday;
                    }
                    break;
            }
        }

        private void BindViewHolder(CachingViewHolder holder, ScheduleEvent studentEvent, int position)
        {
            TextView _time     = holder.FindCachedViewById<TextView>(Resource.Id.studentScheduleEventTime);
            TextView _title    = holder.FindCachedViewById<TextView>(Resource.Id.studentScheduleEventTitle);
            TextView _location = holder.FindCachedViewById<TextView>(Resource.Id.studentScheduleEventDescription);

            holder.DeleteBinding(_time    );
            holder.DeleteBinding(_title   );
            holder.DeleteBinding(_location);

            var _timeBinding = new Binding<string, string>
                (
                    studentEvent,
                    ()=> studentEvent.Time,
                    _time,
                    ()=>_time.Text
                );

            var _titleBinding = new Binding<string, string>
                (
                    studentEvent,
                    () => studentEvent.Title,
                    _title,
                    () => _title.Text
                );

            var _locationBinding = new Binding<string, string>
                (
                     studentEvent,
                    () => studentEvent.Location,
                    _location,
                    () => _location.Text
                );

            holder.SaveBinding(_time    ,_timeBinding);
            holder.SaveBinding(_title   ,_titleBinding);
            holder.SaveBinding(_location,_locationBinding);
        }
    }
}