using Android;
using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Model;
using EaglesNestMobileApp.Core.Model.Food;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel
{
    public class DiningFragmentsViewModel : ViewModelBase
    {
        /* All the items being served in Four Winds         */
        private ObservableCollection<FourWindsItem> _fourWindsItems = new ObservableCollection<FourWindsItem>();
        public ObservableCollection<FourWindsItem> FourWindsItems
        {
            get { return _fourWindsItems; }
            set { Set(() => FourWindsItems, ref _fourWindsItems, value); }
        }

        /* All the items being served in Varsity            */
        private ObservableCollection<VarsityItem> _varsityItems = new ObservableCollection<VarsityItem>();
        public ObservableCollection<VarsityItem> VarsityItems
        {
            get { return _varsityItems; }
            set { Set(() => VarsityItems, ref _varsityItems, value); }
        }

        /* All the items being served in Grab And Go        */
        private ObservableCollection<GrabAndGoItem> _grabAndGoItems = new ObservableCollection<GrabAndGoItem>();
        public ObservableCollection<GrabAndGoItem> GrabAndGoItems
        {
            get { return _grabAndGoItems; }
            set { Set(() => GrabAndGoItems, ref _grabAndGoItems, value); }
        }


        /* The FourWinds menu to be used by the views       */
        private FourWindsMenu _fourWindsMenu = new FourWindsMenu();
        public FourWindsMenu FourWindsMenu
        {
            get { return _fourWindsMenu; }
            set
            {
                Set(ref _fourWindsMenu, value);
                RaisePropertyChanged("FourWindsMenu");
            }
        }


        /* The Varsity menu to be used by the views         */
        private VarsityMenu _varsityMenu = new VarsityMenu();
        public VarsityMenu VarsityMenu
        {
            get { return _varsityMenu; }
            set { Set(() => VarsityMenu, ref _varsityMenu, value); }
        }


        /* The Grab And Go menu to be used by the views     */
        private GrabAndGoMenu _grabAndGoMenu = new GrabAndGoMenu();
        public GrabAndGoMenu GrabAndGoMenu
        {
            get { return _grabAndGoMenu; }
            set { Set(() => GrabAndGoMenu, ref _grabAndGoMenu, value); }
        }

        /* Command to be binded to the refresh event in the view */
        private RelayCommand _refreshCommand;
        public RelayCommand RefreshCommand => _refreshCommand ??
            (_refreshCommand = new RelayCommand(async () => await RefreshMenusAsync()));

        /* Singleton instance of the database                    */
        private readonly IAzureService Database;

        public DiningFragmentsViewModel(IAzureService database)
        {
            Database = database;
        }

        /* Refresh the menus, pulling off of the remote db.                */
        /* There needs to be something that indicates to the user          */
        /* that the page is being refreshed like in a swipe refresh layout */
        public async Task RefreshMenusAsync()
        {
            try
            {
                /* Initialize the localDb if not already present and sync  */
                await Database.InitLocalStore();
                await Database.SyncAsync(pullData: true);

                /* Get all the items for the dining facilities              */
                FourWindsItems = await Database.GetFourWindsItemsAsync();
                //Varsity = await Database.GetVarsityItemsAsync();
                //GrabAndGo = await Database.GetGrabAndGoItemsAsync();

                /* Format the dining menus for the separate views          */
                GetDiningMenus();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred in retrieving the menus:");
                Debug.WriteLine($"{ex.Message} in {ex.Source}");
            }
        }

        public void GetDiningMenus()
        {
            /* Reset all the ObservableCollections so that we're not adding to existing items */
            FourWindsMenu.ClearLines();
            //VarsityMenuItems = new VarsityMenu();
            //GrabAndGoMenuItems = new GrabAndGoMenu();

            /* Format the Four Winds dining menus                           */
            foreach (var item in FourWindsItems)
            {
                FourWindsMenu.AddItem(item);
            }


            //FourWindsMenu.GetMealTime(App.MealTimes.Breakfast);
            ///* Format the Varsity dining menus                              */
            //foreach (var item in Varsity)
            //{
            //    VarsityMenuItems.AddItem(item);
            //}

            ///* Format the Grab And Go dining menus                          */
            //foreach (var item in GrabAndGo)
            //{
            //    GrabAndGoMenuItems.AddItem(item);
            //}
        }

        public void InitializeVm()
        {
            for (int count = 0; count < 10; count++)
            {
                FourWindsItem current = new FourWindsItem { ItemName = $"Food Item {count}", LineNumber = "1", MealTime = "Breakfast" };
                FourWindsMenu.AddItem(current);
            }

            for (int count = 0; count < 10; count++)
            {
                FourWindsItem current = new FourWindsItem { ItemName = $"Lunch Food Item {count}", LineNumber = "1", MealTime = "Lunch" };
                FourWindsMenu.AddItem(current);
            }

            for (int count = 0; count < 10; count++)
            {
                FourWindsItem current = new FourWindsItem { ItemName = $"Dinner Food Item {count}", LineNumber = "1", MealTime = "Dinner" };
                FourWindsMenu.AddItem(current);
            }
        }
    }
}
