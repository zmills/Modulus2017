/*****************************************************************************/
/*                              grabNGoFragment                              */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using EaglesNestMobileApp.Core.ViewModel.DiningViewModels;
using EaglesNestMobileApp.Core;
using GalaSoft.MvvmLight.Helpers;
using EaglesNestMobileApp.Core.Model;
using Android.Support.V7.Widget;
using Android.Support.Design.Widget;
using Android.Widget;
using static Android.Support.Design.Widget.TabLayout;

namespace EaglesNestMobileApp.Android.Views.Dining
{
    public class grabNGoFragment : Fragment
    {
        private View _grabAndGoFragmentView;

        public GrabAndGoFragmentViewModel ViewModel
        {
            get { return App.Locator.GrabAndGo; }
        }

        /* All the recyclerview adapters */
        private ObservableRecyclerAdapter<GrabAndGoItem, CachingViewHolder> _lineOneAdapter;
        private ObservableRecyclerAdapter<GrabAndGoItem, CachingViewHolder> _lineTwoAdapter;
        private ObservableRecyclerAdapter<GrabAndGoItem, CachingViewHolder> _lineThreeAdapter;
        private ObservableRecyclerAdapter<GrabAndGoItem, CachingViewHolder> _lineFourAdapter;
        
        /* All the recyclerviews                                            */
        private RecyclerView _lineOneRecyclerView;
        private RecyclerView _lineTwoRecyclerView;
        private RecyclerView _lineThreeRecyclerView;
        private RecyclerView _lineFourRecyclerView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Use this to return your custom view for this Fragment         */
            _grabAndGoFragmentView = inflater.Inflate(Resource.Layout.GrabNGoFragmentLayout, 
                container, false);

            TabLayout _tabLayout =
                _grabAndGoFragmentView.FindViewById<TabLayout>(Resource.Id.GrabAndGoTabLayout);

            Activity.RunOnUiThread(() => _tabLayout.TabSelected += TabLayoutSelected);

            /* Get all of the recyclerviews                                      */
            Activity.RunOnUiThread(() => GetRecyclerViews());

            /* Set the adapters                                                  */
            Activity.RunOnUiThread(() => BindAdapters());

            /* Set the layout managers                                           */
            Activity.RunOnUiThread(() => SetLayoutManagers());

            /* Set the recylerviews to their adapters                            */
            Activity.RunOnUiThread(() => SetAdaptersToRecyclerViews());

            return _grabAndGoFragmentView;
        }
        private void TabLayoutSelected(object sender, TabSelectedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Tab.Text);

            Activity.RunOnUiThread(() => ViewModel.GrabAndGoMenu.GetMealTime(e.Tab.Text));
            Activity.RunOnUiThread(() => UpDateDataSource());
        }

        private void UpDateDataSource()
        {
            Activity.RunOnUiThread(() => _lineOneAdapter.DataSource = ViewModel.GrabAndGoMenu.LineOne);
            Activity.RunOnUiThread(() => _lineTwoAdapter.DataSource = ViewModel.GrabAndGoMenu.LineTwo);
            Activity.RunOnUiThread(() => _lineThreeAdapter.DataSource = ViewModel.GrabAndGoMenu.LineThree);
            Activity.RunOnUiThread(() => _lineFourAdapter.DataSource = ViewModel.GrabAndGoMenu.LineFour);
        }

        /* Get the recyclerviews in from the xml layout                          */
        public void GetRecyclerViews()
        {
            _lineOneRecyclerView =
                _grabAndGoFragmentView.FindViewById<RecyclerView>(Resource.Id.GrabAndGoLine1);
            _lineTwoRecyclerView =
                _grabAndGoFragmentView.FindViewById<RecyclerView>(Resource.Id.GrabAndGoLine2);
            _lineThreeRecyclerView =
                _grabAndGoFragmentView.FindViewById<RecyclerView>(Resource.Id.GrabAndGoLine3);
            _lineFourRecyclerView =
                _grabAndGoFragmentView.FindViewById<RecyclerView>(Resource.Id.GrabAndGoLine4);
        }

        public void BindAdapters()
        {
            _lineOneAdapter = ViewModel.GrabAndGoMenu.LineOne.GetRecyclerAdapter(
                BindViewHolder, Resource.Layout.FoodMenuList);
            _lineTwoAdapter = ViewModel.GrabAndGoMenu.LineTwo.GetRecyclerAdapter(
                BindViewHolder, Resource.Layout.FoodMenuList);
            _lineThreeAdapter = ViewModel.GrabAndGoMenu.LineThree.GetRecyclerAdapter(
                BindViewHolder, Resource.Layout.FoodMenuList);
            _lineFourAdapter = ViewModel.GrabAndGoMenu.LineFour.GetRecyclerAdapter(
                BindViewHolder, Resource.Layout.FoodMenuList);
        }

        private void BindViewHolder(CachingViewHolder holder, GrabAndGoItem varsityItem, int position)
        {
            TextView _textview = holder.FindCachedViewById<TextView>(Resource.Id.listItem);

            holder.DeleteBinding(_textview);

            var itemBinding = new Binding<string, string>(
                varsityItem,
                () => varsityItem.ItemName,
                _textview,
                () => _textview.Text,
                BindingMode.OneWay,
                "Closed"
               );

            holder.SaveBinding(_textview, itemBinding);
        }


        public void SetAdaptersToRecyclerViews()
        {
            _lineOneRecyclerView.SetAdapter(_lineOneAdapter);
            _lineTwoRecyclerView.SetAdapter(_lineTwoAdapter);
            _lineThreeRecyclerView.SetAdapter(_lineThreeAdapter);
            _lineFourRecyclerView.SetAdapter(_lineFourAdapter);
        }

        public void SetLayoutManagers()
        {
            _lineOneRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
            _lineTwoRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
            _lineThreeRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
            _lineFourRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
        }
    }
}