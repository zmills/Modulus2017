/*****************************************************************************/
/*                             fourWindsFragment                             */
/*                                                                           */
/*****************************************************************************/
//using Android.OS;
//using Android.Views;
//using Android.Support.V4.App;
//using Android.Widget;
//using Android.Support.V7.Widget;
//using GalaSoft.MvvmLight.Helpers;
//using EaglesNestMobileApp.Core.Model;
//using static Android.Support.Design.Widget.TabLayout;
//using EaglesNestMobileApp.Core;
//using Android.Support.Design.Widget;
//using Android.Support.V4.Widget;
//using EaglesNestMobileApp.Core.ViewModel.DiningViewModels;

//namespace EaglesNestMobileApp.Android.Views.Dining
//{
//    public class fourWindsFragment : Fragment
//    {
//        public View _fourWindsFragmentView;

//        public FourWindsFragmentViewModel ViewModel
//        {
//            get { return App.Locator.FourWinds; }
//        }

//        /* All the recyclerview adapters                                                 */
//        private ObservableRecyclerAdapter<FourWindsItem, CachingViewHolder> _lineOneAdapter;
//        private ObservableRecyclerAdapter<FourWindsItem, CachingViewHolder> _lineTwoAdapter;
//        private ObservableRecyclerAdapter<FourWindsItem, CachingViewHolder> _lineThreeAdapter;
//        private ObservableRecyclerAdapter<FourWindsItem, CachingViewHolder> _lineFourAdapter;
//        private ObservableRecyclerAdapter<FourWindsItem, CachingViewHolder> _lineFiveAdapter;
//        private ObservableRecyclerAdapter<FourWindsItem, CachingViewHolder> _lineSixAdapter;
//        private ObservableRecyclerAdapter<FourWindsItem, CachingViewHolder> _lineSevenAdapter;

//        /* All the recyclerviews                                            */
//        private RecyclerView _lineOneRecyclerView;
//        private RecyclerView _lineTwoRecyclerView;
//        private RecyclerView _lineThreeRecyclerView;
//        private RecyclerView _lineFourRecyclerView;
//        private RecyclerView _lineFiveRecyclerView;
//        private RecyclerView _lineSixRecyclerView;
//        private RecyclerView _lineSevenRecyclerView;

//        public override void OnCreate(Bundle savedInstanceState)
//        {
//            base.OnCreate(savedInstanceState);
//        }

//        public override View OnCreateView(LayoutInflater inflater,
//            ViewGroup container, Bundle savedInstanceState)
//        {
//            /* Meal Layout View                                                  */
//            _fourWindsFragmentView = inflater.Inflate(Resource.Layout.FourWindsFragment,
//                container, false);

//            TabLayout _tabLayout =
//                _fourWindsFragmentView.FindViewById<TabLayout>(Resource.Id.FourWindsTabLayout);

//            Activity.RunOnUiThread(() => _tabLayout.TabSelected += TabLayoutSelected);

//            /* Get all of the recyclerviews                                      */
//            Activity.RunOnUiThread(() => GetRecyclerViews());

//            /* Set the adapters                                                  */
//            Activity.RunOnUiThread(() => BindAdapters());

//            /* Set the layout managers                                           */
//            Activity.RunOnUiThread(() => SetLayoutManagers());

//            /* Set the recylerviews to their adapters                            */
//            Activity.RunOnUiThread(() => SetAdaptersToRecyclerViews());

//            return _fourWindsFragmentView;
//        }

//        private void TabLayoutSelected(object sender, TabSelectedEventArgs e)
//        {
//            System.Diagnostics.Debug.WriteLine(e.Tab.Text);

//            Activity.RunOnUiThread(() => ViewModel.FourWindsMenu.GetMealTime(e.Tab.Text));
//            Activity.RunOnUiThread(() => UpDateDataSource());
//        }

//        private void UpDateDataSource()
//        {
//            Activity.RunOnUiThread(() => _lineOneAdapter.DataSource = ViewModel.FourWindsMenu.LineOne);
//            Activity.RunOnUiThread(() => _lineTwoAdapter.DataSource = ViewModel.FourWindsMenu.LineTwo);
//            Activity.RunOnUiThread(() => _lineThreeAdapter.DataSource = ViewModel.FourWindsMenu.LineThree);
//            Activity.RunOnUiThread(() => _lineFourAdapter.DataSource = ViewModel.FourWindsMenu.LineFour);
//            Activity.RunOnUiThread(() => _lineFiveAdapter.DataSource = ViewModel.FourWindsMenu.LineFive);
//            Activity.RunOnUiThread(() => _lineSixAdapter.DataSource = ViewModel.FourWindsMenu.LineSix);
//            Activity.RunOnUiThread(() => _lineSevenAdapter.DataSource = ViewModel.FourWindsMenu.LineSeven);
//        }

//        private void OnItemClick(int oldViewPosition, View oldView, int newViewPosition, View newView)
//        {

//        }

//        /* Bind the meal item text to the textviews      */
//        private void BindViewHolder(CachingViewHolder holder, FourWindsItem fourWindsItem, int position)
//        {
//            TextView _textview = holder.FindCachedViewById<TextView>(Resource.Id.listItem);

//            holder.DeleteBinding(_textview);

//            var itemBinding = new Binding<string, string>(
//                fourWindsItem,
//                () => fourWindsItem.ItemName,
//                _textview,
//                () => _textview.Text,
//                BindingMode.OneWay,
//                "Closed"
//               );

//            holder.SaveBinding(_textview, itemBinding);
//        }

//        /* Get the recyclerviews in from the xml layout                          */
//        public void GetRecyclerViews()
//        {
//            _lineOneRecyclerView =
//                _fourWindsFragmentView.FindViewById<RecyclerView>(Resource.Id.Line1RecyclerView);
//            _lineTwoRecyclerView =
//                _fourWindsFragmentView.FindViewById<RecyclerView>(Resource.Id.Line2RecyclerView);
//            _lineThreeRecyclerView =
//                _fourWindsFragmentView.FindViewById<RecyclerView>(Resource.Id.Line3RecyclerView);
//            _lineFourRecyclerView =
//                _fourWindsFragmentView.FindViewById<RecyclerView>(Resource.Id.Line4RecyclerView);
//            _lineFiveRecyclerView =
//                _fourWindsFragmentView.FindViewById<RecyclerView>(Resource.Id.Line5RecyclerView);
//            _lineSixRecyclerView =
//                _fourWindsFragmentView.FindViewById<RecyclerView>(Resource.Id.Line6RecyclerView);
//            _lineSevenRecyclerView =
//                _fourWindsFragmentView.FindViewById<RecyclerView>(Resource.Id.Line7RecyclerView);
//        }

//        public void BindAdapters()
//        {
//            _lineOneAdapter = ViewModel.FourWindsMenu.LineOne.GetRecyclerAdapter(
//                BindViewHolder, Resource.Layout.FoodMenuList, OnItemClick);
//            _lineTwoAdapter = ViewModel.FourWindsMenu.LineTwo.GetRecyclerAdapter(
//                BindViewHolder, Resource.Layout.FoodMenuList, OnItemClick);
//            _lineThreeAdapter = ViewModel.FourWindsMenu.LineThree.GetRecyclerAdapter(
//                BindViewHolder, Resource.Layout.FoodMenuList, OnItemClick);
//            _lineFourAdapter = ViewModel.FourWindsMenu.LineFour.GetRecyclerAdapter(
//                BindViewHolder, Resource.Layout.FoodMenuList, OnItemClick);
//            _lineFiveAdapter = ViewModel.FourWindsMenu.LineFive.GetRecyclerAdapter(
//                BindViewHolder, Resource.Layout.FoodMenuList, OnItemClick);
//            _lineSixAdapter = ViewModel.FourWindsMenu.LineSix.GetRecyclerAdapter(
//                BindViewHolder, Resource.Layout.FoodMenuList, OnItemClick);
//            _lineSevenAdapter = ViewModel.FourWindsMenu.LineSeven.GetRecyclerAdapter(
//                BindViewHolder, Resource.Layout.FoodMenuList, OnItemClick);
//        }

//        public void SetAdaptersToRecyclerViews()
//        {
//            _lineOneRecyclerView.SetAdapter(_lineOneAdapter);
//            _lineTwoRecyclerView.SetAdapter(_lineTwoAdapter);
//            _lineThreeRecyclerView.SetAdapter(_lineThreeAdapter);
//            _lineFourRecyclerView.SetAdapter(_lineFourAdapter);
//            _lineFiveRecyclerView.SetAdapter(_lineFiveAdapter);
//            _lineSixRecyclerView.SetAdapter(_lineSixAdapter);
//            _lineSevenRecyclerView.SetAdapter(_lineSevenAdapter);
//        }

//        public void SetLayoutManagers()
//        {
//            _lineOneRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
//            _lineTwoRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
//            _lineThreeRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
//            _lineFourRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
//            _lineFiveRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
//            _lineSixRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
//            _lineSevenRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
//        }
//    }
//}


//        private void myClickEvent(object sender, EventArgs e)
//        {
//            int lineCount = 1;

//            foreach (View line in lineObservableCollection)
//            {
//                System.Diagnostics.Debug.Write("LINE: " + lineCount);
//                if (sender.Equals(line))
//                {
//                    System.Diagnostics.Debug.Write("FOUND YOU");
//                    currentMenuItemRecyclerView = menuItemRecyclerViewObservableCollection[lineCount - 1];

//                    if (prevMenuItemRecyclerView == currentMenuItemRecyclerView &&
//                        prevMenuItemRecyclerView.Visibility == ViewStates.Visible)
//                        currentMenuItemRecyclerView.Visibility = ViewStates.Gone;
//                    else
//                    {
//                        if (prevMenuItemRecyclerView != currentMenuItemRecyclerView)
//                            prevMenuItemRecyclerView.Visibility = ViewStates.Gone;
//                        currentMenuItemRecyclerView.Visibility = ViewStates.Visible;
//                    }
//                }
//                else
//                    System.Diagnostics.Debug.Write("NOT YOU");

//                lineCount += 1;
//            }
//            prevMenuItemRecyclerView = currentMenuItemRecyclerView;
//        }
//    }
//}


/////*****************************************************************************/
/////*                         OLD fourWindsFragment Do Not                      */
/////*                                                                           */
/////*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Widget;
using Android.Support.V7.Widget;
using EaglesNestMobileApp.Android.Adapters;
using EaglesNestMobileApp.Core.Model.Food;
using System;
using System.Collections.Generic;
using Android.Animation;
using Android.Views.Animations;

namespace EaglesNestMobileApp.Android.Views.Dining
{
    public class fourWindsFragment : Fragment
    {
        /*********************************************************************/
        /* Constants                                                         */
        /*********************************************************************/
        public const int TOTAL_LINES = 7;

        /*********************************************************************/
        /*                                                                   */
        /*********************************************************************/
        public CampusDining campusDining;
        public List<MenuItem[]> menuList;
        public RecyclerView menuItemRecyclerView;
        public List<RecyclerView> menuItemRecyclerViewList;
        public RecyclerView.LayoutManager menuItemLayoutManager;
        public List<FoodLinearLayoutManager> menuItemLayoutManagerList;
        public MenuItemAdapter menuItemAdapter;
        public List<MenuItemAdapter> menuItemAdapterList;
        public List<View> lineList;
        public View menuItemLayoutView;
        public View baseRecyclerLayoutView;
        public RecyclerView currentMenuItemRecyclerView;
        public RecyclerView prevMenuItemRecyclerView;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            /* Four Winds Meal Menus per line                                */
            menuList = new List<MenuItem[]>();
            campusDining = new CampusDining();
            menuList = campusDining.GetFourWindsBreakfastMealMenus();

        }

        public override View OnCreateView(LayoutInflater inflater,
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Meal Layout View                                              */
            menuItemLayoutView = inflater.Inflate(Resource.Layout.FourWindsFragment,
                container, false);

            /* Base Meal Item RecyclerView Layout                            */
            baseRecyclerLayoutView = inflater.Inflate(Resource.Layout.BaseRecyclerView,
                container, false);

            /* Add each RecyclerView Layout to the recycler view list        */
            menuItemRecyclerViewList = new List<RecyclerView>();
            menuItemRecyclerViewList.Add(menuItemLayoutView.
                FindViewById<RecyclerView>(Resource.Id.Line1RecyclerView));
            menuItemRecyclerViewList.Add(menuItemLayoutView.
                FindViewById<RecyclerView>(Resource.Id.Line2RecyclerView));
            menuItemRecyclerViewList.Add(menuItemLayoutView.
                FindViewById<RecyclerView>(Resource.Id.Line3RecyclerView));
            menuItemRecyclerViewList.Add(menuItemLayoutView.
                FindViewById<RecyclerView>(Resource.Id.Line4RecyclerView));
            menuItemRecyclerViewList.Add(menuItemLayoutView.
                FindViewById<RecyclerView>(Resource.Id.Line5RecyclerView));
            menuItemRecyclerViewList.Add(menuItemLayoutView.
                FindViewById<RecyclerView>(Resource.Id.Line6RecyclerView));
            menuItemRecyclerViewList.Add(menuItemLayoutView.
                FindViewById<RecyclerView>(Resource.Id.Line7RecyclerView));

            /* Create placeholder RecyclerViews from the base recyclerview   */
            menuItemRecyclerView =
                currentMenuItemRecyclerView =
                prevMenuItemRecyclerView =
                baseRecyclerLayoutView.FindViewById<RecyclerView>(Resource.Id.BaseRecyclerView);

            /* Create Layout Managers for each recyclerview                  */
            menuItemLayoutManagerList = new List<FoodLinearLayoutManager>();
            for (int count = 1; count <= TOTAL_LINES; count++)
                menuItemLayoutManagerList.Add(new FoodLinearLayoutManager(Activity));

            /* Create Adapters for each recyclerview                         */
            menuItemAdapterList = new List<MenuItemAdapter>();
            for (int count = 0; count < TOTAL_LINES; count++)
                menuItemAdapterList.Add(new MenuItemAdapter(menuList[count]));

            /* Set Adapter and Layout Manager for each Recycler View         */
            //menuItemRecyclerView.SetLayoutManager(menuItemLayoutManager);
            //menuItemRecyclerView.SetAdapter(menuItemAdapter);

            for (int count = 0; count < TOTAL_LINES; count++)
            {
                menuItemRecyclerViewList[count].SetLayoutManager(menuItemLayoutManagerList[count]);
                menuItemRecyclerViewList[count].SetAdapter(menuItemAdapterList[count]);
            }

            /* Add each line view to the line list                           */
            lineList = new List<View>();
            lineList.Add(menuItemLayoutView.FindViewById<View>(Resource.Id.line1));
            lineList.Add(menuItemLayoutView.FindViewById<View>(Resource.Id.line2));
            lineList.Add(menuItemLayoutView.FindViewById<View>(Resource.Id.line3));
            lineList.Add(menuItemLayoutView.FindViewById<View>(Resource.Id.line4));
            lineList.Add(menuItemLayoutView.FindViewById<View>(Resource.Id.line5));
            lineList.Add(menuItemLayoutView.FindViewById<View>(Resource.Id.line6));
            lineList.Add(menuItemLayoutView.FindViewById<View>(Resource.Id.line7));

            /* Give each line view in the list a click event                 */
            foreach (View line in lineList)
                line.Click += myClickEvent;

            /* ANIMATION                                                     */
            /*Animator hideAnimation = ObjectAnimator.OfPropertyValuesHolder(null, PropertyValuesHolder.OfFloat("scaleX", 1, 0), PropertyValuesHolder.OfFloat("scaleY", 1, 0));
            hideAnimation.SetDuration(1);
            hideAnimation.SetInterpolator(new OvershootInterpolator());

            Animator showAnimation = ObjectAnimator.OfPropertyValuesHolder(null, PropertyValuesHolder.OfFloat("scaleX", 0, 1), PropertyValuesHolder.OfFloat("scaleY", 0, 1));
            showAnimation.SetDuration(1);
            showAnimation.StartDelay = 0;
            showAnimation.SetInterpolator(new OvershootInterpolator());

            LayoutTransition viewItemTransition = new LayoutTransition();
            viewItemTransition.SetAnimator(LayoutTransitionType.Appearing, showAnimation);
            viewItemTransition.SetAnimator(LayoutTransitionType.Disappearing, hideAnimation);

            ViewGroup animatedViewGroup = menuItemLayoutView.FindViewById<ViewGroup>(Resource.Id.FourWindsAnimateViewGroup);
            animatedViewGroup.LayoutTransition = viewItemTransition;*/

            /* Use this to return your custom view for this Fragment         */
            return menuItemLayoutView;
        }

        private void myClickEvent(object sender, EventArgs e)
        {
            int lineCount = 1;

            foreach (View line in lineList)
            {
                System.Diagnostics.Debug.Write("LINE: " + lineCount);
                if (sender.Equals(line))
                {
                    System.Diagnostics.Debug.Write("FOUND YOU");
                    currentMenuItemRecyclerView = menuItemRecyclerViewList[lineCount - 1];

                    if (prevMenuItemRecyclerView == currentMenuItemRecyclerView &&
                        prevMenuItemRecyclerView.Visibility == ViewStates.Visible)
                        currentMenuItemRecyclerView.Visibility = ViewStates.Gone;
                    else
                    {
                        if (prevMenuItemRecyclerView != currentMenuItemRecyclerView)
                            prevMenuItemRecyclerView.Visibility = ViewStates.Gone;
                        currentMenuItemRecyclerView.Visibility = ViewStates.Visible;
                    }
                }
                else
                    System.Diagnostics.Debug.Write("NOT YOU");

                lineCount += 1;
            }
            prevMenuItemRecyclerView = currentMenuItemRecyclerView;
        }
    }
}