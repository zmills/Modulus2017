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

namespace EaglesNestMobileApp.Android.Views.Dining
{
    public class grabNGoFragment : Fragment
    {
        private View _grabAndGoFragmentView;
        List<RecyclerView> RecyclerviewList;
        List<TextView> LineList;
        RecyclerView _currentRecyclerview;
        RecyclerView _previousRecyclerview;
        int _lineCount; 

        public GrabAndGoFragmentViewModel ViewModel
        {
            get { return App.Locator.GrabAndGo; }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _lineCount = ViewModel.GrabAndGoMenu.LunchMenu.Count;
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
                _grabAndGoFragmentView.FindViewById<RecyclerView>(Resource.Id.GrabAndGoLine1);

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
                _grabAndGoFragmentView.FindViewById<RecyclerView>(Resource.Id.GrabAndGoLine1),
                _grabAndGoFragmentView.FindViewById<RecyclerView>(Resource.Id.GrabAndGoLine2),
                _grabAndGoFragmentView.FindViewById<RecyclerView>(Resource.Id.GrabAndGoLine3),
                _grabAndGoFragmentView.FindViewById<RecyclerView>(Resource.Id.GrabAndGoLine4)
            };

            /* Add the lines to a list                                       */
            LineList = new List<TextView>
            {
                _grabAndGoFragmentView.FindViewById<TextView>(Resource.Id.grabNGoOption1),
                _grabAndGoFragmentView.FindViewById<TextView>(Resource.Id.grabNGoOption2),
                _grabAndGoFragmentView.FindViewById<TextView>(Resource.Id.grabNGoOption3),
                _grabAndGoFragmentView.FindViewById<TextView>(Resource.Id.grabNGoOption4)
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
                        _currentRecyclerview.Visibility = ViewStates.Gone;
                    else
                    {
                        if (_previousRecyclerview != _currentRecyclerview)
                            _previousRecyclerview.Visibility = ViewStates.Gone;
                        _currentRecyclerview.Visibility = ViewStates.Visible;
                    }
                }
                else
                    System.Diagnostics.Debug.Write("Something is very wrong: in the grabandgo fragment");
            }
            _previousRecyclerview = _currentRecyclerview;
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
    }
}