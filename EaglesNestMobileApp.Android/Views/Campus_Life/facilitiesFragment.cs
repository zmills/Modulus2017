/*****************************************************************************/
/*                            facilitiesFragment                             */
/*                                                                           */
/*****************************************************************************/
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using EaglesNestMobileApp.Core;
using EaglesNestMobileApp.Core.ViewModel.AccountViewModels;

namespace EaglesNestMobileApp.Android.Views.Campus_Life
{
    public class facilitiesFragment : Fragment
    {
        StudentInfoFragmentViewModel StudentViewModel = App.Locator.StudentInfo;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, 
            ViewGroup container, Bundle savedInstanceState)
        {
            /* Use this to return your custom view for this Fragment         */
            View view = inflater.Inflate(Resource.Layout.FacilitiesFragmentLayout,
                container, false);

            Button logOut = view.FindViewById<Button>(Resource.Id.Recreation);
            logOut.SetCommand("Click", StudentViewModel.LogOutCommand);
            return view;
        }
    }
}