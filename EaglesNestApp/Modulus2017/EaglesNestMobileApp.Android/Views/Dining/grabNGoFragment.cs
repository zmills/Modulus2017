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
using System.Collections.Generic;
using EaglesNestMobileApp.Android.Helpers;

namespace EaglesNestMobileApp.Android.Views.Dining
{
    public class grabNGoFragment : Fragment
    {
        private View _grabAndGoFragmentView;
        List<RecyclerView> RecyclerviewList;
        List<TextView> LineList;
        ObservableRecyclerAdapter<GrabAndGoItem, CachingViewHolder> _adapter;
        RecyclerView _currentRecyclerview;
        RecyclerView _previousRecyclerview;
        int _lineCount = 4;

        public GrabAndGoFragmentViewModel ViewModel
        {
            get { return App.Locator.GrabAndGo; }
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
            _grabAndGoFragmentView = 
                inflater.Inflate(Resource.Layout.GrabNGoFragmentLayout, 
                    container, false);

            /* Set up the tablayout for the meal times                       */
            TabLayout _tabLayout =
                _grabAndGoFragmentView.FindViewById<TabLayout>(Resource.Id.GrabAndGoTabLayout);

            /* Set the current and previous recyclerviews */
            _currentRecyclerview = _previousRecyclerview =
                _grabAndGoFragmentView.FindViewById<RecyclerView>(Resource.Id.Line1RecyclerView);

            /* Set up the recyclerviews and adapters for the fragment        */
            Activity.RunOnUiThread(()=> SetUpGrabAndGo());

            return _grabAndGoFragmentView;
        }
        

        /* Get the recyclerviews in from the xml layout                      */
        private void SetUpGrabAndGo()
        {
            /* Add the recyclerviews to a list                               */
            RecyclerviewList = new List<RecyclerView>
            {
                _grabAndGoFragmentView.FindViewById<RecyclerView>(Resource.Id.Line1RecyclerView),
                _grabAndGoFragmentView.FindViewById<RecyclerView>(Resource.Id.Line2RecyclerView),
                _grabAndGoFragmentView.FindViewById<RecyclerView>(Resource.Id.Line3RecyclerView),
                _grabAndGoFragmentView.FindViewById<RecyclerView>(Resource.Id.Line4RecyclerView)
            };

            /* Add the lines to a list                                       */
            LineList = new List<TextView>
            {
                _grabAndGoFragmentView.FindViewById<TextView>(Resource.Id.line1),
                _grabAndGoFragmentView.FindViewById<TextView>(Resource.Id.line2),
                _grabAndGoFragmentView.FindViewById<TextView>(Resource.Id.line3),
                _grabAndGoFragmentView.FindViewById<TextView>(Resource.Id.line4)
            };
           
            /* Set adapters, layout managers, and click handlers             */
            for (int count = 0; count < _lineCount; count++)
            {
                /* Set Adapters */
                RecyclerviewList[count].SetAdapter
                    (
                        ViewModel.GrabAndGoMenu.LunchMenu[count].GetRecyclerAdapter(BindViewHolder, Resource.Layout.FoodMenuList)
                    );
                
                /* Set Layout Managers */
                RecyclerviewList[count].SetLayoutManager(new LinearLayoutManager(Activity));

                /* Set Click Event */
                LineList[count].Click += LineClick;
                LineList[count].Text = ViewModel.GrabAndGoMenu.LunchMenu[count][0].MealTheme;

            }
        }

        private void LineClick(object sender, System.EventArgs e)
        {
            /* Find the correct recyclerview, close the previous one         */
            for(int count = 0; count < LineList.Count; count++)
            {
                if (sender.Equals(LineList[count]))
                {
                    _currentRecyclerview = RecyclerviewList[count];

                    if (_previousRecyclerview == _currentRecyclerview &&
                        _previousRecyclerview.Visibility == ViewStates.Visible)
                    {
                        _currentRecyclerview.Visibility = ViewStates.Gone;
                        _previousRecyclerview = _currentRecyclerview;
                        return;
                    }
                    else
                    {
                        if (_previousRecyclerview != _currentRecyclerview)
                            _previousRecyclerview.Visibility = ViewStates.Gone;
                        {
                            _currentRecyclerview.Visibility = ViewStates.Visible;
                            _previousRecyclerview = _currentRecyclerview;
                            return;
                        }
                    }
                }
                else
                    System.Diagnostics.Debug.Write("Something is very wrong: in the grabandgo fragment");
            }
        }

        private void BindViewHolder(CachingViewHolder holder, GrabAndGoItem grabAndGoItem, int position)
        {
            TextView _textview = holder.FindCachedViewById<TextView>(Resource.Id.listItem);

            holder.DeleteBinding(_textview);

            var itemBinding = new Binding<string, string>(
                grabAndGoItem,
                () => grabAndGoItem.ItemName,
                _textview,
                () => _textview.Text,
                BindingMode.OneWay,
                "Closed"
               );

            holder.SaveBinding(_textview, itemBinding);
        }

        public void SelectMealTime(string mealTime)
        {
            switch (mealTime)
            {
                case App.MealTimes.Lunch:
                    {
                        Activity.RunOnUiThread(() =>
                        {
                            for (int count = 0; count < _lineCount; count++)
                            {
                                _adapter = RecyclerviewList[count].GetAdapter() as ObservableRecyclerAdapter<GrabAndGoItem, CachingViewHolder>;
                                _adapter.DataSource = ViewModel.GrabAndGoMenu.LunchMenu[count];
                                LineList[count].Text = ViewModel.GrabAndGoMenu.LunchMenu[count][0].MealTheme;
                                _adapter.NotifyDataSetChanged();
                            }
                        });
                    }
                    break;
                case App.MealTimes.Dinner:
                    {
                        Activity.RunOnUiThread(() =>
                        {
                            for (int count = 0; count < _lineCount; count++)
                            {
                                _adapter = RecyclerviewList[count].GetAdapter() as ObservableRecyclerAdapter<GrabAndGoItem, CachingViewHolder>;
                                _adapter.DataSource = ViewModel.GrabAndGoMenu.DinnerMenu[count];
                                LineList[count].Text = ViewModel.GrabAndGoMenu.DinnerMenu[count][0].MealTheme;
                                _adapter.NotifyDataSetChanged();
                            }
                        });
                    }
                    break;
            }
        }
    }
}