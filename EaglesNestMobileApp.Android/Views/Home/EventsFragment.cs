/*****************************************************************************/
/*                              eventsFragment                               */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Support.Design.Widget;
using EaglesNestMobileApp.Core.Model.Home;
using GalaSoft.MvvmLight.Helpers;
using EaglesNestMobileApp.Core.ViewModel;
using EaglesNestMobileApp.Core;
using Android.Widget;

namespace EaglesNestMobileApp.Android.Views.Home
{
    public class eventsFragment : Fragment
    {
        /* This will bind to the list in the viewmodel                       */
        private ObservableRecyclerAdapter<EventsSignUp, CachingViewHolder> _adapter;
        private RecyclerView _eventRecyclerView;
        private TabLayout _currentTabLayout;
        private View _eventSignUpView;
        private int _position;

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

            _eventRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
            _eventRecyclerView.SetAdapter(_adapter);

            _currentTabLayout = ParentFragment.View.FindViewById<TabLayout>(Resource.Id.MainTabLayout);
            _currentTabLayout.TabReselected += TabLayoutTabReselected;

            return _eventSignUpView;
        }

        private void OnItemClick(int oldPosition, View oldView, int newPosition, View newView)
        {
            Activity.RunOnUiThread(() => ViewModel.Refresh());
        }

        private void BindViewHolder(CachingViewHolder Holder, EventsSignUp card, int position)
        {
            _position = position;

            var _textview = Holder.FindCachedViewById<TextView>(Resource.Id.eventSignUpTitle);

            Holder.DeleteBinding(_textview);

            var nameBinding = new Binding<string, string>(
                card,
                () => card.Title,
                _textview,
                () => _textview.Text,
                BindingMode.OneWay);

            Holder.SaveBinding(_textview, nameBinding);
        }

        private void TabLayoutTabReselected(object sender, TabLayout.TabReselectedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Tab.Text);
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