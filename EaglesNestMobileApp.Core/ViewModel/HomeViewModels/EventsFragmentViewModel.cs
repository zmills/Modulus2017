using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Model.Home;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel
{
    public class EventsFragmentViewModel : ViewModelBase
    {
        /* The ObservableCollection of the events */
        private ObservableCollection<Events> _events = new ObservableCollection<Events>();
        public ObservableCollection<Events> Events
        {
            get { return _events; }
            private set { Set(() => Events, ref _events, value); }
        }

        /* Singleton instance of the database                    */
        private readonly IAzureService Database;

        public EventsFragmentViewModel(IAzureService database)
        {
            Database = database;
        }

        public async Task InitializeAsync()
        {
            var list = await Database.GetEventsAsync();
            foreach (var item in list)
                Events.Add(item);
        }

        public void Initialize()
        {
            //Events = new ObservableCollection<Events>();

            ///* Loop through inserting cards in the announcements ObservableCollection after  */
            ///* titling them and providing an image                           */
            //for (int counter = 0; counter < 20; counter++)
            //{
            //    Events current = new Events("Event " + counter,
            //                                "Event Description", "SIGNUP");
            //    Events.Add(current);
        }


        public async Task Refresh()
        {
            await Database.SyncAsync(true);

            Events.Clear();

            var list = await Database.GetEventsAsync();
            foreach (var item in list)
                Events.Add(item);
        }
    }
}