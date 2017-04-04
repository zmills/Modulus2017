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
    public class VarsityFragmentViewModel : ViewModelBase
    {
        /* All the items being served in Varsity            */
        private ObservableCollection<VarsityItem> _varsityItems = 
            new ObservableCollection<VarsityItem>();
        protected ObservableCollection<VarsityItem> VarsityItems
        {
            get { return _varsityItems; }
            set { Set(() => VarsityItems, ref _varsityItems, value); }
        }
        
        /* The Varsity menu to be used by the views         */
        private VarsityMenu _varsityMenu = new VarsityMenu();
        public VarsityMenu VarsityMenu
        {
            get { return _varsityMenu; }
            set { Set(() => VarsityMenu, ref _varsityMenu, value); }
        }

        /* Command to be binded to the refresh event in the view */
        private RelayCommand _refreshCommand;
        public RelayCommand RefreshCommand => _refreshCommand ??
            (_refreshCommand = new RelayCommand(
                async () => await RefreshMenusAsync()));

        /* Singleton instance of the database                    */
        private readonly IAzureService Database;

        public VarsityFragmentViewModel(IAzureService database)
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
                await Database.SyncAsync(pullData: true);

                /* Get all the items for the dining facilities             */
                VarsityItems = await Database.GetVarsityItemsAsync();

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
            /* Format the Varsity dining menus                              */
            foreach (var item in VarsityItems)
            {
                VarsityMenu.AddItem(item);
            }
        }

        public async Task InitializeAsync()
        {
            /* Get all the items for the dining facilities              */
            VarsityItems = await Database.GetVarsityItemsAsync();

            GetDiningMenus();
        }

        /*------------------------------------------------------------------*/
        /* THE FOLLOWING METHODS PROVIDE STATIC DATA                        */
        public void InitializeStatic()
        {
            for (int count = 0; count < 40; count++)
            {
                VarsityItem current = new VarsityItem
                {
                    ItemName = $"Food Item {count}",
                    LineNumber = (count % 5 + 1).ToString(),
                    MealTime = "Breakfast"
                };
                VarsityMenu.AddItem(current);
            }

            for (int count = 0; count < 40; count++)
            {
                VarsityItem current = new VarsityItem
                {
                    ItemName = $"Lunch Food Item {count}",
                    LineNumber = (count % 5 + 1).ToString(),
                    MealTime = "Lunch"
                };
                VarsityMenu.AddItem(current);
            }

            for (int count = 0; count < 40; count++)
            {
                VarsityItem current = new VarsityItem
                {
                    ItemName = $"Dinner Food Item {count}",
                    LineNumber = (count % 5 + 1).ToString(),
                    MealTime = "Dinner"
                };
                VarsityMenu.AddItem(current);
            }
        }
    }
}
