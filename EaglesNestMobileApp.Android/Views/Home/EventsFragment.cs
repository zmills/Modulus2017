/*****************************************************************************/
/*                              eventsFragment                               */
/*                                                                           */
/*****************************************************************************/
using ProgressDialog = Android.App.ProgressDialog;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using EaglesNestMobileApp.Core;
using EaglesNestMobileApp.Core.Model.Home;
using EaglesNestMobileApp.Core.ViewModel;
using GalaSoft.MvvmLight.Helpers;
using EaglesNestMobileApp.Android.Helpers;
using Android.Support.V4.Widget;
using System;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Android.Views.Home
{
    public class eventsFragment : Fragment
    {
        /* This will bind to the list in the view-model                       */
        private ObservableRecyclerAdapter<Events, CachingViewHolder> _adapter;
        private RecyclerView _eventRecyclerView;
        private TabLayout _currentTabLayout;
        private View _eventSignUpView;
        private int _position;
        public SwipeRefreshLayout RefreshLayout { get; set; }

        public EventsFragmentViewModel ViewModel
        {
            get { return App.Locator.Events; }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater,
            ViewGroup container, Bundle savedInstanceState)
        {
            // Inflate the layout for the fragment
            _eventSignUpView =
                inflater.Inflate(Resource.Layout.EventsFragmentLayout,
                                    container, false);
            /* Get the view pager                                            */
            _eventRecyclerView =
                _eventSignUpView.FindViewById<RecyclerView>(
                    Resource.Id.EventSignUpRecyclerView);

            _adapter = ViewModel.Events.GetRecyclerAdapter(
                BindViewHolder,
                Resource.Layout.EventCardLayout,
                OnItemClick);


            /* "Pulling" down on the page will refresh the view              */
            RefreshLayout =
                _eventSignUpView.FindViewById<SwipeRefreshLayout>(
                    Resource.Id.SwipeRefreshEvents);

            RefreshLayout.SetColorSchemeResources(Resource.Color.primary,
                Resource.Color.accent, Resource.Color.primary_text,
                    Resource.Color.secondary_text);
            RefreshLayout.Refresh += RefreshLayoutRefresh;


            _eventRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
            _eventRecyclerView.SetAdapter(_adapter);

            _currentTabLayout = ParentFragment.View.FindViewById<TabLayout>(Resource.Id.MainTabLayout);
            _currentTabLayout.TabReselected += TabLayoutTabReselected;

            return _eventSignUpView;
        }

        private async void RefreshLayoutRefresh(object sender, EventArgs e)
        {
            await Task.Delay(2000);
            RefreshLayout.Refreshing = false;
        }

        private void OnItemClick(int oldPosition, View oldView, int newPosition, View newView)
        {
            Activity.RunOnUiThread(async () => await ViewModel.Refresh());
        }

        private void BindViewHolder(CachingViewHolder Holder, Events card, int position)
        {
            _position = position;

            TextView _eventName = Holder.FindCachedViewById<TextView>(Resource.Id.eventSignUpTitle);
            TextView _eventTime = Holder.FindCachedViewById<TextView>(Resource.Id.eventSignUpDateTime);
            TextView _eventDescription = Holder.FindCachedViewById<TextView>(Resource.Id.eventSignUpDescription);
            Button _eventSignupButton = Holder.FindCachedViewById<Button>(Resource.Id.eventSignUpButton);

            if (card.IsSignedUp)
            {
                _eventSignupButton.Text = "Signed Up";
                _eventSignupButton.Enabled = false;
            }
            _eventSignupButton.Click += (sender, clickEvent) =>
            {
                card.IsSignedUp = true;
                _eventSignupButton.Text = "Signed Up";
                _eventSignupButton.Enabled = false;
                Activity.RunOnUiThread(async ()=> await ViewModel.Signup(card));
            };

            Holder.DeleteBinding(_eventName);
            Holder.DeleteBinding(_eventTime);
            Holder.DeleteBinding(_eventDescription);

            var nameBinding = new Binding<string, string>(
                card,
                () => card.EventName,
                _eventName,
                () => _eventName.Text,
                BindingMode.OneWay);

            var timeBinding = new Binding<string, string>(
                card,
                () => card.EventTime,
                _eventTime,
                () => _eventTime.Text,
                BindingMode.OneWay
                );

            var descriptionBinding = new Binding<string, string>(
                card,
                () => card.EventDescription,
                _eventDescription,
                () => _eventDescription.Text,
                BindingMode.OneWay
                );

            Holder.SaveBinding(_eventName, nameBinding);
            Holder.SaveBinding(_eventTime, timeBinding);
            Holder.SaveBinding(_eventDescription, descriptionBinding);
        }

        private void TabLayoutTabReselected(object sender, TabLayout.TabReselectedEventArgs e)
        {
            if (e.Tab.Text == "Events Signup")
            {
                if (_position > 10)
                {
                    _eventRecyclerView.ScrollToPosition(10);
                }
                _eventRecyclerView.SmoothScrollToPosition(0);
            }
        }
    }
}