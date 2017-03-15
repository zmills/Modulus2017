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

namespace EaglesNestMobileApp.Android.Views.Dining
{
    public class fourWindsFragment : Fragment
    {
        public MenuItem[] line1Item;
        public RecyclerView menuItemRecyclerView; 
        public RecyclerView.LayoutManager menuItemLayoutManager;
        public MenuItemAdapter menuItemAdapter;
        public View menuItemLayoutView;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            line1Item = MenuItems.builtInItems;


           // IListAdapter listAdapter = new ArrayAdapter<string>(Activity, Resource.Layout.FoodMenuList, line1Items);
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {
            menuItemLayoutView = inflater.Inflate(Resource.Layout.FourWindsFragment,
                container, false);

            /* Layout Manager */
            menuItemLayoutManager = new FoodLinearLayoutManager(Activity);

            /* Recycler View */
            menuItemRecyclerView = menuItemLayoutView.FindViewById<RecyclerView>(Resource.Id.Line1RecyclerView);

            /* Adapter */
            menuItemAdapter = new MenuItemAdapter(line1Item);

            /* Set Adapter and Layout Manager */
            menuItemRecyclerView.SetLayoutManager(menuItemLayoutManager);
            menuItemRecyclerView.SetAdapter(menuItemAdapter);

            /* Use this to return your custom view for this Fragment         */
            return menuItemLayoutView;
        }

        //protected void OnListItemClick(ListView l, View v, int position, long id)
        //{
        //    var t = line1Items[position];
        //   Toast.MakeText(Activity, t, ToastLength.Short).Show();
        //}
    }
}