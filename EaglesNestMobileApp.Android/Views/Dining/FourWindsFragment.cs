/*****************************************************************************/
/*                             fourWindsFragment                             */
/*                                                                           */
/*****************************************************************************/
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
        public RecyclerView.LayoutManager menuItemLayoutManager;
        public List<MenuItemAdapter> menuItemAdapterList;
        public MenuItemAdapter menuItemAdapter;
        public View menuItemLayoutView;
        public View baseRecyclerLayoutView;
        public List<View> lineList;
        public List<RecyclerView> menuItemRecyclerViewList;
        public RecyclerView currentMenuItemRecyclerView;
        public RecyclerView prevMenuItemRecyclerView;
        public List<FoodLinearLayoutManager> menuItemLayoutManagerList;

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
            
            for(int count = 0; count < TOTAL_LINES; count++)
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