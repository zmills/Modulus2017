/*****************************************************************************/
/*                              varsityFragment                              */
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
using EaglesNestMobileApp.Core.ViewModel;

namespace EaglesNestMobileApp.Android.Views.Dining
{
    public class fourWindsFragment : Fragment
    {
        private View _fourWindsFragmentView;
        List<RecyclerView> RecyclerviewList;
        List<TextView> LineList;
        RecyclerView _currentRecyclerview;
        RecyclerView _previousRecyclerview;
        int _lineCount = 7;

        public FourWindsFragmentViewModel ViewModel
        {
            get { return App.Locator.FourWinds; }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater,
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Use this to return your custom view for this Fragment         */
            _fourWindsFragmentView =
                inflater.Inflate(Resource.Layout.FourWindsFragmentLayout,
                    container, false);

            /* Set up the tablayout for the meal times                       */
            TabLayout _tabLayout =
                _fourWindsFragmentView.FindViewById<TabLayout>(Resource.Id.FourWindsTabLayout);

            /* Set the current and previous recyclerviews */
            _currentRecyclerview = _previousRecyclerview =
                _fourWindsFragmentView.FindViewById<RecyclerView>(Resource.Id.Line7RecyclerView);

            /* Set up the recyclerviews and adapters for the fragment        */
            Activity.RunOnUiThread(() => SetUpFourWinds());

            return _fourWindsFragmentView;
        }


        /* Get the recyclerviews in from the xml layout                      */
        private void SetUpFourWinds()
        {
            /* Add the recyclerviews to a list                               */
            RecyclerviewList = new List<RecyclerView>
            {
                _fourWindsFragmentView.FindViewById<RecyclerView>(Resource.Id.Line1RecyclerView),
                _fourWindsFragmentView.FindViewById<RecyclerView>(Resource.Id.Line2RecyclerView),
                _fourWindsFragmentView.FindViewById<RecyclerView>(Resource.Id.Line3RecyclerView),
                _fourWindsFragmentView.FindViewById<RecyclerView>(Resource.Id.Line4RecyclerView),
                _fourWindsFragmentView.FindViewById<RecyclerView>(Resource.Id.Line5RecyclerView),
                _fourWindsFragmentView.FindViewById<RecyclerView>(Resource.Id.Line6RecyclerView),
                _fourWindsFragmentView.FindViewById<RecyclerView>(Resource.Id.Line7RecyclerView)
            };

            /* Add the lines to a list                                       */
            LineList = new List<TextView>
            {
                _fourWindsFragmentView.FindViewById<TextView>(Resource.Id.line1),
                _fourWindsFragmentView.FindViewById<TextView>(Resource.Id.line2),
                _fourWindsFragmentView.FindViewById<TextView>(Resource.Id.line3),
                _fourWindsFragmentView.FindViewById<TextView>(Resource.Id.line4),
                _fourWindsFragmentView.FindViewById<TextView>(Resource.Id.line5),
                _fourWindsFragmentView.FindViewById<TextView>(Resource.Id.line6),
                _fourWindsFragmentView.FindViewById<TextView>(Resource.Id.line7)
            };

            /* Set adapters, layout managers, and click handlers             */
            for (int count = 0; count < _lineCount; count++)
            {
                /* Set Adapters */
                RecyclerviewList[count].SetAdapter
                    (
                        ViewModel.FourWindsMenu.LunchMenu[count].GetRecyclerAdapter(BindViewHolder, Resource.Layout.FoodMenuList)
                    );

                /* Set Layout Managers */
                RecyclerviewList[count].SetLayoutManager(new LinearLayoutManager(Activity));


                /* Set Click Event */
                LineList[count].Click += LineClick;
                LineList[count].Text = $"{count + 1}-{ViewModel.FourWindsMenu.LunchMenu[count][0].MealTheme}";
            }
        }

        private void LineClick(object sender, System.EventArgs e)
        {
            /* Find the correct recyclerview, close the previous one         */
            for (int count = 0; count < LineList.Count; count++)
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
                    System.Diagnostics.Debug.Write("Not the corect recyclerview");
            }
        }

        private void BindViewHolder(CachingViewHolder holder, FourWindsItem fourWindsItem, int position)
        {
            TextView _textview = holder.FindCachedViewById<TextView>(Resource.Id.listItem);

            holder.DeleteBinding(_textview);

            ImageView arrowIcon = holder.FindCachedViewById<ImageView>(Resource.Id.ShowGradesArrowIcon);

            var itemBinding = new Binding<string, string>(
                fourWindsItem,
                () => fourWindsItem.ItemName,
                _textview,
                () => _textview.Text,
                BindingMode.OneWay,
                "Closed"
               );

            holder.SaveBinding(_textview, itemBinding);
        }
    }
}