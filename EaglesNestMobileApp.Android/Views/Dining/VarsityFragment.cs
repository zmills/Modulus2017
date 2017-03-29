/*****************************************************************************/
/*                              varsityFragment                              */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;

using Android.Support.Design.Widget;
using System;
using Android.Widget;
using static Android.Support.Design.Widget.TabLayout;
using System.Collections.Generic;
using EaglesNestMobileApp.Android.Adapters;
using EaglesNestMobileApp.Core.ViewModel;
using EaglesNestMobileApp.Core;
using EaglesNestMobileApp.Core.Model;
using GalaSoft.MvvmLight.Helpers;
using Android.Support.V7.Widget;

namespace EaglesNestMobileApp.Android.Views.Dining
{
    public class varsityFragment : Fragment
    {
        private View _varsityFragmentView;

        public VarsityFragmentViewModel ViewModel
        {
            get { return App.Locator.Varsity; }
        }

        /* All the recyclerview adapters */
        private ObservableRecyclerAdapter<VarsityItem, CachingViewHolder> _lineOneAdapter;
        private ObservableRecyclerAdapter<VarsityItem, CachingViewHolder> _lineTwoAdapter;
        private ObservableRecyclerAdapter<VarsityItem, CachingViewHolder> _lineThreeAdapter;
        private ObservableRecyclerAdapter<VarsityItem, CachingViewHolder> _lineFourAdapter;
        private ObservableRecyclerAdapter<VarsityItem, CachingViewHolder> _lineFiveAdapter;

        /* All the recyclerviews                                            */
        private RecyclerView _lineOneRecyclerView;
        private RecyclerView _lineTwoRecyclerView;
        private RecyclerView _lineThreeRecyclerView;
        private RecyclerView _lineFourRecyclerView;
        private RecyclerView _lineFiveRecyclerView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater,
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Use this to return your custom view for this Fragment         */
            _varsityFragmentView = inflater.Inflate(Resource.Layout.VarsityFragmentLayout,
                             container, false);

            TabLayout _tabLayout =
                _varsityFragmentView.FindViewById<TabLayout>(Resource.Id.varsityTabs);

            Activity.RunOnUiThread(() => _tabLayout.TabSelected += TabLayoutSelected);

            /* Get all of the recyclerviews                                      */
            Activity.RunOnUiThread(() => GetRecyclerViews());

            /* Set the adapters                                                  */
            Activity.RunOnUiThread(() => BindAdapters());

            /* Set the layout managers                                           */
            Activity.RunOnUiThread(() => SetLayoutManagers());

            /* Set the recylerviews to their adapters                            */
            Activity.RunOnUiThread(() => SetAdaptersToRecyclerViews());

            return _varsityFragmentView;
        }

        private void TabLayoutSelected(object sender, TabSelectedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Tab.Text);

            Activity.RunOnUiThread(() => ViewModel.VarsityMenu.GetMealTime(e.Tab.Text));
            Activity.RunOnUiThread(() => UpDateDataSource());
        }

        private void UpDateDataSource()
        {
            Activity.RunOnUiThread(() => _lineOneAdapter.DataSource = ViewModel.VarsityMenu.LineOne);
            Activity.RunOnUiThread(() => _lineTwoAdapter.DataSource = ViewModel.VarsityMenu.LineTwo);
            Activity.RunOnUiThread(() => _lineThreeAdapter.DataSource = ViewModel.VarsityMenu.LineThree);
            Activity.RunOnUiThread(() => _lineFourAdapter.DataSource = ViewModel.VarsityMenu.LineFour);
            Activity.RunOnUiThread(() => _lineFiveAdapter.DataSource = ViewModel.VarsityMenu.LineFive);
        }

        /* Get the recyclerviews in from the xml layout                          */
        public void GetRecyclerViews()
        {
            _lineOneRecyclerView =
                _varsityFragmentView.FindViewById<RecyclerView>(Resource.Id.VarsityLine1);
            _lineTwoRecyclerView =                                         
                _varsityFragmentView.FindViewById<RecyclerView>(Resource.Id.VarsityLine2);
            _lineThreeRecyclerView =                                       
                _varsityFragmentView.FindViewById<RecyclerView>(Resource.Id.VarsityLine3);
            _lineFourRecyclerView =                                        
                _varsityFragmentView.FindViewById<RecyclerView>(Resource.Id.VarsityLine4);
            _lineFiveRecyclerView =                                        
                _varsityFragmentView.FindViewById<RecyclerView>(Resource.Id.VarsityLine5);
        }

        public void BindAdapters()
        {
            _lineOneAdapter = ViewModel.VarsityMenu.LineOne.GetRecyclerAdapter(
                BindViewHolder, Resource.Layout.FoodMenuList);
            _lineTwoAdapter = ViewModel.VarsityMenu.LineTwo.GetRecyclerAdapter(
                BindViewHolder, Resource.Layout.FoodMenuList);
            _lineThreeAdapter = ViewModel.VarsityMenu.LineThree.GetRecyclerAdapter(
                BindViewHolder, Resource.Layout.FoodMenuList);
            _lineFourAdapter = ViewModel.VarsityMenu.LineFour.GetRecyclerAdapter(
                BindViewHolder, Resource.Layout.FoodMenuList);
            _lineFiveAdapter = ViewModel.VarsityMenu.LineFive.GetRecyclerAdapter(
                BindViewHolder, Resource.Layout.FoodMenuList);
        }

        private void BindViewHolder(CachingViewHolder holder, VarsityItem varsityItem, int position)
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
            _lineFiveRecyclerView.SetAdapter(_lineFiveAdapter);
        }

        public void SetLayoutManagers()
        {
            _lineOneRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
            _lineTwoRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
            _lineThreeRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
            _lineFourRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
            _lineFiveRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
        }
    }
}