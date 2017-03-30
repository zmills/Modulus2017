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
    public class FourWindsFragmentViewModel: ViewModelBase
    {
        /* All the items being served in Four Winds         */
        private ObservableCollection<FourWindsItem> _fourWindsItems = 
            new ObservableCollection<FourWindsItem>();
        public ObservableCollection<FourWindsItem> FourWindsItems
        {
            get { return _fourWindsItems; }
            set { Set(() => FourWindsItems, ref _fourWindsItems, value); }
        }

        //public RelayCommand<string> ShowMessageCommand
        //{
        //    get
        //    {
        //        return _showMessageCommand
        //               ?? (_showMessageCommand = new RelayCommand<string>(
        //                   message =>
        //                   {
        //                       _dialogService.ShowMessage(message, "Message:");
        //                   },
        //                   message => !string.IsNullOrEmpty(message)));
        //    }
        //}

        /* The FourWinds menu to be used by the views       */
        private FourWindsMenu _fourWindsMenu = new FourWindsMenu();
        public FourWindsMenu FourWindsMenu
        {
            get { return _fourWindsMenu; }
            set { Set(() => FourWindsMenu, ref _fourWindsMenu, value); }
        }

        /* Command to be binded to the refresh event in the view */
        private RelayCommand _refreshCommand;
        public RelayCommand RefreshCommand => _refreshCommand ??
            (_refreshCommand = new RelayCommand(
                async () => await RefreshMenusAsync()));

        /* Singleton instance of the database                    */
        private readonly IAzureService Database;

        public FourWindsFragmentViewModel(IAzureService database)
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

                /* Get all the items for the dining facilities              */
                FourWindsItems = await Database.GetFourWindsItemsAsync();

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
            /* Reset all the ObservableCollections so that we're not adding */
            /* to existing items                                            */
            FourWindsMenu.ClearLines();

            /* Format the Four Winds dining menus                           */
            foreach (var item in FourWindsItems)
            {
                FourWindsMenu.AddItem(item);
            }
        }

        /* This method provides STATIC DATA                                 */
        public void InitializeVm()
        {
            /* Add breakfast items                                          */
            for (int count = 0; count < 40; count++)
            {
                FourWindsItem current = 
                    new FourWindsItem { ItemName = $"Food Item {count}",
                        LineNumber = (count % 7 + 1).ToString(),
                            MealTime = "Breakfast" };

                FourWindsMenu.AddItem(current);
            }

            /* Add lunch items                                               */
            for (int count = 0; count < 40; count++)
            {
                FourWindsItem current = 
                    new FourWindsItem { ItemName = $"Lunch Food Item {count}",
                        LineNumber = (count % 7 + 1).ToString(),
                            MealTime = "Lunch" };

                FourWindsMenu.AddItem(current);
            }

            /* Add dinner items                                               */
            for (int count = 0; count < 40; count++)
            {
                FourWindsItem current = 
                    new FourWindsItem { ItemName = $"Dinner Food Item {count}",
                        LineNumber = (count % 7 + 1).ToString(),
                            MealTime = "Dinner" };

                FourWindsMenu.AddItem(current);
            }
        }
    }
}
