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
using Android.Support.Design.Widget;

namespace EaglesNestMobileApp.Android.Views.Account
{
    public class scheduleFragment : Fragment
    {
        private View _scheduleFragmentView;
        private View _parentView;
        private RecyclerView _recyclerview;
        private TextView _title;
        private ObservableRecyclerAdapter<StudentEvent, CachingViewHolder> _adapter;

        public ScheduleFragmentViewModel ViewModel
        {
            get { return App.Locator.StudentSchedule; }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            if(_parentView != null)
                _parentView.Visibility = ViewStates.Visible;
            RetainInstance = true;
            UserVisibleHint = true;
        }

        public override void OnPause()
        {
            ParentFragment.View.FindViewById<Spinner>(Resource.Id.DaySpinner).Visibility = ViewStates.Gone;
            base.OnPause();
        }

        public override void SetMenuVisibility(bool menuVisible)
        {
            base.SetMenuVisibility(menuVisible);

            if (menuVisible)
            {

                System.Diagnostics.Debug.WriteLine("VISIBLE: VISIBLE");
                if (FragmentManager.Fragments != null || _parentView != null)
                {
                    if (_parentView != null)
                        _parentView.Visibility = ViewStates.Visible;
                    else
                        FragmentManager.Fragments[0].ParentFragment.View.FindViewById<Spinner>(Resource.Id.DaySpinner).Visibility = ViewStates.Visible;
                }

            }
            else
            {
                System.Diagnostics.Debug.WriteLine("INVISIBLE");
                if (FragmentManager.Fragments != null)
                    FragmentManager.Fragments[0].ParentFragment.View.FindViewById<Spinner>(Resource.Id.DaySpinner).Visibility = ViewStates.Gone;
            }
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            if (IsMenuVisible)
            {
                _parentView.Visibility = ViewStates.Visible;
            }
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Use this to return your custom view for this Fragment         */
            _scheduleFragmentView = inflater.Inflate(Resource.Layout.ScheduleFragmentLayout, 
                container, false);

            _parentView = ParentFragment.View.FindViewById<Spinner>(Resource.Id.DaySpinner);

            _recyclerview = _scheduleFragmentView.FindViewById<RecyclerView>(Resource.Id.StudentScheduleRecyclerview);

            _adapter = ViewModel.Schedule[0].GetRecyclerAdapter
                (
                    BindViewHolder, Resource.Layout.StudentScheduleRecyclerViewLayout
                );
            
            _title = _scheduleFragmentView.FindViewById<TextView>(Resource.Id.StudentScheduleDay);

            ParentFragment.View.FindViewById<Spinner>(Resource.Id.DaySpinner).ItemSelected += DayClicked;

            _recyclerview.SetAdapter(_adapter);

            _recyclerview.SetLayoutManager(new LinearLayoutManager(Activity));

            return _scheduleFragmentView;
        }

        private void DayClicked(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            SelectDay((sender as Spinner).GetItemAtPosition(e.Position).ToString());
        }

        public override void OnResume()
        {
            base.OnResume();
            SelectDay(ParentFragment.View.FindViewById<Spinner>(Resource.Id.DaySpinner).SelectedItem.ToString());
        }

        private void BindViewHolder(CachingViewHolder holder, StudentEvent studentEvent, int position)
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
                    ()=> studentEvent.EventTime,
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

        private void SelectDay(string day)
        {
            switch (day)
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
                        _adapter.NotifyDataSetChanged();
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
    }
}