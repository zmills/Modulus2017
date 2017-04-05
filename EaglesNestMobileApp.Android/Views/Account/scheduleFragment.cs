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

namespace EaglesNestMobileApp.Android.Views.Account
{
    public class scheduleFragment : Fragment
    {
        private View _scheduleFragmentView;
        private RecyclerView _recyclerview;
        private ObservableRecyclerAdapter<ScheduleEvent, CachingViewHolder> _adapter;

        public ScheduleFragmentViewModel ViewModel
        {
            get { return App.Locator.StudentSchedule; }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
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

            _recyclerview.SetAdapter(_adapter);

            _recyclerview.SetLayoutManager(new LinearLayoutManager(Activity));

            return _scheduleFragmentView;
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