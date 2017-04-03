using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Model;
using EaglesNestMobileApp.Core.Model.Food;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel.DiningViewModels
{
    public class GrabAndGoFragmentViewModel : ViewModelBase
    {
        /* All the items being served in Grab And Go        */
        private ObservableCollection<GrabAndGoItem> _grabAndGoItems 
            = new ObservableCollection<GrabAndGoItem>();
        protected ObservableCollection<GrabAndGoItem> GrabAndGoItems
        {
            get { return _grabAndGoItems; }
            set { Set(() => GrabAndGoItems, ref _grabAndGoItems, value); }
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

        public GrabAndGoFragmentViewModel(IAzureService database)
        {
            Database = database;
        }
        public async Task RefreshMenusAsync()
        {
            try
            {
                /* Initialize the localDb if not already present and sync  */
                await Database.SyncAsync(pullData: true);

                /* Get all the items for the dining Grab and Go            */
                GrabAndGoItems = await Database.GetGrabAndGoItemsAsync();

                /* Format the dining menus for the separate views          */
                GetDiningMenus();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred in retrieving the menus:");
                Debug.WriteLine($"{ex.Message} in {ex.Source}");
            }
        }

        protected void GetDiningMenus()
        {
            /* Format the Four Winds dining menus                           */
            foreach (var item in GrabAndGoItems)
            {
                GrabAndGoMenu.AddItem(item);
            }
        }

        public async Task InitializeAsync()
        {
            /* Get all the items for the dining facilities              */
            GrabAndGoItems = await Database.GetGrabAndGoItemsAsync();

            GetDiningMenus();
        }

        /*------------------------------------------------------------------*/
        /* THE FOLLOWING METHODS PROVIDE STATIC DATA                        */
        public void InitializeVm()
        {
            /* Add lunch items                                               */
            for (int count = 0; count < 40; count++)
            {
                GrabAndGoItem current =
                    new GrabAndGoItem
                    {
                        ItemName = $"Lunch Food Item {count}",
                        LineNumber = (count % 4 + 1).ToString(),
                        MealTime = "Lunch"
                    };

                GrabAndGoMenu.AddItem(current);
            }

            /* Add dinner items                                               */
            for (int count = 0; count < 40; count++)
            {
                GrabAndGoItem current =
                    new GrabAndGoItem
                    {
                        ItemName = $"Dinner Food Item {count}",
                        LineNumber = (count % 4 + 1).ToString(),
                        MealTime = "Dinner"
                    };

                GrabAndGoMenu.AddItem(current);
            }
        }
    }
}
